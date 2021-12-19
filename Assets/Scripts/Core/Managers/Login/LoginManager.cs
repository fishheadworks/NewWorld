using UnityEngine;
using System.IO;

public class LoginManager : MonoBehaviour
{

    void Start()
    {

        // StartLogin();
    }

    private void StartLogin()
    {
        bool isLogginedBefore = PlayerPrefs.GetInt("isLogginedBefore", 0) == 0 ? false : true;

        if(isLogginedBefore)
        {
            LoginWithCustomID();
        }
        else
        {
            FirstLogin();
        }
    }

    private void FirstLogin()
    {
        // (+) 서버 데이터에 CustomID Key와 Default Data들을 추가 해주고 로그인하는 코드 필요
        // [진현, 21. 12. 19]
       
        PlayerPrefs.SetInt("isLogginedBefore", 1);
        PlayerPrefs.Save();
    }


    public void LoginWithCustomID(System.Action onComplete = null, System.Action onFail = null)
    {
        
        // (+) 데이터 시트에서 해당 ID를 Key로 데이터 value들을 가져오는 코드 필요
        // [진현, 21. 12. 19]
    }


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
