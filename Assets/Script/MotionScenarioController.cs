using UnityEngine;

public class MotionScenarioController : MonoBehaviour
{
    public enum ScenarioState
    {
        Bed,
        Fall,
        Wheelchair,
        Caregiver,
        Grabber,
        Reflection
    }

    public ScenarioState currentState = ScenarioState.Bed;

    public void AttemptStand()
    {
        if (currentState == ScenarioState.Bed)
        {
            currentState = ScenarioState.Fall;
            PlayFallSequence();
        }
    }

    public void UseWheelchair()
    {
        if (currentState == ScenarioState.Bed)
        {
            currentState = ScenarioState.Wheelchair;
            MoveToTable();
        }
    }

    public void CallCaregiver()
    {
        if (currentState == ScenarioState.Bed)
        {
            currentState = ScenarioState.Caregiver;
            ShowCaregiverDialogue();
        }
    }

    public void UseGrabber()
    {
        if (currentState == ScenarioState.Wheelchair)
        {
            currentState = ScenarioState.Grabber;
            KnockGlassOver();
        }
    }

    void PlayFallSequence()
    {
        Debug.Log("Player falls while attempting to stand.");
        ShowReflection();
    }

    void MoveToTable()
    {
        Debug.Log("Player moves closer using wheelchair.");
    }

    void ShowCaregiverDialogue()
    {
        Debug.Log("Caregiver scolds the player.");
        ShowReflection();
    }

    void KnockGlassOver()
    {
        Debug.Log("Glass falls to the floor.");
        ShowReflection();
    }

    void ShowReflection()
    {
        currentState = ScenarioState.Reflection;
        Debug.Log("Reflection message displayed.");
    }
}