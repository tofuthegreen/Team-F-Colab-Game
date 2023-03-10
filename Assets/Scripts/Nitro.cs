using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitro : MonoBehaviour
{
    MovePlayer player;
    public GameObject playerReference;
    float speedBoost = 2;
    float currentSpeed;
    

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
        
        player.nitroActive = true;
        player.speed *= speedBoost;
        Debug.Log("Whoosh");

        yield return new WaitForSeconds(.5f);

        player.speed /= speedBoost;
        player.nitroActive = false;
        Destroy(gameObject);
    }
}
