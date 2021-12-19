using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOGORuler : Ruler
{
    protected override void Init_Status()
    {
        // :: 기본 설정
        App.oInstance.oPOPUPSector.FadeOut(0f, null);
    }

    protected override void Open_Status()
    {
        // :: 간이 사용
        var POPUPSector = App.oInstance.oPOPUPSector;

        // :: 페이드
        POPUPSector.FadeIn(2f, () => {
            POPUPSector.FadeOut(2f, null, 1f);
        }, 1f);
    }
}
