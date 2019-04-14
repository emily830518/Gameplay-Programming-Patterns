using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent(typeof(ControlledByKeyboard));
        gameObject.AddComponent(typeof(Defense));
        //EventManager.Instance.AddHandler<GameStateChanged>(OnGameStateChanged);
        Services.Eventmanager.AddHandler<GameStateChanged>(OnGameStateChanged);

    }

    private void OnDestroy()
    {
        // Always unregister for events when you're done...
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

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            lives--;
            //EventManager.Instance.Fire(new LifeChanged(lives));
            Services.Eventmanager.Fire(new LifeChanged(lives));
            if (lives <= 0)
            {
                //EventManager.Instance.Fire(new PlayerDied());
                Services.Eventmanager.Fire(new PlayerDied());
                Destroy(gameObject);
            }
        }
    }
}
