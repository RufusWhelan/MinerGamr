using UnityEngine;

public class camScript : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float mouseSensitivity = 2f;
    public float smoothSpeed = 10f;
    [HideInInspector] public float yaw;
    [HideInInspector] public float pitch;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity; //gets player position on the y axis (I know that doesn't make sense, it's just how unity does it)
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity; //gets plater position on the x axis
        pitch = Mathf.Clamp(pitch, -1f, 80f); //clamps the camera position so the camera cannot be rotated around the player endlessly.

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f); //turns the values of pitch and yaw into a Quaternion (used to represebt rotations in 3 dimensions)
        Vector3 desiredPosition = player.position + rotation * new Vector3(0f, 0f, -distance); //established where the camera wants to be in relation to the player
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //smoothes the cameras position from its current position to the desired postion

        transform.LookAt(player.position); //makes sure the camera is always looking at the player
    }
}