# GameGoBoom

Lab Checklist:

layered background (background  /foreground)
-birds in foreground and sky in background.

at least one image
-background/foreground/planes.

a player-controlled sprite
-left plane.

an enemy sprite with automatic movement
-right plane.

the ability for the player to shoot bullets at the enemy
-x key.

automatic shooting bullets from the enemy to the player
-right plane.

collision detection of bullets, using tags so that a player does not kill himself with his own bullets
-Enemybullet script's bullet marked player's plane tag to lose health

sound effect on collisions
-sound effect occurs when player plane destroys the enemy plane.

health score for player and enemy, displayed
-displayed at the top side of each plane.

at least three levels in increasing order of difficulty. Document the difficulty of each level in the directions.
-level one - regular random shooting speed.
-level two - faster random shooting speed.
-level 3 - enemy bullets chase player.

Chasing algorithm implemented as one of the levels (enemy plane chases player)
-Level 3.

scene transitions: Every time that your player destroys the enemy, the game should transition to the next level. Every time your player ship gets destroyed, the current level should be restarted.
- scene restarts when player plane's health reaches 0

directions (include the basics of each level)
-instructions in the main menu

settings, including a volume setting with a slider
-main menu -> settings

menu
-main menu

pause/resume and link back to menu
-at the top of each level

some other UI (dropdown, toggle, input)
-Input for name in main menu

a data item that persist from scene to scene
- player name.

a second data item that persists
- level.

high scores (at least 5, presented in order)
-main menu -> highscores but high scores page does not work.

animation #1
- red bird.

animation #2
- fireworks in good end scene.

Extra credit: difficulty selection by player (with documentation about difficulty)
