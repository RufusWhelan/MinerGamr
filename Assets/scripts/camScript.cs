using UnityEngine;
public class camScript : MonoBehaviour
{
    public Transform player;
    public float distance;
    public float mouseSensitivity;
    public float smoothSpeed;
    private float yaw;
    private float pitch;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, 0f, 60f); // Limit up/down view

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = Vector3.Lerp(transform.position, player.position + rotation * direction, smoothSpeed * Time.deltaTime);

        // Camera always looks at the player
        transform.LookAt(player.position);
    }
}
