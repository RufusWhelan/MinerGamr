using UnityEngine;

public class camScript : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float mouseSensitivity = 2f;
    public float smoothSpeed = 10f;

    private float yaw;
    private float pitch;
    private Vector3 smoothedLookTarget;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, 0f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredPosition = player.position + rotation * new Vector3(0f, 0f, -distance);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        smoothedLookTarget = Vector3.Lerp(smoothedLookTarget, player.position, smoothSpeed * Time.deltaTime);
        transform.LookAt(smoothedLookTarget);
    }

    void Start()
    {
        smoothedLookTarget = player.position;
    }
}