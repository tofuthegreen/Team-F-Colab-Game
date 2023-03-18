using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] sections;
    public MovePlayer player;
    public Transform spawnDistance;
    public Vector3 nextSpawnPoint;
    public int spawnCount;
    public int pathLength;
    public int maxPathLength;
    public int currentDirection;
    public int tileRND;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log("starting spawncount is " + spawnCount);
            SpawnTile();
        }
    }
    public void SpawnTile()
    {
            int emptyRoadChance = Random.Range(1, 6);
            if (emptyRoadChance == 1 && spawnCount > 5)
            {
                tileRND = 0;
            }
            else
            {
                if(spawnCount < 5)
                {
                    tileRND = 0;
                }
                else if (spawnCount < 1500)
                {
                    tileRND = Random.Range(1, 4);
                }
                else if(spawnCount < 5000)
                {
                    tileRND = Random.Range(1,7);
                }
                else
                {
                tileRND = Random.Range(1, sections.Length);
                }
            }
            GameObject temp = Instantiate(sections[tileRND], nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(currentDirection).transform.position;
            Debug.Log("Section " + spawnCount + " spawned");
            spawnCount++;
    }
    public void StartTiles()
    {
        tileRND = 0;
        GameObject temp = Instantiate(sections[tileRND], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(currentDirection).transform.position;
    }
}
