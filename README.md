# COM3D2.VRResolutionSetting.Plugin
 COM3D2 VR Resolution Setting Plugin


This plugin adds in-game rendering resolution and MSAA anti-aliasing settings for VR.

<br>

Using Virtual Desktop to play games but the image is blurry?

This plugin has been retired, please see the solution below to launch the game using Revive


<br>

This plugin adds in-game rendering resolution and MSAA anti-aliasing settings for VR.


## Usage
1. Install https://github.com/BepInEx/BepInEx.ConfigurationManager
2. Install COM3D2.VRResolutionSetting.Plugin
3. Jump in game
4. Press F1
5. Setting


<br>
<br>
<br>
<br>

## New Guide


So the game has two sets of VR SDKs: Oculus and OpenVR. Through decompilation, we know that the game uses the device name to decide which set of SDK to use.

In fact, the virtual desktop can allow the game to be launched in OculusRuntime mode. 

Even if it is launched from SteamVR mode, you can use Revive to make the game actually run in OculusRuntime mode, so as to get a better contorl experience. 

Launching the game with the game's VR ON switch will, as far as I know, always launch SteamVR, which causes the game to go into OpenVR mode.

The OpenVR controls in this game are really pain in the ass, so you should avoid them if possible.


To launch into Oculus Runtime mode, some additional steps are required.


Launch the game via Oculus Runtime -> Virtual Desktop
```
"C:\Program Files\Virtual Desktop Streamer\VirtualDesktop.Streamer.exe" "K:\maid\COM3D2\COM3D2x64.exe" /VR
```


But for Virtual Desktop, I recommend using Revive because using Oculus Runtime with Virtual Desktop can make the game appear blurry(Don't know why, even if in Godlike).
Launch the game via Oculus Runtime -> Revive -> OpenVR -> SteamVR -> Virtual Desktop
```
"C:\Program Files\Revive\ReviveInjector.exe" "K:\maid\COM3D2\COM3D2x64.exe" /VR
```



Even if you don't use Virtual Desktop or you use PC VR or PSVR, as long as your setup can run SteamVR, I still recommend that everyone use Revive to launch the game.
Launch the game via Oculus Runtime -> Revive -> OpenVR -> SteamVR -> PCVR software -> HMD
```
"C:\Program Files\Revive\ReviveInjector.exe" "K:\maid\COM3D2\COM3D2x64.exe" /VR
```



Revive lets you actually run the game in Oculus mode but translates it to OpenVR. 

So you get the Oculus mode for better control and the OpenVR extensions (custom resolutions, plugins, etc.) at the same time.

Install Revive according to the repository instructions: 

https://github.com/LibreVR/Revive

We launch the game directly from the command line, so you never actually have to open the Revive deck. 




Still not sure?

Control method comparison

OpenVR + Quest 3 Meta Quest Touch Plus Controllers

Key Binding                                                                                 | Function
------------------------------------------------------- |------------
Joystick (Press)                                                                          | Confirm
Grip Button                                                                                  | Toggle Tablet
A Button                                                                                        | Not sure what it does
B Button                                                                                         | Switch Tools
Left Trigger + Left Joystick (Forward/Backward)             | Horizontal Movement
Left Trigger + Left Joystick (Left/Right)                              | Rotate around a point
Right Trigger + Right Joystick (Forward/Backward)         | Vertical Movement

Oculus + Quest 3 Meta Quest Touch Plus Controllers

The key bindings are the same after using Revive.

Key Binding                       | Function
-------------------------|-----------
A Button                             | Confirm
B Button                              | Switch Tools
Right Joystick (move)     | First person movement in any direction
Right Joystick (Press)    | Toggle Tablet

I installed some plugins, so the movement may be slightly different

<br>
<br>
<br>


I also recommend installing some plugin

[GripMove plugin](https://ux.getuploader.com/scarletkom_mod/download/45)

It allows you to move by grabbing, and also allows you to operate IMGUI plugins (the black window ones)

ankokusamochi's Vibe Your Maid

https://x.com/ankokusamochi

It has some VR operation enhancements, such as jump to head (first person), locking the maid while dancing, etc.

ankokusamochi's VoiceShortcutManager

It allows you to use voice to operate some things, such as opening plugins, taking off the maid's clothes, executing yotogi commands, etc. (add English or other language keywords by yourself) 

よもぎ餅 (@ankokusamochi) on X
