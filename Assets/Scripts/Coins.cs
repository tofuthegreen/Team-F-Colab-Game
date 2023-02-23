using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value = 1;
    MovePlayer player;

    void CollectCoin(Collider other)
    {
        if (other.tag == "Player")
        {
            player.coins++;
            Destroy(gameObject);
        }
    }




}
