using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MOVE 000");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("MOVE");
        float hMovement = Input.GetAxis("Horizontal") * movementSpeed / 2;
        float vMovement = movementSpeed;
        transform.Translate(new Vector3(hMovement, 0, vMovement) * Time.deltaTime);
    }
}
