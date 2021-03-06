﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [Header("Level")]
    public List<GameObject> roadsLevel;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        if (roadsLevel != null && roadsLevel.Count > 0)
        {
            SpawnRoads();
        }
        SetPlayer();
        Camera.main.GetComponent<CameraController>().isPlayerMoving = true;
        Camera.main.GetComponent<CameraController>().isPlayerFighting = false;
    }

    private void SpawnRoads()
    {
        float zOffSet = 0f;
        foreach (var road in roadsLevel)
        {
            zOffSet += road.GetComponent<Road>().zOffeset;
            GameObject ro = Instantiate(road, new Vector3(0, 0, zOffSet), Quaternion.identity);
            ro.GetComponent<Road>().SpawnPersons();
        }
    }

    private void SetPlayer()
    {
        GameObject firstRoad = roadsLevel[0];
        player.position = new Vector3(firstRoad.transform.position.x, firstRoad.transform.position.y + 2f, firstRoad.transform.position.z + firstRoad.GetComponent<Road>().zOffeset);
    }
}
