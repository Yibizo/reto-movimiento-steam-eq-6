![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Logo/logo_mainframe.png?raw=true)
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

The battles consist of extremely simple debugging and coding challenges, which will introduce the player to the world of programming in a fun and entertaining way.

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

The player, when entering combat, is given a terminal question according to the enemy's level, adjusting its difficulty accordingly. During the display of the timed terminal, the player can answer incorrectly and let the timer run out, thus recieving damage, or answering correctly and dealing damage.

If the players health points reach zero, they die and they reload to previous save. But if the enemy's health points run out, they die and the player recieves experience points, thus advancing in level. 

With all of this said, the main mechanic consists of replacing simple turn based combat with easy and time based debugging challenges.

# Level Design
 (Note : These sections can safely be skipped if they’re not relevant, or you’d rather go about it another way. For most games, at least one of them should be useful. But I’ll understand if you don’t want to use them. It’ll only hurt my feelings a little bit.)

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

_(example)_

## Game Flow
```
1.	Player starts in forest
2.	Pond to the left, must move right
3.	To the right is a hill, player jumps to traverse it (“jump” taught)
4.	Player encounters castle - door’s shut and locked
5.	There’s a window within jump height, and a rock on the ground
6.	Player picks up rock and throws at glass (“throw” taught)
7.	… etc.
```
(example)


# Development
 
## Abstract Classes / Components
```
1.	BasePhysics
    a.	BasePlayer
    c.	BaseObject
2.	BaseCollision
3.	BaseInteractable
4.	BaseCombat
```
_(example)_ 

## Derived Classes / Component Compositions
```
1.	BasePlayer
    a.	PlayerMain
    b.	PlayerUnlockable
2.	BaseEnemy
    a.	EnemyWolf
    b.	EnemyGoblin
    c.	EnemyGuard (may drop key)
    d.	EnemyGiantRat
    e.	EnemyPrisoner
3.	BaseObject
    a.	ObjectRock (pick-up-able, throwable)
    b.	ObjectChest (pick-up-able, throwable, spits gold coins with key)
    c.	ObjectGoldCoin (cha-ching!)
    d.	ObjectKey (pick-up-able, throwable)
4.	BaseObstacle
    a.	ObstacleWindow (destroyed with rock)
    b.	ObstacleWall
    c.	ObstacleGate (watches to see if certain buttons are pressed)
5.	BaseInteractable
    a.	InteractableButton
```
_(example)_

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
	ii.	Bug (combat, death
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
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Character/Gum%20Bot%20sprites.png?raw=true)


## Tileset:</br>
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Tileset/scifitiles.png?raw=true)


## Enemies:</br>
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/Zapper/attack.png?raw=true)
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/Zapper/damaged%20and%20death.png?raw=true)
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/Zapper/wake.png?raw=true)
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/BallChain/attack.png?raw=true)
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/BallChain/charge.png?raw=true)
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/BallChain/death.png?raw=true)\\
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/FinalArt/Enemies/ToasterBot/all.png?raw=true)


## Demo Layout:</br>
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/Preview/tutorial_area.PNG?raw=true)


## Terminal View:</br>
![alt text](https://github.com/Yibizo/reto-movimiento-steam-eq-6/blob/main/videogame/Art/Preview/terminal_view.PNG?raw=true)

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
 
(what is a schedule, i don’t even. list is good enough, right? if not add some dates i guess)

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
3.	find some smooth controls/physics
4.	develop other derived classes
    a.	blocks
        i.	moving
        ii.	falling
        iii. breaking
        iv.	cloud
    b.	enemies
        i. soldier
        ii.	rat
        iii. etc.
5.	design levels
a.	introduce motion/jumping
b.	introduce throwing
c.	mind the pacing, let the player play between lessons
6.	design sounds
7.	design music
```
