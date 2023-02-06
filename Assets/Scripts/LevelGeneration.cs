using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] sections;
    public GameObject Player;
    public Transform spawnDistance;
    public Vector3 nextSpawnPoint;
    public int spawnCount;
    public int pathLength;
    public int maxPathLength;
    public int currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        maxPathLength = Random.Range(20, 40);
        for(int i = 0; i < 25; i++)
        {
            SpawnTile();
        }
    }
    public void SpawnTile()
    {
        pathLength++;
        if (pathLength >= maxPathLength)
        {
            
            int rnd = Random.Range(0, 4);
            while(rnd == currentDirection)
            {
                rnd = Random.Range(0, 4);
            }
            if (rnd == 0)
            {
                currentDirection = 0;
                maxPathLength = Random.Range(20, 40);
            }
            else if (rnd == 1)
            {
                if (currentDirection == 2)
                {
                    currentDirection = 0;
                }
                else
                {
                    currentDirection = 1;
                }

                maxPathLength = Random.Range(20, 40);
            }
            else if (rnd == 2)
            {
                if (currentDirection == 1)
                {
                    currentDirection = 0;
                }
                else
                {
                    currentDirection = 2;
                }

                maxPathLength = Random.Range(20, 40);

            }
            pathLength = 0;
        }
        GameObject temp = Instantiate(sections[Random.Range(0, sections.Length)], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(currentDirection).transform.position;
        Debug.Log("Section " + spawnCount + " spawned");
        spawnCount++;
    }
}
