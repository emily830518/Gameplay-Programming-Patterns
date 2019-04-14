using TMPro;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    private void Start()
    {
        // Add a handler to find out when the score has changed
        Services.Eventmanager.AddHandler<LifeChanged>(OnLifeChanged);
    }

    private void OnDestroy()
    {
        // Always make sure you remove registered handlers when you're done
        // Otherwise you can end up with memory leaks and odd bugs
        Services.Eventmanager.RemoveHandler<LifeChanged>(OnLifeChanged);
    }

    private void OnLifeChanged(GameEvent evt)
    {
        var lifechangedevent = evt as LifeChanged;
        GetComponent<TextMeshProUGUI>().text = "life:"+ lifechangedevent.NewLife.ToString();
    }
}