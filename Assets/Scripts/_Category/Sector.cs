using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Sector : MonoBehaviour
{
    public void Init()
    {
        this.Init_Status();
    }
    protected virtual void Init_Status() { }

    protected T SetManager<T>() where T : Manager
    {
        var go
            = Object.Instantiate(
                new GameObject(typeof(T).Name), this.transform);
        var manager = go.AddComponent<T>();
        manager.Init();

        return manager;
    }
}
