using UnityEngine;

public class Character : MonoBehaviour
{
    public int lives = 10;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent(typeof(ControlledByKeyboard));
        gameObject.AddComponent(typeof(Defense));
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
