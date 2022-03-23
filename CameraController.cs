using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;//We get transform component from "Player".

    private void Update()
    {
        //We equate the Main Camera's position with the components we get from the Player by creating a new Vector.
        //In this way, the Main Camera is always in the same position as the Player.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    }
}
