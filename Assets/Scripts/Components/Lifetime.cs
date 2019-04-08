using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifeLeft = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(lifeLeft <= 0)
        {
            EventManager.Instance.Fire(new EnemyDied(GetComponent<Enemy>().PointValue));
            Destroy(this);
            gameObject.AddComponent<Disappear>();
        }
    }

}
