using UnityEngine;

public class Player : MonoBehaviour
{
    public int lives = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent(typeof(ControlledByKeyboard));
        gameObject.AddComponent(typeof(Defense));
        EventManager.Instance.AddHandler<GameStateChanged>(OnGameStateChanged);

    }

    private void OnDestroy()
    {
        // Always unregister for events when you're done...
        EventManager.Instance.RemoveHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameStateChanged evt)
    {
        if ((evt.State == GameState.Over) || (evt.State == GameState.Win)) Destroy(gameObject);
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
            EventManager.Instance.Fire(new LifeChanged(lives));
            if (lives <= 0)
            {
                EventManager.Instance.Fire(new PlayerDied());
                Destroy(gameObject);
            }
        }
    }
}
