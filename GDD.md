<img src="videogame/Art/FinalArt/Logo/tec_logo_2.png" width="50"/><img src="videogame/Art/FinalArt/Logo/logo_mainframe_white_text.png" width="550">
> Game Design Document

# Dream Team

- Diego Mejía (A01024228)
- Enrique Mondelli (A01379363)
- Jorge Cabiedes (A01024053)
- José Salgado (A01023661)

# Table of Content

- [Game Design](#game-design)
    - [Summary](#summary)
    - [Gameplay](#gameplay)
    - [Mindset](#mindset)
- [Technical](#technical)
    - [Screens](#screens)
    - [Controls](#controls)
    - [Mechanics](#mechanics)
- [Level Design](#level-design)
    - [Themes](#themes)
    - [Game Flow](#game-flow)
- [Development](#development)
    - [Abstract Classes / Components](#abstract-classes--components)
    - [Derived Classes / Component Compositions](#derived-classes--component-compositions)
- [Graphics](#graphics)
    - [Style Attributes](#style-attributes)
    - [Graphics Needed](#graphics-needed)
- [Sounds/Music](#soundsmusic)
    - [Style Attributes](#style-attributes-1)
    - [Sounds Needed](#sounds-needed)
    - [Music Needed](#music-needed)
- [Schedule](#schedule)


# Game Design

## Summary
Into the Mainframe is a 2.5D, pixelated, turn-based RPG in which you, the player, get sucked into your work computer and need to fight viruses infecting it. Advance your way through various computer worlds, while battling said enemy viruses, in order to escape and free your computer from malicious malware along the way. 

The battles consist of extremely simple debugging and coding challenges, which will introduce the player to the world of programming in a fun and entertaining way, available for modern web browsers.

## Gameplay
Gameplay consists of 2 parts, overworld and combat. The main goal of the game is to reach the end of each world, and prove what has been learned throughout progression.

## Mindset
We want to make the player feel smarter and more powerful as time goes on, to show how their skills have evolved since they first started.

# Technical
 
## Screens

```
1. Title Screen
    a. New Game
    b. Load Game
    c. Options
    d. Credits
    e. Exit
2. File Select
3. Game
    a. Pause Menu
       a.1. Inventory
       a.2. Save Game
       a.3. Load Game
       a.4. Options
       a.5. Exit
    c. Open Game World
    d. Turn Based Combat
       d.1. Actions Select
       d.2. Terminal
4. End Credits
```

## Controls
The player uses the arrow keys for up/down/left/right movement in the overworld, as well as navigation in the combat screen. To initiate input on the terminal, the player presses 'Tab'. After that, any text can be inputed, and with 'Enter' the player submits their answer.

To access the pause menu, the player presses the 'Escape' key, and traverses it with the arrow keys previously established. To enter any option the player presses the 'Enter' key and to exit the 'Escape' key.

## Mechanics
The main objective of the game is to exit every world by battling a boss in the end of said world, and in the process proving the player's coding skills and critical thinking. 

Player can move around the overworld in order to explore, with certain sections triggering random encounters with enemies. During the overworld, the player can encounter NPC's that have dialogue, as well as rooms with objects that work in union as a puzzle.

No enemies can be seen in the overworld, thus no enemy behaviour can be found in the overworld. During combat, however, enemies	choose at random from a list of attacks. 

The player, when entering combat, is given a console prompt where they can solve the given coding problem, adjusting its difficulty according to how far along the player is in the game. During the display of the timed terminal, the player can answer incorrectly and let the timer run out, thus recieving damage, or answer correctly to deal damage.

If the players health points reach zero, they die and they reload to previous save. But if the enemy's health points run out, they die and the player recieves experience points, thus advancing in level. 

With all of this said, the main mechanic consists of replacing simple turn based combat with easy and time based debugging challenges.

# Level Design

## Themes
```
1.	Circuits
    a.	Mood
        i.	Metallic, calm
    b.	Objects
        i.	Ambient
            1.	Metallic tiles
            2.	Sources of light
            3.	Precaution tiles
        ii.	Interactive
            1.	Consoles
            2.	Buttons
            3.	Doors
            4.	Stairs
```

## Game Flow
```
1.	Players sees cutscene
2.	Player starts inside computer setting
3.	North is a console that teaches the player the basics, to the right is the door to exit
4.	Terminal appears, teaching the players the basics
5.	Next room has the same interactable console that tells the player the encounter system, and a button that opens the door
6.	Player can walk in encounter tiles, which will trigger combat
7.	Player sees the combat UI, and can decide what to do
8.	When the player decides to proceed, they get a basic programming question in which they have to input their answer
9.	The player wins, and exits combat
10.	The player proceeds to the next room, in which they get an iteractable console that tells them about boss tiles
11.	The player can engage in same combat as before, only against a boss
13.	Then, the player can read the final console that tells them to proceed to the next area through the stairs
14.	The player uses the stairs in order to exit the tutorial area
```

# Development
 
## Abstract Classes / Components
```
1.	BasePhysics
    a.	BasePlayer
    b.	BaseObject
2.	BaseInteractable
3.	BaseBattleSystem
    b.	BaseTerminal
    c.	BaseBattleUnit
```

## Derived Classes / Component Compositions
```
1.	BasePlayer
    a.	PlayerMain
    b.	PlayerController
2.	BaseEnemy
    a.	EnemyToasterBot
    b.	EnemyBallChain
    c.	EnemyZapper
3.	BaseObstacle
    a.	ObstacleWall
    b.	ObstacleGate (watches to see if certain buttons are pressed)
    c.	ObstacleConsole
5.	BaseInteractable
    a.	InteractableButton
    b.	InteractableConsole
    c.	InteractableDoor
    d.	EncounterTile
5.	BaseBattleSystem
    a.	BattleActionBox
    b.	BattleDialogBox
    c.	BattleHud
    d.	BattleSystem
    e.	BattleUnit
    f.	TerminalBase
```

# Graphics

## Style Attributes

- no limited color palette
- everything is done in pixel art style to remain consistent
- Characters utilize black outlines in order to stand put from the environment
- interactables throughout the overworld have a distinctive style to them

## Graphics Needed

```
1.	Characters
    a.	Main Character
        i.	Gum Bot (idle, walking, encounter, combat, death)
    b.	Enemies
        i.	Virus (combat, death)
	ii.	Bug (combat, death)
2.	Blocks
    a.	Metal
    b.	Precaution Tiles
    c.	Precaution Path
    d.	Consoles (Non-Interactable)
    e.	Circuits
3.	Ambient
    a.	Encounter Normal Metal
    e.	Encounter Boss Metal
    c.	Light Source
4.	Other
    a.	Consoles (Interactable)
    b.	Button (On The Floor)
    b.	Door
    c.	Gate
```

## Main Character:</br>
![alt text](videogame/Art/FinalArt/Character/Gum%20Bot%20sprites.png?raw=true)


## Tileset:</br>
![alt text](videogame/Art/FinalArt/Tileset/scifitiles.png?raw=true)


## Enemies:</br>
![alt text](videogame/Art/FinalArt/Enemies/Zapper/attack.png?raw=true)
![alt text](videogame/Art/FinalArt/Enemies/Zapper/damaged%20and%20death.png?raw=true)
![alt text](videogame/Art/FinalArt/Enemies/Zapper/wake.png?raw=true)
![alt text](videogame/Art/FinalArt/Enemies/BallChain/attack.png?raw=true)
![alt text](videogame/Art/FinalArt/Enemies/BallChain/charge.png?raw=true)
![alt text](videogame/Art/FinalArt/Enemies/BallChain/death.png?raw=true)
![alt text](videogame/Art/FinalArt/Enemies/ToasterBot/all.png?raw=true)


## Demo Layout:</br>
![alt text](videogame/Art/Preview/tutorial_area.PNG?raw=true)


## Battle System:</br>
![alt text](videogame/Art/Preview/battle_system_1.PNG?raw=true)</br></br></br>
![alt text](videogame/Art/Preview/battle_system_2.PNG?raw=true)</br></br></br>
![alt text](videogame/Art/Preview/battle_system_3.PNG?raw=true)</br>

# Sounds/Music
 
## Style Attributes

- Audio effects consist of 8 bit / 16 bit
- Audio effects are short and satisfyingly responsive
- Music background has a consistent theme of machinery and industry

## Sounds Needed
```
1.	Effects
    a.	Soft Footsteps (Normal Floor)
    b.	Sharper Footsteps (Encounter Floor)
    c.  Object Interaction
    d.	Button Stepping
    e.	Door Opening
    f. 	Stairs Fade-in Footsteps
    g.	Stairs Fade-out Footsteps
    h.	Encounter Noise
    i.	Clock Tick
2.	Feedback
    a.	Accept Button Press
    b.	Cancel / Return Button Press
    c.	Input Detection Terminal
    d.	UI Element Movement
    e.	Player Attack
    f.	Enemy Attack
    g.	Flee Noise
```

## Music Needed
```
1.	Slow-paced, relaxed background music
2.	Intense, mid-paced, boss battle music
3.	Fast-paced, combat music with same tones
4.	Happy ending credits track
``` 

# Schedule

```
1.	develop base classes
    a.	base entity
        i.	base player
        ii.	base enemy
        iii.	base block
    b.	base app state
        i.	game world
        ii.	menu world
2.	develop player and basic block classes
    a.	physics / collisions
3.	get sprites
4.	script tileset movement
5.	develop other derived classes
    a.	enemies
        i.	ToasterBot
        ii.	BallChain
        iii.	Zapper
6.	design levels
	i.	mind the pacing, let the player play between lessons
7.	get sounds
8.	get music
```
