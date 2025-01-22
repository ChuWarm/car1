using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    public static CarStats Instance; 

    public int gas = 100;       
    public int gasConsumption = 5; 

    public GameObject gameOverPanel; 

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        InvokeRepeating(nameof(ConsumeGas), 1f, 1f); 
    }

    void ConsumeGas()
    {
        gas -= gasConsumption;
        if (gas <= 0)
        {
            gas = 0;
            GameOver(); 
        }
    }

    public void IncreaseGas(int amount)
    {
        gas += amount;
    }

    void GameOver()
    {
        CancelInvoke(nameof(ConsumeGas));
        gameOverPanel.SetActive(true);   
        Time.timeScale = 0;            
    }
}
