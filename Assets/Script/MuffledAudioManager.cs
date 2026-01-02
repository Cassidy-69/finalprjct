using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoQuestionManager : MonoBehaviour
{
    [Header("Video")]
    public VideoPlayer videoPlayer;

    [Header("Question UI")]
    public GameObject questionPanel;
    public TMP_Text questionText;
    public TMP_Text resultText;

    public Button buttonA;
    public Button buttonB;
    public Button buttonC;

    [Header("Accessibility")]
    public AudioLowPassFilter lowPassFilter;
    public Button accessibilityButton;
    public TMP_Text messageText;

    private int attempt = 0;

    private bool question1Shown = false;
    private bool question2Shown = false;

    void Start()
    {
        questionPanel.SetActive(false);
        accessibilityButton.gameObject.SetActive(false);
        resultText.text = "";
        messageText.text = "";

        lowPassFilter.enabled = true;
        lowPassFilter.cutoffFrequency = 300f;

        videoPlayer.Play();
    }

    void Update()
    {
        double time = videoPlayer.time;

        if (!question1Shown && time >= 21f)
        {
            question1Shown = true;
            videoPlayer.Pause();
            ShowQuestion1();
        }

        if (!question2Shown && time >= 52f)
        {
            question2Shown = true;
            videoPlayer.Pause();
            ShowQuestion2();
        }
    }

    void ShowQuestion1()
    {
        attempt = 0;
        questionPanel.SetActive(true);
        resultText.text = "";
        accessibilityButton.gameObject.SetActive(false);

        questionText.text =
            "In the talk, what does Woody say he cares more about?";

        SetupButtons(
            "What the people in the room think",
            "What the internet thinks",
            "What his parents think",
            false,  
            false,   
            false   
        );
    }

    void ShowQuestion2()
    {
        attempt = 0;
        questionPanel.SetActive(true);
        resultText.text = "";
        accessibilityButton.gameObject.SetActive(false);

        questionText.text =
            "Why does Woody think attention spans are different now?";

        SetupButtons(
            "Because of boring speakers",
            "Because people read more books",
            "Because attention spans are basically gone in the digital age",
            false,
            false,
            true    
        );
    }

    void SetupButtons(
        string a, string b, string c,
        bool aCorrect, bool bCorrect, bool cCorrect)
    {
        buttonA.GetComponentInChildren<TMP_Text>().text = a;
        buttonB.GetComponentInChildren<TMP_Text>().text = b;
        buttonC.GetComponentInChildren<TMP_Text>().text = c;

        buttonA.onClick.RemoveAllListeners();
        buttonB.onClick.RemoveAllListeners();
        buttonC.onClick.RemoveAllListeners();

        buttonA.onClick.AddListener(() => Answer(aCorrect));
        buttonB.onClick.AddListener(() => Answer(bCorrect));
        buttonC.onClick.AddListener(() => Answer(cCorrect));
    }

    void Answer(bool isCorrect)
    {
        if (isCorrect)
        {
            resultText.text = "Correct answer!";
            messageText.text = "Clarity and captions restore inclusion.";
            StartCoroutine(HideUIAfterDelay(4f));
            videoPlayer.Play();
            return;
        }

        attempt++;
        resultText.text = "Incorrect answer";

        if (attempt == 1)
        {
            accessibilityButton.gameObject.SetActive(true);
            messageText.text = "Audio is hard to understand.";
        }
    }

    public void EnableAccessibility()
    {
        lowPassFilter.enabled = false;
        lowPassFilter.cutoffFrequency = 22000f;

        messageText.text = "Clarity and captions restore inclusion.";

        
        accessibilityButton.interactable = false;

        
        videoPlayer.Play();

        StartCoroutine(HideUIAfterDelay(4f)); 
    }

    IEnumerator HideUIAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        accessibilityButton.gameObject.SetActive(false);
        questionPanel.SetActive(false);
    }



}
