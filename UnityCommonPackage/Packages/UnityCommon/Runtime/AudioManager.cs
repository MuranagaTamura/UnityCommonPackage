using System.Collections.Generic;
using UnityEngine;
using CommonEditor;

namespace CommonRuntime
{
  public class AudioManager : ISingleton<AudioManager>
  {
    private Dictionary<string, AudioClip> _bgmMap = new Dictionary<string, AudioClip>();
    private Dictionary<string, AudioClip> _seMap = new Dictionary<string, AudioClip>();

    private AudioSource _bgmSource = null;
    private AudioSource _seSource = null;

    [SerializeField] private AudioVolume _masterVol = null;
    [SerializeField] private AudioVolume _bgmVol = null;
    [SerializeField] private AudioVolume _seVol = null;

    protected override void Init()
    {
      // BGMとSEを取得
      AudioClip[] bgmList = Resources.LoadAll<AudioClip>(AudioSettingsEntity.I.BgmDir);
      AudioClip[] seList = Resources.LoadAll<AudioClip>(AudioSettingsEntity.I.SeDir);

      foreach (AudioClip clip in bgmList)
      {
        _bgmMap[clip.name] = clip;
      }
      foreach (AudioClip clip in seList)
      {
        _seMap[clip.name] = clip;
      }

      // AudioSourceをアタッチ
      _bgmSource = gameObject.AddComponent<AudioSource>();
      _bgmSource.loop = true;
      _seSource = gameObject.AddComponent<AudioSource>();
    }

    protected override void OnRelease()
    {
      // nop
    }

    public void PlayBgm(string bgmName)
    {
      if (!_bgmMap.ContainsKey(bgmName))
      {
        Debug.LogError($"{bgmName}というBGMは存在しません");
        return;
      }

      _bgmSource.clip = _bgmMap[bgmName];
      ChangeBgmVolume(_bgmVol);
      _bgmSource.Play();
    }

    public void StopBgm()
    {
      _bgmSource.Stop();
    }

    public void PlaySe(string seName)
    {
      if (!_seMap.ContainsKey(seName))
      {
        Debug.LogError($"{seName}というSEは存在しません");
        return;
      }

      _seSource.clip = _seMap[seName];
      ChangeSeVolume(_seVol);
      _seSource.Play();
    }

    public void StopSe()
    {
      _seSource.Stop();
    }

    public void ChangeMasterVolume(AudioVolume volume)
    {
      _masterVol = volume;
      ChangeBgmVolume(_bgmVol);
      ChangeSeVolume(_seVol);
    }


    public void ChangeBgmVolume(AudioVolume volume)
    {
      _bgmVol = volume;
      _bgmSource.volume = _masterVol.Value * _bgmVol.Value;
    }

    public void ChangeSeVolume(AudioVolume volume)
    {
      _seVol = volume;
      _seSource.volume = _masterVol.Value * _seVol.Value;
    }
  }
}
