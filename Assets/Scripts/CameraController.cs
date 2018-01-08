using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;

    void LoadPlayerObject() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (player == null) LoadPlayerObject();
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);

        transform.position = new Vector3(x, y, transform.position.z);
    }
}