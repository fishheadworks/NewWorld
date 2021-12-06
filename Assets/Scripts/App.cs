using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    // :: 싱글턴 인스턴스 간이 제작
    private static App iInstance;
    public static App oInstance
    {
        get
        {
            return iInstance;
        }
    }

    // :: 시작
    private void Awake()
    {
        // :: 시작
        if (iInstance == null)
            iInstance = this;

        // :: 중복 확인
        var go = GameObject.FindObjectOfType<App>();
        if (go.GetHashCode() != this.GetHashCode())
            return;

        // :: 제거 방지
        Object.DontDestroyOnLoad(this.gameObject);

        // :: 섹터 설정
        this.StartCoroutine(this.IENStart());
    }
    private IEnumerator IENStart()
    {
        yield return this.InitSectors();

        // :: 로고 오픈
        this.oTOOLSector.oSCENEManager.LoadScene(Enums.eScene.LOGO);
    }

    public TOOLSector oTOOLSector { get; private set; }

    [Header("팝업")]
    [SerializeField]
    private POPUPSector POPUPSector;
    public POPUPSector oPOPUPSector => this.POPUPSector;
    private IEnumerator InitSectors()
    {
        // :: 툴 섹터
        this.oTOOLSector = this.SetSector<TOOLSector>();

        yield break;
    }

    protected T SetSector<T>() where T : Sector
    {
        var go
            = Object.Instantiate(
                new GameObject(typeof(T).Name), this.transform);
        var sector = go.AddComponent<T>();
        sector.Init();

        return sector;
    }
}
