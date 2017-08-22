# Hololens-visual
## Purpose
We want to help people use the HoloLens as a tool for data analysis. The project was launched as a collaboration between NYU-ITP and CITI-CTO

## Demo Scenes
Learn how to build the project using Unity editor and using the scenes in the \_Demo Scenes folder to run

### Browse Scene
In this Scene, the user scans a graph marker from the physical world to generate a hologram tagged to the marker. We tagged a graph with each database and simulated this flow, which showcased the potential for seamless transition from real world to holographic objects. This scene was build into a separate application. Below is a screenshot of TransitionScene:
### Comparison Scene
The second and the entry scene to our main application is the WelcomeScene. Here the user can see the scanned DataSets as Holographic objects. The user can drag and drop any object on top of another which will trigger an action which will reposition the objects based on their similarity. The user can then give a voice command to transition into the next scene, which delves into the details of the highlighted dataset objects.
### Details Scene
This this the final and most important scene of the application. Here the user can see all the column details of the two datasets.

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


