using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private void Start()
    {
        // Add a handler to find out when the score has changed
        Services.Eventmanager.AddHandler<ScoreChanged>(OnScoreChanged);
    }

    private void OnDestroy()
    {
        // Always make sure you remove registered handlers when you're done
        // Otherwise you can end up with memory leaks and odd bugs
        Services.Eventmanager.RemoveHandler<ScoreChanged>(OnScoreChanged);
    }

    private void OnScoreChanged(GameEvent evt)
    {
        var scorechangedevent = evt as ScoreChanged;
        GetComponent<TextMeshProUGUI>().text = "score:" + scorechangedevent.NewScore.ToString();
    }
}
