using UnityEngine;

/// <summary>
/// 싱글톤을 생성하는 스크립트 [진현 21. 12. 19]
/// </summary>

public class Singleton<T> : MonoBehaviour where T: MonoBehaviour
{
    private static T _instance;

    private static object _lock = new object();

    public static T Instance
    {
        get
        {
           //▼ 다른 쓰레드에서 _lock을 만났을 때 해당 _lock이 끝날 때 까지 잠시 기다린다음 실행한다.
           //  멀티 플레이시 스레드 충돌 방지
           lock(_lock)
           {
                return _instance? _instance : SetSingleton();
           }
        }
    }

    // ▼ 만약에 매니저 인스턴스가 없을 시 싱글턴 생성 후 반환 [진현 21. 12. 19]
    private static T SetSingleton()
    {
        _instance = FindObjectOfType<T>();

        if(_instance==null)
        {
         _instance = new GameObject(typeof(T).Name).AddComponent<T>();
         _instance.transform.position = Vector3.zero;
        }

        DontDestroyOnLoad(_instance);

        return _instance;
    }
}
