using UnityEngine;

public class AccessibilityTrigger : MonoBehaviour
{
    public int failAttempts = 0;
    public float timeSpent = 0f;
    public bool accessibilityEnabled = false;

    public int maxFailAttempts = 2;
    public float timeLimit = 30f;

    public GameObject accessibilityButton;

    void Start()
    {
        if (accessibilityButton != null)
        {
            accessibilityButton.SetActive(false);
        }
    }

    void Update()
    {
        timeSpent += Time.deltaTime;

        CheckAccessibilityNeed();
    }

    public void RegisterFailure()
    {
        failAttempts++;
        CheckAccessibilityNeed();
    }

    void CheckAccessibilityNeed()
    {
        if (!accessibilityEnabled)
        {
            if (failAttempts >= maxFailAttempts || timeSpent >= timeLimit)
            {
                EnableAccessibilityFeature();
            }
        }
    }

    void EnableAccessibilityFeature()
    {
        accessibilityEnabled = true;

        if (accessibilityButton != null)
        {
            accessibilityButton.SetActive(true);
        }

        Debug.Log("Accessibility feature activated.");
    }
}