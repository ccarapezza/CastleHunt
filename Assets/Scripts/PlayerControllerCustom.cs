using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Player))]
public class PlayerControllerCustom : MonoBehaviour {

    public Player royce;



	// Use this for initialization
	void Start ()
    {
        royce = GetComponent<Player>();

	}

    void Update() {
        if (royce.isDead) return;
        if (Input.GetKey(KeyCode.LeftArrow)) royce.Move(-1);
        else if (Input.GetKey(KeyCode.RightArrow)) royce.Move(1);
        else royce.DontMove();

        if (Input.GetKey(KeyCode.UpArrow)) royce.Up(true);
        else royce.Up(false);

        if (Input.GetKey(KeyCode.DownArrow)) royce.Down(true);
        else royce.Down(false);

        if (Input.GetKeyDown(KeyCode.Space)) royce.Jump();

        if (Input.GetKeyDown(KeyCode.A)) royce.Punch();

        if (Input.GetKeyDown(KeyCode.E)) royce.ExecuteAction();

        if (Input.GetKeyDown(KeyCode.F)) royce.Fire();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
    }
}
