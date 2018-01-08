using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

    public int speed;
    public float maxX;
    public float minX;
    int direction;

    public void Start() {
        direction = 1;
    }

    public void Update ()
    {
        if (this.transform.position.x > maxX) {
            direction = -1;
        }

        if (this.transform.position.x < minX){
            direction = 1;
        }

        Vector3 newPosition = new Vector3(this.transform.position.x + speed * Time.deltaTime * direction, this.transform.position.y, this.transform.position.z);

        this.transform.position = newPosition;
	}

}
