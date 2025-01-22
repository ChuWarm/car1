using System.Collections;
using TMPro;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    public static CarStats Instance; 
    public int gas = 100;            
    public int gasConsumption = 8;   
    public GameObject gameOverPanel; 
    public TextMeshProUGUI gasText;  

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(gameObject); 
        }
        
        if (gameOverPanel == null)
        {
            Debug.LogWarning("GameOverPanel is not assigned in the inspector!");
        }

        if (gasText == null)
        {
            Debug.LogWarning("GasText is not assigned in the inspector!");
        }
    }

    private void Start()
    {
        StartGame(); 
    }

    public void ResetGame()
    {
        gas = 100; 
        Time.timeScale = 1; 
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false); 
        }
        UpdateGasUI(); 
    }

    public void StartGame()
    {
        ResetGame(); 
        InvokeRepeating(nameof(ConsumeGas), 1f, 1f); // 연료 소비 시작
    }
    
    public void IncreaseGas(int amount)
    {
        gas += amount;
        if (gas >= 100)
        {
            gas = 100;
        }
        UpdateGasUI(); 
    }
    public void DecreaseGas(int amount)
    {
        gas -= amount;
        if (gas <= 0)
        {
            gas = 0;
            GameOver(); 
        }
        else
        {
            UpdateGasUI(); 
        }
    }

    private void UpdateGasUI()
    {
        if (gasText != null)
        {
            gasText.text = string.Empty;
            gasText.text = "Gas: " + gas; 
        }
    }

    void ConsumeGas()
    {
        DecreaseGas(gasConsumption);
    }

    void GameOver()
    {
        CancelInvoke(nameof(ConsumeGas));
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        Time.timeScale = 0; 
    }
}