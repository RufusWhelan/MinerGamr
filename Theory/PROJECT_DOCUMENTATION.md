# __MinerGame__

## __Sprint 1__
## Requirements Definition
### __Functional Requirements__
* User can move their character around in 3 dimensional space.
* User can move the camera around the character.
* User can throw an explosive that can be detonated to explode objects, enemies or to propel the character into the air.
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
* Game should incorporate assets to allow the player to feel immersed in the world of the game and to improve the clarity of gameplay.

## Determining Specifications
### __Functional Specifications__
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

### Actor
* User (Gamer) 
### Preconditions
* access to hardware capable of running the game

### Main Flow
* __Movement:__ User moves. System changes the players position on the horizontal axes accordingly, abiding by collisions, with continous force.
* __Jumping:__ User jumps. System sends the player upwards, abiding by collisions, with insantaneous force.
* __Dashing:__ User dashes. System sends the player forwards horizontally, abiding by collisions, with instantaneos force
* __Throwing:__ User throws explosive. System spawns the object then lauches forwards on a 45 degree angle relative to the players position. If it hits an entity, the system destroys the explosive and the colliding entity.
* __Exploding:__ User explodes explosive. System destroys the object and any entities within range. If the player is in range of the explosive, they get launched away from the exlplosive.
* __Looking:__ User moves their mouse. system moves the player camera around the player accordingly.
* __Pausing:__ Uses pauses. system freezes game logic to the nearest physics frame, displaying UI to switch to other scenes.

### Postconditions(Main)
* Player is moved horizontally and vertically. 
* Explosives are spawned and exploded (moving and destroying entities accordingly).
* The camera is moved around the player.

### Alternate Flows (Menus)
__Main Menu__
* __Start:__ User starts game. System transitions to the first gameplay scene.
* __Options:__ User goes to Options. System transitions the Options scene.
* __Loading:__ User selects 'load game'. System transitions to the savefile screen, displaying previous save files. User selects a save file. System loads corresponding game state and scene.
* __Quit:__ User quits. System saves the current progress and then exits the game.

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
![UseCaseDiagram](/Theory/images/UseCaseDiagram.png "UseCaseDiagram")
## Design

### Storyboard
![UIStoryboards](/Theory/images/UIStoryboards.png "storyboards")
### Dataflow diagrams
![DataflowDiagram0](/Theory/images/Level0DataflowDiagram.png "Level0DataflowDiagram")
![DataflowDiagram1](/Theory/images/Level1DataflowDiagram.png "Level1DataflowDiagram")
### Gantt Chart
![Ganttchart](/Theory/images/Ganttchart.png "Ganttchart")

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
### StructureChart
![structureChartSprint1](/Theory/images/structureChartSprint1.png "structureChartSprint1")
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
![FlowChart0](/Theory/images/Flowchart0.png "FlowChart0")
![FlowChart1](/Theory/images/Flowchart0.png "FlowChart1")
![FlowChart2](/Theory/images/Flowchart0.png "FlowChart2")
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

## End of Sprint Review Questions
__1)__ In its current state, the game meets some of the functional and non functional requirements established in the requirements definition. Majority of the mechanics desired for the final project have been introduced including the dash and explosive mechanics (plus the features from sprint 1). Elements in UI still lack functionality and will likely not be fixed till sprint 4 due to the actual gameplay being more important than UI. Saving and Loading still hasnt been implemented as no levels exist. In its current state, the program does not meet the projects functional and non functional requirements but does have improved functionality compared to the last sprint.

__2)__ Compared to the use cases, the program performs relatively successfully as 6 of the 7 usecases in the main flow are now functional and inputs are correctly detected and processed for all of the users core abilities. However, the program still underperforms in the alternate flow usecases. The functionality of inputs is still so so in the menus, as multiple elements don't detect or process user inputs correctly. This will likely be remedied in sprint 3. Overall, the current program handles inputs and outputs with improved success compared to sprint 1 but still requires further development, especially in the menus.

__3)__ The quality of my code is satifactory, as it named consistently, lackcommented and is relatively organised. Code has been seperated into different files depending on what they are used for (player movement, camera movement, AiController, explosive and UI) with names that make sense for what they do and the amount of actual code in the main functions (update and fixed update) has been reduced through the use of functions that breakdown the code into more readble and reusable chunks. The new additions in this sprint (the explosive and AiController scripts) lack thorough comments due to being unfinished or not finalised. These will be added next sprint once the entirety of the AIController Script and its classes are built out. For the time being, the codes quality in terms of readability, structure and maintainability is adequite but requires improvements which will be made next sprint.

__4)__ In the next stage of development, comments should be added to code that currently lacks it and AI and player health classes should be introduced to complete more of the functional requirements. UI should be improved to at least a stage that it correctly detects and processes all required inputs even if it is not fully functional and at least one level should be built out. This will take the current 'prototype' and turn it into an actual playable level and improve the size of the project dramatically. By implementing these changes, it can be ensured that more functional and non functional requirements can be met coming out of sprint 3 and going into sprint 4, setting up for the easy introduction of assets that give the game some personality.
good https://learn.unity.com/tutorial/classes-5#

https://excalidraw.com/#json=sGoA7cJHpgVhOvltEKy-E,7eMEukGvekvqzNzFpdYcEA = use case
https://excalidraw.com/#json=zN0EMZ1auaCvxsbXqY2aB,f3NGzKGralf9N8rrP236RQ = story board
https://excalidraw.com/#json=4zMQT8zD0B1HZ4KdXO0hY,6Qrx24upHSLiRYAaXKf17g = level 1 data flow diagram
https://excalidraw.com/#json=It77Z2lMEcaz3L6I0fdrN,WfCtmLXwjxi2DjCIzlN3wQ

## __Sprint 3__
## Design
### Class Diagram
![ClassDiagram](/Theory/images/UMLClass.png "ClassDiagram")
## Build
```
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AiControllerScript : MonoBehaviour
{
    [SerializeField] private bool melee; // used to toggle between melee and ranged enemy
    [SerializeField] private NavMeshAgent navAgent;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Rigidbody aiBody;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private float patrolRange = 10f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float viewRange = 15f;
    [SerializeField] private float attackRange;
    [SerializeField] private float knockbackForce = 10f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletForce;

    public Ai enemy; // the current instance of either melee or ranged AI

    private void Awake()
    {
        playerTarget = GameObject.Find("Player").transform; // grabs the player’s transform in the scene
        navAgent = GetComponent<NavMeshAgent>(); // gets reference to AI nav component

        // decides which type of AI to spawn
        if (melee == true)
            enemy = new MeleeEnemy(navAgent, playerTarget, aiBody, transform, groundLayer, targetLayer, patrolRange, attackCooldown, viewRange, attackRange, knockbackForce, () => StartCoroutine(ResetAttackCooldown(attackCooldown)));

        if (melee == false)
            enemy = new RangedEnemy(navAgent, playerTarget, aiBody, transform, groundLayer, targetLayer, patrolRange, attackCooldown, viewRange, attackRange, bullet, bulletForce, () => StartCoroutine(ResetAttackCooldown(attackCooldown)));
    }

    private void FixedUpdate()
    {
        enemy.Tick(); // calls AI logic every physics update
    }

    public void triggerDeath()
    {
        StartCoroutine(enemy.Die()); // starts death coroutine
    }

    private IEnumerator ResetAttackCooldown(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.ResetAttack(); // resets attack state
    }
}

[System.Serializable]
public class Ai
{
    // common AI properties for all enemies
    protected readonly NavMeshAgent agent;
    protected readonly Transform player;
    protected Rigidbody rigidbody;
    protected Transform self;
    protected LayerMask groundMask;
    protected LayerMask playerMask;
    protected float patrolRadius;
    protected float attackDelay;
    protected float visionRange;
    protected float hitRange;

    protected Vector3 patrolTarget;
    protected bool hasPatrolTarget;
    protected bool hasAttacked;
    protected bool canSeePlayer;
    protected bool canHitPlayer;

    protected System.Action onAttackReset; // action to reset attack after delay

    public Ai(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, System.Action onAttackReset)
    {
        this.agent = agent;
        this.player = player;
        this.rigidbody = rigidbody;
        this.self = self;
        this.groundMask = groundMask;
        this.playerMask = playerMask;
        this.patrolRadius = patrolRadius;
        this.attackDelay = attackDelay;
        this.visionRange = visionRange;
        this.hitRange = hitRange;
        this.onAttackReset = onAttackReset;
    }

    public void Tick()
    {
        /*
        Swtches between the AI's states and checks if it can see anything everyframe

        'Returns'
        AI state
        */
        if (agent == null || !agent.isOnNavMesh || !agent.enabled)
            return; //if the pathfinder for the enemy does not exist or is diabled, return.

        canSeePlayer = Physics.CheckSphere(self.position, visionRange, playerMask);
        canHitPlayer = Physics.CheckSphere(self.position, hitRange, playerMask);
        // checks if enemy can see or hit the player

        // decision tree
        if (!canSeePlayer && !canHitPlayer) Patrol(); // if player not in sight patrol
        else if (canSeePlayer && !canHitPlayer) Chase(); // if player seen but out of range chase
        else if (canSeePlayer && canHitPlayer) Attack(); // if player seen and in range attack
    }

    private void Patrol()
    {
        /*
        moves the AI between two points

        Returns:
            Vector3: enemy position

        */
        if (!hasPatrolTarget) PickNewPatrolPoint(); //if no patrol points, make some

        if (hasPatrolTarget)
            agent.SetDestination(patrolTarget); //if a patrol point exists, the agent patrols

        if (Vector3.Distance(self.position, patrolTarget) < 1f)
            hasPatrolTarget = false; // if the player is too far away from their patrol points, create a new one
    }

    private void PickNewPatrolPoint()
    {
        /*
        creates a new patrol path for the AI to travel on

        'Returns':
            Vector3: point that the AI will patrol
        */
        float randX = Random.Range(-patrolRadius, patrolRadius);
        float randZ = Random.Range(-patrolRadius, patrolRadius);
        Vector3 point = new Vector3(self.position.x + randX, self.position.y, self.position.z + randZ);
        // creates a random point in range around the enemy

        if (Physics.Raycast(point, -Vector3.up, 2f, groundMask)) // checks that the point is on the ground
        {
            patrolTarget = point;
            hasPatrolTarget = true;
        }
    }

    private void Chase()
    /*
    AI moves towards player position

    Returns:
            Vector3: enemy position
    */
    {
        agent.SetDestination(player.position); // move towards player
    }

    protected virtual void Attack()
    {
        /* 
        AI attacks
        Returns:
            float: players health
        */
    } // overriden by subclasses
    public virtual void ResetAttack()
    {
        /* 
        Resets AI attacks
        Returns:
            bool: if the player has attacked
        */
    } // overriden by subclasses

    public IEnumerator Die()
    {
        if (agent != null)
            Object.Destroy(agent); // disable pathfinding on death

        yield return new WaitForSeconds(0.7f); // short delay for death animation/sound
        Object.Destroy(self.gameObject); // remove from scene
    }
}

public class MeleeEnemy : Ai
{
    private float recoilForce;

    public MeleeEnemy(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, float recoilForce, System.Action onAttackReset) : base(agent, player, rigidbody, self, groundMask, playerMask, patrolRadius, attackDelay, visionRange, hitRange, onAttackReset)
    {
        this.recoilForce = recoilForce;
    }

    protected override void Attack()
    {
        self.LookAt(player); // face player before attacking

        if (!hasAttacked)
        {
            hasAttacked = true;

            var healthController = player.GetComponent<playerHealthController>();
            if (healthController != null && healthController.player.isAlive)
            {
                agent.enabled = false; // stop AI movement
                rigidbody.isKinematic = false;
                rigidbody.AddForce(-self.forward * recoilForce, ForceMode.Impulse); // apply recoil
                healthController.player.takeDamage();
                healthController.player.playerDeath(); // check if the player is dead
            }

            onAttackReset?.Invoke(); // schedule reset
        }
    }

    public override void ResetAttack()
    {
        hasAttacked = false;
        rigidbody.linearVelocity = Vector3.zero; // cancel momentum
        agent.enabled = true;
    }
}

public class RangedEnemy : Ai
{
    private GameObject projectile;
    private float projectileForce;

    public RangedEnemy(NavMeshAgent agent, Transform player, Rigidbody rigidbody, Transform self, LayerMask groundMask, LayerMask playerMask, float patrolRadius, float attackDelay, float visionRange, float hitRange, GameObject projectile, float projectileForce, System.Action onAttackReset) : base(agent, player, rigidbody, self, groundMask, playerMask, patrolRadius, attackDelay, visionRange, hitRange, onAttackReset)
    {
        this.projectile = projectile;
        this.projectileForce = projectileForce;
    }

    protected override void Attack()
    {
        /*
        AI attacks
        Returns:
            gameObject: projectile that is being fired at the player
        */
        agent.SetDestination(agent.transform.position); // stop moving during attack
        self.LookAt(player); // face player

        if (!hasAttacked)
        {
            hasAttacked = true;

            Vector3 spawnPos = self.position + self.forward * 1f;
            Vector3 direction = (player.position - spawnPos).normalized;
            direction += Vector3.up * 0.05f; // add slight upward arc
            direction.Normalize();

            GameObject newBullet = GameObject.Instantiate(projectile, spawnPos, Quaternion.LookRotation(direction));
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();

            rb.AddForce(direction * projectileForce, ForceMode.Impulse); // fire projectile

            onAttackReset?.Invoke(); // reset after cooldown
        }
    }

    public override void ResetAttack()
    {
        hasAttacked = false;
    }
}

using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime); // destroys the projectile after a short delay
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        Checks if the projectile hit the player, and applies damage if it did.
        Args:
            collision (collision): the collider of what the projectile hit

        'Returns':
`             a destroyed projectile
        */
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<playerHealthController>();
            if (healthController != null && healthController.player.isAlive)
            {
                healthController.player.takeDamage();
                healthController.player.playerDeath();
            } //on collision with player, deal damage to the player then check if they are dead.
        }

        Destroy(gameObject); // Destroy projectile after any collision
    }
}

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

using UnityEngine;

public class explosive : MonoBehaviour
{
    public playerData Data { get; set; }
    private bool explodable;
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
        {
            Data.explosionInput = false;
            if (explodable)
                Explode();
            // if the explosive can explode, explode it.
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        Checks if the explosive hit the player, an enemy or the ground.
        Args:
            collision (collision): the collider of what the projectile hit

        'Returns':
`              none
        */

        if (collision.gameObject.CompareTag("Player"))
            playerExplode(); // trigger a special kind of explosion if the explosive collides with player

        else if (collision.gameObject.CompareTag("Enemy"))
            Explode(); // trigger normal explosion

        else if (collision.gameObject.CompareTag("Ground"))
        {
            explodable = true;
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
                rb.constraints = RigidbodyConstraints.FreezeAll;
            Data.cantThrow = false;
        } //if the explosive hits the ground, it can now explode and is frozen in position

        else
            explodable = false;
    }
    private void Explode()
    {
        /*
        If the explosive collides with a collider, checks what kind of collider it is and if it is a player or enemy send it away from the explosive. If its an enemy, kill it

        'Returns':
            Vector3: updated playerposition
            enemy death
        */
        Data.cantThrow = false;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //search through nearby colliders
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0)
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0)
                    force = force * 0.2f;
                //modify the force applied if the object is travelly up or down

                rb.AddExplosionForce(force, transform.position, explosionRadius); //apply force to nearby colliders
                rb.AddForce(Vector3.up * 12f, ForceMode.VelocityChange); // send the collided objects up a little bit

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath(); //calls a method of the ai class
                } //if the explosion hits an enemy, destroy it.
            }
        }
        Destroy(gameObject);
    }

    private void playerExplode()
    {
        /* 
        If the explosive collides with a collider, checks what kind of collider it is and if it is a player send them forwards on an angle. If its an enemy, destroy it.
        'Returns':
            Vector3: updated playerposition
            enemy death
        */
        Data.cantThrow = false; // allow throwing again since explosion happened
        Rigidbody myRb = GetComponent<Rigidbody>();
        if (myRb != null)
        {
            Destroy(myRb); // remove rigidbody so explosive doesn’t collide with the player and change the launch direction
            GetComponent<Collider>().enabled = false; // disable collider so no more collisions
        }


        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius); //search through nearby colliders
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null && !rb.gameObject.CompareTag("Player"))
            {
                float force = explosionForce;
                if (rb.linearVelocity.y < 0) 
                    force -= rb.linearVelocity.y;
                if (rb.linearVelocity.y > 0)
                    force = force * 0.7f;
                     //modify the force applied if the object is travelly up or down

                
                rb.AddExplosionForce(force, transform.position, explosionRadius); // apply force to nearby colliders
                rb.AddForce(Vector3.up * 12f, ForceMode.VelocityChange); // send the collided objects up a little bit

                if (rb.gameObject.CompareTag("Enemy"))
                {
                    var enemy = rb.GetComponent<AiControllerScript>();
                    enemy.triggerDeath(); //calls a method of the ai class
                } //if the explosion hits an enemy, destroy it.
            }
            if (rb != null && rb.gameObject.CompareTag("Player"))
            {
                float angleRad = Mathf.Deg2Rad * launchAngle;

                Vector3 flatForward = rb.transform.forward;
                flatForward.y = 0f;
                flatForward.Normalize();

                float yComponent = Mathf.Sin(angleRad);
                float horizontalComponent = Mathf.Cos(angleRad);
                Vector3 launchDirection = (flatForward * horizontalComponent + Vector3.up * yComponent).normalized;
                //uses pythagoras theorem to determine the to send the player forwards at 

                float finalPower = launchPower;
                if (Data.isDashing)
                    finalPower *= 0.8f; // reduce force if player is dashing

                rb.AddForce(launchDirection * finalPower, ForceMode.VelocityChange); // launch player forward at angle
            }
        }
        Destroy(gameObject); // remove explosive after explosion
    }

}


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
    public GameObject explosivePrefab;
    public float throwForce;
    public bool cantThrow = false;
    public Transform throwPosition;
    [HideInInspector] public Vector3 throwDirection = new Vector3(0, 1, 0);
    [HideInInspector] public bool throwInput;
    [HideInInspector] public bool explosiveEntity;
    [HideInInspector] public bool explosionInput;
    [HideInInspector] public float numberOfExplosives;
    [HideInInspector] public float maximumNumberOfExplosives;

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

using UnityEngine;

public class playerHealthController : MonoBehaviour
{
    public PlayerHealth player { get; private set; } = new PlayerHealth(3, true); // creates a player health instance that can be shared and accessed easily
}

[System.Serializable]
public class PlayerHealth
{
    [SerializeField] private float health;
    [SerializeField] public bool isAlive;

    public PlayerHealth(float hp, bool alive)
    {
        health = hp;
        isAlive = alive;
    }

    public void takeDamage()
    {
        /*
        Reduces the players health by one

        'Returns':
            float: players current health
        */
        health -= 1f; // subtracts 1 health when hit
    }

    public void playerDeath()
    {
        /*
            Checks if the player is alive and freezes time if they are not

            'Returns':
            bool : if the player is alive
        */
        if (health <= 0)
        {
            isAlive = false; // mark player as dead
            Debug.Log("Player Died");
            Time.timeScale = 0f; // freeze game on death
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void gameStart()
    {
        /*
            Moves the player to the new scene

            'Returns':
            the next scene
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads the next scene
    }


    public void gameQuit()
    {
        /*
            Closes the application

            'Returns':
            closed game
        */
        Debug.Log("quit");
        Application.Quit(); //closes the application
    }
}

```

## End of Sprint Review Questions
__1)__ In it's current state, the project reaches most of its functional requirements and some of its non functional requirements. All mechanics have been implemented and improved upon compared to prior sprints, which has created fun and engaging gameplay. Additionally, 2 AI variants have been introduced which have melee and ranged attacks that can deal damage to the player, as mentioned in the functional requirements. The multiple variants of AI exceeds the original expectations of AI in the game and is thus very functional. As in prior Sprints, the UI still lacks a lot of functionality and likely will not get full functionality as the game never reached a scope at which saving and loading progress would make sense as a feature. overall the program meets the functional requirements of the project with relative success, but is lack luster in terms of non functional requirements.

__2)__ As with last sprint, the program performs relatively successfully in terms of usecases as 6 of the 7 identified usecases in the main flow are now functional and are improved in terms of useability and fluidity compared to sprint 2. Inputs are correctly detected and processed for all of the users core abilities and now yield satifying outputs and fluid movement which makes for an engaging user experience. However, the program still underperforms in the alternate flow usecases as the menus still lack several functionalities and don't create outputs for the corresponding inputs (many of them are placeholders). Overall, the program handles inputs and outputs in the mainflow with great success, but is lackluster in terms of processing inputs in menus.

__3)__ By implementing classes, the quality of my code has drastically improved as it is more readable, well structured and maintained. The AI and player Health scripts were written using classes, taking advantage of inheritance to reduce repeating code and to allow more complex functionality in terms of attacks from AI without drastically increasing the size of the program. The classes keep things clear and concise, and the use of encapsulation protects date. Furthermore, with this sprint thorough commenting and Docstrings were added which improves how easy to understand my program is as a whole. Therefore, the codes quality in terms of readability, structure and maintainability is high.

__4)__ In the next stage of development, the overall looks of the game will be improved by implementing textures and models for the character and the surrroundings. UI may be improved if time permits, but the priority is building out a fully playable level that uses the systems and mechanics that have been built in the prior 3 sprints, along with the implementation of assets to take the project from its current state to a final product that has provides the player with some level of enjoyment with high functionality in the main flow. Once this has been accomplished, UI will be improved in terms of functionality buit will still likely lack some features on hand in.

## __Sprint 4__
## Design
N/A (they are up to date)

## Build (Same as last sprint + these scripts)
``` 
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void gameStart()
    {

        /*
            Moves the player to the new scene

            'Returns':
            the next scene
        */
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // loads the next scene
    }

    public void respawn()
    {
        /*
            Moves the player to the prototype scene

            'Returns':
            the next scene
        */
        SceneManager.LoadScene(1); // loads the game scene
    }
    


    public void gameQuit()
    {
        /*
            Closes the application

            'Returns':
            closed game
        */
        Debug.Log("quit");
        Application.Quit(); //closes the application
    }
}

using UnityEngine;

public class endPoint : MonoBehaviour
{
    public GameObject player;
    public UIController UIController; //Inisialises a script from a different gameobject
    private void OnCollisionEnter(Collision other) //Checks collisions it has with other objects
    {
        /*
            On collision with player, trigger the end screen

            'Returns':
            the end scene
        */
        if (other.gameObject.CompareTag("Player"))
            UIController.gameStart();
            //if the tag of a game object is "Player" use the method gameStart() from gameOverScreenScript.
    }
}

```

## Review

## End of Sprint Review Questions
__1)__ as stated in final breakdown

__2)__ In terms of usecases, my project has remaining within a similar range of success in both main flow and alternate flow usecases. The program continues to accomplish almost all of the main flow usecases but only a couple of the alternate flow ones.

__3)__ The quality of my code is the same as it was last sprint as very minor changes were made to code. The changes that were made recieved docstrings and comments. Therefore, the codes quality in terms of readability, structure and maintainability is still high as not much has changed in terms of code.

__4)__ As stated in full breakdown

## Full Breakdown of Evaluation Requirements
__1)__ The system could be improved in future updates by implementing the remaining UI functionalities, custom assets, more AI classes for greater enemy variety, by introducing level progression and a boss battle of some sort. The scope of the game was too large for the amount of time we had to work on the project which means that the ‘game’ feels more like a level rather than a finished product because I chose to focus on adding mechanics and functionality that would add to the gameplay experience rather than tons of unpolished content or non essential menus or assets. Now that that relatively polished gameplay exists, the addition of fully functional UI, custom assets that feel like they are part of the same world and more content (more levels and boss fights) would increase the games scope and allow for greater player freedom.

__The implication of these changes:__
UI: The implementation of fully functional UI would not negatively affect the system in any way and would not drastically increase the size of the game either which means that its implementation would not meaningfully impact the performance or size of the game. The clarity of information available to the player would also be improved (it is unclear how much hp you have as it is not displayed to the player.)

Custom Assets: Currently all of the games assets are royalty free assets found in the Unity asset store or on sites online like itch. Adding assets with a consistent artstyle would enhance the world building and make the game feel more complete at the cost of being low poly because I’m not a 3D modeller.

AI: adding more AI subclasses would allow for further enemy variety and more complexity in level design (e.g flying enemies that you can bounce off in the air to travel over gaps or an enemy that mimics player inputs and chases them down), boosting the skill ceiling and making the gameplay always feel fresh. This may have slight negative effects on performance.

Levels / level progression: Adding more levels would simply add more content and playgrounds for the player to mess around in, increasing the amount of replayability and enjoyable moments in the game without much of a downside.
 
Boss Battle: A boss battle/s would add a climactic end to the game, make for more interesting gameplay and make the player feel like they have really accomplished something at the end of the game with little downside.

__2)__ Overall, the final product is very successful in terms of functional requirements (7 of 8) but is only satisfactory in terms of non functional requirements (4 of 8). The system performs all but one of the functional requirements with great success. The 8th functional requirement is not met as the scale of the project never reached a point where saving and loading would be necessary, which is unfortunate. 1 of the non functional requirements were not introduced due to time pressures (keybinds), 1 was not introduced because it made more sense to explain the keybinds to the player through gameplay and the final non functional requirement (automatic saving) was not introduced because as stated previously, saving and loading never became a necessary feature. Overall, the final project is moderately successful

__3)__ In terms of project management, this Assessment Task was quite poor. Due to TAS to TAS, I was already a week behind where my project should have been according to my gantt chart by the time I finished Sprint 1 and the scale of this Unity project was larger than I expected (anytime I would finish something and prepare to move on I would realise that another feature was necessary). This drastically increased the amount of time necessary to complete each sprint and led to much longer chunks of development towards the end of the project.



 
__4)__
__Ario evaluation__

+’s: The game had very fun mechanics that were fun to use and provided a good user experience. The enemy was fun to fight against and had a very good learning curve. I wish there was a tutorial so that i would know what to do sooner but the games basic mechanics were very fun.
-’s: It was confusing to see when the ball exploded a particle system would make me very happy
I’s: Using the unique mechanics to build a boss fight.



__Maksim evaluation__

+’s: The movement in the game is very fun and understandable and the mechanics are joyous to explore. The idea for the enemies is very good and they gave me a good challenge. The requirements and specifications were very clearly followed and outlined in his project documentation.
-’s: When a ball explodes, it’s pretty hard to tell, as Ario said a particle system would be useful, the appearance of the enemies could also be better.
I's: Overall just playing the game is fun and it's very fun to run around and throw projectiles.

Ario said that he wanted a tutorial implemented to teach the player how the game works before throwing them into the gameplay, which would be a good idea to implement in a the finished game. Something brought up by both Ario and Maksim was that the clarity in projectile explosion was not clear. This is a fair criticism and in a future update I would use the unity particle system to introduce an explosion effect so that the player can more clearly tell what is going on when an explosive goes off.

__5)__ There are two types of classes used throughout this project, monobehaviour (a unity specific parent class) which allows for the scripts to communicate with unity and standard classes. The monobehaviour scripts aren’t exactly like normal classes as instances of them are not created in code, but rules regarding encapsulation still apply (all variables that don’t need to be accessed in other scripts were labelled as private). Methods were used throughout these monobehaviour scripts such as addforce or get component inherited from unities monobehaviour parent class. These scripts behave more similarly to normal scripting then actual classes in most regards I will thus not be going into a deep analysis of them. Normal classes were implemented throughout this project to build a range of components whilst keeping code efficient, organised and reusable. The use of classes allowed for the easy introduction of the enemies and the players health/death mechanics due to the reusability and structure of classes. 
Using classes allowed for multiple different instances of an enemy and streamlined the process of creating its subroutines. The AI class is responsible for the enemy AI logic and is the source of any real challenge in the game, the patrol and Chase methods are used to establish how the enemy AI should behave when not attacking the enemy. These voids are private to ensure encapsulation and because they are not used in any other class. The abstract methods attack and resetAttack() allow for children classes that behave differently in the way that they attack. This system is modular and means that if I ever wanted to introduce more AI classes, it would be as simple as overriding these abstract methods in the new child classes. All of the attributes in this class are protected because only need to be accessed by the children classes and nothing else, improving data integrity. 
The Melee enemy class is responsible for the melee enemy ai behaviour and allows them for enemies that deal damage close range. The new attribute ‘recoil force’ is necessary as it makes the enemy attacks feel like they have impact without animation.
The Ranged enemy class is responsible for the ranged ai behaviour and allows enemies to span a projectile into the game world and fire it at the player which makes combat more dynamic and creates more complexity in gameplay. The two new class specific attributes are responsible for how far the enemies bullet travels and for getting the prefab that will be used as the spawned explosive. The public class playerHealth is responsible for controlling how the player takes damage from the enemies and for the player's death. It is through the calling of the playerHealth class’s methods that the enemies are able to deal damage to the player.
Therefore, I believe that classes were justifiable in their use in this assessment and that they were implemented in a way that contributed to the project's success.
