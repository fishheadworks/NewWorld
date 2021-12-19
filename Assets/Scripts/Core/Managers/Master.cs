using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : Singleton<Master>
{
    void Start()
    {
        if(Instance==null)
        {
            //
        }
    }
    Enums.DeviceType deviceType = Enums.DeviceType.Android;
    
   
}

