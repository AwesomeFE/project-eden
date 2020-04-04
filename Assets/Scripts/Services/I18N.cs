using System;
using System.Collections.Generic;
using UnityEngine;

public class I18N
{
    #region 公有静态变量

    // 翻译字典
    public static Dictionary<String, String> Fields = new Dictionary<string, string>();
    // 默认语言
    public static SystemLanguage defaultLocale = SystemLanguage.ChineseSimplified;
    // 用户系统语言
    public static SystemLanguage currentLocale = Application.systemLanguage;

    #endregion

    /// <summary>
    /// 获取翻译语言名称
    /// </summary>
    /// <param name="locale">语言类型</param>
    /// <returns></returns>
    public static string GetCurrentLanguage(SystemLanguage locale)
    {
        string language = "";

        switch(locale)
        {
            case SystemLanguage.English: language = "en"; break;
            case SystemLanguage.ChineseSimplified: language = "zh_Hans"; break;
        }

        return language;
    }

    /// <summary>
    /// 获取某种语言的每一行翻译
    /// </summary>
    /// <param name="locale">语言类型</param>
    /// <returns></returns>
    public static string[] LoadLocaleLines(SystemLanguage locale)
    {
        string[] localeStrings = new string[] { };
        string language = GetCurrentLanguage(locale);
        TextAsset currentLanguage = Resources.Load(@"Locales/" + language) as TextAsset;

        if (currentLanguage)
        {
            localeStrings = currentLanguage.text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

        return localeStrings;
    }

    /// <summary>
    /// 在场景加载前，解析多语言文件，然后写入全局I18N.Fields[多语言key]中
    /// 优先混入默认语言翻译，再混入用户语言翻译
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadTranslation()
    {
        Fields.Clear();

        string[] currentLines = LoadLocaleLines(currentLocale);
        string[] defaultLines = LoadLocaleLines(defaultLocale);

        for (int i = 0; i < defaultLines.Length; i += 1)
        {
            string key, value;
            string line = defaultLines[i];

            if (line.IndexOf("=") >= 0 && !line.StartsWith("#"))
            {
                string originalKey = line.Substring(0, line.IndexOf("="));
                key = originalKey.Replace("\\r\\n", " ").Replace("\\n", " ");

                string originalValue = line.Substring(line.IndexOf("=") + 1, line.Length - line.IndexOf("=") - 1);
                value = originalValue.Replace("\\r\\n", Environment.NewLine).Replace("\\n", Environment.NewLine);

                Fields.Add(key, value);
            }
        }

        for (int i = 0; i < currentLines.Length; i += 1)
        {
            string key, value;
            string line = currentLines[i];

            if (line.IndexOf("=") >= 0 && !line.StartsWith("#"))
            {
                string originalKey = line.Substring(0, line.IndexOf("="));
                key = originalKey.Replace("\\r\\n", " ").Replace("\\n", " ");

                string originalValue = line.Substring(line.IndexOf("=") + 1, line.Length - line.IndexOf("=") - 1);
                value = originalValue.Replace("\\r\\n", Environment.NewLine).Replace("\\n", Environment.NewLine);

                Fields.Add(key, value);
            }
        }
    }
}
