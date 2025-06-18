using System.Collections;
using System.Data;
using UnityEngine;

public class playerControllerScript : MonoBehaviour
{
    public playerHealthController PlayerHealth;
    public playerData Data;
    [SerializeField] private Rigidbody playerBody; 
    [SerializeField] private Transform cameraTransform;
    void Start()
    {
        playerBody.useGravity = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Data.jumpBuffer -= Time.deltaTime; //establishes constant jumpbuffer timer
        PlayerInput(); //runs player input in update for smoother gameplay experience

        if (Data.pause == true)
            Pause(); //pause time on pause input

        if (Data.pause == false)
            Unpause(); //if no pause input, time is normal
    }
    void FixedUpdate()
    {
        Rotation();
        GroundCheck();
        Gravity();
        MovePlayer();
        //runs functions that are constant and run every physics update

        if (Data.jumpState == true)
            Jump();

        if (Data.dashInput == true)
            StartCoroutine(Dash());

        if (Data.throwInput == true)
            ThrowExplosive();


        //if the input for an action has been entered, trigger the corresponding action.
    }

    private void PlayerInput()
    {
        /*
        Interprets player inputs from update into booleans that can trigger functions in FixedUpdate.

        'returns':
            bools: player input values 

        */
        Data.playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //gets the users WASD input and turns it into a useable vector
        if (Data.playerMovementInput.magnitude > 1) Data.playerMovementInput.Normalize(); //normalises player input to prevent the player from travelling faster diagonally.

        if (Input.GetKeyDown(KeyCode.Space))
            Data.jumpBuffer = Data.jumpBufferCounter; //gives the player a short moment where they can press the jump button before they are on the ground. They will jump the first frame they are touching the ground again.

        if (Data.jumpBuffer > 0 && Data.coyoteTime > 0 && playerBody.linearVelocity.y <= 0.1f)
            Data.jumpState = true; //If the player isn't already moving upwards and they haven't pressed the jump button too early or too late, the player jumps.

        if (Input.GetKeyDown(KeyCode.LeftShift) && Data.canDash == false)
        {
            Debug.Log("call dash");
            Data.dashInput = true; //If the player clicks leftShift they dash
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && Data.cantThrow == false)
                Data.throwInput = true; //If the player leftClicks they throw an explosive

        if (Input.GetKeyDown(KeyCode.Mouse1))
            Data.explosionInput = true; //if the player RightClicks they attempt to explode an explosive

        if (Input.GetKeyDown(KeyCode.Escape))
            Data.pause = !Data.pause;
    }

    private void Rotation()
    {
        /*
        Rotates the player in accordance to the camera.
        
        'returns':
            vector3: updated player rotation
        */
        float targetYaw = cameraTransform.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, targetYaw, 0); //adjusts the player's rotation of the y axis to the rotation of the camera's y axis
    }
    private void GroundCheck()
    {
        /*
        Checks if the player is touching the ground.

        'returns':
            bool: whether or not the player is grounded
        */
        if (Physics.Raycast(transform.position, -transform.up, out Data.hit, Data.groundCheckDistance)) //sends a raycast from the center of the player to a little bit below the base of the player
        {
            Data.coyoteTime = Data.coyoteTimeCounter;
            Data.grounded = true;
            //If this ray hits anything, then the player is grounded.
        }
        else
        {
            Data.coyoteTime -= Time.deltaTime; //gives the player a little leeway in reguards to whether or not they were on the ground when the jump button was pressed
            Data.grounded = false;
        }
    }
    private void Gravity()
    {
        /*
        Applies constant acceleration force to the player, pulling downwards on the y axis.

        'returns':
            vector3: updated player position on the y axis
        */
        if (Mathf.Abs(playerBody.linearVelocity.y) < Data.jumpHangTimeThreshold && Data.coyoteTime <= 0) //checks if the player is not touching the ground and if there velocity is within the Hangtime Theshhold
            Data.gravityScale = Data.jumpHangTimeMulti; //weakens the gravity at the apex of the jump to improve game feel

        else if (Input.GetKeyUp(KeyCode.Space) && playerBody.linearVelocity.y > 0.5 && Data.gravityScale != Data.jumpHangTimeMulti)
            Data.gravityScale = Data.jumpCutGravMulti; //increases gravity when the player releases the jump button so they fall faster.

        else if (playerBody.linearVelocity.y < -0.5) //checks if the player is falling
            Data.gravityScale = Data.FallGravMulti; //sets gravity to a falling value

        else if (Data.isDashing && playerBody.linearVelocity.y < 0.5)
            Data.gravityScale = 0;

        else
            Data.gravityScale = 1; //resets the value of gravity inbetween falling states

        playerBody.AddForce(Vector3.up * Data.gravityStrength * Data.gravityScale, ForceMode.Acceleration); //creates the constant acceleration that will be applied to the player
        Vector3 velocity = playerBody.linearVelocity; //turns the acceleration into a Vector3 that can be manipulated
        velocity.y = Mathf.Clamp(velocity.y, -60f, float.MaxValue); //clamps the values of gravity to prevent the player from falling to quickly.
        playerBody.linearVelocity = velocity; //applies the acceleration to the player
    }

    private void MovePlayer()
    {
        /*
        Moves the player on the X and Z axis.

        'returns':
            Vector3: updated player position on the X and Z axes
        */
        Vector3 moveVector = transform.TransformDirection(Data.playerMovementInput); //makes the WASD vector relative to the direction the player is facing
        Vector3 targetSpeed = new Vector3(moveVector.x * Data.topSpeed, 0f, moveVector.z * Data.topSpeed); //ensures that the users target speed is the correct sign

        Vector3 accelRate;
        accelRate = new Vector3(Mathf.Abs(targetSpeed.x) > 0.01 ? Data.accelAmount : Data.deccelAmount, 0f, Mathf.Abs(targetSpeed.z) > 0.01 ? Data.accelAmount : Data.deccelAmount); //checks if the player is actively moving and applies accelarion or deccelaration accordingly

        if (Mathf.Abs(playerBody.linearVelocity.x) > Mathf.Abs(targetSpeed.x) && Mathf.Abs(playerBody.linearVelocity.x) == Mathf.Abs(targetSpeed.x) && Mathf.Abs(targetSpeed.x) > 0.01f)
            accelRate.x = 0;

        if (Mathf.Abs(playerBody.linearVelocity.z) > Mathf.Abs(targetSpeed.z) && Mathf.Abs(playerBody.linearVelocity.z) == Mathf.Abs(targetSpeed.z) && Mathf.Abs(targetSpeed.z) > 0.01f)
            accelRate.z = 0;
        //allows the player to conserve momentum even if they are surpassing the target speed as long as they don't slow down

        Vector3 speedDif = new Vector3(targetSpeed.x - playerBody.linearVelocity.x, playerBody.linearVelocity.y, targetSpeed.z - playerBody.linearVelocity.z); //compares players current speed to target speed to determine how much force is applied to the player.
        Vector3 movement;
        movement = new Vector3(speedDif.x * accelRate.x, 0f, speedDif.z * accelRate.z); //sets players speed to acceleration multiplied by the distance between current speed and target speed

        playerBody.AddForce(movement.x, movement.y, movement.z, ForceMode.Force); //applies the force to the player
    }
    private void Jump()
    {
        /*
        Moves the player upwards on the y axis.

        'returns':
            vector3: updated player position on th y axis
        */
        Data.jumpState = false;  //stop registering input on the first frame this function is called
        Data.coyoteTime = 0;
        Data.jumpBuffer = 0;
        //these values are set to zero to prevent the user from doulbe jumping
        float force = Data.jumpForce;
        if (playerBody.linearVelocity.y < 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
            force -= playerBody.linearVelocity.y;

        playerBody.AddForce(Vector3.up * force, ForceMode.Impulse); //applies the force to the player as an impulse
    }

    private IEnumerator Dash()
    {
        /*
        Player dashes forward.
        
        'returns':
            Vector3: updated player position on x and z axis
        */
        Data.dashInput = false;
        Data.canDash = true;
        Data.isDashing = true;
        //sets the dashinput to false so the player doesn't dash multiple times and establishes that the player is dashing, but can't dash again
        Vector3 dashDirection = transform.forward; //establishes a dash vector
        playerBody.linearVelocity = dashDirection.normalized * Data.dashForce;
        yield return new WaitForSeconds(Data.dashDuration); //applies the dash vector to the player until end of dash duration
        Data.isDashing = false; //player is no longer dashing
        yield return new WaitForSeconds(Data.dashCooldown);
        Data.canDash = false; //player can dash again
    } //player dashes

   private void ThrowExplosive()
    {
        /*
        An explosive is spawned and sent forwards on an arc
        
        'returns':
            gameObject: the explosive prefab
        */
        Data.cantThrow = true; //player can no longer throw explosive
        Data.throwInput = false; // sets throwinput to false so that player can throwinput again
        GameObject existingExplosive = GameObject.FindWithTag("CurrentExplosive");
        if (existingExplosive != null)
        {
            Destroy(existingExplosive);
        }
        //if an explosive currently exists, destroy it before making a new one


        Vector3 spawnPosition = Data.throwPosition.position + gameObject.transform.forward;
        GameObject explosive = Instantiate(Data.explosivePrefab, spawnPosition, gameObject.transform.rotation); //spawn the explosive prefab in front of the player (spawn position)
        
        explosive.tag = "CurrentExplosive"; 
        // Spawns the explosive prefab to a position transform slightly infront of the player

            Rigidbody explosiveRb = explosive.GetComponent<Rigidbody>();
        float verticalArc = Data.throwDirection.y;
        Vector3 arcDirection = new Vector3(gameObject.transform.forward.x, verticalArc, gameObject.transform.forward.z).normalized; //creates a vector for the direction the projectile will travel based off player rotation

        explosiveRb.AddForce(arcDirection * Data.throwForce + playerBody.linearVelocity / 3, ForceMode.VelocityChange); //Applies arc force (for height and base distance) of the explosive

        
        Vector3 flatForward = new Vector3(gameObject.transform.forward.x, 0f, gameObject.transform.forward.z).normalized; //establishes a vector that holds current player velocity


        explosiveRb.AddForce(flatForward, ForceMode.VelocityChange); //adds this vector to the distance that the explosive travels

        explosive.GetComponent<explosive>().Data = Data; //assigns the playerData component to the Data referenced throughout this function on each individual explosive spawned
    }


    private void Pause()
    {
        /*
        time is paused
        
        'returns':
            Time: tickspeed is now 0
        */
        Time.timeScale = 0f; //game is 'paused'
    }
    private void Unpause()
    {/*
        time is unpaused
        
        'returns':
            Time: tickspeed is now 1
        */
        if (PlayerHealth.player.isAlive)
            Time.timeScale = 1f; //game is 'unpaused'
    }
}

