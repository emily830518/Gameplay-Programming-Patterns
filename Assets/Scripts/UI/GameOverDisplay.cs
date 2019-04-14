using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        Services.Eventmanager.AddHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Services.Eventmanager.RemoveHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameEvent evt)
    {
        var gamestatechangedevent = evt as GameStateChanged;
        if (gamestatechangedevent.State == GameState.Over)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

}
