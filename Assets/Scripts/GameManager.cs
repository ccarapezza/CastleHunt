using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public int level;
    public int difficult;
    public int lives;
    public int diamonds;

    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
