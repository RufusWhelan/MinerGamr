# __MinerGame__

## __Sprint 1__
## Requirements Definition
### __Functional Requirements__
* User can move their character around in 3 dimensional space.
* User can move the camera around the character.
* User can throw an explosive that can be detonated to explode objects, enemies or to propel the character into the air
* User can dash forwards on ground or in the air, giving the player a sudden burst of speed.
* system can simulate basic enemies that can attack the player and that the player can destroy.
* User can die if their hp reaches zero.
* User can navigate through a main menu to start the game, quit the game, adjust Options or save/load a save file.
* User can save their progress in the game and continue the game from that point next time they load the game.

### __Non-functional Requirements__
* Game must run at a consistent 60 frames per second.
* System should only load the area of the game that the player is in to improve performance.
* System should always return the corresponding output from the users input (e.g player presses w, character moves forward).
* User should be able to customise controls to allow people with disabilities to play the game.
* User should have access to an instruction panel that describes how to play the game.
* System should automatically save, occasionally to prevent loss of save data in the event of a crash.
* User should be able to adjust mouse sensitivity and volume.

## Determining Specifications
### __Functional Requirements__
### Inputs & Outputs
* User can input using WASD. The system will move the player character in 3d space accordingly.
* User can input by moving their mouse. The system will move the player camera accordingly.
* User can use a 'dash' input. The system will send the player forward, increasing the characters speed for a short duration after the dash ends.
* User can use a 'throw explosive' input. The system will spawn in an object from inside the player that shoots upwards at a 45 degree angle before landing on the ground in front of the player. If it hits the player or an enemy, it will instantly explode
* User can use an 'explode explosive' input. The system will destroy the 'explosive' and any destructable objects around it. Additionally, if any moveable objects (including the player) are in the radius of the explosion, they will be launched on an angle according to their position in relation to the explosive's position
* User can choose to 'start', go to 'Options', 'load', 'quit'. The system will then trigger the scene that corresponds to that input whilst in the main menu.
* User can use sliders to adjust volume of music or SFX and can change the key that corresponds to each input, whilst in Options. The system will take these inputs and adjust the game accordingly.
* User can use a 'pause' input. This freezes the game world and brings up a pause menu where users can 'save', go to Options or 'quit'.
* On saving, the system creates a json file or uses playerprefs to save the users progress in the game.
* On loading, the system brings the user to a screen which shows their previous saves. They can select the one they want to play and the corresponding scene will be triggered.
* On quiting, the system automatically saves player progress just incase, before shutting the game.

### Core features
__System needs to simulate a game world that:__
* Allows the user to move in 3d space, walking, dashing and jumping.
* Allows the user to throw an explosive which can destroy certain objects in the world.
* simulates enemies with basic ai that can be destroyed by the player and can deal damage to the player.
* Allows the user to die and respawn.
* Allows the user to start the game by clicking the buttons.
* Allows the user to adjust Options by using sliders and buttons.
* Allows the user to save and load their progress.
* Allows the user to quit the program.

### User Interaction
* User will interact with the system during gameplay by using keyboard and mouse inputs by default (WASD, Shift, LeftClick, RightClick, Mouse movement).
* User will interact with the system while in menus by using their mouse to click buttons or move sliders by default (Left click, mouse movement). (GUI)
* User can set their inputs to come from a connected controller.
* User will interact with the system during gameplay by using the joysticks and and buttons on the controller (Left joystick, B, A, LT, RT, Right joystick) in controller mode.
* User will interact with system in menus by using the left joystick and button inputs (Left joystick, A, B) in controller mode.
* User can change inputs from defaults to make the game more accessible.


### Error Handling
* System will return an error to the user in the event of a crash, loading the game from the last savepoint on next reboot.
* System will return an error message in the event of an error occuring while saving progress.
* System will return an error message to the user if it fails to load part of a level when it is necessary
* System will return an error message to the user and attempt to reboot, in the event that their is an error loading the users savefile.
* All User inputs are required to have a UNIQUE key assigned to them before the user can save their keybinds. To prevent unexpected errrors or make the game completely unplayable.

### __Non-functional Specifications__
* Physics calculations should be calculated at a stable rate of 50 times per second (Unity default for fixed update)
* Gameplay should remain at a consistent 60 frames per second on school hardware to ensure it is playable.
* To efficiently maintain framerates, the amount of entities and the amount of the level loaded at any one time should limited as this improves performance without effecting gameplay
* To ensure usability and accessibility, users can assign inputs to their own custom keybinds which allows for greater player freedoms and allows for indivuals with disabilities to play the game.
* To improve reliability of the system when saving, to seperate saves will be made of the player one after another in case one has errors.
* An error that could occur is that the player falls through the map, missing the death plane and is essentially stuck. If this becomes a problem, an 'unstuck' button could be added that moves the player to a safe position to remedy this.


## Use Cases

the numbers next to each use case refer to which sprint it was completed in

### Actor
* User (Gamer) 
### Preconditions
* access to hardware capable of running the game

### Main Flow
* __Movement:__ User moves. System changes the players position on the horizontal axes accordingly, abiding by collisions, with continous force. (1)
* __Jumping:__ User jumps. System sends the player upwards, abiding by collisions, with insantaneous force. (1)
* __Dashing:__ User dashes. System sends the player forwards horizontally, abiding by collisions, with instantaneos force
* __Throwing:__ User throws explosive. System spawns the object then lauches forwards on a 45 degree angle relative to the players position. If it hits an entity, the system destroys the explosive and the colliding entity.
* __Exploding:__ User explodes explosive. System destroys the object and any entities within range. If the player is in range of the explosive, they get launched away from the exlplosive.
* __Looking:__ User moves their mouse. system moves the player camera around the player accordingly. (1)
* __Pausing:__ Uses pauses. system freezes game logic to the nearest physics frame, displaying UI to switch to other scenes.

### Postconditions(Main)
* Player is moved horizontally and vertically. 
* Explosives are spawned and exploded (moving and destroying entities accordingly).
* The camera is moved around the player.

### Alternate Flows (Menus)
__Main Menu__
* __Start:__ User starts game. System transitions to the first gameplay scene. (1)
* __Options:__ User goes to Options. System transitions the Options scene. (1)
* __Loading:__ User selects 'load game'. System transitions to the savefile screen, displaying previous save files. User selects a save file. System loads corresponding game state and scene.
* __Quit:__ User quits. System saves the current progress and then exits the game. (1)

__Options Menu__
* __Adjustiing Volume:__ User drags volume sliders (Music/SFX). System updates volume of music and SFX values.
* __Keybinding:__ User selects a keybind. System waits for new input, records the chosen key, and assigns it to the corresponding action, ensuring no duplicates before saving.
* __Sensitivity:__ User adjusts mouse sensitivity. System stores sensitivity value and updates input detection accordingly.

__Pause Menu__
* __MainMenu:__ User selects 'return to main menu'. System saves, then loads the mainmenu scene.
* __Saving:__ User saves. system generates or updates a save file with current player progress using JSON or PlayerPrefs.
* __Loading:__ User selects 'load game'. System transitions to the savefile screen, displaying previous save files. User selects a save file. System loads corresponding game state and scene.
* __Options:__ User goes to Options. system triggers Options scene.
* __Quit:__ User quits. System saves the current progress and then exits the game.

### Postconditions(Alts)
* Scenes are transitioned to accordingly. 
* Player preferences are changed and updates. 
* Savefiles are created, updated and loaded. 
* Progress is saved and system is terminated.

### Use Case Diagram

## Design

### Storyboard

### Dataflow diagrams

### Gantt Chart

## Build
(all scripts)
```
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


public class playerMovementScript : MonoBehaviour
{
    public playerMovementData Data;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Transform cameraTransform;
    private Vector3 playerMovementInput;
    void Start()
    {
        playerBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Data.jumpBuffer -= Time.deltaTime; //establishes constant jumpbuffer timer
        PlayerInput(); //runs player input in update for smoother gameplay experience
        if (Data.pause == true)
            pause();

        if (Data.pause == false)
            unpause();
    }
    void FixedUpdate()
    {
        rotation();
        GroundCheck();
        Gravity();
        MovePlayer();
        //runs functions that are constant and run every physics update

        if (Data.jumpState == true)
            Jump();

        if (Data.dashInput == true)
            dash();

        if (Data.throwInput == true)
            throwExplosive();

        if (Data.explosionInput == true)
            explodeExplosive();

        //if the input for an action has been entered, trigger the corresponding action.
    }

    private void PlayerInput()
    {
        /*
        Interprets player inputs from update into booleans that can trigger functions in FixedUpdate.

        'returns':
            bools: player input values 

        */
        playerMovementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); //gets the users WASD input and turns it into a useable vector
        if (playerMovementInput.magnitude > 1) playerMovementInput.Normalize(); //normalises player input to prevent the player from travelling faster diagonally.

        if (Input.GetKeyDown(KeyCode.Space))
            Data.jumpBuffer = Data.jumpBufferCounter; //gives the player a short moment where they can press the jump button before they are on the ground. They will jump the first frame they are touching the ground again.

        if (Data.jumpBuffer > 0 && Data.coyoteTime > 0 && playerBody.linearVelocity.y <= 0.1f)
            Data.jumpState = true; //If the player isn't already moving upwards and they haven't pressed the jump button too early or too late, the player jumps.

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Data.dashInput = true; //If the player clicks leftShift they dash

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Data.throwInput = true; //If the player leftClicks they throw an explosive

        if (Input.GetKeyDown(KeyCode.Mouse1))
            Data.explosionInput = true; //if the player RightClicks they attempt to explode an explosive

        if (Input.GetKeyDown(KeyCode.Escape))
            Data.pause = !Data.pause;
    }

    private void rotation()
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
        Vector3 moveVector = transform.TransformDirection(playerMovementInput); //makes the WASD vector relative to the direction the player is facing
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
    private void dash()
    {
        /*
        Player dashes forward.
        
        'returns':
            str: a "dashed" msg
        */
        Debug.Log("Dashed");
        Data.dashInput = false;
    } //player dashes

    private void throwExplosive()
    {
        /*
        Spawns an Explosive.

        'returns':
            str: a 'Thrown' msg 
        */
        Data.throwInput = false; //stop registering input on the first frame this function is called
        Data.explosiveEntity = true; //'spawns' an explosive entity
        Debug.Log("Thrown");
    }

    private void explodeExplosive()
    {
        /*
        Explodes the explosive spawned by throw explosive.

        'returns':
            str: an 'exploded' msg 
        */
        Data.explosionInput = false; //stop registering input on the first frame this function is called
        if (Data.explosiveEntity == true) //checks if there is an entity to explode
        {
            Data.explosiveEntity = false;
            Debug.Log("exploded");
        } //explodes and removes said entity
    }

    private void pause()
    {
        Debug.Log("game paused"); //game is 'paused'
        Time.timeScale = 0f;
    }
    private void unpause()
    {
        Debug.Log("game unpaused"); //game is 'unpaused'
        Time.timeScale = 1f;
    }
}

public class camScript : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float mouseSensitivity = 2f;
    public float smoothSpeed = 10f;

    private float yaw;
    private float pitch;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity; //gets player position on the y axis (I know that doesn't make sense, it's just how unity does it)
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity; //gets plater position on the x axis
        pitch = Mathf.Clamp(pitch, -1f, 90f); //clamps the camera position so the camera cannot be rotated around the player endlessly.

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f); //turns the values of pitch and yaw into a Quaternion (used to represebt rotations in 3 dimensions)
        Vector3 desiredPosition = player.position + rotation * new Vector3(0f, 0f, -distance); //established where the camera wants to be in relation to the player
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime); //smoothes the cameras position from its current position to the desired postion

        transform.LookAt(player.position); //makes sure the camera is always looking at the player
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void gameQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void modeSwitchSlider(float value)
    {
        float localvalue = value;
        if (localvalue == 0)
            Debug.Log("switchedToControllerBinds");
    }
}
```

## Evaluation
__1)__ In its current state, the project does not meet the functional and non functional requirements, as many of the mechanics of the game have not been implemented into the program yet including the dash, explosives, health and enemy AI. Additionally, elements in UI lack functionality which means that keybinds, volume and sensitivity cannot be adjusted. Save files and the planned optimisations to conserve framerates do not exist yet either because levels have not been built. Despite this, the games core functionalities (player and camera movement and interactable menus) have been implemented and I am satified with the games growth up until this point.

__2)__ Compared to the usecases, the program performs unsatifactory, living up to 3 of the 7 usecases in the main flow and 3 of the 10 from alternate flows. It correctly interprets inputs for basic movement (running and jumping) and allows the user to move the camera or pause the game, but in its current state only prints debuglogs for the remaining functions. The menus are interactable and the user can transition between the different screens by clicking the buttons, and can start and quit. Overall, the current program handles inputs and outputs with some success, but still needs further improvements.

__3)__ The quality of my code is high, as it named consistently, thouroughly commented and is relatively organised. Code has been seperated into different files depending on what they are used for (player movement, camera movement and UI) with names that make sense for what they do and the amount of actual code in the main functions (update and fixed update) has been reduced through the use of functions that breakdown the code into more readble and reusable chunks. Code could be broken down further if some functions were placed in separate files or classes were implemented. For the time being, the codes quality in terms of readability, structure and maintainability is adequite.

__4)__ In the next stage of development, the remaining functional requirements and usecases should be implemented into the program. In its current state the game lacks many of its core mechanics that seperate the game from just another 3d platformer, by implementing the remaining functions from the mainflow, the projects quality can drastically be increased. By fininishing the menus and completing the non functional requirements (such as adjustable volume, sensitivty and changing keybinds) the accessability and overall game polish will be improved in the next sprint. By implementing these changes, it can be ensured that the project alligns with its original functional and non-functional requirements by the end of sprint 2.

## __Sprint 2__ 
## Design
### Pseudocode
```
PLAYER CONTROLLER
BEGIN FixedUpdate()
    alive = true
    WHILE alive is true
        RotatePlayer
        CheckGroundCollision
        Gravity
        MovePlayer

        IF jumpInput THEN
            Jump
        END IF

        If dashInput THEN
            Dash
        ENDIF

        If throwInput THEN
            ThrowExplosive
        ENDIF

        If explideInput THEN
            ExplodeInput
        ENDIF

    END WHILE
END FixedUpdate()
```

```
BEGIN MovePlayer()
    moveVector = WASD Input relative to player position
    targetSpeed = The Top horizontal speed multiplied by the movement vector (x, z)

    IF the absolute value of target speed is more than 0.1 THEN
        acceleration = acceleration
    ELSE
        acceleration = decceleration
    END IF

    IF the player travels faster than the target speed THEN
        acceleration = 0
    END IF

    speedDif = targetSpeed - players current Horizontal velocity (x, z)
    movement = acceleration * speedDif
    Apply movement as a force to the players

END MovePlayer()
```

```
CAMERASCRIPT
BEGIN LateUpdate()
    yaw += mouseInput on the y axis * mouseSenitivity
    pitch -= mouseInput on the x axis * mouseSensitivty but must be between the values of -1 and 80

    rotation = pitch, yaw (x,y)
    desiredPosition = the players position + rotation * the distance that the camera is away from the player
    cameraPosition = the interpolated value of the camera current position and desiredPosition

    Camera Looks at player

END LateUpdate()

```

### Flowcharts

## Build
```
using UnityEngine;
using Unity.Mathematics;
public class playerData : MonoBehaviour
{
    [HideInInspector] public Vector3 playerMovementInput;
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
     public bool canDash = true;
    [HideInInspector] public bool isDashing = false;
    [HideInInspector] public float dashForce;
    [Header("Dash")]   
    public float rawDashForce;
    public float dashDuration;
    public float dashCooldown;

    [Header("Explosive")]
    public GameObject explodivePrefab;
    public float throwForce;
    public Transform throwPosition;
    [HideInInspector] public Vector3 throwDirection = new Vector3(0, 1, 0);
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

        dashForce = (rawDashForce * 50) / dashDuration;

    }
}
```

```
using System.Collections;
using System.Data;
using UnityEngine;

public class playerControllerScript : MonoBehaviour
{
    public playerData Data;
    [SerializeField] private Rigidbody playerBody;
    [SerializeField] private Transform cameraTransform;
    void Start()
    {
        playerBody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        Data.jumpBuffer -= Time.deltaTime; //establishes constant jumpbuffer timer
        PlayerInput(); //runs player input in update for smoother gameplay experience
        if (Data.pause == true)
            Pause();

        if (Data.pause == false)
            Unpause();
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
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
            str: a "dashed" msg
        */
        Debug.Log("dash");
        Data.dashInput = false;
        Data.canDash = true;
        Data.isDashing = true;
        Vector3 dashDirection = transform.forward;
        playerBody.linearVelocity = dashDirection.normalized * Data.dashForce;
        yield return new WaitForSeconds(Data.dashDuration);
        Data.isDashing = false;
        yield return new WaitForSeconds(Data.dashCooldown);
        Data.canDash = false;
    } //player dashes

   private void ThrowExplosive()
{
    Data.throwInput = false;

    Vector3 spawnPosition = Data.throwPosition.position + gameObject.transform.forward;
    GameObject explosive = Instantiate(Data.explodivePrefab, spawnPosition, gameObject.transform.rotation);
    // Spawns the explosive prefab to a position transform slightly infront of the player

    Rigidbody explosiveRb = explosive.GetComponent<Rigidbody>();
    float verticalArc = Data.throwDirection.y;
    Vector3 arcDirection = new Vector3(gameObject.transform.forward.x, verticalArc, gameObject.transform.forward.z).normalized;

    explosiveRb.AddForce(arcDirection * Data.throwForce, ForceMode.VelocityChange); // Applies arc force (for height and base distance)

    
    Vector3 flatForward = new Vector3(gameObject.transform.forward.x, 0f, gameObject.transform.forward.z).normalized;

    float movementFactor = Mathf.Clamp01(Vector3.Dot(playerBody.linearVelocity.normalized, flatForward)); // scales throw based on movement direction

    float extraFlatForce = Data.throwForce * 0.3f * movementFactor;

    if (!Data.grounded)
    {
        extraFlatForce *= 1.35f; // Increase distance throw by 25% in air
    }

    explosiveRb.AddForce(flatForward * extraFlatForce, ForceMode.VelocityChange);

    explosive.GetComponent<explosive>().Data = Data; //assigns the playerData component to the Data referenced throughout this function on each individual explosive spawned
}


    private void Pause()
    {
        Debug.Log("game paused"); //game is 'paused'
        Time.timeScale = 0f;
    }
    private void Unpause()
    {
        //Debug.Log("game unpaused"); //game is 'unpaused'
        Time.timeScale = 1f;
    }
} 
```
```
using UnityEngine;

public class explosive : MonoBehaviour
{
    public playerData Data;
    [SerializeField] private float rawExplosionForce;
    private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float rawLaunchPower;
    private float launchPower;
    [SerializeField] private float launchAngle;


    private void Start()
    {
        explosionForce = rawExplosionForce * 50;
        launchPower = rawLaunchPower * 50;
    }

    void FixedUpdate()
    {
        if (Data.explosionInput == true)
            Explode();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerExplode();

        else if (collision.gameObject.CompareTag("Enemy"))
            Explode();
            
        else if (collision.gameObject.CompareTag("Ground")) // Add this condition
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force = force * 0.2f;

                rb.AddExplosionForce(force, transform.position, explosionRadius);

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath();
                }
            }
        }
        Destroy(gameObject);
    }

    private void playerExplode()
    {
        Rigidbody myRb = GetComponent<Rigidbody>();
    if (myRb != null)
        Destroy(myRb);
        GetComponent<Collider>().enabled = false;


        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && !rb.gameObject.CompareTag("Player"))
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0) //checks if player is travelling downwards when jump is pressed. If they are, extra force is added to the jump so the same distance is travelled.
                    force = force * 0.7f;
                

                rb.AddExplosionForce(force, transform.position, explosionRadius);
                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>(); 
                    enemy.triggerDeath();
                }
            }
            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                float angleRad = Mathf.Deg2Rad * launchAngle;
                Vector3 launchDirection = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad)).normalized;
                Vector3 movement = new Vector3(Data.playerMovementInput.x, 0, Data.playerMovementInput.y).normalized;
                launchDirection.x =  launchDirection.x * movement.x;
                if (Data.isDashing == true)
                    launchPower = launchPower * 0.8f;

                rb.AddForce(launchDirection * launchPower, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }

}
```

``` 
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiControllerScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask groundLayer, playerLayer;
    public class AiController
    {
        public Vector3 walkPoint;
        public bool walkPointSet;
        public float walkPointRange;
        public float fieldOfView, damageRange;
        public bool playerSeen, playerInDamageRange;
        public AiController(Vector3 point, bool pointSet, float pointRge, float FOV, float damRge, bool seen, bool inDamRge)
        {
            walkPoint = point;
            walkPointSet = pointSet;
            walkPointRange = pointRge;
            fieldOfView = FOV;
            damageRange = damRge;
            playerSeen = seen;
            playerInDamageRange = inDamRge;

        }

        public void Patrolling()
        {

        }
        public void Chasing()
        {

        }
        public void Attack()
        {

        }

    }

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void triggerDeath()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
}
```

```
using UnityEngine;

public class camScript : MonoBehaviour
{
    public Transform player;
    public float distance = 5f;
    public float mouseSensitivity = 2f;
    public float smoothSpeed = 10f;
    private float yaw;
    private float pitch;

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
```

```
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void gameStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void gameQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void modeSwitchSlider(float value)
    {
        float localvalue = value;
        if (localvalue == 0)
            Debug.Log("switchedToControllerBinds");
    }
}
```

## End of Review Questions
__1)__ In its current state, the game meets some of the functional and non functional requirements established in the requirements definition. Majority of the mechanics desired for the final project have been introduced including the dash and explosive mechanics (plus the features from sprint 1). Elements in UI still lack functionality and will likely not be fixed till sprint 4 due to the actual gameplay being more important than UI. Saving and Loading still hasnt been implemented as no levels exist. In its current state, the program does not meet the projects functional and non functional requirements but does have improved functionality compared to the last sprint

__2)__ Compared to the use cases, the program performs relatively successfully as 6 of the 7 usecases in the main flow are now functional. However, the program still underperforms in the alternate flow usecases. Inputs are correctly detected and processed for all of the users core abilities. The functionality of inputs is still so so in the menus, as multiple elements don't detect or process user inputs correctly. This will likely be remedied in sprint 3. Overall, the current program handles inputs and outputs with improved success compared to sprint 1 but still requires further development, especially in the menus.

__3)__ The quality of my code is satifactory, as it named consistently, lackcommented and is relatively organised. Code has been seperated into different files depending on what they are used for (player movement, camera movement, AiController, explosive and UI) with names that make sense for what they do and the amount of actual code in the main functions (update and fixed update) has been reduced through the use of functions that breakdown the code into more readble and reusable chunks. The new additions in this sprint (the explosive and AiController scripts) lack thorough comments due to being unfinished or not finalised. These will be added next sprint once the entirety of the AIController Script and its classes are built out. For the time being, the codes quality in terms of readability, structure and maintainability is adequite but requires improvements which will be made next sprint.

__4)__ In the next stage of development, comments should be added to code that currently lacks it and AI and player health classes should be introduced to complete more of the functional requirements. UI should be improved to at least a stage that it correctly detects and processes all required inputs even if it is not fully functional and at least one level should be built out. This will take the current 'prototype' and turn it into an actual playable level and improve the size of the project dramatically. By implementing these changes, it can be ensured that more functional and non functional requirements can be met coming out of sprint 3 and going into sprint 4, setting up for the easy introduction of assets that give the game some personality.
good https://learn.unity.com/tutorial/classes-5#

https://excalidraw.com/#json=sGoA7cJHpgVhOvltEKy-E,7eMEukGvekvqzNzFpdYcEA = use case
https://excalidraw.com/#json=zN0EMZ1auaCvxsbXqY2aB,f3NGzKGralf9N8rrP236RQ = story board
https://excalidraw.com/#json=4zMQT8zD0B1HZ4KdXO0hY,6Qrx24upHSLiRYAaXKf17g = level 1 data flow diagram
https://excalidraw.com/#json=w2wetovOaj9oAc9bN4qzF,wXfp6WzOCY-ZiYJQzDhTRw