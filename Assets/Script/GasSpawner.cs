using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasSpawner : MonoBehaviour
{
    public GameObject gasPrefab; 
    public Transform[] spawnPoints; 
    public float gasSpeed = 5;

    private List<GameObject> activeGases = new List<GameObject>();
    public float spawnInterval = 5f; 

    void Start()
    {
        InvokeRepeating(nameof(SpawnGas), 2f, spawnInterval); 
    }
    
    void LateUpdate()
    { 
        foreach (GameObject gas in activeGases)
        {
            if (gas != null) 
            {
                gas.transform.Translate(new Vector3(0, -1, 0) * gasSpeed * Time.deltaTime);
            }
        }
    }

    void SpawnGas()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        GameObject newGas = Instantiate(gasPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
        activeGases.Add(newGas);
    }
}
