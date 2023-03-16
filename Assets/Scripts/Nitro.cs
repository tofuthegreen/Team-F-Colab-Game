using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Nitro : MonoBehaviour
{
    MovePlayer player;
    public GameObject playerReference;
    float speedBoost = 2;
    float currentSpeed;

    float duration = 0.5f;

    void Start()
    {
        player = playerReference.GetComponent<MovePlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject.GetComponent<MovePlayer>();
            Debug.Log(player.speed);
            StartCoroutine(NitroBoost(player));
        }
    }

    public IEnumerator NitroBoost(MovePlayer player)
    {
        if (player.nitroActive != true)
        {
            player.nitroActive = true;
            currentSpeed = player.speed;
            if (player.speed <= (player.maxSpeed / speedBoost))
            {
                player.nitroActive = true;
                player.speed *= speedBoost;
                Debug.Log("Whoosh");

                yield return new WaitForSeconds(duration);

                player.speed /= speedBoost;
                player.nitroActive = false;
                Destroy(gameObject);
            }
            else if (player.speed >= player.maxSpeed)
            {
                player.nitroActive = true;
                player.speed += 5;
                Debug.Log("Whoosh");

                yield return new WaitForSeconds(.5f);
                yield return new WaitForSeconds(duration);

                player.speed /= speedBoost;
                player.nitroActive = false;
                Destroy(gameObject);
                player.speed = player.maxSpeed;
                player.nitroActive = false;
                Destroy(gameObject);
            }
            else
            {
                player.nitroActive = true;
                player.speed = player.maxSpeed;
                Debug.Log("Whoosh");

                yield return new WaitForSeconds(duration);

                player.speed = currentSpeed;
                player.nitroActive = false;
                Destroy(gameObject);
            }
        }
        
    }
}
