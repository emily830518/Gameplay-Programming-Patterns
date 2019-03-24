using GPP;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public int lives = 15;
    public int PointValue = 100;
    private readonly SerialTasks _attackTask = new SerialTasks();
    // Start is called before the first frame update
    void Start()
    {
        _attackTask.Add(new Step1Task(this.gameObject));
        _attackTask.Add(new Step2Task(this.gameObject));
        _attackTask.Add(new Step3Task(this.gameObject));
    }

    // Update is called once per frame
    void Update()
    {
        _attackTask.Update();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lives--;
            //Debug.Log(lives);
            if (lives <= 0)
            {
                EventManager.Instance.Fire(new EnemyDied(PointValue));
                EventManager.Instance.Fire(new PlayerWin());
                Destroy(gameObject);
            }
        }
    }
}
