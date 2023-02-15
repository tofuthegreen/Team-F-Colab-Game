using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    //public LevelGeneration levelGenerator;
    CharacterController characterController;
    // Start is called before the first frame update


    [SerializeField]
    float speed = 10f;
    [SerializeField]
    int movePlayer = 3;
    public int playerPos = 1;
    private Vector3 startingPos, currentPos;
    public int distance;
    [SerializeField]
    int[] movePositions = new int[3];

    float lerpDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        startingPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, 0, speed);
        currentPos = transform.position;
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPos < 2)
            {               
                playerPos++;
                StartCoroutine(LerpPosition(new Vector3(movePositions[playerPos], transform.position.y, transform.position.z + speed * lerpDuration), lerpDuration));
                Debug.Log(playerPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPos > 0)
            {
                
                playerPos--;
                StartCoroutine(LerpPosition(new Vector3(movePositions[playerPos], transform.position.y, transform.position.z + speed * lerpDuration), lerpDuration));
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
}