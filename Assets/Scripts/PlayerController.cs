using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeedH = 10f;
    public float movementSpeedV = 10f;
    [Header("Effects")]
    public GameObject dieEffect;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = Input.GetAxis("Horizontal") * movementSpeedH / 2;
        float vMovement = movementSpeedV;
        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Enter to fight zone
        if (other.tag == "Trigger")
        {
            movementSpeedV = 0;
            Camera.main.GetComponent<CameraController>().isPlayerMoving = false;
            Camera.main.GetComponent<CameraController>().isPlayerFighting = true;            
        }
        //Touch an obstacle
        if (other.tag == "Obstacle")
        {
            movementSpeedV = 0;
            movementSpeedH = 0;
            GameObject die = Instantiate(dieEffect, transform.position, Quaternion.identity);
            Destroy(die, 3f);
            GameObject.Find("GameManager").GetComponent<UIController>().ShowGameOver();
        }
        //Touch a person
        if (other.tag == "Person")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
}
