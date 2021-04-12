#if UNITY_EDITOR
using UnityEditor;

namespace CommonEditor
{
  public static class AudioSettings
  {
    [SettingsProvider]
    public static SettingsProvider CreateCommonEditor()
    {
      AudioSettingsEntity entity = AudioSettingsEntity.I;

      SettingsProvider provider = AssetSettingsProvider.CreateProviderFromObject(
        "Project/AudioSettings", entity);
      SerializedObject so = new SerializedObject(entity);

      provider.keywords = SettingsProvider.GetSearchKeywordsFromSerializedObject(so);

      return provider;
    }
  }
}
#endif
