using TMPro;
using UnityEngine;

public class TMPSoftnessReset : MonoBehaviour
{
    void Start()
    {
        TMP_Text[] texts = FindObjectsOfType<TMP_Text>();

        foreach (TMP_Text t in texts)
        {
            // Clone material biar ga ngerusak global
            Material mat = new Material(t.fontMaterial);
            mat.SetFloat("_OutlineSoftness", 0f);
            mat.SetFloat("_UnderlaySoftness", 0f);

            t.fontMaterial = mat;
        }
    }
}
