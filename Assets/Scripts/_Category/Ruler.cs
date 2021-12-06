using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : MonoBehaviour
{
    private void Awake()
    {
        // :: App이 없을 경우, 해당 로드
        if (GameObject.FindObjectOfType<App>() == null)
            TOOLSceneManager.LoadApp();
    }

    public void Init()
    {
        this.Init_Status();
    }
    protected virtual void Init_Status() { }

    public void Open()
    {
        this.Open_Status();

        // :: 열기
        this.gameObject.SetActive(true);
    }
    protected virtual void Open_Status() { }
    public void Close()
    {
        this.Close_Status();

        // :: 닫기
        this.gameObject.SetActive(false);
    }
    protected virtual void Close_Status() { }
}
