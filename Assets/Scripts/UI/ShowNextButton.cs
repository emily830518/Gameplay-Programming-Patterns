using UnityEngine;

public class ShowNextButton : MonoBehaviour
{
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
        if (gamestatechangedevent.State == GameState.Win || gamestatechangedevent.State == GameState.Over)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
}
