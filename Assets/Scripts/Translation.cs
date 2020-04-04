using System;
using UnityEngine;
using UnityEngine.UI;

public class Translation : MonoBehaviour
{
    void Start()
    {
        Text TextComponent = GetComponent<Text>();
        try
        {
            TextComponent.text = I18N.Fields[TextComponent.text];
        } catch (Exception)
        {
            GlobalTracer.Warn(TracerTypes.LOST_TRANSLATION(TextComponent.text));
        }
    }
}
