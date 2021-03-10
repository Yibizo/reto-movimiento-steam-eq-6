# Easy to use Template for Software Requirements Specification
Start with a descriptive and succinct name for your project. Change the above with the name of your project

# Table of content

- [Introduction](#introduction)
    - [Purpose](#purpose)
    - [Scope](#scope)
    - [Definitions and Acronyms](#definitions-and-acronyms)
- [Overall Description](#overall-description)
    - [User classes](#user-classes)
    - [Assumptions and Dependencies](#assumptions-and-dependencies)
- [System Features and Requirements](#system-features-and-requirements)
    - [Functional Requirements](#functional-requirements)
    - [External Interface Requirements](#external-interface-requirements)
    - [Non-functional Requirements](#non-functional-requirements)
- [Screens](#screens)
    - [Wireframes](#wireframes)

_Table of content generated using VSCode plugin [Markdown TOC](https://marketplace.visualstudio.com/items?itemName=AlanWalk.markdown-toc)_

# Introduction

## Purpose
Create a video game focused on inspiring vocations in STEM (Biotechnology, Agriculture and Livestock, Physicomathematical and Earth Earth Sciences, ICT Software and Services, Industrial engineering and transportation, Pharmaceuticals and biotechnology), as well as dveelop cognitive abilities (creativity, communication, colaborative work, crticial thinking, problem-solving, data alphabetization, digital alphabetization and computational sciences). In addition to this, track and register all user data and activity within the videogame in order to determine its effciency. 

## Scope
- Benefits: inclusion of women within STEM vocations, as well as the promotion of said subjects
- Objectives: break barriers, myths and prejudices describing that those types of careers are only for men
- Goals: Proximity to STEM subjects, without any gender discrimination

Describe the software being specified. Include benefits, objectives, and goals. This should relate to overall business goals, especially if teams outside of development will have access to the SRS

## Definitions and Acronyms
- STEM: science, technology, engineering, and mathematics education
- STEAM: science, technology, engineering, arts, and mathematics education
- RPG: role playing game
- RNG: random number generator, often only refers to events determined by random chance
- terminal: refers to a terminal that can be seen within any modern code editor
- dashboard: type of interface which presents information to the user

Include any non-trivial definition or acronym used in the document.

# Overall Description
The team's going to build a turn-based rpg with a focus on programming from scratch. Combat will be replaced with basic terminal problems and questions in order to explore said topic, as well as an overworld to promote critical-thinking. The videogame will be hosted within a webpage created by the team. Finally, user data and activity inside the videogame will be tracked, registered and displayed within the website to show the game's efficieny in terms of encouragement towards STEM vocations.

Describe what you’re going to build. Is it an update to an existing product? Is it a new product? Is it an add-on to a product you’ve already created?

These are important to describe upfront, so everyone knows what you’re building.

## User classes
- External users: 
- STEM members: 

User classes and characteristics are critical. You’ll need to define who (different roles) is going to use the product and how. Don't forget to include each user needs.

## Assumptions and Dependencies
- We may not be able to develop the project until our professors teach us the subjects necessary for its evolution.
- We may deliver a different product to what STEM is asking because of the unclarity of the requirements, as well as how long its taking to get specifics.
- We may be constraint by time and only be able to finish one world, as opposed to the expected three. 

There might be factors that impact your ability to fulfill the requirements outlined in this document. What are those factors?

Are there any assumptions you’re making that could turn out to be false? You should include those here, as well.

Finally, you should note if your project is dependent on any external factors. This might include software components you’re reusing from another project.

# System Features and Requirements
This is where you detail the specific requirements for building your product.

## Functional Requirements
- Have a complete and playable videogame
- Host the videogame within the webpage
- Track user data correpsonding to activity inside the videogame
- Display user information in order to determine system effcieny
The functional requirements describe the services and functions of a system. Functional requirements must be precise and unambiguous.

Include user stories, which are short descriptions of a feature, told from the perspective of one of your end user profiles. They are typically structured in the following fashion:

> As a __[type of user]__, I want __[some goal]__ so that __[some reason]__.

You may want to use the following template table.

|Title|User story|Importance|Notes|
|---|---|---|---|
|_External User_|_As an external user, I want to be able to sign up so that my progress within the videogame is saved_|_Must have_|_Sample Comment_|
|_STEM Member_|_As a STEM member, I want to be able to access and view user data regarding activity within the videogame so that I can determine its efficieny towards the promotion of STEM vocations_|_Must have_|_Sample comment_|
|_External User_|_As an external user, I want the videogame to not be too hard and frustrating, but also not too easy and boring so that I have an enjoyable experience_|_Should have_|_Sample comment_|
|_Short identifier_|_As a [type of user], I want [some goal] so that [some reason]_|_Must have_|_Write here any additional consideration_|

## External Interface Requirements
External interface requirements are types of functional requirements. They outline how your product will interface with other components or systems.

There are several types of interfaces you may have requirements for, including:
- User:
    - Have a playable videogame that is not too hard and frustrating, but also not too easy and boring that induces STEM abilities.
    - Have a clear and inductive way to access user data according to the videogame's efficieny
- Hardware
    - 4gb of RAM
    - Intel Core I3 or AMD Ryzen 3
    - 500mb of storage
    - 2.0GHz processor
- Software
    - Any modern web browser (Chrome, Firefox, etc.)
- Communications
    - ??

## Non-functional Requirements
- The product must be on a website platform
- The product must be able to run on a PC with 4gb of RAM and 2.0GHz processor
- The database must register user actions and progress within the videogame
- The videogame must have at least one overworld, with one final boss
- The videogame must be hosted within a webpage
- The website must display user data with high precision
- The user profile data is confidential and must comply with mexican privacy laws
- Users have the right to audit their data and request their removal from the system

Non-functional requirements are restrictions on the system or the development process. Non-functional requirements can be more critical than functional ones. If they are not met, the system is useless!

# Screens
The website consists of three pages; the landing page, the dashboard displaying user data and the page where the videogame is hosted.

- The landing page includes the games title and a brief description in order to motivate the visitor to play the videgame.
- The dashboard includes graphs and data of user information and intercations within the videogame in order to evaluate the game efficieny.
- The third, where the videogame is hosted, just involves a fullscreen view of the game.

The videogame itself contains a few different screens.

- The 2.5D overworld which can be explored, in addition to including puzzles and leading to combat determined by RNG.
- Combat, in which you are able to see enemy stats, your stats and options for the turn, which also includes the terminal. 
- Cutscenes, which are brief and offer no player interaction, apart from skipping said cutscene.

Identifying the individual screens (for an app), or pages (for a website) are where a product’s shape starts to become clear. They are a distillation of the user stories into a set of distinct sections that satisfy the needs and behaviors identified so far. The process of outlining an application’s screens may also highlight any requirements or considerations that have been overlooked up to this point.

This has the dual purpose of both contributing to a more accurate vision of the product early on, and serving as a jumping-off point for the time when designers do get involved.

## Wireframes
Wireframes are simple page layouts that outline the size and placement of elements, and features on a page. They are generally devoid of color, font styles, logos or any design elements.

Wireframing is probably the most time-consuming step of this process and for some simple projects, it may be overkill. For complex projects where serious design thinking needs to happen, wireframes are an indispensable tool.

Here are some popular tools for wireframing:
- https://marvelapp.com/  
- https://balsamiq.com/ 
- https://jetstrap.com/ 
- https://www.fluidui.com/ 
- https://ninjamock.com/ 
- https://www.justinmind.com/ 
- https://moqups.com/
