using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  캐릭터 스킨 데이터 컨트롤러이다. [진현, 21. 12. 19]
/// </summary>

public class CharacterSkinDataController : MonoBehaviour
{
    const string KEYDATAONSERVER = "CharacterSkinDatas";

    public static CharacterSkinDataController Instance;

    #region Data Variables
  
    [Header("▼ CharacterSkins List")]
    [Space(10)]
    public BaseData baseData = new BaseData();

    [Header("▼ Player-Owned Character")]
    public List<SkinData> listSkins = new List<SkinData>();

    [System.Serializable]
    // ▼ SkinBaseData의 콜렉션
    public class BaseData
    {
        public List<CharacterSkinBaseData> listCharacterSkin = new List<CharacterSkinBaseData>();
    }

    // ▼ Character Data
    [System.Serializable]
    public class SkinData : CharacterSkinBaseData
    {
        [JsonConverter(typeof(int))]
        public int Quantity = 0;
    }

    // ▼ Character Data의 기본 형태
    [System.Serializable]
    public class CharacterSkinBaseData
    {
        [JsonConverter(typeof(string))]
        public string ID = "CharacterSkin_01";

        [JsonConverter(typeof(string))]
        public string Name = "Fish Man";

        [JsonConverter(typeof(float))]
        public float BonusHeatlh = 0f;

        [JsonConverter(typeof(float))]
        public float BonusMoveSpeed = 0f;

        [JsonConverter(typeof(float))]
        public float BonusArmor = 0f;

        [JsonConverter(typeof(float))]
        public float BonusDodge = 0f;

        [JsonConverter(typeof(int))]
        public int Price = 0;
    }

    #endregion


    #region Unity Events
    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #endregion


    #region Data Controller Methods
    // ▼ Base Data List를 불러온다
    public void GetBaseDatasList(System.Action OnComplete=null)
    {
        JsonSaveLoad.Instance.GetTitleData(KEYDATAONSERVER, (json) =>
        {
            // ▼ 데이터 로드 성공시
            baseData = JsonUtility.FromJson<BaseData>(json);
            OnComplete?.Invoke();

        },()=>
        {
            // ▼ 데이터 로드 실패시
            Debug.Log($"{KEYDATAONSERVER}라는 데이터는 {StringUtils.color.Return(Enums.eColor.Red, "존재하지않음.")}");
        });

    }

    #endregion

}
