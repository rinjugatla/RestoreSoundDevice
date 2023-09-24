using CoreAudio;
using System.Diagnostics;
using System.Text;

namespace RestoreSoundDevice
{
    public partial class Form1 : Form
    {
        private MMDeviceEnumerator MMDeviceEnumerator;
        /// <summary>デフォルト入力デバイス</summary>
        private DeviceInfo? DefaultCaptureDevice;
        /// <summary>デフォルト出力デバイス</summary>
        private DeviceInfo? DefaultRenderDevice;
        /// <summary>デバイス復元機能が実行中か</summary>
        private bool IsRunningRestoreWatchdog => RestoreModeSwitch_Button.Text != "停止中";

        private DeviceInfo? GetDefaultDevice(DataFlow flow)
        {
            switch (flow)
            {
                case DataFlow.Capture:
                    return DefaultCaptureDevice;
                case DataFlow.Render:
                    return DefaultRenderDevice;
                default:
                    return null;
            }
        }

        public Form1()
        {
            InitializeComponent();

            MMDeviceEnumerator = new MMDeviceEnumerator(Guid.NewGuid());

            RestoreWatchdogInterval_TextBox.Text = Properties.Settings.Default.RestoreWatchdogInterval;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.RestoreWatchdogInterval = RestoreWatchdogInterval_TextBox.Text;
            Properties.Settings.Default.Save();

            if (!IsRunningRestoreWatchdog) { return; }

            RestoreModeSwitch_Button.PerformClick();
            Task.Run(async () => { await Task.Delay(1500); });
            
        }

        #region デバイス
        /// <summary>デバイスの一覧を取得</summary>
        private void GetDevice_Button_Click(object sender, EventArgs e)
        {
            // アイテム追加時にイベントが発火してしまうので一時的に無効化
            CaptureDevice_DataGridView.CurrentCellChanged -= DataGridView_CurrentCellChanged;
            RenderDevice_DataGridView.CurrentCellChanged -= DataGridView_CurrentCellChanged;

            var defaultCaptureDevice = UpdateDeviceDataGridView(DataFlow.Capture, MMDeviceEnumerator);
            var defaultRenderDevice = UpdateDeviceDataGridView(DataFlow.Render, MMDeviceEnumerator);

            UpdateDetaultDeviceCache(defaultCaptureDevice);
            UpdateDetaultDeviceCache(defaultRenderDevice);

            UpdateSelectedDeviceDataGridViewRowHightite(DataFlow.Capture);
            UpdateSelectedDeviceDataGridViewRowHightite(DataFlow.Render);

            CaptureDevice_DataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;
            RenderDevice_DataGridView.CurrentCellChanged += DataGridView_CurrentCellChanged;
        }

        /// <summary>接続中のデバイス一覧をDGVに表示</summary>
        /// <param name="flow">デバイス種類</param>
        /// <returns>デフォルトのデバイス</returns>
        private DeviceInfo? UpdateDeviceDataGridView(DataFlow flow, MMDeviceEnumerator deviceEnum)
        {
            if (flow != DataFlow.Capture && flow != DataFlow.Render) { return null; }

            var dgv = flow == DataFlow.Capture ? CaptureDevice_DataGridView : RenderDevice_DataGridView;
            var devices = deviceEnum.EnumerateAudioEndPoints(flow, DeviceState.Active);

            dgv.Rows.Clear();

            DeviceInfo? defaultDevice = null;
            foreach (var device in devices)
            {
                var info = new DeviceInfo(device);
                dgv.Rows.Add(info);

                if (device.Selected) { defaultDevice = info; }
            }

            return defaultDevice;
        }

        /// <summary>デフォルトデバイスをハイライト</summary>
        /// <param name="flow">デバイス種類</param>
        private void UpdateSelectedDeviceDataGridViewRowHightite(DataFlow flow)
        {
            if (flow != DataFlow.Capture && flow != DataFlow.Render) { return; }

            var defaultDevice = flow == DataFlow.Capture ? DefaultCaptureDevice : DefaultRenderDevice;
            if (defaultDevice == null) { return; }

            int rowIndex = 0;
            var dgv = flow == DataFlow.Capture ? CaptureDevice_DataGridView : RenderDevice_DataGridView;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var info = row.Cells[0].Value as DeviceInfo;
                if (info == null) { continue; }

                bool isDefault = info.Id == defaultDevice.Id;
                if (isDefault)
                {
                    dgv.Rows[rowIndex].Selected = true;
                    break;
                }

                rowIndex++;
            }
        }

        /// <summary>デバイスの選択が変更された際にデフォルトデバイスを変更</summary>
        private void DataGridView_CurrentCellChanged(object? sender, EventArgs e)
        {
            if (sender == null) { return; }

            var dgv = (DataGridView)sender;
            var cell = dgv.CurrentCell;
            var selectedDevice = cell.Value as DeviceInfo;
            if (selectedDevice == null) { return; }

            var deviceEnum = new MMDeviceEnumerator(Guid.NewGuid());
            var devices = deviceEnum.EnumerateAudioEndPoints(selectedDevice.DataFlow, DeviceState.Active);
            foreach (var device in devices)
            {
                bool isTarget = device.ID == selectedDevice.Id;
                if (!isTarget) { continue; }

                // デフォルトデバイスを変更
                device.Selected = true;

                var info = new DeviceInfo(device);
                UpdateDetaultDeviceCache(info);

                break;
            }
        }

        /// <summary>デフォルトデバイス情報をキャッシュ</summary>
        /// <param name="info">デバイス情報</param>
        private void UpdateDetaultDeviceCache(DeviceInfo? info)
        {
            if (info == null) { return; }

            if (info.DataFlow == DataFlow.Capture) { DefaultCaptureDevice = info; }
            else { DefaultRenderDevice = info; }
        }
        #endregion

        #region 監視
        /// <summary>監視間隔の変更</summary>
        private void RestoreWatchdogInterval_TextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 不正な文字列を除外
            var box = (TextBox)sender;
            float value = 0;
            bool isNumber = float.TryParse(box.Text, out value);
            if (isNumber) { return; }

            MessageBox.Show("監視間隔は数値で入力してください。", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }

        /// <summary>デバイス監視モードの切り替え</summary>
        private void RestoreModeSwitch_Button_Click(object sender, EventArgs e)
        {
            var color = IsRunningRestoreWatchdog ? Color.FromArgb(255, 192, 192) : Color.FromArgb(192, 255, 192);
            var text = IsRunningRestoreWatchdog ? "停止中" : "監視中";

            RestoreModeSwitch_Button.BackColor = color;
            RestoreModeSwitch_Button.Text = text;

            if (IsRunningRestoreWatchdog) { RestoreDefaultDeviceWatchDowg(); }
        }

        private Task RestoreDefaultDeviceWatchDowg()
        {
            return Task.Run(async () =>
            {
                while (IsRunningRestoreWatchdog)
                {
                    RestoreDefaultDevice(DataFlow.Capture);
                    RestoreDefaultDevice(DataFlow.Render);

                    int delayCount = 30;
                    int.TryParse(RestoreWatchdogInterval_TextBox.Text, out delayCount);
                    for (int i = 0; i < delayCount; i++)
                    {
                        // 指定時間待機すると直ちに終了できないので1秒毎で判定
                        await Task.Delay(1000);
                        if (!IsRunningRestoreWatchdog) { return; }
                    }
                }
            });
        }

        /// <summary>デフォルトデバイスを復元</summary>
        /// <param name="flow">デバイス種類</param>
        private void RestoreDefaultDevice(DataFlow flow)
        {
            if (flow != DataFlow.Capture && flow != DataFlow.Render) { return; }

            var currentSelectedDevice = CurrentSelectedDevice(flow);
            if (currentSelectedDevice == null) { return; }

            bool isSelectedDefault = IsDefaultDevice(currentSelectedDevice);
            if (isSelectedDefault) { return; }

            var defaultDevice = GetDefaultDevice(flow);
            var device = MMDeviceEnumerator.GetDevice(defaultDevice!.Id);
            MMDeviceEnumerator.SetDefaultAudioEndpoint(device);
        }

        /// <summary>現在有効なデバイス情報を取得</summary>
        /// <param name="flow">デバイス種類</param>
        private DeviceInfo? CurrentSelectedDevice(DataFlow flow)
        {
            if (flow != DataFlow.Capture && flow != DataFlow.Render) { return null; }

            var currentDefaultDevice = GetDefaultDevice(flow);
            if (currentDefaultDevice == null) { return null; }

            var devices = MMDeviceEnumerator.EnumerateAudioEndPoints(flow, DeviceState.Active);
            var selectedDevice = devices.Where(d => d.Selected).FirstOrDefault();
            if (selectedDevice == null) { return null; }

            var info = new DeviceInfo(selectedDevice);
            return info;
        }

        /// <summary>デフォルトのデバイスと同じか</summary>
        /// <param name="info">デバイス情報</param>
        private bool IsDefaultDevice(DeviceInfo info)
        {
            var defaultDevice = GetDefaultDevice(info.DataFlow);
            if (defaultDevice == null) { return false; }

            bool isSame = info.Id == defaultDevice.Id;
            return isSame;
        }
        #endregion
    }
}