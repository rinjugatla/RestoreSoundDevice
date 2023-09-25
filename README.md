# サウンドデバイス設定自動復元ツール

サウンドデバイスが変更された場合にツールで指定したデバイスに再設定します。

## 導入

1. .NET 6 Runtimeの導入
   .NET 6 Runtimeが必要です。  
   すでに導入済みの場合は操作不要です。
   
   こちらからインストーラをダウンロードしてインストールしてください。  
   [ASP.NET Core 6.0 Runtime (v6.0.22) - Windows x64 Installer のダウンロード](https://dotnet.microsoft.com/ja-jp/download/dotnet/thank-you/runtime-aspnetcore-6.0.22-windows-x64-installer)

2. ツールの導入

   サウンドデバイス設定自動復元ツールの最新版を以下からダウンロード、任意の位置に解凍します。  
   [RestoreSoundDevice - Release](https://github.com/rinjugatla/RestoreSoundDevice/releases)

## 使い方

1. RestoreSoundDevice.exeを実行		

   初回実行時にWindowsの警告(青い画面)が表示される場合があります。  
   詳細ボタンを押して実行します。

2. 復元先のデバイスを指定

   現在設定しているデバイスが選択された状態で立ち上がります。  
   現在の入力、出力デバイスを変更する場合や自動復元先のデバイスを変更する場合は別のデバイスを指定します。

3. 監視間隔を設定

   監視間隔に任意の秒数を指定します。  

4. 停止中ボタンを押下

   停止中ボタンを押下すると、監視中に切り替わります。
   監視間隔毎に入出力デバイスの設定を確認し、変更があれば変更前のデバイスに復元します。

5. 終了方法

   Xボタンを押すと常駐アプリとしてタスクトレイ(画面右下)に格納されます。
   終了する場合はタスクトレイのアイコンを右クリックし「終了」を押下します。

## 権利

1. アイコン

[Sound wave icons created by Victoruler - Flaticon](https://www.flaticon.com/free-icons/sound-wave)