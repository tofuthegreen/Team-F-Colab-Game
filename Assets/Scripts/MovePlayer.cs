using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //public LevelGeneration levelGenerator;
    CharacterController characterController;
    // Start is called before the first frame update


    [SerializeField]
    float speed = 5f;
    [SerializeField]
    int movePlayer = 3;
    public int playerPos = 1;
    private Vector3 startingPos, currentPos;
    public int distance;
    public int health;
    public float maxSpeed, hitTimer, damageMultiplier;
    public bool beenHit;
    // Start is called before the first frame update
    void Start()
    {
        health = 1;
        damageMultiplier = 1f;
        characterController = GetComponent<CharacterController>();
        startingPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, 0, speed * Time.deltaTime);
        currentPos = transform.position;
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPos < 2)
            {
                move.x = movePlayer;
                playerPos++;
                Debug.Log(playerPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPos > 0)
            {
                move.x = -movePlayer;
                playerPos--;
                Debug.Log(playerPos);
            }
        }

        characterController.Move(move);
        distance = (int)(currentPos - startingPos).magnitude;
        if(beenHit == true)
        {
            hitTimer -= Time.deltaTime;
            damageMultiplier = 100f;
            if(hitTimer <= 0)
            {
                beenHit = false;
                health = 1;
                damageMultiplier = 1f;
                hitTimer = 3f;
            }
        }
        if(speed < maxSpeed && health >= 0)
        {
            speed += 0.001f * damageMultiplier;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            health--;
            if(health < 0)
            {
                Debug.Log("Dead");
                speed = 0;
                damageMultiplier = 0;
            }
            else
            {
                Debug.Log("Ow");
                beenHit = true;
                speed = 25;
            }
        }
    }
}
