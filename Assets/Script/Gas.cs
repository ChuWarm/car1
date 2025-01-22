using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public int gasAmount = 30; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CarStats.Instance.IncreaseGas(gasAmount); 
            Destroy(gameObject); 
            Debug.Log("gas");
        }
    }
}
