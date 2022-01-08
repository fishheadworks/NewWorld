using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

/// <summary>
/// 
///  [순서]
///  
///  1. 해당 기기로 이전에 접속한 적이 있는지 체크
///  2. 데이터 매니저들로부터 각각의 데이터를 로드 혹은 생성한다.
///  3. 모든 데이터를 셋팅하면 게임을 시작한다
///  
///  [진현, 21. 12. 19]
///  
/// </summary>

public class LoginManager : MonoBehaviour
{
    public static LoginManager Instance;


    #region Variables
    [SerializeField]
    ProgressBar progressBar;
    #endregion


    #region Unity Events

    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }

        if(progressBar==null)
        {
            progressBar = FindObjectOfType<ProgressBar>();
        }
    }

    private void Start()
    {
        bool isLogginedBefore = 
            PlayerPrefs.GetInt("isLogginedBefore", 0) == 0 ? false : true;

        if(isLogginedBefore)
        {
            LoginWithCustomID();
        }
        else
        {
            FirstLogin();
        }
    }

    #endregion


    #region Login Methods
    // 현재 디바이스에서 최초 접속 일 경우
    private void FirstLogin()
    {
        PlayerPrefs.SetInt("isLogginedBefore", 1);
        PlayerPrefs.Save();
        LoadDatas();

    }

    // 현재 디바이스에서 접속한 기록이 있을 경우
    private void LoginWithCustomID(System.Action onComplete = null, System.Action onFail = null)
    {
        LoadDatas();
    }
    #endregion



    #region Data Loading Methods

    [Header("▼ Data List")]
    public string[] LoadDataSteps;

    // 데이터를 불러온다 [진현, 21. 12. 19]
    public void LoadDatas()
    {
        if(LoadDataSteps==null || LoadDataSteps.Length ==0)
        {
            LoadDataSteps = new string[2];
        }

        progressBar.MaxProgress = LoadDataSteps.Length;

        JsonSaveLoad.Instance.CheckUserID(() =>
        {
            progressBar.CurrentProgress++;

            CharacterSkinDataController.Instance.GetBaseDatasList(() =>
            {
                progressBar.CurrentProgress++;


                // (+) 다른 모든 데이터 value들을 가져오는 코드 필요
                // [진현, 21. 12. 19]

                // :: 임시로 In Game으로 직행 해놓음
                SceneManager.LoadSceneAsync((int)Enums.eScene.IN_GAME);
            });
        });

    }

    #endregion

    public string GetCustomID()
    {
        string customID = "";
#if UNITY_IOS
       customID = UnityEngine.iOS.Device.advertisingIdentifier;

       if (customID == null || customID == "")
       {
           customID = SystemInfo.deviceUniqueIdentifier;
       }
#elif UNITY_ANDROID
        customID = SystemInfo.deviceUniqueIdentifier;
#else
       customID = SystemInfo.deviceUniqueIdentifier;
#endif
        return customID;
    }

}
