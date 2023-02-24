using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value = 1;
    MovePlayer player;
    public GameObject playerReference;

    void Start()
    {
        player = playerReference.GetComponent<MovePlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.coins = player.coins + value;
            Destroy(gameObject);
            Debug.Log(player.coins);
        }
    }




}
