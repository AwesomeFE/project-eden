using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Login
{
    public class Startup : MonoBehaviour
    {
        private InputField UsernameInput;
        private InputField PasswordInput;

        public void Start()
        {
            UsernameInput = GameObject.Find("Username").GetComponent<InputField>();
            PasswordInput = GameObject.Find("Password").GetComponent<InputField>();
        }

        IEnumerator LoginRequest()
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            formData.Add(new MultipartFormDataSection($"username={UsernameInput.text}&password={PasswordInput.text}"));

            UnityWebRequest request = UnityWebRequest.Post(APIs.login, formData);
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }

        public void Login()
        {
            StartCoroutine(LoginRequest());
        }
    }
}
