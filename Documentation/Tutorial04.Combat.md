# Tutorial 04 - Combat

- [Overview](#overview)
- [Setup](#setup)
  - [Type Options](#type-options)
  - [InputActions](#inputactions)
  - [Player Game Object](#player-game-object)
  - [Bullet Prefabs](#bullet-prefabs)
- [Visual Scripting](#visual-scripting)
  - [Scene Variables](#scene-variables)
    - [Scene.\[Type\].ApplicationSceneVariables.Camera](#scenetypeapplicationscenevariablescamera)
  - [Common Object Variables](#common-object-variables)
    - [Object.\[Type\].Direction](#objecttypedirection)
  - [Common Methods](#common-methods)
    - [Method.IsRendererVisible](#methodisrenderervisible)
    - [Method.GetDirectionVector2FromAngle](#methodgetdirectionvector2fromangle)
    - [Method.SpawnDirectionalObject](#methodspawndirectionalobject)
    - [Method.FireCannon01](#methodfirecannon01)
    - [Method.FireCannon02](#methodfirecannon02)
    - [Method.FireCannon03](#methodfirecannon03)
    - [Method.FireWeapon](#methodfireweapon)
    - [Object.Get.Bullet.Speed](#objectgetbulletspeed)
    - [Behavior.Bullet](#behaviorbullet)
    - [Player Object Variables](#player-object-variables)
      - [Object.Player.\[Type\].CurrentWeapon](#objectplayertypecurrentweapon)
      - [Object.Player.\[Type\].BaseReloadDelay](#objectplayertypebasereloaddelay)
    - [Player.Behavior](#playerbehavior)
- [Finish](#finish)


# Overview

In this tutorial we will be adding a combat mechanic to fire a weapon when the player hits space bar.
Don't forget to reference the [OnChain Studios File Templates README](https://github.com/onchainstudios/onchainstudios-unity-extensions/blob/development/Packages/com.onchainstudios.filetemplates/Documentation/README.md) for creating new script graphs.

# Setup

## Type Options

Add the [GeometryUtility](https://docs.unity3d.com/ScriptReference/GeometryUtility.html) class to the Project Settings->Visual Scripting->Type Options. This will be used to destroy the bullets when they are no longer visible by the camera.

[![img.png](Images/Tutorial04.Combat/img.png)](Images/Tutorial04.Combat/img.png)

## InputActions

Add the `Fire` input action as a button so that the `Player.Behavior` will be able to fire bullets. Make sure to add the `Hold` [Interaction](https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Interactions.html).

[![img_25.png](Images/Tutorial04.Combat/img_25.png)](Images/Tutorial04.Combat/img_25.png)

[![img_26.png](Images/Tutorial04.Combat/img_26.png)](Images/Tutorial04.Combat/img_26.png)

## Player Game Object

1. Select the SortingLayer of the SpriteRenderer of the Player GameObject in the Hierarchy and add 2 new [Sorting Layers](https://docs.unity3d.com/ScriptReference/SortingLayer.html) `Weapons` and `Player` order matters so make sure Weapons is layer 1 and Player is layer 2. This will allow us to easily position the player above the bullets that are spawned.

    [![img_12.png](Images/Tutorial04.Combat/img_12.png)](Images/Tutorial04.Combat/img_12.png)

    [![img_13.png](Images/Tutorial04.Combat/img_13.png)](Images/Tutorial04.Combat/img_13.png)

    [![img_14.png](Images/Tutorial04.Combat/img_14.png)](Images/Tutorial04.Combat/img_14.png)

## Bullet Prefabs

1. Right click and create a Capsule in the scene.

   [![img_9.png](Images/Tutorial04.Combat/img_9.png)](Images/Tutorial04.Combat/img_9.png)

2. Rename the capsule to `Bullet000`, and attach the following components. Match your prefab to the image shown below. We will attach the `Behavior.Bullet` script graph later. 

   [![img_11.png](Images/Tutorial04.Combat/img_11.png)](Images/Tutorial04.Combat/img_11.png)

3. Create a prefab with `Bullet000` and duplicate the prefab 4 more times in the project view. Rename the new prefabs as shown and set their directions to the value of the bullet. IE Bullet006 has a direction of 6. 

   [![img_15.png](Images/Tutorial04.Combat/img_15.png)](Images/Tutorial04.Combat/img_15.png)

# Visual Scripting

## Scene Variables

### Scene.[Type].ApplicationSceneVariables.Camera

Add a SceneVariable getter to get the Camera used later to check if a Renderer is visible.

[![img_7.png](Images/Tutorial04.Combat/img_7.png)](Images/Tutorial04.Combat/img_7.png)

[![img_6.png](Images/Tutorial04.Combat/img_6.png)](Images/Tutorial04.Combat/img_6.png)

## Common Object Variables

### Object.[Type].Direction

Create the Get and Set methods for a Direction Object variable in the common folder.

[![img_3.png](Images/Tutorial04.Combat/img_3.png)](Images/Tutorial04.Combat/img_3.png)

After hooking up the VariableName Modify the `Object.Get.Direction` to include a GameObject to send in so we can use this to access the direction Object Variable of any GameObject. We will use this for bullets and enemies.

[![img_4.png](Images/Tutorial04.Combat/img_4.png)](Images/Tutorial04.Combat/img_4.png)

## Common Methods

### Method.IsRendererVisible

Create `Method.IsRendererVisible` to check if a renderer is visible by the camera.

[![img_1.png](Images/Tutorial04.Combat/img_1.png)](Images/Tutorial04.Combat/img_1.png)

### Method.GetDirectionVector2FromAngle

Create `Method.GetDirectionVector2FromAngle` to calculate a direction vector based on an angle. This will be used to convert angles to Vector2 in movement and setting rotation of objects.

[![img_2.png](Images/Tutorial04.Combat/img_2.png)](Images/Tutorial04.Combat/img_2.png)

### Method.SpawnDirectionalObject

Create `Method.SpawnDirectionalObject` to spawn an object we know has a Direction Object Variable on it. This allows us to spawn anything in relation to the GameObject spawner you are spawning from. So, if you rotate your player, the bullets will spawn in the correct direction of the player.

[![img_5.png](Images/Tutorial04.Combat/img_5.png)](Images/Tutorial04.Combat/img_5.png)

### Method.FireCannon01

Create `Method.FireCannon01` to spawn `Bullet000` when the method is called. By using `this` as the GameObject we can also allow enemies to fire the cannon. You can drag the prefab into the script graph for speed of creating the graph just like you can drag other script graphs into any other graph.

[![img_16.png](Images/Tutorial04.Combat/img_16.png)](Images/Tutorial04.Combat/img_16.png)

### Method.FireCannon02

Create `Method.FireCannon02` to spawn `Bullet006` and `Bullet354`.

[![img_17.png](Images/Tutorial04.Combat/img_17.png)](Images/Tutorial04.Combat/img_17.png)

### Method.FireCannon03

Create `Method.FireCannon03` to spawn `Bullet000` and `Bullet015` and `Bullet345`.

[![img_18.png](Images/Tutorial04.Combat/img_18.png)](Images/Tutorial04.Combat/img_18.png)

### Method.FireWeapon

Create `Method.FireWeapon` to switch on a string to decide which weapon to fire.

[![img_19.png](Images/Tutorial04.Combat/img_19.png)](Images/Tutorial04.Combat/img_19.png)

### Object.Get.Bullet.Speed

Create the Object Variable Getter for the Speed ObjectVariable on the bullet to use while moving the bullet.

[![img_20.png](Images/Tutorial04.Combat/img_20.png)](Images/Tutorial04.Combat/img_20.png)

[![img_21.png](Images/Tutorial04.Combat/img_21.png)](Images/Tutorial04.Combat/img_21.png)

### Behavior.Bullet

Create `Behavior.Bullet` to move itself if it is visible. Otherwise destroy it. Also attach `Bullet.Behavior` to all of the bullet prefabs.

[![img_22.png](Images/Tutorial04.Combat/img_22.png)](Images/Tutorial04.Combat/img_22.png)

[![img_23.png](Images/Tutorial04.Combat/img_23.png)](Images/Tutorial04.Combat/img_23.png)

### Player Object Variables

#### Object.Player.[Type].CurrentWeapon

Add the `CurrentWeapon` Object Variable to the player so that we can change out the weapon the player is using.

[![img_30.png](Images/Tutorial04.Combat/img_30.png)](Images/Tutorial04.Combat/img_30.png)

[![img_31.png](Images/Tutorial04.Combat/img_31.png)](Images/Tutorial04.Combat/img_31.png)

#### Object.Player.[Type].BaseReloadDelay

Add the `BaseReloadDelay` Object Variable to the player so that we can use the hold interaction on the fire weapon and prevent the player from spamming bullets.

[![img_32.png](Images/Tutorial04.Combat/img_32.png)](Images/Tutorial04.Combat/img_32.png)

[![img_33.png](Images/Tutorial04.Combat/img_33.png)](Images/Tutorial04.Combat/img_33.png)

### Player.Behavior

Update the `Player.Behaviour` to fire the CurrentWeapon when the fire action is pressed. Make sure to edit the `Player.Behavior` script by selecting the Player GameObject in the Hierarchy and clicking the "Edit Graph" button on the Script Machine component in the inspector or you may have difficulties Setting the Input Action on the `OnInputSystemEventButton` nodes. If you are still having issues, close Unity, reopen it and try again. If you still have issues after that, you may need to provide the `PlayerInput` component to the event nodes. The Modifier graph variables will be used later when we introduce powerups.

[![img_27.png](Images/Tutorial04.Combat/img_27.png)](Images/Tutorial04.Combat/img_27.png)

Make sure to set each of the `OnInputSystemEventButton` nodes to a Coroutine because the `WaitForSeconds` node is a [Time Unit](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.5/manual/vs-time.html) and requires the flow to be a Coroutine flow.

[![img_28.png](Images/Tutorial04.Combat/img_28.png)](Images/Tutorial04.Combat/img_28.png)

[![img_29.png](Images/Tutorial04.Combat/img_29.png)](Images/Tutorial04.Combat/img_29.png)

# Finish

You should now be able to play your game and fire the weapon. You can modify the PlayTime on the `Level1` prefab from the previous tutorial something longer than 3 seconds if you need to.

Additionally, you can modify the CurrentWeapon on the player game object to a different weapon to check out the other two weapons we created.