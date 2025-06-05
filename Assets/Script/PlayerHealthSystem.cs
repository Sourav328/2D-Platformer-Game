using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private int startingHealth = 3;
    private int currentHealth;

    [Header("UI Components")]
    [SerializeField] private GameObject[] hearts;

    [Header("Game Over UI")]
    [SerializeField] private GameObject gameOverPanel;

    [Header("Components")]
    [SerializeField] private Player_Controller playerController;

    private void Awake()
    {
        currentHealth = startingHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        UpdateHearts();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < currentHealth);
        }
    }

    private void Die()
    {
        StartCoroutine(ShowGameOver());
    }
    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(0.5f);

        if (playerController != null)
        {
            playerController.enabled = false; 
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        else
        {
            Debug.LogWarning("GameOverPanel is not assigned in PlayerHealthSystem!");
        }


    }
}
