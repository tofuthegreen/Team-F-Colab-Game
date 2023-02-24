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
            
            Debug.Log(player.speed);
            StartCoroutine(NitroBoost());
        }
    }

    IEnumerator NitroBoost()
    {

        player.speed *= speedBoost;
        Debug.Log("Whoosh");

        yield return new WaitForSeconds(1f);

        player.speed /= speedBoost;
    }

    
}
