using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cam Offsets")]
    public Vector3 cameraOffsetMove;
    public Vector3 cameraOffsetFight;
    [Header("Player status")]
    public bool isPlayerMoving;
    public bool isPlayerFighting;

    private Transform player;
    private Vector3 cameraPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (isPlayerMoving)
        {
            transform.position = new Vector3(player.position.x + cameraOffsetMove.x, player.position.y + cameraOffsetMove.y, player.position.z + cameraOffsetMove.z);
            cameraPos = transform.position;
        }
        if (isPlayerFighting)
        {
            Vector3 newPos = new Vector3(cameraPos.x + cameraOffsetFight.x, cameraPos.y + cameraOffsetFight.y, cameraPos.z + cameraOffsetFight.z);
            transform.position = Vector3.Lerp(transform.position, newPos, 2f * Time.deltaTime);
        }
    }
}
