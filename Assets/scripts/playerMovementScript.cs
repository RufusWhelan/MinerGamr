using UnityEngine;
using UnityEngine.Rendering;

public class playerMovementScript : MonoBehaviour
{
    public playerMovementData Data;

    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Transform cameraTransform;
    private Vector3 playerMovementInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Data.jumpBuffer -= Time.deltaTime;
        PlayerInput();
    }
    void FixedUpdate()
    {
        rotation();
        GroundCheck();
        Gravity();
        MovePlayer();
        if (Data.jumpState == true)
        {
            Jump();
        }
    }

    private void PlayerInput()
    {
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //gets the users WASD input and turns it into a useable vector
        if (playerMovementInput.magnitude > 1)
            playerMovementInput.Normalize();

        if (Input.GetKeyDown(KeyCode.Space))
            Data.jumpBuffer = Data.jumpBufferCounter;

        if (Data.jumpBuffer > 0 && Data.coyoteTime > 0 && playerBody.linearVelocity.y <= 0.1f)
        {
            Data.jumpState = true;   
        }
    }

    private void rotation()
    {
        float targetYaw = cameraTransform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, targetYaw, 0);
    }
    private void GroundCheck()
    {  
        if (Physics.Raycast(transform.position, -transform.up, out Data.hit, Data.groundCheckDistance))
        {
            Data.coyoteTime = Data.coyoteTimeCounter; 
            Data.grounded = true;
        }
        else
        {
            Data.coyoteTime -= Time.deltaTime;
            Data.grounded = false;
        }
    }
    private void Gravity()
    {
        if (Mathf.Abs(playerBody.linearVelocity.y) < Data.jumpHangTimeThreshold && Data.coyoteTime <= 0)
            Data.gravityScale = Data.jumpHangTimeMulti;

        else if (Input.GetKeyUp(KeyCode.Space) && playerBody.linearVelocity.y > 0.5 && Data.gravityScale != Data.jumpHangTimeMulti)
            Data.gravityScale = Data.jumpCutGravMulti;

        else if (playerBody.linearVelocity.y < -0.5)
            Data.gravityScale = Data.FallGravMulti;
        
        else
            Data.gravityScale = 1;

        playerBody.AddForce(Vector3.up * Data.gravityStrength * Data.gravityScale, ForceMode.Acceleration); 
        Vector3 velocity = playerBody.linearVelocity;
        velocity.y = Mathf.Clamp(velocity.y, -60f, float.MaxValue);
        playerBody.linearVelocity = velocity;
    }

    private void MovePlayer()
    {
        Vector3 moveVector = transform.TransformDirection(playerMovementInput); //makes the WASD vector relative to the direction the player is facing
        Vector3 targetSpeed = new Vector3(moveVector.x * Data.topSpeed, 0f, moveVector.z * Data.topSpeed); //ensures the the users target speed as the correct sign.

        Vector3 accelRate;
        accelRate = new Vector3(Mathf.Abs(targetSpeed.x) > 0.01 ? Data.accelAmount : Data.deccelAmount, 0f,  Mathf.Abs(targetSpeed.z) > 0.01 ? Data.accelAmount : Data.deccelAmount); //checks if the player is actively moving and applies accelarion or deccelaration accordingly

        if (Mathf.Abs(playerBody.linearVelocity.x) > Mathf.Abs(targetSpeed.x) && Mathf.Abs(playerBody.linearVelocity.x) == Mathf.Abs(targetSpeed.x) && Mathf.Abs(targetSpeed.x) > 0.01f)
            accelRate.x = 0;
        
        if (Mathf.Abs(playerBody.linearVelocity.z) > Mathf.Abs(targetSpeed.z) && Mathf.Abs(playerBody.linearVelocity.z) == Mathf.Abs(targetSpeed.z) && Mathf.Abs(targetSpeed.z) > 0.01f)
            accelRate.z = 0;
        //allows the player to conserve momentum even if they are surpassing the target speed as long as they don't slow down

        Vector3 speedDif = new Vector3(targetSpeed.x - playerBody.linearVelocity.x, playerBody.linearVelocity.y, targetSpeed.z - playerBody.linearVelocity.z); //compares players current speed to target speed
        Vector3 movement;
        movement = new Vector3(speedDif.x * accelRate.x, 0f, speedDif.z * accelRate.z); //sets players speed to acceleration multiplied by the distance between current speed and target speed.
        
        playerBody.AddForce(movement.x, movement.y, movement.z, ForceMode.Force); //applies the force to the player.
    }
    private void Jump()
    { 
        Data.coyoteTime = 0;
        Data.jumpBuffer = 0;
        Data.jumpState = false;
        float force = Data.jumpForce;
        if (playerBody.linearVelocity.y < 0)
			force -= playerBody.linearVelocity.y;

		playerBody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }
}
