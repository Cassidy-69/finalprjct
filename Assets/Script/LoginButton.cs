using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginButton : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public BlurredCaptcha captchaManager;
    public TMP_Text messageText;
    public Button bacMainMenu;

    public void backMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

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
        bacMainMenu.gameObject.SetActive(true);
    }
}
