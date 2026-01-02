using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlurredCaptcha : MonoBehaviour
{
    public TMP_Text messageText;

    public TMP_InputField captchaInput;
    public string correctCaptcha = "2b827";

    public Button accessibilityButton;

    private int attempt = 0;
    private bool captchaValid = false;

    void Start()
    {
        attempt = 0;
        captchaValid = false;
        accessibilityButton.gameObject.SetActive(false);
    }

    public void AttemptCaptcha()
    {
        // cek captcha input
        if (captchaInput.text != correctCaptcha)
        {
            attempt++;

            if (attempt == 1)
            {
                messageText.text = "Incorrect CAPTCHA!";
            }
            else if (attempt == 2)
            {
                messageText.text = "Last attempt before account lock";
                accessibilityButton.gameObject.SetActive(true);
            }

            return;
        }

        // CAPTCHA BENAR
        captchaValid = true;
        attempt = 3; // dianggap selesai
        messageText.text = "CAPTCHA Valid!";
    }

    public bool IsCaptchaValid()
    {
        return captchaValid;
    }
}
