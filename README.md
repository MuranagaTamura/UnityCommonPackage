# Unity Common Package

Unityで共通して使うアセットをパッケージ化したリポジトリ



## AudioManager

* AudioManagerの参照先の設定は「Edit > Project Settings... > AudioSettings」にある「BgmDir」と「SeDir」を設定する
* 参照先は常にResources内だと仮定してる
* 使用する場合はHierarchyにAudioManagerをアタッチする必要あり
  * そうしないと使えない

### サンプル

```csharp
// BGM再生
CommonRuntime.AudioManager.I.PlayBgm("bgmName");
// BGM停止
CommonRuntime.AudioManager.I.StopBgm();
// SE再生
CommonRuntime.AudioManager.I.PlaySe("seName");
// SE停止
CommonRuntime.AudioManager.I.StopSe();
```



## KeyManager

* 使用する場合はHierarchyにKeyManagerをアタッチする必要あり
  * そうしないと使えない

### サンプル

```csharp
// キーが押されているか
CommonRuntime.KeyManager.I.IsKeyDown(KeyCode.A);
// キーが押されたか
CommonRuntime.KeyManager.I.IsKeyPush(KeyCode.A);
// キーが離されているか
CommonRuntime.KeyManager.I.IsKeyUp(KeyCode.A);
// キーが離されたか
CommonRuntime.KeyManager.I.isKeyRelease(KeyCode.A);
```

