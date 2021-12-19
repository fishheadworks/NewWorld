/// <summary>
/// String 관련 확장 메서드 모음 [진현, 21. 12. 19] 
/// </summary>

public static class StringUtils
{
    #region Variabels

    public const string bold = "<b>{0}</b>";
    public const string italic = "<i>{0}</i>";
    public const string size = "<size={0}>{1}</size>";
    public const string color = "<color={0}>{1}</color>";

    #endregion

    #region Extensions
    public static string Return(this string str, string msg)
    {
        return string.Format(str, msg);
    }
    // ▼ 색깔  (ex)  Debug.Log(StringUtils.color.Return(Enums.eColor.Red,"컬러")+"테스트");
    public static string Return(this string str, Enums.eColor color, string msg)
    {
        return string.Format(str, color.ToString(), msg);
    }
    // ▼ 사이즈
    public static string Return(this string str, int size, string msg)
    {
        return string.Format(str, size, msg);
    }
    #endregion
}
