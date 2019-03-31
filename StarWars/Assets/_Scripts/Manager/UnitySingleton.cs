using UnityEngine;

public class UnitySingleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(Instance == null){
            Instance = this as T;
        }else{
            Destroy(gameObject);
        }
    }
}
