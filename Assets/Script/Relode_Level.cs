using UnityEngine;
using UnityEngine.SceneManagement;

public class Relode_Level : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); 
        }
        else
        {
            Debug.LogWarning("GameOverPanel not assigned in Relode_Level!");
        }


        Player_Controller controller = collision.GetComponent<Player_Controller>();
        if (controller != null)
        {
            controller.enabled = false;
        }

        // Stop physics movement
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic; // freezes physics interaction
        }

    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
