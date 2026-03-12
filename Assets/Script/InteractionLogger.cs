using UnityEngine;
using System.IO;

public class InteractionLogger : MonoBehaviour
{
    string logPath;

    void Start()
    {
        logPath = Application.persistentDataPath + "/interaction_log.txt";
    }

    public void LogInteraction(string scenarioName, int attempts, float timeSpent, bool accessibilityUsed)
    {
        string record =
            "Scenario: " + scenarioName +
            " | Attempts: " + attempts +
            " | Time: " + timeSpent +
            " | AccessibilityUsed: " + accessibilityUsed + "\n";

        File.AppendAllText(logPath, record);

        Debug.Log("Interaction logged: " + record);
    }
}