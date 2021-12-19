/// <summary>
/// String 관련 도구 모음 [진현, 21. 12. 19] 
/// </summary>

public static class StringUtils
{
    #region Const Variabels

    public const string bold = "<b>{0}</b>";
    public const string italic = "<i>{0}</i>";
    public const string size = "<size={0}>{1}</size>";
    public const string color = "<color={0}>{1}</color>";

    #endregion

    #region Style Methods
    public static string Bold(string msg)
    {
        return string.Format(bold, msg);
    }

    public static string Italic(string msg)
    {
        return string.Format(italic, msg);
    }

    public static string Size(int sizeNum, string msg)
    {
        return string.Format(size, sizeNum, msg);
    }
    #endregion

    #region Color Methods
    // (ex) Debug.Log($"{StringUtils.Red("색깔")} 테스트");
    public static string Red(string msg)
    {
        return string.Format(color, "red", msg);
    }
    public static string White(string msg)
    {
        return string.Format(color, "white", msg);
    }
    public static string Grey(string msg)
    {
        return string.Format(color, "grey", msg);
    }
    public static string Black(string msg)
    {
        return string.Format(color, "black", msg);
    }
    public static string Green(string msg)
    {
        return string.Format(color, "green", msg);
    }

    public static string Yellow(string msg)
    {
        return string.Format(color, "yellow", msg);
    }
    public static string Cyan(string msg)
    {
        return string.Format(color, "cyan", msg);
    }

    public static string Brown(string msg)
    {
        return string.Format(color, "brown", msg);
    }

    #endregion
}
