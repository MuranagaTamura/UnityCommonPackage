using System;
using UnityEngine;

namespace CommonRuntime
{
  [Serializable]
  public class AudioVolume
  {
    [Range(0f, 1f)]
    [SerializeField] private float _value = 1f;

    public float Value => _value;

    public AudioVolume(float value)
    {
      if (value < 0 || 1 < value) 
        throw new ArgumentOutOfRangeException("0~1の範囲で指定してください");

      _value = value;
    }
  }
}