# Hololens-visual
## Purpose
We want to help people use the HoloLens as a tool for data analysis. The project was launched as a collaboration between NYU-ITP and CITI-CTO

## Demo Scenes
The scenes are in the \_Demo Scenes folder

### Browse Scene
In this Scene, the user scans a graph marker from the physical world to generate a hologram tagged to the marker. We tagged a graph with each database and simulated this flow, which showcased the potential for seamless transition from real world to holographic objects. This scene was build into a separate application. Below is a screenshot of TransitionScene:
### Comparison Scene
The second and the entry scene to our main application is the WelcomeScene. Here the user can see the scanned DataSets as Holographic objects. The user can drag and drop any object on top of another which will trigger an action which will reposition the objects based on their similarity. The user can then give a voice command to transition into the next scene, which delves into the details of the highlighted dataset objects.
### Details Scene
This this the final and most important scene of the application. Here the user can see all the column details of the two datasets.

## How to Deploy
1. *Export to the Visual Studio solution*
```
Open File > Build Settings window.
Click Add Open Scenes to add the scene.
Change Platform to Windows Store and click Switch Platform.
In Windows Store settings ensure, SDK is Universal 10.
For Target device, leave to Any Device for occluded displays or switch to HoloLens.
UWP Build Type should be D3D.
UWP SDK could be left at Latest installed.
Check Unity C# Projects under Debugging.
Click Build.
In the file explorer, click New Folder and name the folder "App".
With the App folder selected, click the Select Folder button.
When Unity is done building, a Windows File Explorer window will appear.
Open the App folder in file explorer.
Open the generated Visual Studio solution
```

2. *Compile the Visual Studio solution*
```
Using the top toolbar in Visual Studio, change the target from Debug to Release and from ARM to X86.
The instructions differ for deploying to a device versus the emulator. Follow the instructions that match your setup.
```

3. *Deploy to mixed reality device over Wi-Fi*
```
Click on the arrow next to the Local Machine button, and change the deployment target to Remote Machine.
Enter the IP address of your mixed reality device and change Authentication Mode to Universal (Unencrypted Protocol) for HoloLens and Windows for other devices.
Click Debug > Start without debugging.
For HoloLens, If this is the first time deploying to your device, you will need to pair Using Visual Studio.
```

4. *Deploy to mixed reality device over USB*
```
Ensure you device is plugged in via the USB cable.
For HoloLens, click on the arrow next to the Local Machine button, and change the deployment target to Device.
For targeting occluded devices attached to your PC, keep the setting to Local Machine. Ensure you have the Mixed Reality Portal running.
Click Debug > Start without debugging.
```

5. *Deploy to Emulator*
```
Click on the arrow next to the Device button, and from drop down select HoloLens Emulator.
Click Debug > Start without debugging.
```

## Contents
This repository contains reusable components, samples and tools aimed to make it easier to use HoloLens as a tool for for data analysis and visualization

### Assets

**AzureServicesForUnity:** Asset to integrate Azure service

**Chart and Graph:** Asset to build graphs easier
**Editor:** Editor Interface in unity to graphs

**HoloToolkit-Gesture:** Asset for Gesture tools from  Microsoft HoloToolkit

**HoloToolkit:** Asset for tools from  Microsoft HoloToolkit

**Holograms:** Default holograms from  Microsoft HoloToolkit

**Prefab:** GameObject presets for setting up hololens feature enabled scene

**Resources:** Includes all the resources to build

**Scripts:** customized scripts for gameobjects

**StreamingAssets:** sqlite database

**TextMesh Pro:** Asset for better text display

**_Demo Scenes:** Scenes for demo

### ProjectSettings
* This folder stores the unity parameters for the project.
* Changes can be made within using unity under edit > Project Settings


