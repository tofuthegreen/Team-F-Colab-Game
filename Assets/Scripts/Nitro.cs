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
            NitroBoost(player);
        }
    }

    public void NitroBoost(MovePlayer player)
    {
        if (player.nitroActive != true)
        {
            player.speed += 3;
        }
        
    }
    IEnumerator Boost(float time, float targetSpeed, float returnSpeed)
    {
        player.nitroActive = true;
        player.speed = targetSpeed;
        Debug.Log("Whoosh");

        yield return new WaitForSeconds(time);

        player.speed = returnSpeed;
        player.nitroActive = false;
        Destroy(gameObject);
    }
}
