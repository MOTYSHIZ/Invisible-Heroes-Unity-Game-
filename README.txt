Creators: Justin Ordonez and John To

Invisible Heroes is a very simple exploration game where the player must find the artifact and touch it to awaken the Heroes. The player has seeker balls to help him find the artifact. In that sense they can be considered OP, so they can be toggled off in the "Advanced Settings" panel in the main menu. 

We used an online tutorial to get most of the map generation down, but to prove that we didn't simply just copy and paste the source code, we typed it out along with the tutorial and commented the code throughout to make the functions more clear.

We both worked on implementing and commenting the Procedural Map Generation code.
John To scripted the Day/Night cycle.
Justin Ordonez worked on the other features.

The game builds were exported from a Windows machine for Windows and Mac OS X, but neither of us own a Mac, so we are unsure about how that build runs.

This project has been a joy to work on, and we invested a lot of time into it while learning so much more about the Unity Game Engine. Please consider us for this internship, because we would love to work on much bigger and better projects with your talented team!

Features:
-Main Menu
	-Fully Functional UI
	-Animated map and visual demonstration of Procedural Map Generation
	-Instructions on how to play with controls listed.

-Procedural Map Generation: Every map is different, unless the user chooses the same settings for the map.
	-Utilizes Unity's Perlin Noise
	-Random Spawning Map objects
		-Trees, AI (ballsies), and heroes.
	-Randomly placed player spawn and Artifact spawn location.
	-Map seed setting allows variation on top of the other settings.
		-Using the same seed with other same settings results in the same map every time.

-Advanced Settings
	-Customize the map and see a live preview of it from the menu.
	-User can change most of the settings involved in generating the map.
	*Would have liked to implement more settings concerning the AI and player, but ran out of time.	
		
-AI
	-Attempts to locate and follow the player as soon as the game begins.
	-AI balls will find the artifact for the player if the player hits "G"
		-Player can switch them back to follow mode by pressing "F"

-Basic Underwater Audio and Visual Effects
	
-Day/Night Cycle
		-Speed modifiable in the editor, would have added settings in the "advanced settings" if had more time.
	
-Simple Animated End Game sequence
	-Payoff for finding the artifact. A bit better than a simple "You won!"
	
External Sources used:
Sebastian Lague - Unity Procedural Generation
https://www.youtube.com/watch?v=wbpMiKiSKm8&list=PLFt_AvWsXl0eBW2EiBtl_sxmDtSgZBxB3&index=1

John Cena Model From
http://dxmaster9.deviantart.com/art/John-Cena-3D-Model-477629261

Underwater visuals script modified from:
http://wiki.unity3d.com/index.php?title=Underwater_Script

