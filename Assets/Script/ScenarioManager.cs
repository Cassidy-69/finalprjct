using UnityEngine;

public class ScenarioManager : MonoBehaviour
{
    public FirstPerson cameraController;
    public GameObject choiceUI;

    void Start()
    {
        choiceUI.SetActive(false);

        Invoke(nameof(ShowChoices), 6f);
    }

    void ShowChoices()
    {
        cameraController.SetCamera(false); 
        choiceUI.SetActive(true);          
    }

    public void ShowChoicesAgain()
    {
        cameraController.SetCamera(false);
        choiceUI.SetActive(true);
    }

    public void OnChoiceSelected()
    {
        choiceUI.SetActive(false);
        cameraController.SetCamera(true); 
    }
}
