# Block Breaker WITH COLOR
#### Video Demo:  <URL HERE>
## Description:
A short remake of Atari's "Breakout" in Unity2D, but with increased difficulty and elements of "bubble shooters". The game is built is written entirely in C# on      Unity2D (manifestly uses NVIDIA PhysX). Each level (6 in total) contains destructible balls of different colors. Accordingly, the player will be provided with multiple sprites or balls of matching colors to destroy all the balls.

##### Design and Controls
Each level in the game contains a ball, a paddle, destructible balls (of different colors, a.k.a "HitBall"), a GameSession object (which stores information like score and level index which has to be preserved till the end of a game session), a Level object (which retrieves "level-specific" information from GameSession and uses it within a level), among other minor elements. The game is in 4:3 aspect ratio (with 2048 x 1536 being the default resolution). The GameSession object carries the total score, current level score, level number (for the level text in the game), and the conventional level index (for loading scenes during a "Retry"), all int variables.
  
The main menu contains buttons, a MainMenu object which contains respective methods for each button, and a music player object for playing main menu music until the MainMenu object inverts a boolean value to destroy the music player object before starting the actual game, thus stopping the music. A similar object is also present in Preferences for the functioning of the different buttons. I have used a simple Quality Slider than mentioning specific resolutions to reduce complications. This kind of object is also present the Game Over scene which retrieves player stats from the the GameSession level (which will continue to exist due to DontDestroyOnLoad() singleton script added in it) and displays it on the screen.
