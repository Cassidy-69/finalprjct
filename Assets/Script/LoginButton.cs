using TMPro;
using UnityEngine;

public class LoginButton : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public BlurredCaptcha captchaManager;
    public TMP_Text messageText;

    public void OnLoginClicked()
    {
        if (string.IsNullOrEmpty(usernameInput.text))
        {
            messageText.text = "Username is required";
            return;
        }

        if (string.IsNullOrEmpty(passwordInput.text))
        {
            messageText.text = "Password is required";
            return;
        }

        if (!captchaManager.IsCaptchaValid())
        {
            messageText.text = "Please complete the CAPTCHA";
            return;
        }

        messageText.text = "Login successful";
        Debug.Log("LOGIN SUCCESS");
    }
}
