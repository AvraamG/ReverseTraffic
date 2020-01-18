using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    private static CarManager _instance;
    public static CarManager Instance { get { return _instance; } }


    [SerializeField]
    GameObject[] spawnPoints;

    //There can only be 10 cars at a given time on the road
    int maxCarsNumber = 10;
    public int currentCarsOnRoad = 0;


    [SerializeField]
    GameObject genericCar;
    [SerializeField]
    GameObject policeCar;
    [SerializeField]
    GameObject taxiCar;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }



    void Start()
    {
        if (spawnPoints.Length <= 0)
        {
            spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        }

        //Spawn a couple of cars.




        for (int i = 0; i < maxCarsNumber; i++)
        {

        }
    }

    //Call this method when the GameManagerSays StartGame
    public void InitializeCarLane()
    {
        //IF Game Status is PLAYING
        //IF CarsOnRoad < MaxCARS
        //SPAWN CARs
    }

    public void SpawnRandomCar()
    {
        int randomSpawnPoint = Random.RandomRange(0, spawnPoints.Length);
        //   int randomSpawnPoint = 0;

        int randomCarType = Random.Range(0, 3);

        switch (randomCarType)
        {
            case 0:
                Instantiate(genericCar, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
                break;
            case 1:
                Instantiate(taxiCar, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
                break;
            case 2:
                Instantiate(policeCar, spawnPoints[randomSpawnPoint].transform.position, spawnPoints[randomSpawnPoint].transform.rotation);
                break;
            default:
                break;
        }
    }

    public void DestroyCar(CarBase car)
    {

        SpawnRandomCar();

        Destroy(car.gameObject);
    }

    public void SpawnCar()
    {
        //Check of the difficulty

        //Find the first unCappedSpawnPoint
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomCar();
        }
    }
}
