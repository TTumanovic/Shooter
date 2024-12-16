using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public TextMeshProUGUI healthText;
    public GameObject gameOverUI;
    public Button restartButton;

    public Material defaultMaterial; 
    public Material flashMaterial; 
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        gameOverUI.SetActive(false);


        UpdateHealthUI();
       restartButton.onClick.AddListener(RestartGame);


        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on Player!");
        }


        if (defaultMaterial == null && spriteRenderer != null)
        {
            defaultMaterial = spriteRenderer.material;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        if (flashMaterial != null)
        {
            StartCoroutine(FlashMaterial());
        }

     
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth.ToString();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");
        gameOverUI.SetActive(true);


        restartButton.gameObject.SetActive(true);

      
        gameObject.SetActive(false);
    }

    void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator FlashMaterial()
    {
     
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(0.1f); 

        spriteRenderer.material = defaultMaterial;
    }
}