using UnityEngine;

namespace CommonRuntime
{
  public abstract class ISingleton<T> : MonoBehaviour where T : ISingleton<T>
  {
    protected virtual bool DestroyTargetGameObject => false;

    public static T I { get; private set; } = null;

    public static bool IsValid() => I != null;

    private void Awake()
    {
      if (I == null)
      {
        I = this as T;
        I.Init();
        return;
      }
      if (DestroyTargetGameObject)
      {
        Destroy(gameObject);
      }
      else
      {
        Destroy(this);
      }
    }

    protected abstract void Init();

    private void OnDestroy()
    {
      if (I == this) I = null;
      OnRelease();
    }

    protected abstract void OnRelease();
  }
}
