using System.Collections;
using TMPro;
using UnityEngine;

public class CarStats : MonoBehaviour
{
    public static CarStats Instance; 
    public int gas = 100;            
    public int gasConsumption = 5;   
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

        InvokeRepeating(nameof(ConsumeGas), 1f, 1f);
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
            gasText.ForceMeshUpdate();
        }
    }

    void ConsumeGas()
    {
        DecreaseGas(gasConsumption);
    }

    public void IncreaseGas(int amount)
    {
        gas += amount;
        UpdateGasUI(); 
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

    public void RestartGame()
    {
        Time.timeScale = 1;
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        gas = 100; 
        UpdateGasUI(); 
        InvokeRepeating(nameof(ConsumeGas), 1f, 1f); 
    }
}