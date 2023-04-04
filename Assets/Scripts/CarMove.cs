using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public GameObject player;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovePlayer>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f, gameObject.transform.position.z - 50), Color.red);
        
        if (Vector3.Distance(gameObject.transform.position,player.transform.position) < 50)
        {
            transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,transform.position.z- speed * Time.deltaTime);
        }
    }
}
