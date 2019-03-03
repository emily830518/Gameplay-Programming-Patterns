﻿using UnityEngine;

public class GameOverDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Hide();
        EventManager.Instance.AddHandler<GameStateChanged>(OnGameStateChanged);
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
        EventManager.Instance.RemoveHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameStateChanged evt)
    {
        if (evt.State == GameState.Over)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

}
