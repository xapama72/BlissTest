using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsController : MonoBehaviour
{
    [Header("Effects")]
    public GameObject dieEffect;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Person")
        {
            other.gameObject.transform.SetParent(player);
        }

        if (other.tag == "Obstacle")
        {
            GameObject die = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(die, 3f);
            gameObject.transform.SetParent(GameObject.Find("Death").GetComponent<Transform>());
            Destroy(gameObject);
        }
    }    
}
