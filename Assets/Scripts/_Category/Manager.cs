using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public void Init()
    {
        this.Init_Status();
    }
    protected virtual void Init_Status() { }
}
