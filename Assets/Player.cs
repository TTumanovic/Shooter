using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


//Paveldėjimas
//D
public class Player : Character
{
    public TextMeshProUGUI healthText;   
    public GameObject gameOverUI;       
    public Button restartButton;        

    protected override void Start()
    {
        //L
        base.Start();

        UpdateHealthUI();
        gameOverUI.SetActive(false);

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
    }

    public override void TakeDamage(int damageAmount)
    {
        // Polimorfizmas 
        base.TakeDamage(damageAmount);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        //Inkap
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    protected override void Die()
    {
        //Poli
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }

        gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        //S
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}

