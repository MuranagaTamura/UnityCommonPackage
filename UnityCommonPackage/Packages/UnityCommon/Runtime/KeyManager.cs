using System.Collections.Generic;
using UnityEngine;
using System;

namespace CommonRuntime
{
  public class KeyManager : ISingleton<KeyManager>
  {
    private Dictionary<KeyCode, bool> _pre = new Dictionary<KeyCode, bool>();
    private Dictionary<KeyCode, bool> _current = new Dictionary<KeyCode, bool>();

    protected override void Init()
    {
      foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
      {
        _pre[code] = false;
        _current[code] = false;
      }
    }

    private void Update()
    {
      Dictionary<KeyCode, bool> temp = _pre;
      _pre = _current;
      _current = temp;

      foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
      {
        _current[code] = Input.GetKey(code);
      }
    }

    protected override void OnRelease()
    {
    }

    public bool IsKeyDown(KeyCode code) => _current[code];

    public bool IsKeyPush(KeyCode code) => _current[code] && !_pre[code];

    public bool IsKeyUp(KeyCode code) => !_current[code];

    public bool IsKeyRelease(KeyCode code) => !_current[code] && _pre[code];
  }
}
