using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastnFurious : MonoBehaviour
{
    Movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        Debug.Log("Go fast");

        if (col.CompareTag("Player"))
        {
            player.fast = true;
            player.moveSpeed += player.fastSpeed;
        }
    }

    void OnTriggerExit(Collider col)
    {
        Debug.Log("No more");
        if (col.CompareTag("Player"))
        {
            player.fast = false;
            player.moveSpeed -= player.fastSpeed;
        }
    }

}
