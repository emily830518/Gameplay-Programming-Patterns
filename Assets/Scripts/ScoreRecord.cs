using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRecord : MonoBehaviour
{
    public List<int> Top_five=new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        Services.Eventmanager.AddHandler<GameStateChanged>(OnGameStateChanged);
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
            if (Top_five.Count == 0)
            {
                Top_five.Add(gamestatechangedevent.FinalScore);
            }
            else if (Top_five.Count < 5)
            {
                Top_five.Add(gamestatechangedevent.FinalScore);
                Top_five.Sort();
            }
            else
            {
                Top_five.Add(gamestatechangedevent.FinalScore);
                Top_five.Sort();
                Top_five.RemoveAt(0); //remove the lowest score
            }
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
