using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lobby_Controller : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject levelPanel;

    private void Awake()
    {
        playButton.onClick.AddListener(ShowLevels);

        exitButton.onClick.AddListener(ExitGame);
    }

    private void ShowLevels()
    {
        if (levelPanel != null)
            levelPanel.SetActive(true);

        playButton.gameObject.SetActive(false);
        Sound_Manager.Instance.Play(Sound.ButtonClick);
        exitButton.gameObject.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}