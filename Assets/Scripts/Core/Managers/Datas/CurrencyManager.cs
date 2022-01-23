using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class CurrencyManager : Singleton<CurrencyManager>
{
    public delegate void EARN_RESOURCE();
    public enum Monetization
    {
        Shell,
        Coconut,
        Coin
    }

    #region Private Values
    private float _shellValue = 0f;
    private float _coconutValue = 0f;
    private float _coinValue = 0f;

    [SerializeField] Text _shellAmt;
    [SerializeField] Text _coconutAmt;
    [SerializeField] Text _coinAmt;
    #endregion


    #region Public Values
    public EARN_RESOURCE ResourceGetVoid;

    public Monetization ResourceType;
    public float ShellValue
    {
        get => _shellValue;
        private set
        {
            _shellValue = value;
            _shellAmt.text = _shellValue.ToString("F0");
        }
    }
    public float CoconutValue
    {
        get => _coconutValue;
        private set
        {
            _coconutValue = value;
            _coconutAmt.text = _coconutValue.ToString("F0");
        }
    }
    public float CoinValue
    {
        get => _coinValue;
        private set
        {
            _coinValue = value;
            _coinAmt.text = _coinValue.ToString("F0");
        }
    }

    #endregion

    private void Start()
    {
       ResourceGetVoid = EarnShell; 
       ShellValue = PlayerPrefs.GetFloat("Shell",0f);
       CoconutValue = PlayerPrefs.GetFloat("Coconut", 0f);
       CoinValue = PlayerPrefs.GetFloat("Coin", 0f);
    }

    public void EarnShell()
    {
        ShellValue += Random.Range(1f, 10f);
        PlayerPrefs.SetFloat("Shell", _shellValue);
        PlayerPrefs.Save();
    }

    public void EarnCoconut()
    {
        CoconutValue += Random.Range(1f, 10f);
        PlayerPrefs.SetFloat("Coconut", _coconutValue);
        PlayerPrefs.Save();
    }

    public void EarnCoin()
    {
        CoinValue += Random.Range(1f, 10f);
        PlayerPrefs.SetFloat("Coin", _coinValue);
        PlayerPrefs.Save();
    }
}

[CustomEditor(typeof(CurrencyManager))]
public class CurrencyEvent : Editor
{
    CurrencyManager _editor;
    SerializedProperty OptionProp;

    private void Awake()
    {
        _editor = target as CurrencyManager;
        OptionProp = serializedObject.FindProperty("ResourceType");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(OptionProp);

        EditorGUILayout.Space(10);

        if(GUILayout.Button("해당 자원 얻기"))
        {
            _editor.ResourceGetVoid.Invoke();
        }

        if((CurrencyManager.Monetization)OptionProp.enumValueIndex == CurrencyManager.Monetization.Coconut)
        {
            _editor.ResourceGetVoid = _editor.EarnCoconut;
        }
        else if ((CurrencyManager.Monetization)OptionProp.enumValueIndex == CurrencyManager.Monetization.Coin)
        {
            _editor.ResourceGetVoid = _editor.EarnCoin;
        }
        else if ((CurrencyManager.Monetization)OptionProp.enumValueIndex == CurrencyManager.Monetization.Shell)
        {
            _editor.ResourceGetVoid = _editor.EarnShell;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
