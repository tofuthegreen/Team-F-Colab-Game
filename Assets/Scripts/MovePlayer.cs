using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
public class MovePlayer : MonoBehaviour
{
    //Calls the character controller functionality
    CharacterController characterController;

    //contains all variables for player movement
    #region playerVariables
    [SerializeField]
    public float speed;
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

    public AudioClip coinPickUp;
    public AudioSource audioSource;

    public bool nitroActive = false;
    float speedBoost = 1.5f;
    public int coins,displayCoins;
    int value = 1;

    public int health;
    public int maxHealth;
    public bool beenHit;
    float healTime;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        startingPos = transform.position;
        health = maxHealth;

        speed = VariableTransfer.speed;
        displayCoins = SaveSystem.LoadCoins();
        coins = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (nitroActive == false || beenHit == true)
        {
            CheckSpeed();
        }
       

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

        

        if(beenHit == true)
        {
            healTime -= Time.deltaTime;
            if(healTime <= 0)
            {
                health = maxHealth;
                beenHit = false;
                healTime = 3f;
            }
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            health--;
            if(health <= -1)
            {
                Debug.Log("You died");
                SaveGame();
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("Been Hit");
                speed /=2;
                if(speed < 10f)
                {
                    speed = 10f;
                }
                beenHit = true;
            }
        }
        else if (other.CompareTag("Coin"))
        {
            audioSource.clip = coinPickUp;
            audioSource.Play();
            displayCoins += value;
            coins += value;
            Destroy(other.gameObject);
            Debug.Log(coins);
            
        }
    }

    void CheckSpeed()
    {
        if (distance > 0f)
        {
            if (speed < maxSpeed)
            {
                    float multiplier = 0.001f;
                    speed += multiplier;
            }
            
            
        }
    }

    
   public void SaveGame()
    {
        SaveSystem.CompareDistance(distance, SaveSystem.LoadDistance());
        SaveSystem.AddCoins(coins, SaveSystem.LoadCoins());
    }
}