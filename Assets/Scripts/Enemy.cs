using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyManager Manager { get; set; }
    public int PointValue;

    //Start is called before the first frame update
    void Start()
    {
        PointValue = 0;
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
        if (GetComponent<Disappear>() != null)
        {
            if (GetComponent<Disappear>().readyToBeDestroyed == true)
            {
                Manager.Destroy(this);
            }
        }
    }

    public static void CreateEntity(GameObject go)
    {
        Vector3 pos = new Vector3(Random.Range(-9.0f, 9.0f), 0.5f, Random.Range(5.0f, 9.0f));
        go.transform.position = pos;

        go.AddComponent<Lifetime>();
        go.gameObject.tag = "Enemy";
        int enemytype=AddRandomComponent(go);
        if (enemytype == 0)
        {
            go.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (enemytype == 1)
        {
            go.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            go.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    private static int AddRandomComponent(GameObject go)
    {
        int type = Random.Range(0, 3);
        if (type == 0)
        {
            //go.AddComponent(typeof(ChaseTarget));
            go.AddComponent<Rigidbody>();
            go.AddComponent(typeof(EnemyBT));
        }
        else if (type == 1)
        {
            go.AddComponent(typeof(ShootTarget));
        }
        else
        {
            go.AddComponent(typeof(ChaseTarget));
            go.AddComponent(typeof(ShootTarget));
        }
        return type;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<Lifetime>() != null && collision.gameObject.tag == "Player")
        {
            GetComponent<Lifetime>().lifeLeft--;
        }
    }
}
