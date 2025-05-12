# __MineGame__

## Sprint 1
### __Requirements Definition__
### Functional Requirements
* User can move their character around in 3 dimensional space.
* User can move the camera around the character.
* User can throw an explosive that can be detonated to explode objects, enemies or to propel the character into the air
* User can dash forwards on ground or in the air, giving the player a sudden burst of speed.
* system can simulate basic enemies that can attack the player and that the player can destroy.
* User can navigate through a main menu to start the game, quit the game, adjust settings or save/load a save file.
* User can save their progress in the game and continue the game from that point next time they load the game.
* User can unlock new abilities overtime by collecting objects in the game world.
* User can interact with objects to trigger certain events/cutscenes
* User can enter an arena that triggers a bossfight and prevents the user from running away.
* system automatically saves player progress at certain points in the game. (before boss fights, after beating a level, ect.)

### Non-functional Requirements
* Game must run at a consistent 60 frames per second.
* System should only load the area of the game that the player is in to improve performance.
* System should always return the corresponding output from the users input (e.g player presses w, character moves forward).
* User should be able to customise controls to allow people with disabilities to play the game.
* User should have access to an instruction panel that describes how to play the game.
* System should automatically save, occasionally to prevent loss of save data in the event of a crash.
* User should be able to adjust mouse sensitivity and volume.

### __Determining Specifications__
### Inputs & Outputs
* User can input using WASD. The system will move the player character in 3d space accordingly.
* User can input by moving their mouse. The system will move the player camera accordingly.
* User can use a 'dash' input. The system will send the player forward, increasing the characters speed for a short duration after the dash ends.
* User can use a 'throw explosive' input. The system will spawn in an object from inside the player that shoots upwards at a 45 degree angle before landing on the ground in front of the player
* User can use an 'explode explosive' input. The system will destroy the 'explosive' and any destructable objects around it. Additionally, if any moveable objects (including the player) are in the radius of the explosion, they will be launched on an angle according to their position in relation to the explosive's position
* In the main menu, user can choose to 'start', go to 'settings', 'load', 'quit'. The system will then trigger the scene that corresponds to that input.
* In settings, user can use sliders to adjust volume of music or SFX and can change the key that corresponds to each input. The system will take these inputs and adjust the game accordingly.
* system can use a 'pause' input. This freezes the game world and brings up a pause menu where users can 'save', go to settings or 'quit'.
* On saving, the system creates a json file or uses playerprefs to save the users progress in the game.
* On loading, the system brings the user to a screen which shows their previous saves. They can select the one they want to play and the corresponding scene will be triggered.
* On quiting, the system automatically saves player progress just incase, before shutting the game.

### Core features
__System needs to simulate a game world that:__
* allows the user to move in 3d space, walking, dashing and jumping.
* allows the user to throw an explosive which can destroy certain objects in the world.
* simulates enemies with basic ai that can be destroyed by the player and can deal damage to the player
* allows the user to start the game by clicking the buttons.
* allows the user to adjust settings by using sliders and buttons.
* allows the user to save and load their progress.
* allows the user to quit the program.

### User Interaction
* User will interact with the system during gameplay by using keyboard and mouse inputs.
* User will interact with the system while in menus by using their mouse to click buttons.

### Error Handling


good https://learn.unity.com/tutorial/classes-5#