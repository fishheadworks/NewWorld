using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class JsonSaveLoad : MonoBehaviour
{

    public static JsonSaveLoad Instance;

    public static T DeserializeObject<T>(string value)
    {
        return JsonConvert.DeserializeObject<T>(value);
    }

    #region Variabels

    private static int DataSavedTime=0;
    public int GetDataSavedTime
    {
        get
        {
            return DataSavedTime++;
        }
    }

    #endregion


    #region Unity Events
    private void Start()
    {
        if (Instance == null)
            Instance = this;
    }
    #endregion


    #region Save & Load Methods

    public void CheckUserID(System.Action OnComplete = null)
    {

        JObject savedata = LoadData("IDCollections");


        if (!((JArray)savedata["UserIDs"]).Contains(SystemInfo.deviceUniqueIdentifier))
        {
            // 신규 회원일 경우
            // ▼ 나중에 서버 데이터에서 플레이어의 기본 Title Data를 생성해주는 코드로 변경해야함
            SaveMyIDtoJson();
        }

        if (OnComplete != null)
            OnComplete();

    }

    // ▼ 새로운 Json 만드는 함수
    public void SaveData(JObject savedata, string DataName)
    {
        if (savedata == null)
        {
           Debug.Log(StringUtils.color.Return(Enums.eColor.Red, 
                                              $"Data : {DataName}" + "는 존재하지 않음!. 임시 데이터 생성 완료"));

           SaveData(new JObject(), $"Created{GetDataSavedTime}Data");
        }

        string savestring = JsonConvert.SerializeObject(savedata, Formatting.Indented);
        File.WriteAllText(Application.dataPath + $"/Scripts/Core/JsonRelated/Datas/{DataName}.json", savestring);
    }

    // ▼ 데이터가 있을 경우 데이터 반환
    public JObject LoadData(string DataName)
    {
        string loadstring = File.ReadAllText(Application.dataPath + $"/Scripts/Core/JsonRelated/Datas/{DataName}.json");
        JObject loadData = JObject.Parse(loadstring);

        return loadData;
    }

    // ▼ 타이틀 데이터가 있을 경우 해당 데이터를 가지고 OnComplete 콜백 실행
    public void GetTitleData(string DataName, System.Action<string> OnComplete = null, System.Action OnFail = null)
    {
        JObject loadData = LoadData(DataName);

        if (loadData != null)
        {
            OnComplete?.Invoke(loadData.ToString());
        }
        else
        {
            OnFail?.Invoke();
        }
    }

    // ▼ 유저 ID (기기 고유 번호)를 Json에 저장한다. [진현, 21. 12. 19]
    public void SaveMyIDtoJson(System.Action OnComplete=null)
    {
        JObject LoadedData = LoadData("IDCollections");
        ((JArray)LoadedData["UserIDs"]).Add(SystemInfo.deviceUniqueIdentifier);

        if (OnComplete != null)
            OnComplete();
    }


    #endregion 
}
