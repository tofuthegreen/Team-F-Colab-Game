using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    public LevelGeneration levelGenerator;
    public PlayerController player;
    public bool isTJunction;
    public bool inTile;
    // Start is called before the first frame update
    void Start()
    {
        levelGenerator = GameObject.FindObjectOfType<LevelGeneration>();

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
