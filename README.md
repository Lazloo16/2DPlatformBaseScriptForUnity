| Permanent Link | [2D Platform Scripts](https://github.com/Lazloo16/2DPlatformBaseScriptForUnity) |
| --- | :--- |
| Describe | Sample Unity Script For 2D Platform Game |

Frequently Asked Questions:

* **Is it Free?**(Absolutely *yes*. Here reposity [license](https://github.com/Lazloo16/2DPlatformBaseScriptForUnity/blob/main/LICENSE))
* **How can I use it**(You can download the scripts and import them *directly into Unity*. **For more** "[Information](#information)".)
* **What the Scripts contain**(Contains *simple*, *beginner-level* scripts. **For More** "[Scripts](#scripts)".)

###### NOTE: You must read [this](#important) part
###### This Scripts written in Unity v*2020.3.30f1* with Visual Studio *2019*

## Information <a id="information" />

You can download the scripts and transfer them *directly to unity*. Then **drag the scripts to the relevant objects**. <details><summary>Or</summary><p> **Right Click(on the assets folder) > Create > C# Script** and copy and paste the codes</p>
</details>
*What the codes do and how they work* are explained in the explanation lines.

###### Which script will be used where and what is required? <a id="important" />
[Camera Following](https://github.com/Lazloo16/2DPlatformBaseScriptForUnity/blob/main/CameraController.cs)
- Go to Unity and put the CameraController Script into your Camera object. Its default name is "Main Camera".
  - ![image](https://user-images.githubusercontent.com/100877570/159800461-dff86789-54f8-4b71-8d72-4330e31366fd.png)
  - Drag and drop your player object where it says 1 (in the "Player" section).
  - Now your camera always follow your player.

[Player Movement](https://github.com/Lazloo16/2DPlatformBaseScriptForUnity/blob/main/PlayerMovement.cs)
- Go to Unity and put the **PlayerMovement** Script into your **Player object**.
  - First you need to **add Rigidbody2D** component to your **character**. [More](https://docs.unity3d.com/ScriptReference/Rigidbody2D.html)
    - Add Component > Search "Rigidbody2D" > Add
  - Second, your character needs a **box collider**. Add that too, then set it. [More](https://docs.unity3d.com/Manual/class-BoxCollider2D.html)
    - Add Component > Searc "Box Collider2D" > Add
  - Now Let's make *other settings*
  - ![image](https://user-images.githubusercontent.com/100877570/159802283-9144d26f-fbc6-4f5e-bfbc-0ed099c8503a.png)
  - You can change jump power *where it says 1*
  - You can change move speed *where it says 2*
  - There will be places on which our *jump layer* character can occupy. Create a new layer and put it there. In the areas where you want the character to jump, select this layer from the Layer section.
    - Edit > Project Settings > Tags and Layers > Layers > Type Ground in a blank space
    - Now you can see the Ground here
    - ![image](https://user-images.githubusercontent.com/100877570/159802963-dd984bdb-cdfa-45eb-8f15-390aac2eb53f.png)
    - After, Choose Ground from the Layer section where you want your character to be able to jump. For example, we want it to jump on a Ground object >
    - ![image](https://user-images.githubusercontent.com/100877570/159803223-fba8596b-c6c8-4092-9ff8-68f748a01d5a.png)

If you did **everything right**, you can *run the game without any errors*!


## Scripts <a id="scripts" />

- [x] Camera Movement Script
- [x] Player Movement Script
- [ ] Player Animations
- [ ] Player Item Collector
- [ ] Player Life
