using UnityEngine;
using UnityEngine.SceneManagement;

namespace Startup
{
    public class Startup : MonoBehaviour
    {
        private GameObject[] antiObjects;

        private GameObject[] logoObjects;

        private void Start()
        {
            antiObjects = GameObject.FindGameObjectsWithTag("防沉迷");
            logoObjects = GameObject.FindGameObjectsWithTag("Logo");

            Invoke("Step1", 0.0f);
            Invoke("Step2", 3.0f);
            Invoke("Step3", 6.0f);
            Invoke("Step4", 7.0f);
        }

        private void Step1()
        {
            ShowAntiObjects();
        }

        private void Step2()
        {
            HideAntiObjects();
            ShowLogoObjects();
        }

        private void Step3()
        {
            HideLogoObjects();
        }

        private void Step4()
        {
            SceneManager.LoadScene("Login");
        }

        private void HideAntiObjects()
        {
            foreach (GameObject antiObject in antiObjects)
            {
                antiObject.SendMessage("FadeOut");
            }
        }

        private void ShowAntiObjects()
        {
            foreach (GameObject antiObject in antiObjects)
            {
                antiObject.SendMessage("FadeIn");
            }
        }

        private void HideLogoObjects()
        {
            foreach (GameObject logoObject in logoObjects)
            {
                logoObject.SendMessage("FadeOut");
            }
        }

        private void ShowLogoObjects()
        {
            foreach (GameObject logoObject in logoObjects)
            {
                logoObject.SendMessage("FadeIn");
            }
        }
    }
}
