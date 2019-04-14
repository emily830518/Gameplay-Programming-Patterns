using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float existTime = 5.0f;

    void Start()
    {
        //EventManager.Instance.AddHandler<GameStateChanged>(OnGameStateChanged);
        Services.Eventmanager.AddHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnDestroy()
    {
        //EventManager.Instance.RemoveHandler<GameStateChanged>(OnGameStateChanged);
        Services.Eventmanager.RemoveHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameEvent evt)
    {
        var gamestatechangedevent = evt as GameStateChanged;
        if ((gamestatechangedevent.State == GameState.Over) || (gamestatechangedevent.State == GameState.Win)) Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, existTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
