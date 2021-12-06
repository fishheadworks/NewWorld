using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOOLSector : Sector
{
    protected override void Init_Status()
    {
        this.InitManager();
    }

    public TOOLSceneManager oSCENEManager { get; private set; }
    private void InitManager()
    {
        this.oSCENEManager = this.SetManager<TOOLSceneManager>();
    }
}
