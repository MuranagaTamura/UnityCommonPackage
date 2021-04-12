using System.IO;
using System.Text;
using UnityEngine;

namespace CommonEditor
{
  public class AudioSettingsEntity : ScriptableObject
  {
    private const string PATH = "ProjectSettings/Audio Setting";

    [SerializeField] private string _bgmDir = "Audio/BGM";
    [SerializeField] private string _seDir = "Audio/SE";

    public string BgmDir => _bgmDir;
    public string SeDir => _seDir;

    private static AudioSettingsEntity _instance;

    public static AudioSettingsEntity I
    {
      get
      {
        // ���߂ăA�N�Z�X���ꂽ
        if(_instance == null)
        {
          _instance = CreateInstance<AudioSettingsEntity>();

          // JSON�����݂���
          if(File.Exists(PATH))
          {
            string jsonText;
            using (StreamReader read = new StreamReader(PATH, Encoding.UTF8))
            {
              jsonText = read.ReadToEnd();
            }

            JsonUtility.FromJsonOverwrite(jsonText, _instance);

            // JSON�̓ǂݍ��݂Ɏ��s
            if(_instance == null)
            {
              _instance = CreateInstance<AudioSettingsEntity>();
            }
          }
        }

        return _instance;
      }
    }

    private void OnValidate()
    {
      string jsonText = JsonUtility.ToJson(_instance);
      using (StreamWriter writer = new StreamWriter(PATH, false, Encoding.UTF8))
      {
        writer.Write(jsonText);
      }
    }
  }
}
