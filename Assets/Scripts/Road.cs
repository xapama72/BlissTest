using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public float zOffeset;
    public float difficulty;
    [Header("Persons")]
    public int personsCount;
    public GameObject personPrefab;

    public void SpawnPersons()
    {
        for (int i = 0; i < personsCount; i++)
        {
            Vector3 newPos = new Vector3(transform.position.x + i + Random.Range(-2, 2f), transform.position.y + 2f, transform.position.z + i + Random.Range(-2, 2f)); 
            Instantiate(personPrefab, newPos, Quaternion.identity);
        }
    }    
}
