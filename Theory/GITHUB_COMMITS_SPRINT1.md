# Sprint 1
__Sprint 1's commit comments were not done in Github because half of the projects code was written before we had the assessment task. Looking back at it now, this was stupid and I should have just started doing propper commits once we got the assessment task.__

__Additionally, some very minor commits were combined into other larger ones to improve readability__

## April 15th
Basic player movement was established, the player can move on the x and y axes and a jump has been implemented. The horizontal movement works as intended but the jump is not great. It's a bit buggy (player can doulbe jump) and still needs some improvements to its game feel. (e.g jumpbuffer and adjustments for when the player is falling downwards and presses the jump button). Next lesson, I will make use of custom gravity to improve jump feel, introduce a jump buffer and fix the double jump bug.

## April 25th
issue with double jump was resolved, a jump buffer was introduced, the players jump height is now consistent and gravity now changes depending on what state the player is in. Sometimes gravity gets stuck in the wrong state when the player transitions from jumping to falling. this will need to be resolved. It was also noticed that the player can move faster diagonally than forwards. In the next update, gravity will need fixing, as will the unnormalised vector of player movement.

## May 5th p1
added a gravity default that gravity resets to inbetween states, fixing the issues with gravity not changing, the vector of horizontal movement was normalised, fixing the problem and minor changes to the strength of gravity were made. Next Update I will begin work on a player camera, as the player movement seems finished for now.

## May 5th p2
Began work on a basic player camera which works pretty much as intended. Additionally, the player now rotates to face the same direction has the camera. A slight jitter with the camera was noted. An attempt to remedy this will be introduced next lesson.

## May 7th (fixed camera movement + adadad)
Adjusted Camera code to make it smoother, in an attempt to remedy the weird jittering. This seems to have improved the jitteriness of the camera (He had in fact not fixed the camera jitter). Additionally, I established some varriables for a dash which likely will not be introduced in practicality till sprint 2. Next lesson I will begin work on the UI.

## May 20th
Instead of working on the UI, I actually fixed the camera jitter. It was occuring because the player was being rotated in update to create smoother movement, but had the unintended side effect of bugging out the camera. Next lesson, work on UI will start.

## May 22nd
UI was formatted and basic buttons (without functionality) were introduced. UI looks passable for a first sprint and will improve in later sprints.. Next lesson, I will fininsh the UI.

## May 25th
Project did not push to github correctly and hours worth of progress were lost. This means that I will have to do the UI again and redo some code along with theory to catch up. Next Update I will work on UI.

## May 26th
Formatted UI again and re-added the start and quit functionality to the buttons in the UI. Also added the non-functional dash, throw and explode functions to my player movement which will be implemented in Sprint 2. Next Update I will finish the UI.

## May 28th
Sprint 1 UI has been completed. It lacks some functionality (Saving and loading because levels aren't built yet, Volume and Sensitivity because there is no music in the game, and keybinds which will be added in Sprint 2). Next lesson code will be polished and minor changes will be made before the completion of sprint 1.

## May 29th
Pause button now works as intended (minus UI) and small changed were made to camera script to remove redundancies. Once theory is finished, Sprint 2 will begin. Sprint 2 will likely begin within the introduction of the Dash, throw and explode mechanics followed by enemy AI.

__Further Commits are in GitHub__