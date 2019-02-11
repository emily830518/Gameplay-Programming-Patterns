# Gameplay Programming Patterns Assignment
Setup a basic project:

1. Top-down Static View
2. Player: A player controlled avatar that can:
    (1) The avatar can be moved via keyboard key:rightarrow, leftarrow, uparrow, and downarrow.
    (2) The player can shoot bullets via keyboard key:space. And the bullet will only exist 1.5 second and then be destroyed.
3. Arena Bounds: The avatar is constrained to move within the plane(play area).

Components:

1. Design three enemy types for the game:
	(1) chase the target(player)
	(2) shoot toward the target(player) but stay at the fixed position
	(3) also controlled by the keyboard and shoot toward the target(player)
2. Create components to implement the enemies:
	(1) ChaseTarget
	(2) ShootTarget
	(3) ControlledByKeyboard
3. Refactor the player code with your new components: I refactored the controller part of the avatar and using ControlledByKeyboard component instead. 