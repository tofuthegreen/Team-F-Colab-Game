using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value = 1;

    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            VariableTransfer.coins += value;
            Destroy(gameObject);
            Debug.Log(VariableTransfer.coins);
        }
    }




}
