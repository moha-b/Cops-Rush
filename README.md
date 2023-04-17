# Step-by-Step Guide: Getting Started
If you're ready to embark on your gaming journey, follow these simple steps:

1 - Download the game package to your computer.

2 - Open Unity and create a new Unity project or open an existing one.

3 - In the Unity editor, go to the `Assets` menu and select `Import Package` > `Custom Package`.

4 - Browse to the location where you have downloaded or saved the package file on your computer.

5 - Select the package file (.unitypackage) and click `Open`.

6 - In the `Import Unity Package` window, you can choose which items from the package you want to import. You can select or deselect individual assets. 

7 - import everything by leaving all the items checked.

8 - Click `Import` to start the import process.

With these steps, you'll be well on your way to exploring the exciting world of the game. Get ready to embark on an unforgettable adventure and experience the thrill of gaming at its best!

> **Note**                     
*Please ensure that you have imported the required assets, such as TextMeshPro, for this project to function properly.*


## Package Content 📦

- Prefabs
  - Cop
  - Zombie
  - Mixer
  - Enemy Spawner
  - Bullets
  - Rotary Grater
  - Gate Holder
  
- Scripts
  - Cop
    - Cop Animations
    - Cop Bullets
    - Cop Centerized 
    - Cop Controller
  - Player
    - Player Movement
    - Player Rotation
    - Player Spawning
    - Player Controller
  - Zombie
    -  Enemy Spawner Controller
    - Zombie Movement
    - Zombie Spawner
    - Zombie Controller
  - Gate
    - Gate Controller
    - Gate Holder Controller
  - Utils
    - Bullet Controller
    - Camera Controller
    - Obstecles Controller
    - Audio Controller
    
- Martials

- Ui component

-  Animations

- Scenes

- Audio


## Customizing Your Game
Within yoru game inspector, you have complete control over how your game looks and functions. Don't worry, it's simple and hassle-free!

#### Adding Gates

To add gates to your game, follow these easy steps:  

1 - Head to the Prefab folder within your project. 

2 - Drag and drop the `GateHolder` prefab into your hierarchy.   


That's it! You've successfully added gates to your game!

#### Modifying Gate Values   <img align="right" src="https://user-images.githubusercontent.com/73842931/232593240-24a21d61-b6ab-489e-8a2f-e67406dad581.png" />

Now, if you want to change the values of the gates, follow these steps:

1 - In the Hierarchy, navigate to GateHolder Prefab > Right or Left Gate > Gate Controller Script.

2 - In the inspector, you can easily modify the Gate Value to suit your needs.

3 - You can also specify whether the value should be added or multiplied as per your requirements.

With our intuitive inspector, you have the power to customize your game and create the perfect gameplay experience for your players. It's that easy!

> **Warning**                     
*This part may cuz an error so Please ensure that you have imported the required assets, such as TextMeshPro, for this project to function properly.*

#### Adding Obstacles

To add obstacles to your game, follow these easy steps:  

1 - Head to the Prefab folder within your project. 

2 - Drag and drop the `Obstacles(RotaryGrater, Mixer)` prefab into your hierarchy.   

#### Adding Zombies

To add obstacles to your game, follow these easy steps:  

1 - Head to the Prefab folder within your project. 

2 - Drag and drop the `EnemySpawner` prefab into your hierarchy. 

#### Modifying Gate Values   <img align="right" src="https://user-images.githubusercontent.com/73842931/232598409-abb64904-789a-4854-88d7-4e00dcba08e0.png" />

Now, if you want to change the values of the gates, follow these steps:

1 - In the Hierarchy, navigate to EnemySpawner Prefab > Zombie Spawner Script.

2 - In the inspector, you can easily modify the Enemy Number to suit your needs.

