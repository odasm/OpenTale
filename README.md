# OpenTale
### PoC of an Cross Platform Open Source NosTale Client
This repo will hold an Open Source Rewrite of the NosTale Client.

For now, proper handling of Packets is the main goal of this project. After we have finished the emulation of the current official feature set, we plan to implement a GUI and work on it. The client will use Unity3D as Graphic Engine

The aim of this Client is to bring a Wirkung NosTale Client to Non-Windows platforms and to probably even bring it to mobile devices(although there's no plan for it for now). It will make it possible to play the game on Linux and Mac OS X without Lags in DirectX and graphic Glitches in OGL.

## Roadmap
### 0.0.1
* NetCode implementation for Login
* Crypto for both, Login and World
* File-based Configuration System
### 0.0.2
* Basic World NetCode implementation
* Simple Map Rendering in Window(Walkable/Non-Walkable areas)
* Load Client Version and Hashes from Official Client
### 0.0.3
* Extended Map Rendering(Monsters, Friends, Family, Group...)
* Walk using rendered Map
* Complete World Packet Handling
### 0.0.4
* Decryption support for .NOS archives
### 0.0.5
* Move from the parially Headless Client to a fully featured GUI
* Implement basic Overlay GUI
### 0.0.6
* Expand Map Renderer to display Assets
### 0.0.7
* Entity Rendering
### 0.0.8
* Skill Rendering
### 0.0.9
* Launcher containing a Patch Utility based on libgamepatch
### 0.1.0
* Optimization
* First official prebuilt-release
* Contains all features to play most parts of the game
### 0.1.1
* Minigames
### 0.1.2
* to be continued

## Contributing
For Contributing, you need to have the following Software installed:
* Unity Engine 5 with Support for Linux, OS X and WebGL
* Visual Studio 2015
* A working installation of OpenNos(for NetCode debugging), which requires MSSQL 
* Probably a ton of other Software I forgot about right now
If you have done something, please open a Pull Request to get your edits merged to this repo. Pay attention that you follow some basic Guidelines while committing and programming.

Please do not file an issue if you're not on the latest commit. If you do nevertheless, your issue will be closed without any help.