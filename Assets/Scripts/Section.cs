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
    public GameObject coinGroup, coin, nitro;
    public GameObject[] coins;

    public GameObject[] nitroSpawns;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.FindObjectOfType<LevelGeneration>();
        coins = new GameObject[10];
        CoinSpawn();
        NitroSpawn();
    }

    public void CoinSpawn()
    {
        for(int i = 0; i < coinSpawnPoints.Length; i++)
        {
            int rnd = Random.Range(1, 10);
            if(rnd < 5)
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
            if (rnd < 7)
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
