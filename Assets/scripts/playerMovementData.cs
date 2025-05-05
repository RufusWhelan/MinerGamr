using UnityEngine;
public class playerMovementData : MonoBehaviour
{
    [Header("Run")]
    public float rawAccelaration;
    [HideInInspector] public float accelAmount;
    public float rawDeccelaration;
    [HideInInspector] public float deccelAmount;
    public int topSpeed;

    [HideInInspector] public bool grounded = false;
    [HideInInspector] public float groundCheckDistance = 0.5f;
    [HideInInspector] public RaycastHit hit;

    [HideInInspector]public float jumps;
    [HideInInspector]public bool jumpState = false;

    [Space(5)]
    [Header("Jump")]
    public float jumpHeight;
    public float timeToApex;
    [HideInInspector] public float jumpForce;
    public float jumpHangTimeThreshold;
    public float jumpHangTimeMulti;
    public float jumpCutGravMulti;
    public float FallGravMulti;
    [HideInInspector]public float coyoteTime;

    [Space(5)]
    [Header("CoyoteTime")]
    public float coyoteTimeCounter;
    [HideInInspector]public float jumpBuffer;
    public float jumpBufferCounter;

    [HideInInspector]public float gravityStrength;
    [HideInInspector]public float gravityScale;
    private void OnValidate()
    {
        accelAmount = (rawAccelaration * 50) / topSpeed; //makes it so that accelaration is applied
        deccelAmount = (rawDeccelaration * 50) / topSpeed;

        gravityStrength = -(2 * jumpHeight) / (timeToApex * timeToApex); //a physics formula which established what the strength of gravity should be to allow the player to jump an entered height
        jumpForce = Mathf.Abs(gravityStrength) * timeToApex; //determins the amount of force required for the jump to reach the specified height that the specified rate

    }
}
