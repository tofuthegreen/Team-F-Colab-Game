using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //Calls the character controller functionality
    CharacterController characterController;

    //contains all variables for player movement
    #region playerVariables
    [SerializeField]
    float initialSpeed = 10f;
    public float speed = 10f;
    [SerializeField]
    int movePlayer = 3;
    [SerializeField]
    int maxSpeed = 50;
    [SerializeField]
    float dodgeSpeed = 0.3f;
    public int playerPos = 1;
    #endregion  
    private Vector3 startingPos, currentPos;
    public int distance;
    //Array for the lanes the playe can move between
    [SerializeField]
    int[] movePositions = new int[3];

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        startingPos = transform.position;
        
    }


    // Update is called once per frame
    void Update()
    {
        //CheckSpeed();
        Vector3 move = new Vector3(0, 0, speed);
        currentPos = transform.position;
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPos < 2)
            {               
                playerPos++;
                StartCoroutine(LerpPosition(new Vector3(movePositions[playerPos], transform.position.y, transform.position.z + speed * dodgeSpeed), dodgeSpeed));
                Debug.Log(playerPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPos > 0)
            {
                
                playerPos--;
                StartCoroutine(LerpPosition(new Vector3(movePositions[playerPos], transform.position.y, transform.position.z + speed * dodgeSpeed), dodgeSpeed));
                Debug.Log(playerPos);
            }
        }

        characterController.Move(move * Time.deltaTime);
        distance = (int)(currentPos - startingPos).magnitude;
        
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0f;
        Vector3 startPosition = transform.position;
        while (time < duration + 0.03)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log(playerPos);
        transform.position = targetPosition;
    }
    
    void CheckSpeed()
    {
        if (distance > 0f)
        {
            if (speed != maxSpeed)
            {
                float multiplier = distance / 100f;
                speed = initialSpeed + multiplier;
            }
            
            
        }
    }
}