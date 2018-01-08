using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level1Creator : MonoBehaviour {

    private List<Vector3> jewellsPositions = new List<Vector3>();
    public GameObject jewelPrefab;

    private List<Vector3> enemies1Positions = new List<Vector3>();
    public GameObject enemy1Prefab;

    private List<Vector3> enemies2Positions = new List<Vector3>();
    public GameObject enemy2Prefab;

    private List<Vector3> flamesPositions = new List<Vector3>();
    public GameObject flamePrefab;

    public List<Vector3> gunItemPosition = new List<Vector3>();
    public GameObject gunPrefab;

    public List<Vector3> lifeItemPosition = new List<Vector3>();
    public GameObject lifePrefab;

    public GameObject fondoMapaPrefab;
    public GameObject plataformasMapaPrefab;
    public GameObject escalerasMapaPrefab;
    public GameObject plataformaMovilPrefab;
    public GameObject pinchesMapaPrefab;
    public GameObject detallesMapaPrefab;
    public GameObject enemyLimitsMapaPrefab;

    public List<GameObject> escalerasPrefabs = new List<GameObject>();
    public List<GameObject> doorsPrefabs = new List<GameObject>();

    public GameObject leverPrefab;

    public GameObject endDoorPrefab;
    public GameObject playerPrefab;

    public Canvas canvasPrefab;

    public List<GameObject> enemies;

    // Use this for initialization
    void Awake() {
        Instantiate(canvasPrefab);

        loadInitialJewelPosition();
        loadEnemies1Positions();
        loadEnemies2Positions();
        loadInitialFlamesPosition();
        loadGunsPosition();
        loadLifesItemPosition();

        createMapPrefabs();
        Instantiate(playerPrefab);

        createPrefabs(escalerasPrefabs);
        createPrefabs(doorsPrefabs);
        createPrefabsInPosition(flamePrefab, flamesPositions);
        createPrefabsInPosition(jewelPrefab, jewellsPositions);
        createPrefabsInPosition(enemy1Prefab, enemies1Positions);
        createPrefabsInPosition(enemy2Prefab, enemies2Positions);
        createPrefabsInPosition(lifePrefab, lifeItemPosition);
        createPrefabsInPosition(gunPrefab, gunItemPosition);
    }

    void Start() {
        SoundManager.instance.Play(SoundID.GAME, true, 0.2f, 0);
    }

    void createMapPrefabs() {
        Instantiate(fondoMapaPrefab);
        Instantiate(plataformasMapaPrefab);
        Instantiate(escalerasMapaPrefab);
        Instantiate(plataformaMovilPrefab);
        Instantiate(pinchesMapaPrefab);
        Instantiate(detallesMapaPrefab);
        Instantiate(enemyLimitsMapaPrefab);
        Instantiate(leverPrefab);
        Instantiate(endDoorPrefab);
    }

    void createPrefabs(List<GameObject> prefabs)
    {
        foreach (var prefab in prefabs)
        {
            Instantiate(prefab);
        }
    }

    void createPrefabsInPosition(GameObject prefab, List<Vector3> positions)
    {
        foreach (var position in positions)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.transform.position = position;
        }
    }

    void loadLifesItemPosition()
    {
        lifeItemPosition.Add(new Vector3(23.04273f, 11.51079f, 0.0f));
    }

    void loadGunsPosition()
    {
        gunItemPosition.Add(new Vector3(16.09307f, 10.28438f, 0.0f));
    }

    void loadEnemies1Positions()
    {
        enemies1Positions.Add(new Vector3(-4.0f, 14.5f, 0.0f));
        enemies1Positions.Add(new Vector3(-1.0f, 7.0f, 0.0f));
        enemies1Positions.Add(new Vector3(15.0f, 0.0f, 0.0f));
        enemies1Positions.Add(new Vector3(23.0f, 6.5f, 0.0f));
        enemies1Positions.Add(new Vector3(28.0f, 6.5f, 0.0f));
        enemies1Positions.Add(new Vector3(6.0f, -1.0f, 0.0f));
    }

    void loadEnemies2Positions()
    {
        enemies2Positions.Add(new Vector3(24.0f, -3.0f, 0.0f));
        enemies2Positions.Add(new Vector3(15.0f, 14.0f, 0.0f));
        enemies2Positions.Add(new Vector3(26.0f, 6.5f, 0.0f));
        enemies2Positions.Add(new Vector3(29.0f, 10.0f, 0.0f));
        enemies2Positions.Add(new Vector3(11.0f, -3.5f, 0.0f));
        enemies2Positions.Add(new Vector3(3.0f, 3.5f, 0.0f));
    }

    void loadInitialJewelPosition() {
        jewellsPositions.Add(new Vector3(19.8f, -1.9f, 0.0f));
        jewellsPositions.Add(new Vector3(19.3f, -1.9f, 0.0f));
        jewellsPositions.Add(new Vector3(25.9f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(26.9f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(26.4f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(27.4f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(24.1f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(23.1f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(23.6f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(22.6f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(10.3f, -0.4f, 0.0f));
        jewellsPositions.Add(new Vector3(10.8f, -0.4f, 0.0f));
        jewellsPositions.Add(new Vector3(9.8f, -0.4f, 0.0f));
        jewellsPositions.Add(new Vector3(3.0f, 14.8f, 0.0f));
        jewellsPositions.Add(new Vector3(3.0f, 14.4f, 0.0f));
        jewellsPositions.Add(new Vector3(3.5f, 14.8f, 0.0f));
        jewellsPositions.Add(new Vector3(2.5f, 14.8f, 0.0f));
        jewellsPositions.Add(new Vector3(12.1f, 14.8f, 0.0f));
        jewellsPositions.Add(new Vector3(15.8f, 11.1f, 0.0f));
        jewellsPositions.Add(new Vector3(15.3f, 10.7f, 0.0f));
        jewellsPositions.Add(new Vector3(16.8f, 10.7f, 0.0f));
        jewellsPositions.Add(new Vector3(16.3f, 11.1f, 0.0f));
        jewellsPositions.Add(new Vector3(-0.3f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(0.2f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(0.7f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(1.2f, 8.8f, 0.0f));
        jewellsPositions.Add(new Vector3(15.2f, 6.3f, 0.0f));
        jewellsPositions.Add(new Vector3(15.7f, 6.3f, 0.0f));
        jewellsPositions.Add(new Vector3(15.2f, 5.8f, 0.0f));
        jewellsPositions.Add(new Vector3(15.7f, 5.8f, 0.0f));
        jewellsPositions.Add(new Vector3(0.5f, 5.4f, 0.0f));
        jewellsPositions.Add(new Vector3(1.0f, 5.4f, 0.0f));
        jewellsPositions.Add(new Vector3(1.5f, 5.4f, 0.0f));
        jewellsPositions.Add(new Vector3(2.0f, 5.4f, 0.0f));
        jewellsPositions.Add(new Vector3(2.0f, 1.0f, 0.0f));
        jewellsPositions.Add(new Vector3(2.0f, 0.6f, 0.0f));
        jewellsPositions.Add(new Vector3(0.5f, 1.0f, 0.0f));
        jewellsPositions.Add(new Vector3(0.5f, 0.6f, 0.0f));
        jewellsPositions.Add(new Vector3(1.0f, 1.0f, 0.0f));
        jewellsPositions.Add(new Vector3(1.0f, 0.6f, 0.0f));
        jewellsPositions.Add(new Vector3(1.5f, 0.6f, 0.0f));
        jewellsPositions.Add(new Vector3(1.5f, 1.0f, 0.0f));
        jewellsPositions.Add(new Vector3(7.5f, -2.0f, 0.0f));
    }

    void loadInitialFlamesPosition() {
        flamesPositions.Add(new Vector3(14.2f, 7.5f, 0.0f));
        flamesPositions.Add(new Vector3(1.8f, 2.5f, 0.0f));
        flamesPositions.Add(new Vector3(5.0f, -0.4f, 0.0f));
        flamesPositions.Add(new Vector3(3.5f, -1.9f, 0.0f));
        flamesPositions.Add(new Vector3(5.0f, -1.9f, 0.0f));
        flamesPositions.Add(new Vector3(14.2f, 2.1f, 0.0f));
        flamesPositions.Add(new Vector3(14.0f, 2.0f, 0.0f));
        flamesPositions.Add(new Vector3(14.5f, 2.0f, 0.0f));
        flamesPositions.Add(new Vector3(7.0f, 1.1f, 0.0f));
        flamesPositions.Add(new Vector3(8.5f, 1.1f, 0.0f));
        flamesPositions.Add(new Vector3(0.0f, 4.6f, 0.0f));
        flamesPositions.Add(new Vector3(2.5f, 4.6f, 0.0f));
        flamesPositions.Add(new Vector3(22.5f, 1.6f, 0.0f));
        flamesPositions.Add(new Vector3(27.6f, 4.1f, 0.0f));
        flamesPositions.Add(new Vector3(27.8f, 4.0f, 0.0f));
        flamesPositions.Add(new Vector3(28.2f, 4.0f, 0.0f));
        flamesPositions.Add(new Vector3(28.5f, 4.1f, 0.0f));
        flamesPositions.Add(new Vector3(31.0f, -3.4f, 0.0f));
        flamesPositions.Add(new Vector3(32.5f, -3.4f, 0.0f));
        flamesPositions.Add(new Vector3(30.1f, 14.6f, 0.0f));
        flamesPositions.Add(new Vector3(30.3f, 14.5f, 0.0f));
        flamesPositions.Add(new Vector3(30.7f, 14.5f, 0.0f));
        flamesPositions.Add(new Vector3(31.0f, 14.6f, 0.0f));
        flamesPositions.Add(new Vector3(12.2f, 16.0f, 0.0f));
        flamesPositions.Add(new Vector3(13.4f, 16.0f, 0.0f));
        flamesPositions.Add(new Vector3(-1.8f, 16.0f, 0.0f));
        flamesPositions.Add(new Vector3(-0.7f, 16.0f, 0.0f));
        flamesPositions.Add(new Vector3(-3.4f, 12.1f, 0.0f));
        flamesPositions.Add(new Vector3(-3.2f, 12.1f, 0.0f));
        flamesPositions.Add(new Vector3(-2.8f, 12.0f, 0.0f));
        flamesPositions.Add(new Vector3(-2.6f, 12.1f, 0.0f));
        flamesPositions.Add(new Vector3(2.0f, 9.6f, 0.0f));
        flamesPositions.Add(new Vector3(10.6f, 2.6f, 0.0f));
        flamesPositions.Add(new Vector3(10.8f, 2.6f, 0.0f));
        flamesPositions.Add(new Vector3(11.2f, 2.6f, 0.0f));
        flamesPositions.Add(new Vector3(11.5f, 2.6f, 0.0f));
        flamesPositions.Add(new Vector3(15.3f, 7.5f, 0.0f));
        flamesPositions.Add(new Vector3(0.7f, 2.5f, 0.0f));
    }

	// Update is called once per frame
	void Update () {
	
	}
}
