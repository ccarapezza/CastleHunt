using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level0Creator : MonoBehaviour {

    private List<Vector3> flamesPositions = new List<Vector3>();
    public GameObject flamePrefab;

    private List<Vector3> enemies1Positions = new List<Vector3>();
    public GameObject enemy1Prefab;

    private List<Vector3> enemies2Positions = new List<Vector3>();
    public GameObject enemy2Prefab;

    public List<Vector3> gunItemPosition = new List<Vector3>();
    public GameObject gunPrefab;

    public List<GameObject> prefabs;

    public GameObject playerPrefab;

    // Use this for initialization
    void Start () {
        SoundManager.instance.Play(SoundID.GAME, true, 0.2f, 0);
        loadFlamesPositions();
        loadEnemies1Positions();
        loadEnemies2Positions();
        loadGunsPositions();
        createPlayer();

        createPrefabsInPosition(flamePrefab, flamesPositions);
        createPrefabsInPosition(enemy1Prefab, enemies1Positions);
        createPrefabsInPosition(enemy2Prefab, enemies2Positions);
        createPrefabsInPosition(gunPrefab, gunItemPosition);
        createPrefabs(prefabs);

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

    public void createPlayer()
    {
        GameObject player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(-7.59f, -2.81f, 0);
    }



    void loadGunsPositions()
    {
        gunItemPosition.Add(new Vector3(25.66f, -1.09741f, 0.0f));
    }

        void loadEnemies1Positions()
    {
        enemies1Positions.Add(new Vector3(3.78215f, -2.9f, 0.0f));
        enemies1Positions.Add(new Vector3(32.54886f, -2.9f, 0.0f));
    }

    void loadEnemies2Positions()
    {
        enemies2Positions.Add(new Vector3(19.05448f, -2.9f, 0.0f));
        enemies2Positions.Add(new Vector3(29.95692f, -2.9f, 0.0f));
    }

    void loadFlamesPositions()
    {
        flamesPositions.Add(new Vector3(-8.5f, -0.2f, 0.0f));
        flamesPositions.Add(new Vector3(0.1f, -2.2f, 0.0f));
        flamesPositions.Add(new Vector3(40.0f, -0.6f, 0.0f));
        flamesPositions.Add(new Vector3(23.4f, -0.6f, 0.0f));
        flamesPositions.Add(new Vector3(22.1f, -0.6f, 0.0f));
        flamesPositions.Add(new Vector3(32.9f, 3.8f, 0.0f));
        flamesPositions.Add(new Vector3(31.7f, 3.7f, 0.0f));
        flamesPositions.Add(new Vector3(34.9f, 0.4f, 0.0f));
        flamesPositions.Add(new Vector3(29.0f, 0.4f, 0.0f));
        flamesPositions.Add(new Vector3(15.3f, -0.6f, 0.0f));
        flamesPositions.Add(new Vector3(15.0f, -0.7f, 0.0f));
        flamesPositions.Add(new Vector3(15.5f, -0.7f, 0.0f));
        flamesPositions.Add(new Vector3(14.7f, 3.7f, 0.0f));
        flamesPositions.Add(new Vector3(15.9f, 3.8f, 0.0f));
        flamesPositions.Add(new Vector3(19.1f, 0.4f, 0.0f));
        flamesPositions.Add(new Vector3(19.3f, 0.3f, 0.0f));
        flamesPositions.Add(new Vector3(19.8f, 0.3f, 0.0f));
        flamesPositions.Add(new Vector3(20.0f, 0.4f, 0.0f));
        flamesPositions.Add(new Vector3(10.6f, 1.4f, 0.0f));
        flamesPositions.Add(new Vector3(10.9f, 1.3f, 0.0f));
        flamesPositions.Add(new Vector3(11.3f, 1.3f, 0.0f));
        flamesPositions.Add(new Vector3(11.5f, 1.4f, 0.0f));
        flamesPositions.Add(new Vector3(-3.8f, 3.7f, 0.0f));
        flamesPositions.Add(new Vector3(7.0f, -0.6f, 0.0f));
        flamesPositions.Add(new Vector3(6.8f, -0.7f, 0.0f));
        flamesPositions.Add(new Vector3(6.3f, -0.7f, 0.0f));
        flamesPositions.Add(new Vector3(1.6f, 0.8f, 0.0f));
        flamesPositions.Add(new Vector3(1.1f, 0.8f, 0.0f));
        flamesPositions.Add(new Vector3(1.3f, 0.9f, 0.0f));
        flamesPositions.Add(new Vector3(-2.6f, 3.8f, 0.0f));
    }
}
