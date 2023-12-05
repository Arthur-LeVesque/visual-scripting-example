# Tutorial 03 - Levels

- [Overview](#overview)
- [Setup Level Prefabs](#setup-level-prefabs)
- [Visual Scripting](#visual-scripting)
  - [Application Variables](#application-variables)
  - [Scene Variables](#scene-variables)
  - [Configuration.Resources](#configurationresources)
  - [Object.\[Type\].Level.PlayTime](#objecttypelevelplaytime)
  - [Method.Main.SpawnLevel](#methodmainspawnlevel)
  - [Configuration.Main.LevelSelect](#configurationmainlevelselect)
  - [Method.Main.ResetGameData](#methodmainresetgamedata)
  - [State.Main.LevelSelect](#statemainlevelselect)
  - [State.Main.Level.Intro](#statemainlevelintro)
  - [State.Main.Level.Play](#statemainlevelplay)
  - [State.Main.Level.Outro](#statemainleveloutro)
- [Finish](#finish)

# Overview

This tutorial serves as a starting point for spawning and destroying levels upon level select.

# Setup Level Prefabs

1. Create an empty GameObject in the scene and call it Level1 and make it a [Prefab](https://docs.unity3d.com/Manual/Prefabs.html) by dragging it into a folder Assets->Resources->Prefabs->Levels. This prefab will serve as the container for all of the Level1 content.

    [![img.png](Images/Tutorial03.Levels/img.png)](Images/Tutorial03.Levels/img.png)

2. Delete the Level1 GameObject out of the scene.

    [![img_1.png](Images/Tutorial03.Levels/img_1.png)](Images/Tutorial03.Levels/img_1.png)

3. You can double click the Level1 Prefab to open it and add any GameObjects you want. Including backgrounds, Sprites, Spawners, Enemies etc.

    [![img_2.png](Images/Tutorial03.Levels/img_2.png)](Images/Tutorial03.Levels/img_2.png)

# Visual Scripting

## Application Variables

Add the `SelectedLevel` and `ElapsedLevelTime` application variables.

`SelectedLevel` will allow the player to select a level prefab that will spawn when that level button is pressed.

[![img_18.png](Images/Tutorial03.Levels/img_18.png)](Images/Tutorial03.Levels/img_18.png)

`ElapsedLevelTime` will allow us to keep track of how long we have been inside a level and exit when the time has reached a certain threshold.

[![img_19.png](Images/Tutorial03.Levels/img_19.png)](Images/Tutorial03.Levels/img_19.png)

## Scene Variables

Create a scene variable `SpawnedLevel` to hold a handle to the level we will spawn later.

[![img_24.png](Images/Tutorial03.Levels/img_24.png)](Images/Tutorial03.Levels/img_24.png)

[![img_25.png](Images/Tutorial03.Levels/img_25.png)](Images/Tutorial03.Levels/img_25.png)

## Configuration.Resources

Create a configuration in the Common folder called `Configuration.Resources`. This will help us define where the prefabs live in order to load them without having to have direct handles to them.

[![img_11.png](Images/Tutorial03.Levels/img_11.png)](Images/Tutorial03.Levels/img_11.png)

[![img_12.png](Images/Tutorial03.Levels/img_12.png)](Images/Tutorial03.Levels/img_12.png)

## Object.[Type].Level.PlayTime

1. When opened, add a Variables Component to the Level1 Prefab and add a PlayTime Object Variable. This will allow us to set the PlayTime of the level Prefab to check when we should exit the level.

   [![img_13.png](Images/Tutorial03.Levels/img_13.png)](Images/Tutorial03.Levels/img_13.png)

1. Create a folder called "Level" under the main visual scripting folder.

   [![img_14.png](Images/Tutorial03.Levels/img_14.png)](Images/Tutorial03.Levels/img_14.png)

2. Create an Object Variable getter.

   [![img_15.png](Images/Tutorial03.Levels/img_15.png)](Images/Tutorial03.Levels/img_15.png)

3. Modify `Object.Get.Level.PlayTime` to take a GameObject Data Input to allow you to grab the value of play time off of the currently spawned level.

   [![img_21.png](Images/Tutorial03.Levels/img_21.png)](Images/Tutorial03.Levels/img_21.png)

## Method.Main.SpawnLevel

Create a new Method `Method.Main.SpawnLevel` This method is used to spawn a level residing the in path of the resources.

[![img_10.png](Images/Tutorial03.Levels/img_10.png)](Images/Tutorial03.Levels/img_10.png)

[![img_9.png](Images/Tutorial03.Levels/img_9.png)](Images/Tutorial03.Levels/img_9.png)

## Configuration.Main.LevelSelect

In the previously created `Configuration.Main.LevelSelect` script graph. Change the Level1ButtonName Key to `LevelButtonName` and change the string literal to `Level`. This is so we can select any level button and move forward.

[![img_3.png](Images/Tutorial03.Levels/img_3.png)](Images/Tutorial03.Levels/img_3.png)

## Method.Main.ResetGameData

Modify the `Method.Main.ResetGameData` to initialize the ElapsedLevelTime Application Variable.

[![img_20.png](Images/Tutorial03.Levels/img_20.png)](Images/Tutorial03.Levels/img_20.png)

## State.Main.LevelSelect

1. Fix the Level Select click event and set the `Match Rule' on the event node to `Visual Element Name Contains`.

[![img_5.png](Images/Tutorial03.Levels/img_5.png)](Images/Tutorial03.Levels/img_5.png)

[![img_4.png](Images/Tutorial03.Levels/img_4.png)](Images/Tutorial03.Levels/img_4.png)

2. Set the `SelectedLevel` application variable to the visual element name so you can spawn the level prefab using this name later.

[![img_8.png](Images/Tutorial03.Levels/img_8.png)](Images/Tutorial03.Levels/img_8.png)

## State.Main.Level.Intro

Spawn the level and set the `ApplicationSceneVariables.SpawnedLevel` to the spawned level game object.

[![img_17.png](Images/Tutorial03.Levels/img_17.png)](Images/Tutorial03.Levels/img_17.png)

## State.Main.Level.Play

Add the functionality to wait for the PlayTime of the spawned level and transition to the outro state.

[![img_22.png](Images/Tutorial03.Levels/img_22.png)](Images/Tutorial03.Levels/img_22.png)

## State.Main.Level.Outro

Cleanup the spawned level by destroying it and transition back to the level select.

[![img_23.png](Images/Tutorial03.Levels/img_23.png)](Images/Tutorial03.Levels/img_23.png)

# Finish

You should now be able to create any number of levels and spawn them based on the level select screen by creating more level buttons and level prefabs. 