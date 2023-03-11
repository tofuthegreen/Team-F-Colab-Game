using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public MovePlayer player;

    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //player.coins += value;
            Destroy(gameObject);
            Debug.Log(player.coins);
        }
    }




}
