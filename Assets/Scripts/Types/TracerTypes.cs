using System;
public class TracerTypes
{
    public static string LOST_TRANSLATION(string i18nField)
    {
        return $"[LOST_TRANSLATION]\"{i18nField}\"不在翻译列表中，请检查是否有遗漏。";
    }
}
