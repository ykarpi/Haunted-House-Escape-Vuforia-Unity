# IMTC Lab3 - Haunted House Escape!
This project consists of a series of AR-based interactions that form the foundation of a thrilling game. Using Vuforia image target detection, players are immersed in an environment where they are jumpscared by a ghost, solve riddles, and finally escape through an animated door.

## Ghost Interaction
The interaction marks the initial phase of the game. Once the AR camera detects the ImageTarget, a jump scare is triggered to startle the player. Furthermore, a "screaming" sound effect is added to provide a more realistic and immersive experience. The jump scare implementation is achieved by displaying a nearly full-screen image of the ghost asset on Canvas in a 2D plane. However, after 3 seconds, the jump scare fades, and the 3D model of the ghost is rendered in AR whenever the ImageTarget is detected. Additionally, as the player moves, the ghost model will continuously follow and remain oriented towards the player. 

Asset used: https://poly.pizza/m/Iip30bDHmu 

Audio used: https://pixabay.com/sound-effects/cartoon-scream-1-6835/

## Riddle Interaction
On our second image target, a skull appears, with the text asking the user a riddle. The answer to our riddle is echo, and once the user gets the riddle correct, the text changes to inform the user that they’ve broken the skull’s curse, and the skull disappears. 

Asset used: https://poly.pizza/m/EAsVEJwsv7  

## Door Interaction: 
Our third image target is the one which the user can use to escape. Upon target detection, a door appears. When the user taps on the door, the door opens via an animation, and the sound changes to birds chirping, and some text appears in green, informing the user that they’ve escaped.  

Asset used: https://assetstore.unity.com/packages/tools/physics/interactive-physical-door-pack-163249

Audio used: https://pixabay.com/sound-effects/birds-singing-nature-sounds-8001/
