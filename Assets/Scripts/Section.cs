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
    public GameObject coinGroup,coin;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.FindObjectOfType<LevelGeneration>();
        CoinSpawn();
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
                    Instantiate(coinGroup, coinSpawnPoints[i].transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(coin, coinSpawnPoints[i].transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && inTile == true)
        {
            Debug.Log("Leaving section");
            levelGenerator.SpawnTile();
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
