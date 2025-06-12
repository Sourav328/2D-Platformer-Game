using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;

    public string LevelName;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }
    private void onClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level Is Locked " + LevelName);
                break;
            case LevelStatus.Unlocked:
                Sound_Manager.Instance.Play(Sound.ButtonClick);
                SceneManager.LoadScene(LevelName);
                Debug.Log(" Unlock ");
                break;
            case LevelStatus.Completed:
                Debug.Log(" Completed ");
                SceneManager.LoadScene(LevelName);
                break;
        }
       
    }

}