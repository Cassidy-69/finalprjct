using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    public float sensitivity = 100f;
    public bool cameraActive = true;

    float pitch;
    float yaw;

    void Start()
    {
        SetCamera(true);
    }

    void Update()
    {
        if (!cameraActive) return;

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -70f, 70f);

        yaw += mouseX;
        yaw = Mathf.Clamp(yaw, -180f, 180f);

        transform.localRotation = Quaternion.Euler(pitch, yaw, 0f);
    }

    public void SetCamera(bool active)
    {
        cameraActive = active;
        Cursor.lockState = active ? CursorLockMode.Locked : CursorLockMode.None;
        Cursor.visible = !active;
    }
}
