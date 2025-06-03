using UnityEngine;
public class playerData : MonoBehaviour
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

    [HideInInspector] public bool dashInput;
    [HideInInspector]public float dashForce; 
    [Header("Dash")]   
    public float dashDistance;
    public float dashDuration;

    [HideInInspector] public bool throwInput;
    [HideInInspector] public bool explosiveEntity;
    [HideInInspector] public bool explosionInput;

    [HideInInspector] public bool pause;
    private void OnValidate()
    {
        /*
        Adjusts values from editor so they are calculated every physics frames and ajusts gravity to coincide with jump height

        return:
            none
        */
        accelAmount = (rawAccelaration * 50) / topSpeed; //makes it so that acceleration entered in the editor is adjusted to be calculated every physics frame.
        deccelAmount = (rawDeccelaration * 50) / topSpeed; //makes it so that deceleration entered in the editor is adjusted to be calculated every physics frame.

        gravityStrength = -(2 * jumpHeight) / (timeToApex * timeToApex); //a physics formula which established what the strength of gravity should be to allow the player to jump an entered height
        jumpForce = Mathf.Abs(gravityStrength) * timeToApex; //determins the amount of force required for the jump to reach the specified height that the specified rate

        dashForce = (dashDistance * 50) / dashDuration;

    }
}
