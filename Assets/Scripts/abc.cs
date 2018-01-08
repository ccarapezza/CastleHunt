using UnityEngine;
using System.Collections;

public class abc : MonoBehaviour {

    public GameObject[] list;

	// Use this for initialization
	void Start () {
        string a=null;
        foreach (var item in list)
        {
            a += item.transform.position + "\n";
        }
        print(a);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
