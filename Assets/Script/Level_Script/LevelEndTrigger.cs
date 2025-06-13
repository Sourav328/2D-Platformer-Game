using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndTrigger : MonoBehaviour
{
    [SerializeField] private GameObject levelCompletePanel;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (levelCompletePanel != null)
                levelCompletePanel.SetActive(true);
            Sound_Manager.Instance.Play(Sound.ButtonClick);
            
          
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Sound_Manager.Instance.Play(Sound.ButtonClick);
    }


}
