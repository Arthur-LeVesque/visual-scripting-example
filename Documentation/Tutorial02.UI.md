# Tutorial 02 - UI

- [Overview](#overview)
- [Project Setup](#project-setup)
- [UI Documents Setup](#ui-documents-setup)
- [Logic](#logic)
  - [WARNING](#warning)
  - [Scene Variables](#scene-variables)
  - [Application Variables](#application-variables)
  - [Player.Behaviour](#playerbehaviour)
  - [Configurations](#configurations)
    - [Configuration.Main.InitialGameDataValues](#configurationmaininitialgamedatavalues)
    - [Configuration.Main.HUD](#configurationmainhud)
    - [Configuration.Main.LevelSelect](#configurationmainlevelselect)
    - [Configuration.Main.PauseMenu](#configurationmainpausemenu)
    - [Configuration.Main.TitleScreen](#configurationmaintitlescreen)
  - [Methods](#methods)
    - [Method.Main.ResetGameData](#methodmainresetgamedata)
    - [Method.Main.SetActiveLevelContainer](#methodmainsetactivelevelcontainer)
    - [Method.Main.SetActiveLevelSelect](#methodmainsetactivelevelselect)
    - [Method.Main.SetActivePauseMenu](#methodmainsetactivepausemenu)
    - [Method.Main.SetActiveTitleScreen](#methodmainsetactivetitlescreen)
  - [State Machine](#state-machine)
    - [StateMachine.Main](#statemachinemain)
    - [Transitions and States](#transitions-and-states)
    - [Hooking up the State Machine](#hooking-up-the-state-machine)
      - [State.Main.Initialize](#statemaininitialize)
      - [State.Main.TitleScreen](#statemaintitlescreen)
      - [State.Main.LevelSelect](#statemainlevelselect)
    - [SuperState.Main.Level](#superstatemainlevel)
      - [State.Main.Level.Intro](#statemainlevelintro)
      - [State.Main.Level.Play](#statemainlevelplay)
      - [State.Main.Level.Outro](#statemainleveloutro)
      - [State.Main.Level.Pause](#statemainlevelpause)
- [Finish](#finish)

# Overview

In this tutorial we will build out some basic UI and functionalities for a game including a Title Screen, Level Select, Game HUD and Pause Menu.

# Project Setup

1. Import the OnChainStudios UIToolkitExtensions package through the Package Manager using the following URL and regenerate nodes.

   https://github.com/onchainstudios/onchainstudios-unity-extensions.git?path=/Packages/com.onchainstudios.uitoolkitextensions#v0.7.0-preview.15

2. Add onchainstudios.uitoolkitextensions.runtime to the Node Library in Project Settings->Visual Scripting->Node Library  

   [![img.png](Images/Tutorial02.UI/img.png)](./Images/Tutorial02.UI/img.png)

3. Add VisualElement to the Project Settings->Visual Scripting->Type Options list. 

   [![img_1.png](Images/Tutorial02.UI/img_1.png)](./Images/Tutorial02.UI/img_1.png)

4. Regenerate Nodes in Project Settings->Visual Scripting

   [![img_2.png](Images/Tutorial02.UI/img_2.png)](./Images/Tutorial02.UI/img_2.png)

5. In the InputActions.Controls asset, create a new Action Map called MenuControls and add an action "Pause" mapped to the "Escape" key.

   [![img.png](Images/Tutorial02.UI/img_55.png)](./Images/Tutorial02.UI/img_55.png)

   [![img_3.png](Images/Tutorial02.UI/img_3.png)](./Images/Tutorial02.UI/img_3.png)

# UI Documents Setup

Unity's UIBuilder is a very versital toolset. An introduction to it can be found at the [UIBuilder getting started menual](https://docs.unity3d.com/Manual/UIB-getting-started.html).
Additionally the UI toolkit manual can be found here [UIToolkit Manual](https://docs.unity3d.com/Manual/UIElements.html)

1. Create the following folder structures in the Project
   1. Assets->Application->UI->PanelSettings
   2. Assets->Application->UI->UIDocuments

   [![img_4.png](Images/Tutorial02.UI/img_4.png)](./Images/Tutorial02.UI/img_4.png)

2. Create a [PanelSettings asset](https://docs.unity3d.com/Manual/UIE-Runtime-Panel-Settings.html) in the PanelSettings folder called `PanelSettings.Global`. This file is used to determine how your UI will react to resolution changes.

   [![img_5.png](Images/Tutorial02.UI/img_5.png)](./Images/Tutorial02.UI/img_5.png)

3. Set the properties of the panel settings as follows.

   [![img_6.png](Images/Tutorial02.UI/img_6.png)](./Images/Tutorial02.UI/img_6.png)

4. Drag and drop the 4 [UIDocuments](https://docs.unity3d.com/ScriptReference/UIElements.UIDocument.html) provided in the [Materials/Tutorial02.UI](Materials/Tutorial02.UI) folder into the UIDocuments Folder. The [UIBuilder](https://docs.unity3d.com/Manual/UIBuilder.html) is a very robust UI System and has incredible documentation. Learn more to come up with your own cool UI's!

   [![img_8.png](Images/Tutorial02.UI/img_8.png)](./Images/Tutorial02.UI/img_8.png)

5. Double click a UIDocument to open it up and notice the inline styles and attributes show up in bold if they have been modified.

   [![img_18.png](Images/Tutorial02.UI/img_18.png)](./Images/Tutorial02.UI/img_18.png)

   [![img_19.png](Images/Tutorial02.UI/img_19.png)](./Images/Tutorial02.UI/img_19.png)

   [![img_20.png](Images/Tutorial02.UI/img_20.png)](./Images/Tutorial02.UI/img_20.png)

5. To create your own UIDocuments, Right click a folder to create them.
   
   [![img_7.png](Images/Tutorial02.UI/img_7.png)](./Images/Tutorial02.UI/img_7.png)

6. In the Scene Hierarchy create 4 new GameObject and attach the `UIDocument` and [UIDocumentEventBusBridge](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.uitoolkitextensions/Documentation#ui-document-event-bus-bridge). Hook Up their respective PanelSettings, UIDocuments and set their sort orders accordingly.

   [![img_9.png](Images/Tutorial02.UI/img_9.png)](./Images/Tutorial02.UI/img_9.png)
   
   [![img_10.png](Images/Tutorial02.UI/img_10.png)](./Images/Tutorial02.UI/img_10.png)
   
   [![img_11.png](Images/Tutorial02.UI/img_11.png)](./Images/Tutorial02.UI/img_11.png)
   
   [![img_12.png](Images/Tutorial02.UI/img_12.png)](./Images/Tutorial02.UI/img_12.png)

# Logic

## WARNING

When working with a team you should always make sure to set the Source of a [ScriptMachine or StateMachine](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.8/manual/vs-graph-machine-types.html) component to `Graph` to make sure working with your team goes smoothly. If you work on the same `ScriptGraph` or `StateMachine` as another person and check it into github it will result in merge conflicts and this will be nearly impossible to resolve just like any other unity asset (like scenes) and someone will have to redo their work.

## Scene Variables

Add the following [Scene Variables](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#scene-variables) to the project. These scene variables are references to the GameObjects in the scene. They allow us to access them in any `ScriptMachine` or `StateMachine` on any GameObject in the Scene to interact with or manipulate them.

[![img_21.png](Images/Tutorial02.UI/img_21.png)](./Images/Tutorial02.UI/img_21.png)

## Application Variables

Make sure you have the following [Application Variables](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#application-variables) in your project.

* WorldSpeed will be used to manipulate the speed of the world as the player is passing through it.
* IsPaused will be used to check if the game is paused and prevent player and world movement.
* Current Score will be used to track the current score of the player and display it in a scoreboard.

[![img_22.png](Images/Tutorial02.UI/img_22.png)](./Images/Tutorial02.UI/img_22.png)

## Player.Behaviour

1. Update the Player.Behaviour script to check if the game is paused before capturing and applying the movement. Also refactor the capture of the input to only be in the update loop.

   [![img_23.png](Images/Tutorial02.UI/img_23.png)](./Images/Tutorial02.UI/img_23.png)

## Configurations

Create the following [Configurations](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#configurations)

### Configuration.Main.InitialGameDataValues

This configuration will hold the initial game state values so we can easily reference them to reset the game.

   [![img_32.png](Images/Tutorial02.UI/img_32.png)](./Images/Tutorial02.UI/img_32.png)

### Configuration.Main.HUD

This configuration holds the information about the `UIDocument.HUD` for easy reference when trying to interface with it in visual scripting.

   [![img_31.png](Images/Tutorial02.UI/img_31.png)](./Images/Tutorial02.UI/img_31.png)

### Configuration.Main.LevelSelect

This configuration holds the information about `UIDocument.LevelSelect` for easy reference when trying to interface with it in visual scripting.

   [![img_33.png](Images/Tutorial02.UI/img_33.png)](./Images/Tutorial02.UI/img_33.png)

### Configuration.Main.PauseMenu

This configuration holds the information about the `UIDocument.PauseMenu` for easy reference when trying to interface with it in visual scripting.

   [![img_34.png](Images/Tutorial02.UI/img_34.png)](./Images/Tutorial02.UI/img_34.png)

### Configuration.Main.TitleScreen

This configuration holds the information about the `UIDocument.TitleScreen` for easy reference when trying to interface with it in visual scripting.

   [![img_35.png](Images/Tutorial02.UI/img_35.png)](./Images/Tutorial02.UI/img_35.png)

## Methods

Create the following [Methods](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#methods)

### Method.Main.ResetGameData

This method will allow us to easily reset the game data whenever we need to and can be updated as we add more game specific data.

   [![img_37.png](Images/Tutorial02.UI/img_37.png)](./Images/Tutorial02.UI/img_37.png)

### Method.Main.SetActiveLevelContainer

This method will allow us to activate and deactivate the `LevelContainer` GameObject whenever we start a game or end it.

   [![img_38.png](Images/Tutorial02.UI/img_38.png)](./Images/Tutorial02.UI/img_38.png)

### Method.Main.SetActiveLevelSelect

This method will allow us to activate and deactivate the `LevelSelect` GameObject whenever we enter or leave the level select menu.

   [![img_39.png](Images/Tutorial02.UI/img_39.png)](./Images/Tutorial02.UI/img_39.png)

### Method.Main.SetActivePauseMenu

This method will allow us to activate and deactivate the `PauseMenu` GameObject whenever the game is paused or unpaused.

   [![img_40.png](Images/Tutorial02.UI/img_40.png)](./Images/Tutorial02.UI/img_40.png)

### Method.Main.SetActiveTitleScreen

This method will allow us to activate and deactivate the `LevelContainer` GameObject when we enter or leave the title screen menu.

   [![img_41.png](Images/Tutorial02.UI/img_41.png)](./Images/Tutorial02.UI/img_41.png)

## State Machine

### StateMachine.Main

`StateMachine.Main` is the main Finite State Machine that will run the application. We will be doing the all of the flow through the app with this state machine.
Documentation on state machines can be found [here](https://docs.unity3d.com/Packages/com.unity.visualscripting@1.8/manual/vs-graph-machine-types.html).

1. Create a folder in the Assets->Application->Visual Scripting folder called `Main`

   [![img_24.png](Images/Tutorial02.UI/img_24.png)](./Images/Tutorial02.UI/img_24.png)

2. In the `Main` folder, create a [State Machine](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#state-machines).

   [![img_25.png](Images/Tutorial02.UI/img_25.png)](./Images/Tutorial02.UI/img_25.png)

   [![img_26.png](Images/Tutorial02.UI/img_26.png)](./Images/Tutorial02.UI/img_26.png)

### Transitions and States

In the following steps we will be creating empty [States], [Transitions] and [SuperStates]. These assets will provide the basic scaffolding for our `StateMachine` which we will fill out later with Methods and other various nodes.  

1. In the `Main` folder, create the following [States](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#states) and [Transitions](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#transitions) for the state machine.

   * State.Main.Initialize: Where we will initialize the program.
   * State.Main.LevelSelect: Where we show the `UIDocument.LevelSelect` menu to allow the player to select a level.
   * State.Main.TitleScreen: Where we show the `UIDocument.TitleScreen` after initialization.
   * Transitions: Transitions are used to traverse the States. Once hooked up, you can use the Transition.Trigger in a state hooked up to the transition to move through the state machine.

   [![img_27.png](Images/Tutorial02.UI/img_27.png)](./Images/Tutorial02.UI/img_27.png)

2. In the Assets-Application->VisualScripting->Main folder create the `SuperStates->Level` folder.

   [![img_28.png](Images/Tutorial02.UI/img_28.png)](./Images/Tutorial02.UI/img_28.png)

3. Create the SuperState.Level By right clicking the `Level` folder, create the SuperState.Main.Level [SuperState](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#super-states)

    `SuperState.Level` is a sub state machine that will reside inside the `StateMachine.Main`. This allows us to exit this SuperState from any State within the SuperState StateMachine.

   [![img_29.png](Images/Tutorial02.UI/img_29.png)](./Images/Tutorial02.UI/img_29.png)

4. Inside the `Level` folder, create the following [States](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#states) and [Transitions](https://github.com/onchainstudios/onchainstudios-unity-extensions/tree/development/Packages/com.onchainstudios.filetemplates/Documentation#transitions).

   [![img_30.png](Images/Tutorial02.UI/img_30.png)](./Images/Tutorial02.UI/img_30.png)

### Hooking up the State Machine

1. Create a GameObject called `Main` in the Hierarchy and hook up StateMachine.Main to it using the State Machine component. Also hook up the PlayerInput component and set the default map to MenuControls.

   [![img_46.png](Images/Tutorial02.UI/img_46.png)](./Images/Tutorial02.UI/img_46.png)

2. Setup `StateMachine.Main`.

   1. Notice `State.Main.Initialize` has a green bar on top of it. This is the entry state. When you add it, make sure to right click `State.Main.Initialize` to toggle it as the start state.

      [![img_56.png](Images/Tutorial02.UI/img_56.png)](./Images/Tutorial02.UI/img_56.png)

   2. When adding transitions, right click the state you are transitioning from and select Make Transition. Transitions are named at the end with the name of the state they are going to so when hooking up the transitions you will drag the transition state with the same name as the direction of the arrow.

      [![img_57.png](Images/Tutorial02.UI/img_57.png)](./Images/Tutorial02.UI/img_57.png)
   
      [![img_45.png](Images/Tutorial02.UI/img_45.png)](./Images/Tutorial02.UI/img_45.png)

   3. Setup the main state machine to create the basic flow of the program.

      [![img_44.png](Images/Tutorial02.UI/img_44.png)](./Images/Tutorial02.UI/img_44.png)

#### State.Main.Initialize

Fill out as follows. In `State.Main.Initialize` we are initializing the program to make sure all of the UI and Level Game objects are deactivated. This is also a good place to load saved data if you don't support multiple save files which is common in mobile development.

[![img_47.png](Images/Tutorial02.UI/img_47.png)](./Images/Tutorial02.UI/img_47.png)

#### State.Main.TitleScreen

Fill out as follows. In `State.Main.TitleScreen` we are showing the title screen on enter and waiting for the player to click one of the buttons to either move forward or quit.

[![img_48.png](Images/Tutorial02.UI/img_48.png)](./Images/Tutorial02.UI/img_48.png)

#### State.Main.LevelSelect

Fill out as follows. In `State.Main.LevelSelect` we are showing the level select menu and waiting for a level button or the back button to be pressed to transition. When a level button is pressed, we reset the game data to make sure we have a fresh game.

[![img_49.png](Images/Tutorial02.UI/img_49.png)](./Images/Tutorial02.UI/img_49.png)

### SuperState.Main.Level

Fill out as follows. `SuperState.Main.Level` is the main state machine for the gameplay of the game.

[![img_50.png](Images/Tutorial02.UI/img_50.png)](./Images/Tutorial02.UI/img_50.png)

#### State.Main.Level.Intro

Fill out as follows. `State.Main.Level.Intro` is the main entry point of `SuperState.Main.Level`. For now we just show the `LevelContainer` but you could also put in some intro animations or anything you want to setup your level before allowing gameplay.

[![img_51.png](Images/Tutorial02.UI/img_51.png)](./Images/Tutorial02.UI/img_51.png)

#### State.Main.Level.Play

Fill out as follows. In `State.Main.Level.Play` we play the level, allow pausing and will be updating live hud elements.

[![img_52.png](Images/Tutorial02.UI/img_52.png)](./Images/Tutorial02.UI/img_52.png)

#### State.Main.Level.Outro

Fill out as follows. `State.Main.Level.Outro` is where you naturally exit the game. You could do things like show a celebration screen here and then exit the level.

[![img_53.png](Images/Tutorial02.UI/img_53.png)](./Images/Tutorial02.UI/img_53.png)

#### State.Main.Level.Pause

Fill out as follows. `State.Main.Level.Pause` is where you pause the game. We also allow the player to exit the level or continue.

[![img_54.png](Images/Tutorial02.UI/img_54.png)](./Images/Tutorial02.UI/img_54.png)

# Finish

You should now be able to run the game and traverse the menus. Additionally, hitting esc while in the "Level" will prevent the player from moving while "Paused".