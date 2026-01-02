using UnityEngine;

public class ScenarioMotion : MonoBehaviour
{
    public Animator animator;
    public CanvasGroup fadeCanvas;
    public TMPro.TextMeshProUGUI messageText;

    [Header("References")]
    public Transform player;        // orang
    public Transform wheelchair;    // wheelchair

    [Header("Positions")]
    public Vector3 playerStartPos = new Vector3(-3.29099989f, 0f, -0.720000029f);
    public Vector3 wheelchairTargetPos = new Vector3(-3.47000003f, 0.0872218758f, -5.78999996f);

    public float moveSpeed = 1.5f;

    public void ChooseStand()
    {
        animator.SetTrigger("Stand");
        Invoke(nameof(FallResult), 3f);
    }

    void FallResult()
    {
        animator.SetTrigger("Fallen");
        ShowMessage("Trying to stand caused a dangerous fall.\nSimple actions can become life-threatening.");
    }

    public void ChooseWheelchair()
    {
        animator.SetTrigger("Wheelchair");

        // teleport player ke posisi awal
        player.position = playerStartPos;

        // parent player ke wheelchair supaya ikut jalan
        player.SetParent(wheelchair);

        // mulai gerakin wheelchair
        StartCoroutine(MoveWheelchair());

        Invoke(nameof(WheelchairFail), 4f);
    }

    System.Collections.IEnumerator MoveWheelchair()
    {
        while (Vector3.Distance(wheelchair.position, wheelchairTargetPos) > 0.05f)
        {
            wheelchair.position = Vector3.MoveTowards(
                wheelchair.position,
                wheelchairTargetPos,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        // pastikan posisi presisi
        wheelchair.position = wheelchairTargetPos;

        // balik ke idle
        animator.ResetTrigger("Wheelchair");
        animator.SetTrigger("Idle");
    }


    void WheelchairFail()
    {
        player.SetParent(null); // lepas dari wheelchair
        ShowMessage("Even with a wheelchair, reaching simple things isn’t guaranteed.\nAccessibility isn’t universal.");
    }


    public void ChooseHelp()
    {
        animator.SetTrigger("AskHelp");
        Invoke(nameof(HelpResult), 3f);
    }

    void HelpResult()
    {
        ShowMessage("Asking for help shouldn’t feel shameful.\nBut many face judgment instead of support.");
    }

    // Hidden option
    public void ChooseGrabber()
    {
        ShowMessage("Adaptive tools help, but they’re not perfect.\nAccessibility requires more than tools.");
    }

    void ShowMessage(string msg)
    {
        StartCoroutine(FadeAndShow(msg));
    }

    System.Collections.IEnumerator FadeAndShow(string msg)
    {
        fadeCanvas.alpha = 0;
        fadeCanvas.gameObject.SetActive(true);

        while (fadeCanvas.alpha < 1)
        {
            fadeCanvas.alpha += Time.deltaTime;
            yield return null;
        }

        messageText.text = msg;
    }
}
