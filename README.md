# Lab 3 Assignment
This project is done as part of the Lab 3 assignment for IMTC 505 course.
Unity 2022.3.45f1 is used along side with the Vuforia to create an AR application.

Project Setup:

Used assets:
- [Ghost model](https://poly.pizza/m/Iip30bDHmu)
- [Skull model](https://poly.pizza/m/EAsVEJwsv7)
- [Door & Key](https://assetstore.unity.com/packages/tools/physics/interactive-physical-door-pack-163249)
- ADD HERE the music assets too
 
## Description
In this immersive experience, players are trapped in a haunted mansion and must interact with various cursed objects to find their way out. The first interaction occurs when the player scans a first mysterious ImageTarget, triggering a startling jump scare as a ghost unexpectedly appears. In the second encounter, a skull presents a riddle that players must solve. The final interaction reveals a door, behind which lies a key crucial to their escape. Upon retrieving the key, you can successful escape from the haunted mansion.

// add some kind of pitch for the project & an image

 ## Video Demo
//add a youtube link



## Table of Contents
- [Ghost Interaction](#ghost-interaction)
- [Skull Riddle](#skull-riddle)
- [Door & Key](#door-animation)
- [Future Works](#future-works)
- [Main challenges](#main-challenges)
- [Useful Tutorials](#useful-tutorials)


## Ghost Interaction
The interaction marks the initial phase of the game. Once the AR camera detects the ImageTarget, a jump scare is triggered to startle the player. Furthermore, a "scaring" sound effect is added to provide a more realistic and immersive experience. The jump scare implementation is achieved by displaying a nearly full-screen image of the ghost asset on Canvas in a 2D plane. However, after 3 seconds, the jump scare fades, and the 3D model of the ghost is rendered in AR whenever the ImageTarget is detected. Additionally, as the player moves, the ghost model will continuously follow and remain oriented towards the player.  


## Skull Riddle
On our second image target, a skull appears, with the text asking the user a riddle. The answer to our riddle is echo, and once the user gets the riddle correct, the text changes to inform the user that they’ve broken the skull’s curse, and the skull disappears. 


## Door Animation
Our door interaction image target is the one which the user can use to escape. Upon target detection, a door appears. When the user taps on the door, the door opens via an animation, and the sound changes to birds chirping, and some text appears in green, informing the user that they’ve escaped.  


## Future Works
// 

## Main Challenges
// add some reflection with what challenges we faced


## Useful Tutorials:
As part of the assignment, we'd like to acknowledge the following tutorials that were very helpful in the learning and development process: 
- [Animate 3D Model in AR Games | Unity and Vuforia](https://www.youtube.com/watch?v=lCu4z7CNELA)
- [How To Make a Jumpscare in Unity](https://www.youtube.com/watch?v=peNVI0O9mxY)
- [How To Make Your Game Look The Same On All Mobile Screen Sizes - Unity Mobile Game Development](https://www.youtube.com/watch?v=KxwxZea0KAg)
