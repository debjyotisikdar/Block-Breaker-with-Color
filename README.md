# Block Breaker WITH COLOR
#### Video Demo:  <URL HERE>
## Description:
A short remake of Atari's "Breakout" in Unity2D, but with increased difficulty and elements of "bubble shooters". The game is built is written entirely in C# on      Unity2D (manifestly uses NVIDIA PhysX). Each level (6 in total) contains destructible balls of different colors. Accordingly, the player will be provided with multiple sprites or balls of matching colors to destroy all the balls.

### Design and Controls
  
###### Design
Each level in the game contains a ball, a paddle, destructible balls (of different colors, a.k.a "HitBall"), a GameSession object (which stores information like score and level index which has to be preserved till the end of a game session), a Level object (which retrieves "level-specific" information from GameSession and uses it within a level), among other minor elements. The game is in 4:3 aspect ratio (with 2048 x 1536 being the default resolution). The GameSession object carries the total score, current level score, level number (for the level text in the game), and the conventional level index (for loading scenes during a "Retry"), all int variables. Some levels have background music.
  
The main menu contains buttons, a MainMenu object which contains respective methods for each button, and a music player object for playing main menu music until the MainMenu object inverts a boolean value to destroy the music player object before starting the actual game, thus stopping the music. A similar object is also present in Preferences for the functioning of the different buttons. I have used a simple Quality Slider than mentioning specific resolutions to reduce complications. This kind of object is also present the Game Over scene which retrieves player stats from the the GameSession level (which will continue to exist due to ```Object.DontDestroyOnLoad(Object target)``` method for a singleton script added in it) and displays it on the screen, and for the Game Complete/Completed scene.

###### Ball Sprites (PlayBall, HitBall, and SpecialHitBall)
The ball contains an array of sprites (of different colored balls), and another array of strings which contain the names of the colors in proper order. It has an spriteIndex variable of type int which retrieves sprites from the sprites array serially, applies that sprite to the SpriteRenderer component, accordingly uses the spriteIndex to update the current sprite color name from the colors array, until it reaches the end when it loads the Game Over session (preserving the GameSession object to provide the player stats and store the last level index in case the player wants to and can retry). Similarly, the HitBalls contain a field mentioning their color. When the player Ball or playBall collides with a HitBall, it checks whether the strings containing the current colors match. If true, the HitBall destroys itself and the score is incremented within GameSession, otherwise the ball bounces off. In the final level, there is a SpecialHitBall object which changes its color periodically using a Coroutine method. The ball must collide with the SpecialHitBall at the correct time such that the color of the PlayBall matches with that of the SpecialHitBall.
  
###### Walls
The game has 4 blank GameObjects which contains a Box Collider 2D for collision. The bottom wall or LoseWall has an ```OnCollisionEnter2D(Collision2D collision)``` trigger method which calls the PlayBall to either use the next sprite and accordingly update the Next Sprite canvas element to inform the player of the upcoming ball color, or to load Game Over. GameSession contains a boolean variable "retried", which makes sure that Player can replay each level only once.

###### Controls
- Formerly, the paddle would follow the X-axis position of the mouse for navigation, but due to platform issues it uses directional keys and/or A and D keys for navigation.
- Use the Space key to launch each Player Ball or PlayBall.
- Press Escape as instructed to return to the main menu (this will destroy the GameSession object, getting rid of the player scores and progresses).

### C# Scripts
###### The following is a list of all the C# scripts located in the /Assets/Scripts folder, along with a short description of their basic purpose.
- **```Ball.cs```** - Script containing driver class ```Ball``` which extends ```MonoBehaviour```. Contains script for the Player Ball (called PlayBall in the Sprites).
- **```GameComplete.cs```** - Script containing driver class ```GameComplete``` which extends ```MonoBehaviour```. Just contains an ```Exit()``` function to return to the Main Menu.
- **```GameOver.cs```** - Script containing driver class ```GameOver``` which extends ```MonoBehaviour```. Contains elementary methods for the different canvas elements in Game Over scene.
- **```GameSession.cs```** - Script containing driver class ```GameSession``` which extends ```MonoBehaviour```. Contains current level score, total session score, current level number for displaying the current level scene index for loading scene in the future (if needed). Also controls game speed.
- **```HelpMenu.cs```** - Script containing driver class ```HelpMenu``` which extends ```MonoBehaviour```. Only detects Return key press to start the first level. This scene is opened when the Start Game button is pressed from the main menu. It shows the basic controls and the pairs of PlayBalls and HitBalls. Added to a simple ```GameObject``` for the Help scene.
- **```HitBall.cs```** - Script containing driver class ```HitBall``` which extends ```MonoBehaviour```. Contains the color of the HitBall. Deals with collision by itself, calls ```updateScore()``` from ```GameSession``` accordingly.
  
  
  
  
