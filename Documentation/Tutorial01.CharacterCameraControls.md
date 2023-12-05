# Tutorial 01 - Character, Camera, Controls

- [Overview](#overview)
- [Project Setup](#project-setup)
- [Scene Setup](#scene-setup)
- [Event System](#event-system)
- [Character Setup](#character-setup)
- [Camera Setup](#camera-setup)
- [Controls Setup](#controls-setup)
- [Visual Scripting Setup](#visual-scripting-setup)
- [Logic](#logic)
  - [Common Logic](#common-logic)
    - [Method.MoveRigidBody2D](#methodmoverigidbody2d)
  - [Player Logic](#player-logic)
    - [Configuration.Player.Controls](#configurationplayercontrols)
    - [Object.Get.\[Type\].BaseSpeed](#objectgettypebasespeed)
    - [Method.Player.GetMoveDirection](#methodplayergetmovedirection)
    - [Behaviour.Player](#behaviourplayer)
- [Finish](#finish)

# Overview

In this tutorial we will setup the Character, Camera and Controls for a shoot-em-up style game.

# Project Setup

1. If you skipped Tutorial00, your project should be based off of the 2D Core Template.

   [![img_120.png](Images/Tutorial01.CharacterCameraControls/img_120.png)](./Images/Tutorial01.CharacterCameraControls/img_120.png)

2. Once your project is opened. Navigate to the [Package Manager](https://docs.unity3d.com/Manual/upm-ui.html) window and make sure you have all of the following packages installed.

   [![UnityProject07a.png](Images/Tutorial01.CharacterCameraControls/UnityProject07a.png)](Images/Tutorial01.CharacterCameraControls/UnityProject07a.png)

   [![UnityProject07b.png](Images/Tutorial01.CharacterCameraControls/UnityProject07b.png)](Images/Tutorial01.CharacterCameraControls/UnityProject07b.png)

3. If you don't you may need to try creating the project again or [import the packages manually](https://docs.unity3d.com/Manual/upm-ui-install.html) through the Unity registry.

4. Install the following Unity Extensions from OnChain Studios.

   * Instructions for installing a package through a git URL: https://docs.unity3d.com/Manual/upm-ui-giturl.html
    
         https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.filetemplates#v0.7.0-preview.13
   
         https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.uitoolkitextensions#v0.7.0-preview.13

   * Instructions on how to use the OnChain Studios extensions can be found here: https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/README.md

    [![UnityProject10.png](Images/Tutorial01.CharacterCameraControls/UnityProject10.png)](Images/Tutorial01.CharacterCameraControls/UnityProject10.png)

5. Navigate to [Project Settings](https://docs.unity3d.com/Manual/comp-ManagerGroup.html#:~:text=To%20open%20the%20Project%20Settings,go%20to%20Edit%20%3E%20Project%20Settings.&text=The%20Search%20box%20lets%20you,category%20list%20on%20the%20left) -> Visual Scripting and initialize Visual Scripting.

   [![img.png](Images/Tutorial01.CharacterCameraControls/img.png)](./Images/Tutorial01.CharacterCameraControls/img.png)

6. Once Initialized, Add InputAction to the visual scripting node library in the ProjectSettings-VisualScripting->Type Options and regenerate nodes.

    Unity Manual: [Add or remove available nodes](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.8/manual/vs-add-remove-node-library.html)
    
    [![img_2.png](Images/Tutorial01.CharacterCameraControls/img_2.png)](Images/Tutorial01.CharacterCameraControls/img_2.png)

7. Navigate to the [Project Settings](https://docs.unity3d.com/Manual/comp-ManagerGroup.html#:~:text=To%20open%20the%20Project%20Settings,go%20to%20Edit%20%3E%20Project%20Settings.&text=The%20Search%20box%20lets%20you,category%20list%20on%20the%20left) -> Player and set the Company Name, Product Name and Version.

   [![img_3.png](Images/Tutorial01.CharacterCameraControls/img_3.png)](./Images/Tutorial01.CharacterCameraControls/img_3.png)

8. Navigate to [Preferences](https://docs.unity3d.com/Manual/Preferences.html#:~:text=To%20access%20the%20Preferences%20window,right%20of%20the%20Preferences%20window.) -> OnChain Studios -> File Templates and fill out author and namespace.

   [![img_4.png](Images/Tutorial01.CharacterCameraControls/img_4.png)](./Images/Tutorial01.CharacterCameraControls/img_4.png)

9. Navigate to [Preferences](https://docs.unity3d.com/Manual/Preferences.html#:~:text=To%20access%20the%20Preferences%20window,right%20of%20the%20Preferences%20window.) -> Visual Scripting and disable human naming to remove inserted spaces on visual script graphs when using . notation in naming.

   [![img_5.png](Images/Tutorial01.CharacterCameraControls/img_5.png)](./Images/Tutorial01.CharacterCameraControls/img_5.png)

# Scene Setup

Make sure to [save your scene](https://docs.unity3d.com/Manual/scenes-working-with.html) frequently during this process.

1. In the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html) right click and create a folder called Application in the main assets folder.

   [![img_6.png](Images/Tutorial01.CharacterCameraControls/img_6.png)](./Images/Tutorial01.CharacterCameraControls/img_6.png)

   [![img_7.png](Images/Tutorial01.CharacterCameraControls/img_7.png)](./Images/Tutorial01.CharacterCameraControls/img_7.png)

2. In the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html) rename the Scenes Folder to Scene and move it into the Application folder.

   [![img_8.png](Images/Tutorial01.CharacterCameraControls/img_8.png)](./Images/Tutorial01.CharacterCameraControls/img_8.png)

3. In the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html) rename the [Scene](https://docs.unity3d.com/Manual/CreatingScenes.html) in the Scene folder to `Scene.Application`

   [![img_9.png](Images/Tutorial01.CharacterCameraControls/img_9.png)](./Images/Tutorial01.CharacterCameraControls/img_9.png)

4. Open the Scene by double clicking it.

# Event System

The [Event System](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/EventSystem.html) allows input events to communicate to the different components in your project.

5. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html) add an Event System to the [Scene](https://docs.unity3d.com/Manual/CreatingScenes.html).
   
   [![img_10.png](Images/Tutorial01.CharacterCameraControls/img_10.png)](./Images/Tutorial01.CharacterCameraControls/img_10.png)

   [![img_12.png](Images/Tutorial01.CharacterCameraControls/img_12.png)](./Images/Tutorial01.CharacterCameraControls/img_12.png)

10. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html) select the EventSystem [GameObject](https://docs.unity3d.com/Manual/GameObjects.html).

   [![img_11.png](Images/Tutorial01.CharacterCameraControls/img_11.png)](./Images/Tutorial01.CharacterCameraControls/img_11.png)

11. While the EventSystem is selected, view the [GameObject](https://docs.unity3d.com/Manual/GameObjects.html) in the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html) and click the `Replace with InputSystemUIInputModule` button on the Standalone Input Module [Component](https://docs.unity3d.com/Manual/Components.html). This will allow the Event System to work with the new input system. 

   [![img_13.png](Images/Tutorial01.CharacterCameraControls/img_13.png)](./Images/Tutorial01.CharacterCameraControls/img_13.png)

# Character Setup

1. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html) right click and create an empty [GameObject](https://docs.unity3d.com/Manual/GameObjects.html) and name it `LevelContainer`.

   [![img_14.png](Images/Tutorial01.CharacterCameraControls/img_14.png)](./Images/Tutorial01.CharacterCameraControls/img_14.png)

   [![img_15.png](Images/Tutorial01.CharacterCameraControls/img_15.png)](./Images/Tutorial01.CharacterCameraControls/img_15.png)

2. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html) right click the `LevelContainer`, create a triangle sprite and name it Player.

   [![img_17.png](Images/Tutorial01.CharacterCameraControls/img_17.png)](./Images/Tutorial01.CharacterCameraControls/img_17.png)

3. In the [Game View](https://docs.unity3d.com/Manual/GameView.html) notice the triangle shows up.

   [![img_18.png](Images/Tutorial01.CharacterCameraControls/img_18.png)](./Images/Tutorial01.CharacterCameraControls/img_18.png)

4. In the [Scene View](https://docs.unity3d.com/Manual/UsingTheSceneView.html) notice the triangle shows up.

   [![img_19.png](Images/Tutorial01.CharacterCameraControls/img_19.png)](./Images/Tutorial01.CharacterCameraControls/img_19.png)

5. While the `Player` GameObject is selected in the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html), notice the [SpriteRenderer](https://docs.unity3d.com/Manual/class-SpriteRenderer.html) component is attached in the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html).

   [![img_20.png](Images/Tutorial01.CharacterCameraControls/img_20.png)](./Images/Tutorial01.CharacterCameraControls/img_20.png)

6. Attach a [RigidBody2d](https://docs.unity3d.com/Manual/class-Rigidbody2D.html) component to the `Player` GameObject to allow physics based movement and to prevent collisions from missing at high velocities. And set the values as follows.

   [![img_70.png](Images/Tutorial01.CharacterCameraControls/img_70.png)](./Images/Tutorial01.CharacterCameraControls/img_70.png)

7. Attach a [CircleCollider2D](https://docs.unity3d.com/Manual/class-CircleCollider2D.html) component to the `Player` GameObject to allow the player to enable collisions on the player and set the values as follows.

   [![img_61.png](Images/Tutorial01.CharacterCameraControls/img_61.png)](./Images/Tutorial01.CharacterCameraControls/img_61.png)

8. If you zoom in on the `Player` GameObject in the scene you will notice a green circle inside the triangle. This is the collider.

   [![img_60.png](Images/Tutorial01.CharacterCameraControls/img_60.png)](./Images/Tutorial01.CharacterCameraControls/img_60.png)

9. Add a layer to the [Layers](https://docs.unity3d.com/Manual/Layers.html) called Player and set the `Player` GameObject Layer to player. This will allow you to modify the [Layer Collision Matrix](https://docs.unity3d.com/Manual/LayerBasedCollision.html) to enable and disable collisions between certain layers.

   [![img_64.png](Images/Tutorial01.CharacterCameraControls/img_64.png)](./Images/Tutorial01.CharacterCameraControls/img_64.png)

   [![img_63.png](Images/Tutorial01.CharacterCameraControls/img_63.png)](./Images/Tutorial01.CharacterCameraControls/img_63.png)
   
   [![img_65.png](Images/Tutorial01.CharacterCameraControls/img_65.png)](./Images/Tutorial01.CharacterCameraControls/img_65.png)
   
   [![img_66.png](Images/Tutorial01.CharacterCameraControls/img_66.png)](./Images/Tutorial01.CharacterCameraControls/img_66.png)

# Camera Setup

1. Rename the `Main Camera` GameObject to `Camera` since we will only be using one camera in these tutorials. Move the [Camera](https://docs.unity3d.com/Manual/class-Camera.html) GameObject as a child to the `LevelContainer` GameObject.

   [![img_113.png](Images/Tutorial01.CharacterCameraControls/img_113.png)](Images/Tutorial01.CharacterCameraControls/img_113.png)

1. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html), select the `Camera` [GameObject](https://docs.unity3d.com/Manual/GameObjects.html) and set the [Component](https://docs.unity3d.com/Manual/Components.html) data on in the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html) on the [Transform](https://docs.unity3d.com/ScriptReference/Transform.html) and [Camera](https://docs.unity3d.com/ScriptReference/Camera.html).

   [![img_21.png](Images/Tutorial01.CharacterCameraControls/img_21.png)](./Images/Tutorial01.CharacterCameraControls/img_21.png)

2. Notice the change in the [Game View](https://docs.unity3d.com/Manual/GameView.html). Make sure to change the size to 1920 x 1080

   [![img_26.png](Images/Tutorial01.CharacterCameraControls/img_26.png)](./Images/Tutorial01.CharacterCameraControls/img_26.png)

3. In the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html) attach the [PixelPerfectCamera](https://docs.unity3d.com/Packages/com.unity.2d.pixel-perfect@1.0/manual/index.html) component to the `Camera` and set the following.

   [![img_22.png](Images/Tutorial01.CharacterCameraControls/img_22.png)](./Images/Tutorial01.CharacterCameraControls/img_22.png)

5. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html), right click the `LevelContainer` and create an empty [GameObject](https://docs.unity3d.com/Manual/GameObjects.html) and name it `Bounds`. This will contain the GameObjects that will prevent the player from moving outside of the camera.

   [![img_24.png](Images/Tutorial01.CharacterCameraControls/img_24.png)](./Images/Tutorial01.CharacterCameraControls/img_24.png)

6. In the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html), right click `Bounds` and create Square Sprite a called `LeftBounds`.

   [![img_27.png](Images/Tutorial01.CharacterCameraControls/img_27.png)](./Images/Tutorial01.CharacterCameraControls/img_27.png)

   [![img_29.png](Images/Tutorial01.CharacterCameraControls/img_29.png)](./Images/Tutorial01.CharacterCameraControls/img_29.png)

7. Set the Color on the SpriteRenderer component to Red.

   [![img_32.png](Images/Tutorial01.CharacterCameraControls/img_32.png)](./Images/Tutorial01.CharacterCameraControls/img_32.png)

8. Use the following calculation to set the Position and Scale on the Transform Component. Notice the bounds object lives right outside the camera square. 

    These values are calculated using the PixelPerfectCamera values and the values of the sprite.

       Width of Camera: 1920 pixels / 64 pixels per unit = 30 world units
       Height of Camera: 1080 pixels / 64 pixels per unit = 16.875 world units
       Width of Sprite: 256 pixels / 256 pixels per unit = 1 world unit
       Height of Sprite: 256 pixels / 256 pixels per unit = 1 world unit

       Position.X of LeftBounds GameObject: -(Width of Camera / 2 + Width of Sprite / 2) = -15.5 world units.
       Scale.Y of LeftBounds GameObject: Height of Camera + 2 * Height of Sprite = 18.875 world units.

   [![img_38.png](Images/Tutorial01.CharacterCameraControls/img_38.png)](./Images/Tutorial01.CharacterCameraControls/img_38.png)

   You can find the Pixels Per Unit and size of the Sprite by selecting the Sprite image in the project view.

   [![img_36.png](Images/Tutorial01.CharacterCameraControls/img_36.png)](./Images/Tutorial01.CharacterCameraControls/img_36.png)

9. Attach a [BoxCollider2D](https://docs.unity3d.com/Manual/class-BoxCollider2D.html) and [RigidBody2D](https://docs.unity3d.com/ScriptReference/Rigidbody2D.html) components to the `LeftBounds`. Set them accordingly. These are the physics components that will prevent the player from moving outside of the camera on the left.

   [![img_44.png](Images/Tutorial01.CharacterCameraControls/img_44.png)](./Images/Tutorial01.CharacterCameraControls/img_44.png)

10. Add a layer to the [Layers](https://docs.unity3d.com/Manual/Layers.html) called `PlayerBounds` and set the layer on the `LeftBounds` GameObject to use the `PlayerBounds` layer.

   [![img_67.png](Images/Tutorial01.CharacterCameraControls/img_67.png)](./Images/Tutorial01.CharacterCameraControls/img_67.png)

   [![img_68.png](Images/Tutorial01.CharacterCameraControls/img_68.png)](./Images/Tutorial01.CharacterCameraControls/img_68.png)

11. Duplicate (ctrl + d) the `LeftBounds` 3 times and rename them to the following.

    [![img_37.png](Images/Tutorial01.CharacterCameraControls/img_37.png)](./Images/Tutorial01.CharacterCameraControls/img_37.png)

12. Set the position and size to the following for each bounds. You will now have a boundary around your camera to prevent the player from moving outside of the camera.

   [![img_41.png](Images/Tutorial01.CharacterCameraControls/img_41.png)](./Images/Tutorial01.CharacterCameraControls/img_41.png)

   [![img_40.png](Images/Tutorial01.CharacterCameraControls/img_40.png)](./Images/Tutorial01.CharacterCameraControls/img_40.png)

   [![img_42.png](Images/Tutorial01.CharacterCameraControls/img_42.png)](./Images/Tutorial01.CharacterCameraControls/img_42.png)

   [![img_43.png](Images/Tutorial01.CharacterCameraControls/img_43.png)](./Images/Tutorial01.CharacterCameraControls/img_43.png)

13. Under Project Settings -> Physics 2D -> Layer Collision Matrix Disable all and enable the Player -> Player Bounds collisions.

   [![img_114.png](Images/Tutorial01.CharacterCameraControls/img_114.png)](Images/Tutorial01.CharacterCameraControls/img_114.png)

# Controls Setup

1. In the `Application` folder, create a folder called `Input`

   [![img_45.png](Images/Tutorial01.CharacterCameraControls/img_45.png)](./Images/Tutorial01.CharacterCameraControls/img_45.png)

2. Right click the `Input` folder, create an [InputActionsAsset](https://docs.unity3d.com/Packages/com.unity.inputsystem@0.9/manual/ActionAssets.html) and name it `InputActions.Controls`

   [![img_46.png](Images/Tutorial01.CharacterCameraControls/img_46.png)](./Images/Tutorial01.CharacterCameraControls/img_46.png)

   [![img_47.png](Images/Tutorial01.CharacterCameraControls/img_47.png)](./Images/Tutorial01.CharacterCameraControls/img_47.png)

3. Double click `InputActions.Controls` to [edit the InputActionAsset](https://docs.unity3d.com/Packages/com.unity.inputsystem@0.9/manual/ActionAssets.html#editing-input-action-assets) and create a new ActionMap called `PlayerControls` and an Action called `Move`.

   [![img_48.png](Images/Tutorial01.CharacterCameraControls/img_48.png)](./Images/Tutorial01.CharacterCameraControls/img_48.png)

4. Create a Control Scheme for Keyboard and mouse

   [![img_51.png](Images/Tutorial01.CharacterCameraControls/img_51.png)](./Images/Tutorial01.CharacterCameraControls/img_51.png)

   [![img_53.png](Images/Tutorial01.CharacterCameraControls/img_53.png)](./Images/Tutorial01.CharacterCameraControls/img_53.png)

   [![img_54.png](Images/Tutorial01.CharacterCameraControls/img_54.png)](./Images/Tutorial01.CharacterCameraControls/img_54.png)

   [![img_52.png](Images/Tutorial01.CharacterCameraControls/img_52.png)](./Images/Tutorial01.CharacterCameraControls/img_52.png)

5. Delete the pre-created binding and change the Action Properties under the Action section as follows:
   * Action Type: Value
   * Control Type: Vector2
   
   [![img_49.png](Images/Tutorial01.CharacterCameraControls/img_49.png)](./Images/Tutorial01.CharacterCameraControls/img_49.png)

6. Add an Up\Down\Left\Right composite binding to the move action and name it Arrows.

   [![img_55.png](Images/Tutorial01.CharacterCameraControls/img_55.png)](./Images/Tutorial01.CharacterCameraControls/img_55.png)

   [![img_56.png](Images/Tutorial01.CharacterCameraControls/img_56.png)](./Images/Tutorial01.CharacterCameraControls/img_56.png)

7. Set the paths of the up, down, left and right composites by using the listen for key button in the path dropdown and pressing the appropriate key.

   [![img_57.png](Images/Tutorial01.CharacterCameraControls/img_57.png)](./Images/Tutorial01.CharacterCameraControls/img_57.png)

   [![img_58.png](Images/Tutorial01.CharacterCameraControls/img_58.png)](./Images/Tutorial01.CharacterCameraControls/img_58.png)

8. Make sure to save the asset and close the InputActions window.

9. Add a [PlayerInput](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.5/manual/PlayerInput.html) component to the `Player` Container. Hook up the `InputActions.Controls` asset to the Actions field on the PlayerInput component and confirm the default map is set to Player.

   [![img_73.png](Images/Tutorial01.CharacterCameraControls/img_73.png)](./Images/Tutorial01.CharacterCameraControls/img_73.png)

# Visual Scripting Setup

1. Create a folder called `VisualScripting` in the `Application` folder.

   [![img_74.png](Images/Tutorial01.CharacterCameraControls/img_74.png)](./Images/Tutorial01.CharacterCameraControls/img_74.png)

2. Add a ScriptMachine component to the `Player` GameObject 

   [![img_76.png](Images/Tutorial01.CharacterCameraControls/img_76.png)](./Images/Tutorial01.CharacterCameraControls/img_76.png)

3. Temporarily switch the Source field on the ScriptMachine to `Embed`

   [![img_78.png](Images/Tutorial01.CharacterCameraControls/img_78.png)](./Images/Tutorial01.CharacterCameraControls/img_78.png)

4. Click the "Edit Graph" button and notice the "Script Graph" window appears and a VisualScripting SceneVariables GameObject is generated.

   [![img_81.png](Images/Tutorial01.CharacterCameraControls/img_81.png)](./Images/Tutorial01.CharacterCameraControls/img_81.png)

5. In the Blackboard of the of the Script Graph Window navigate to the App tab and Hit the + button next to the New Variable Name text field. Notice the ApplicationVariables asset has now been created in the project.

   [![img_115.png](Images/Tutorial01.CharacterCameraControls/img_115.png)](./Images/Tutorial01.CharacterCameraControls/img_115.png)

   [![img_82.png](Images/Tutorial01.CharacterCameraControls/img_82.png)](./Images/Tutorial01.CharacterCameraControls/img_82.png)

6. Switch the ScriptMachine component Source on the `Player` GameObject back to Graph.

   [![img_83.png](Images/Tutorial01.CharacterCameraControls/img_83.png)](./Images/Tutorial01.CharacterCameraControls/img_83.png)

7. Rename and move the autogenerated `VisualScripting SceneVariables` GameObject to `ApplicationSceneVariables` as shown.

   [![img_87.png](Images/Tutorial01.CharacterCameraControls/img_87.png)](./Images/Tutorial01.CharacterCameraControls/img_87.png)

# Logic

* To expedite the speed of creation of visual script graphs we will be using the using the [OnChain Studios File Templates](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md) package to generate visual script graphs. I'll be referencing this README frequently for steps to create script graphs throughout the tutorial.
* Additional Information on how to work with Visual Scripting can be found in the [Visual Scripting Unity Manual](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-script-graphs-intro.html)
* Logic is organized in folders based on the names of the GameObjects the script graphs are attached to. All common functionalities will live inside a folder called `Common`.

## Common Logic

Visual Script Graphs in the `Common` folder should not contain the Folder Name in their file names like visual scripts that belong to a GameObject as seen below.

1. Create a folder called `Common` in the `VisualScripting` folder.

   [![img_75.png](Images/Tutorial01.CharacterCameraControls/img_75.png)](./Images/Tutorial01.CharacterCameraControls/img_75.png)

### Method.MoveRigidBody2D

This method is used to move any GameObject with a RigidBody2D in a specified direction at a specified speed.

1. In the `Common` folder, create a [Method](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md#methods) called `Method.MoveRigidBody2D`

   [![img_116.png](Images/Tutorial01.CharacterCameraControls/img_116.png)](./Images/Tutorial01.CharacterCameraControls/img_116.png)

2. Add the [Trigger ports, Data ports](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-triggers-data-graph.html) and logic for this script graph as shown. Additional Documentation: [Add a node to a Script Graph Documentation](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-node-to-graph.html)

   [![img_117.png](Images/Tutorial01.CharacterCameraControls/img_117.png)](./Images/Tutorial01.CharacterCameraControls/img_117.png)

## Player Logic

The player logic will help capture input and move the player in the direction of that input.

1. Create a folder called `Player` in the `VisualScripting` folder.

   [![img_91.png](Images/Tutorial01.CharacterCameraControls/img_91.png)](./Images/Tutorial01.CharacterCameraControls/img_91.png)

### Configuration.Player.Controls

This configuration is used to store information about the Player Controls.

1. In the `Player` folder, Create a [Configuration](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md#configurations) called `Configuration.Player.Controls`

   [![img_92.png](Images/Tutorial01.CharacterCameraControls/img_92.png)](./Images/Tutorial01.CharacterCameraControls/img_92.png)

2. Add the [Trigger ports, Data ports](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-triggers-data-graph.html) and logic for this script graph as shown. Additional Documentation: [Add a node to a Script Graph Documentation](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-node-to-graph.html)

   [![img_93.png](Images/Tutorial01.CharacterCameraControls/img_93.png)](./Images/Tutorial01.CharacterCameraControls/img_93.png)

### Object.Get.[Type].BaseSpeed

1. Create an [Object Variable](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md#object-variables) getter for a BaseSpeed Object Variable as a float.

   [![img_118.png](Images/Tutorial01.CharacterCameraControls/img_118.png)](./Images/Tutorial01.CharacterCameraControls/img_118.png)

   [![img_119.png](Images/Tutorial01.CharacterCameraControls/img_119.png)](./Images/Tutorial01.CharacterCameraControls/img_119.png)

### Method.Player.GetMoveDirection

This method is used to get the move direction from the input.

1. In the `Player` folder, create a [Method](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md#methods) called `Method.Player.GetMoveDirection`.

   [![img_99.png](Images/Tutorial01.CharacterCameraControls/img_99.png)](./Images/Tutorial01.CharacterCameraControls/img_99.png)

2. Add the [Trigger ports, Data ports](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-triggers-data-graph.html) and logic for this script graph as shown. Additional Documentation: [Add a node to a Script Graph Documentation](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-node-to-graph.html)

   [![img_100.png](Images/Tutorial01.CharacterCameraControls/img_100.png)](./Images/Tutorial01.CharacterCameraControls/img_100.png)

### Behaviour.Player

This is the main behaviour of the player and handles how the player functions.

1. In the `Player` folder, create a [Behaviour](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md#behaviours) called `Behaviour.Player`.

   [![img_101.png](Images/Tutorial01.CharacterCameraControls/img_101.png)](./Images/Tutorial01.CharacterCameraControls/img_101.png)

2. Add the logic for this script graph as shown. Additional Documentation: [Add a node to a Script Graph Documentation](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.7/manual/vs-add-node-to-graph.html) 

   [![img_102.png](Images/Tutorial01.CharacterCameraControls/img_102.png)](./Images/Tutorial01.CharacterCameraControls/img_102.png)

3. Attach the `Behaviour.Player` to the `Player` GameObject's ScriptMachine component.

   [![img_103.png](Images/Tutorial01.CharacterCameraControls/img_103.png)](./Images/Tutorial01.CharacterCameraControls/img_103.png)

# Finish

Running the game in play mode should now allow you to move the character around the screen. 