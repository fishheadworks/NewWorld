using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


public class JsonSaveLoad : Singleton<JsonSaveLoad>
{

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
    public void CheckUserID(System.Action OnComplete=null)
    {

        JObject savedata = LoadData("IDCollections");


        if(!((JArray)savedata["UserIDs"]).Contains(SystemInfo.deviceUniqueIdentifier))
        {
            // 신규 회원일 경우
            // ▼ 나중에 서버 데이터에서 플레이어의 기본 Title Data를 생성해주는 코드로 변경해야함
            SaveMyIDtoJson();
        }

        if (OnComplete != null)
            OnComplete();

    }

    #endregion 


    #region Save & Load Methods

    public void SaveData(JObject savedata, string DataName)
    {
        if (savedata == null)
        {
           Debug.Log(StringUtils.color.Return(Enums.eColor.Red, 
                                              $"Data : {DataName}" + "는 존재하지 않음!. 임시 데이터 생성 완료"));

           SaveData(new JObject(), $"Created{GetDataSavedTime}Data");
        }

        string savestring = JsonConvert.SerializeObject(savedata, Formatting.Indented);
        File.WriteAllText(Application.dataPath + $"Resources/Datas/{DataName}.json", savestring);
    }

    public JObject LoadData(string DataName)
    {
        string loadstring = File.ReadAllText(Application.dataPath + $"Resources/Datas/{DataName}.json");
        JObject loadData = JObject.Parse(loadstring);

        return loadData;
    }

    // ▼ 유저 ID (기기 고유 번호)를 Json에 저장한다. [진현, 21. 12. 19]
    public void SaveMyIDtoJson(System.Action OnComplete=null)
    {
        JObject LoadedData = LoadData("IDCollections");
        ((JArray)LoadedData["UserIDs"]).Add(SystemInfo.deviceUniqueIdentifier);

        if (OnComplete != null)
            OnComplete();
    }

    /*
        savedata["package"] = "wanmok";
        savedata["UserIDs"] = new JArray();
        ((JArray)savedata["UserIDs"]).Add(SystemInfo.deviceUniqueIdentifier);

        string savestring = JsonConvert.SerializeObject(savedata, Formatting.Indented);
        File.WriteAllText(Application.dataPath + "Resources/Datas/IDCollections.json", savestring);

     */

    #endregion 
}
