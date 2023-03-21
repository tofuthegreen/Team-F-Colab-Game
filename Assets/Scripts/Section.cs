using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public LevelGeneration levelGenerator;
    public MovePlayer player;
    public bool isTJunction;
    public bool inTile;
    public GameObject[] coinSpawnPoints;
    public GameObject coinGroup, coin, nitro, rock, rock2,spike;
    public GameObject[] coins;

    public GameObject[] easyObstacles;
    public GameObject[] medObstacles;
    public GameObject[] hardObstacles;

    public GameObject[] obstaclesSpawn;
    public GameObject[] obstacles;
    public Transform obstaclesParent;
    public int[] obstaclesTest;
    public bool emptyRoad;
    public GameObject[] nitroSpawns;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.FindObjectOfType<LevelGeneration>();
        coins = new GameObject[10];
        if (emptyRoad == false)
        {
            SpawnObstacles();
        }

        CoinSpawn();
        NitroSpawn();
    }
    public void SpawnObstacles()
    {
        obstaclesTest = new int[obstaclesSpawn.Length];
        obstacles = new GameObject[obstaclesTest.Length];
        for (int i = 0; i < obstaclesTest.Length; i++)
        {
            int spawnRND = Random.Range(0, 3+levelGenerator.difficulty);
            if(spawnRND == 0)
            {
                obstaclesTest[i] = 1;
            }
            else
            {
                obstaclesTest[i] = 0;
            }
        }
        if(obstaclesTest[1] == 1 && obstaclesTest[0] == 1 && obstaclesTest[2] == 1)
        {
            int rnd = Random.Range(0, 3);
            if(rnd == 0)
            {
                obstaclesTest[0] = 0;
            }
            else if (rnd == 0)
            {
                obstaclesTest[1] = 0;
            }
            else
            {
                obstaclesTest[2] = 0;
            }
        }
        else if(obstaclesTest[3] == 1 && obstaclesTest[4] == 1 && obstaclesTest[5] == 1)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                obstaclesTest[5] = 0;
            }
            else if (rnd == 1)
            {
                obstaclesTest[4] = 0;
            }
            else
            {
                obstaclesTest[3] = 0;
            }
        }
        else if (obstaclesTest[6] == 1 && obstaclesTest[7] == 1 && obstaclesTest[8] == 1)
        {
            int rnd = Random.Range(0, 3);
            if (rnd == 0)
            {
                obstaclesTest[6] = 0;
            }
            else if (rnd == 1)
            {
                obstaclesTest[7] = 0;
            }
            else
            {
                obstaclesTest[8] = 0;
            }
        }
        for (int j = 0; j < obstaclesTest.Length; j++)
        {
            if(obstaclesTest[j] == 1) {
                int obstacleRND = Random.Range(0, 2);
                if (obstacleRND == 0)
                {
                    int rockRND = Random.Range(0, 2);
                    if (rockRND == 1)
                    {
                        obstacles[j] = Instantiate(rock, new Vector3(obstaclesSpawn[j].transform.position.x, obstaclesSpawn[j].transform.position.y + 0.5f, obstaclesSpawn[j].transform.position.z), Quaternion.identity, obstaclesParent);
                        Debug.Log("Spawned obstacle");
                    }
                    else
                    {
                        obstacles[j] = Instantiate(rock2, new Vector3(obstaclesSpawn[j].transform.position.x, obstaclesSpawn[j].transform.position.y + 0.5f, obstaclesSpawn[j].transform.position.z), Quaternion.identity, obstaclesParent);
                        Debug.Log("Spawned obstacle");
                    }
                }
                else
                {
                    obstacles[j] = Instantiate(spike, obstaclesSpawn[j].transform.position, Quaternion.identity, obstaclesParent);
                    Debug.Log("Spawned obstacle");
                }

            }
        }
    }
    
    public void CoinSpawn()
    {
        for(int i = 0; i < coinSpawnPoints.Length; i++)
        {
            int rnd = Random.Range(1, 11);
            if(rnd > 5 + levelGenerator.difficulty)
            {
                int coinRnd = Random.Range(0, 2);
                if(coinRnd == 1)
                {
                    coins[i] = Instantiate(coinGroup, coinSpawnPoints[i].transform.position, Quaternion.identity);
                    
                }
                else
                {
                    coins[i] = Instantiate(coin, coinSpawnPoints[i].transform.position, Quaternion.identity);
                }
            }
        }
    }

    public void NitroSpawn()
    {
        for (int i = 0; i < nitroSpawns.Length; i++)
        {
            int rnd = Random.Range(1, 10);
            if (rnd < 2)
            {
                Instantiate(nitro, nitroSpawns[i].transform.position, Quaternion.identity);

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && inTile == true)
        {
            Debug.Log("Leaving section");
            levelGenerator.SpawnTile();
            for(int i = 0; i < coins.Length; i++)
            {
                Destroy(coins[i]);
            }
            for(int i = 0; i< obstacles.Length; i++)
            {
                Destroy(obstacles[i]);
            }
            Destroy(gameObject,1);
            inTile = false;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inTile = true;
            if (isTJunction == true)
            {
            
                if (player.playerPos == 0)
                {
                    levelGenerator.currentDirection = 1;
                    levelGenerator.tileRND = Random.Range(0, 4);
                }
                else if (player.playerPos == 2)
                {
                    levelGenerator.currentDirection = 2;
                    levelGenerator.tileRND = Random.Range(0, 4);
                }
            }
        }
    }
}
