using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public bool isDefaultShow = false;
    public float fadeInDuring = 1.0f;
    public float fadeOutDuring = 1.0f;

    private float currentTime = 0;
    private bool isFadeIn = false;
    private bool isFadeOut = false;

    #region 公有：渐入检出接口
    public void FadeIn()
    {
        StopFade();
        StartFadeIn();
    }

    public void FadeOut()
    {
        StopFade();
        StartFadeOut();
    }
    #endregion

    #region 私有：生命周期
    private void Start()
    {
        SetAlpha(isDefaultShow ? 1 : 0);
    }

    private void FixedUpdate()
    {
        if (isFadeIn || isFadeOut)
        {
            currentTime += Time.fixedDeltaTime;

            if (currentTime >= fadeInDuring)
            {
                StopFade();
            }
        }
    }

    private void Update()
    {
        if (isFadeIn)
        {
            float alpha = (currentTime * 1.0f) / (fadeInDuring * 1.0f);
            SetAlpha(alpha);
        }
        else if (isFadeOut)
        {
            float alpha = 1 - (currentTime * 1.0f) / (fadeInDuring * 1.0f);
            SetAlpha(alpha);
        }
    }
    #endregion

    #region 私有：控制渐入渐出
    private void StartFadeIn()
    {
        isFadeIn = true;
    }

    private void StartFadeOut()
    {
        isFadeOut = true;
    }

    private void StopFade()
    {
        isFadeIn = false;
        isFadeOut = false;
        currentTime = 0;
    }
    #endregion

    #region 私有：设置透明度
    private void SetAlpha(float alpha)
    {
        SetComponentAlpha(GetComponent<Text>(), alpha);
        SetComponentAlpha(GetComponent<Image>(), alpha);
    }

    private void SetComponentAlpha<T>(T component, float alpha) where T : Graphic
    {
        if (component != null)
        {
            Color color = component.color;
            if (alpha > 1)
            {
                color.a = 1;
            }
            else if (alpha < 0)
            {
                color.a = 0;
            }
            else
            {
                color.a = alpha;
            }
            color.a = alpha;
            component.color = color;
        }
    }
    #endregion
}
