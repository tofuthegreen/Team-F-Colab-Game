using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value = 1;
    MovePlayer playerController;
    public GameObject playerReference;

    void Start()
    {
        playerController = playerReference.GetComponent<MovePlayer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController.coins += value;
            Destroy(gameObject);
            Debug.Log(playerController.coins);
        }
    }




}
