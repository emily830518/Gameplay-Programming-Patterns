# Gameplay Programming Patterns Assignment
Setup a basic project:

1. Top-down Static View
2. Player: A player controlled avatar that can:
    (1) The avatar can be moved via keyboard key:rightarrow, leftarrow, uparrow, and downarrow.
    (2) The player can shoot bullets via keyboard key:space. And the bullet will only exist 1.5 second and then be destroyed.
3. Arena Bounds: The avatar is constrained to move within the plane(play area).

Components:

1. Design 4 enemy types for the game:
	(1) chase the target(player)
	(2) shoot toward the target(player) but stay at the fixed position
	(3) also controlled by the keyboard and shoot toward the target(player)
	(4) chase the target and shoot toward the target
2. Create components to implement the enemies:
	(1) ChaseTarget
	(2) ShootTarget
	(3) ControlledByKeyboard
3. Refactor the player code with your new components: I refactored the controller part of the avatar and using ControlledByKeyboard component instead. 

Manager:

1. Create an EnemyManager to manage enemies
2. A wave is 5 enemies in random types at a time

Events:

Use event system to score and drive all the UI in the game(such as score display, life display and Game Over display).

Tasks:

I add 3 tasks to implement 3 different attacks of Boss Enemy. The boss enemy has 15 lives, at first, the boss enemy will move from left to right continuously until lives = 10. Then, the boss enemy will move in circle until lives - 5. And then, the boss enemy move in circle and scale and shrink over time.