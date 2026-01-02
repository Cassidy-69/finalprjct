using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessibilityButton : MonoBehaviour
{
    public Image captchaImage;
    public Material clearMaterial;
    public TMP_Text messageText;
    public Button verifyButton;

    public void EnableAccessibility()
    {
        // Unblur captcha
        captchaImage.material = clearMaterial;

        // Accessibility message
        messageText.text = "Accessibility isn’t convenience — it’s necessity.";

        // RESET SEMUA TMP (MOBILE SDF SAFE)
        TMP_Text[] allTexts = FindObjectsOfType<TMP_Text>();

        foreach (TMP_Text txt in allTexts)
        {
            Material mat = txt.fontMaterial;

            if (mat.HasProperty("_OutlineSoftness"))
                mat.SetFloat("_OutlineSoftness", 0f);

            if (mat.HasProperty("_UnderlaySoftness"))
                mat.SetFloat("_UnderlaySoftness", 0f);

            if (mat.HasProperty("_Sharpness"))
                mat.SetFloat("_Sharpness", 0.5f); // default TMP
        }

        verifyButton.interactable = true;
        
    }
}
