using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DestroyAllOfTypeExcept<T>(T except) where T : Component
    {
        foreach (var obj in FindObjectsByType<T>(FindObjectsSortMode.None))
        {
            if (!ReferenceEquals(obj, except))
            {
                Destroy(obj.gameObject);
            }
        }
    }
}
