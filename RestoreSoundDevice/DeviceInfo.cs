using CoreAudio;

namespace RestoreSoundDevice
{
    internal class DeviceInfo
    {
        public string Name { get; private set; }
        public string Id { get; private set; }
        public DataFlow DataFlow { get; private set; }
        public DeviceInfo(MMDevice device)
        {
            if (device == null) throw new ArgumentNullException(nameof(device));

            Name = device.DeviceFriendlyName;
            Id = device.ID;
            DataFlow = device.DataFlow;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
