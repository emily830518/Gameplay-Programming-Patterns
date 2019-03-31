using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadLevel : MonoBehaviour
{
    public enum LevelState
    {
        ShowMainMenu,
        LevelStart,
        ShowScoreBoard,
    }

    private LevelState currentState = LevelState.ShowMainMenu;


    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case LevelState.ShowMainMenu:
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    if (EventSystem.current.currentSelectedGameObject.name == "PlayButton")
                    {
                        SceneManager.LoadScene("GameScene");
                        currentState = LevelState.LevelStart;
                    }
                    else if (EventSystem.current.currentSelectedGameObject.name == "ScoreboardButton")
                    {
                        SceneManager.LoadScene("ScoreBoard");
                        currentState = LevelState.ShowScoreBoard;
                    }
                }
                break;

            case LevelState.LevelStart:
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    if (EventSystem.current.currentSelectedGameObject.name == "MenuButton")
                    {
                        SceneManager.LoadScene("MainMenu");
                        currentState = LevelState.ShowMainMenu;
                    }
                    else if (EventSystem.current.currentSelectedGameObject.name == "NextButton")
                    {
                        SceneManager.LoadScene("ScoreBoard");
                        currentState = LevelState.ShowScoreBoard;
                    }
                }
                break;
            case LevelState.ShowScoreBoard:
                if (EventSystem.current.currentSelectedGameObject != null)
                {
                    if (EventSystem.current.currentSelectedGameObject.name == "MenuButton")
                    {
                        SceneManager.LoadScene("MainMenu");
                        currentState = LevelState.ShowMainMenu;
                    }
                }
                break;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
