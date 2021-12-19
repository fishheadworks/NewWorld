using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class POPUPSector : Sector
{
    [Header("Dim")]
    [SerializeField]
    private Image IMAGE_Dim;
    public void FadeOut(float duration, System.Action action, float waitTime = 0f)
    {
        // :: 초기 설정
        this.IMAGE_Dim.color = new Color(0, 0, 0, 0);

        // :: Fade
        this.StartCoroutine(this.Fade(1f, duration, action, waitTime));
    }
    public void FadeIn(float duration, System.Action action, float waitTime = 0f)
    {
        // :: 초기 설정
        this.IMAGE_Dim.color = new Color(0, 0, 0, 1);

        // :: Fade
        this.StartCoroutine(this.Fade(0f, duration, action, waitTime));
    }
    private IEnumerator Fade(float goal, float duration, 
        System.Action action, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // :: 열기
        this.IMAGE_Dim.gameObject.SetActive(true);

        // :: 페이드
        this.IMAGE_Dim.DOFade(goal, duration)
            .onComplete = () => { action?.Invoke(); };
    }
}
