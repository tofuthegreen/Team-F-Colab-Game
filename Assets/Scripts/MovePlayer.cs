using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public LevelGeneration levelGenerator;
    CharacterController characterController;
    // Start is called before the first frame update
    

    [SerializeField]
    float speed = 5f;
    public float moveDistance = 100;
    public int playerPos = 1;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(0, 0, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerPos < 2)
            {
                move.x = 3;
                playerPos++;
                Debug.Log(playerPos);
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerPos > 0)
            {
                move.x = -3;
                playerPos--;
                Debug.Log(playerPos);
            }
        }

        characterController.Move(move);
    }
}
