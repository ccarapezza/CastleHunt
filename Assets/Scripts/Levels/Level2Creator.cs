using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level2Creator : MonoBehaviour {

    public List<Vector3> gunItemPosition = new List<Vector3>();
    public GameObject gunPrefab;

    public List<Vector3> lifeItemPosition = new List<Vector3>();
    public GameObject lifePrefab;

    public List<Vector3> lavaPositions = new List<Vector3>();
    public GameObject lavaPrefab;

    public List<GameObject> prefabs = new List<GameObject>();

    public GameObject playerPrefab;

    // Use this for initialization
    void Start () {
        SoundManager.instance.Play(SoundID.BOSS_MUSIC, true, 0.2f, 0);
        loadGunsPosition();
        loadLifesItemPosition();
        loadLavasPosition();

        createPrefabs(prefabs);

        createPlayer();

        createPrefabsInPosition(gunPrefab, gunItemPosition);
        createPrefabsInPosition(lifePrefab, lifeItemPosition);
        createPrefabsInPosition(lavaPrefab, lavaPositions);

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void createPlayer() {
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(-6,-4,0);
    }

    void loadGunsPosition() {
        gunItemPosition.Add(new Vector3(-3.57f, -0.09f, 0f));
    }

    void loadLifesItemPosition()
    {
        lifeItemPosition.Add(new Vector3(2.56f, -5.2f, 0f));
    }

    void loadLavasPosition()
    {
        lavaPositions.Add(new Vector3(-7.11f, -8.01f, 0f));
        lavaPositions.Add(new Vector3(-3.56f, -8.01f, 0f));
        lavaPositions.Add(new Vector3(-0.01f, -8.01f, 0f));
        lavaPositions.Add(new Vector3(3.54f, -8.01f, 0f));
        lavaPositions.Add(new Vector3(7.09f, -8.01f, 0f));
    }

    void createPrefabsInPosition(GameObject prefab, List<Vector3> positions)
    {
        foreach (var position in positions)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.transform.position = position;
        }
    }

    void createPrefabs(List<GameObject> prefabs)
    {
        foreach (var prefab in prefabs)
        {
            Instantiate(prefab);
        }
    }
}
