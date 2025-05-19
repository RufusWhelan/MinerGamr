# __MinerGame__

## __sprint 1__
## Requirements Definition
### __Functional Requirements__
* User can move their character around in 3 dimensional space.
* User can move the camera around the character.
* User can throw an explosive that can be detonated to explode objects, enemies or to propel the character into the air
* User can dash forwards on ground or in the air, giving the player a sudden burst of speed.
* system can simulate basic enemies that can attack the player and that the player can destroy.
* User can die if their hp reaches zero.
* User can navigate through a main menu to start the game, quit the game, adjust settings or save/load a save file.
* User can save their progress in the game and continue the game from that point next time they load the game.
* User can unlock new abilities overtime by collecting objects in the game world. (If time, this drastically increases the scope of the project.)
* User can interact with objects to trigger certain events/cutscenes
* User can enter an arena that triggers a bossfight and prevents the user from running away. (If time, increases the scope of the project somewhat.)
* system automatically saves player progress at certain points in the game. (before boss fights, after beating a level, ect.)

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
* User can choose to 'start', go to 'settings', 'load', 'quit'. The system will then trigger the scene that corresponds to that input whilst in the main menu.
* User can use sliders to adjust volume of music or SFX and can change the key that corresponds to each input, whilst in settings. The system will take these inputs and adjust the game accordingly.
* User can use a 'pause' input. This freezes the game world and brings up a pause menu where users can 'save', go to settings or 'quit'.
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
* Allows the user to adjust settings by using sliders and buttons.
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
* An error that could occur is that the player falls through the map, missing the death plane and is essentially stuck.
* Another potential error that could occur is that the player skips around a collision check and skips a cutscene. This could result in sequence breaking and should return an error message in the event of it becoming problematic.

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
* __Settings:__ User goes to settings. System transitions the settings scene.
* __Loading:__ User selects 'load game'. System transitions to the savefile scene, displaying previous save files. User selects a save file. System loads corresponding game state and scene.
* __Quit:__ User quits. System saves the current progress and then exits the game.


__Settings Menu__
* __Adjustiing Volume:__ User drags volume sliders (Music/SFX). System updates volume of music and SFX values.
* __Keybinding:__ User selects a keybind. System waits for new input, records the chosen key, and assigns it to the corresponding action, ensuring no duplicates before saving.
* __Sensitivity:__ User adjusts mouse sensitivity. System stores sensitivity value and updates input detection accordingly.

__Pause Menu__
* __Saving:__ User saves. system generates or updates a save file with current player progress using JSON or PlayerPrefs.
* __Settings:__ User goes to settings. system triggers settings scene.
* __Quit:__ User quits. System saves the current progress and then exits the game.

### Postconditions(Alts)
* Scenes are transitioned to accordingly. 
* Player preferences are changed and updates. 
* Savefiles are created, updated and loaded. 
* Progress is saved and system is terminated.



good https://learn.unity.com/tutorial/classes-5#

Questions to ask sir:
Is my User Interaction, error handling and non-functional specifications ok?
Inputs and outputs vs mainflow / is my main flow right?
Is it ok for me to have alternate FLOWS and then specify which one it is underneath
do I only need the diagram for my main flow?

https://excalidraw.com/#json=sGoA7cJHpgVhOvltEKy-E,7eMEukGvekvqzNzFpdYcEA = use case
https://excalidraw.com/#json=zN0EMZ1auaCvxsbXqY2aB,f3NGzKGralf9N8rrP236RQ = story board
https://excalidraw.com/#json=4zMQT8zD0B1HZ4KdXO0hY,6Qrx24upHSLiRYAaXKf17g = level 1 data flow diagram
Do Gantt Chart