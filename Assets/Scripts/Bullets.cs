using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float existTime = 5.0f;

    void Start()
    {
        EventManager.Instance.AddHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveHandler<GameStateChanged>(OnGameStateChanged);
    }

    private void OnGameStateChanged(GameStateChanged evt)
    {
        if (evt.State == GameState.Over) Destroy(gameObject);
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
