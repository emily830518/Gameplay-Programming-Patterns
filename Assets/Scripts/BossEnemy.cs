//using GPP;
using UnityEngine;
using BehaviorTree;
using System.Collections;

public class BossEnemy : MonoBehaviour
{
    //private const int maxlives = 15;
    public float lives = 15;
    public int PointValue = 100;
    private Tree<BossEnemy> _tree;

    //private readonly SerialTasks _attackTask = new SerialTasks();
    //// Start is called before the first frame update
    //void Start()
    //{
    //    _attackTask.Add(new Step1Task(this.gameObject));
    //    _attackTask.Add(new Step2Task(this.gameObject));
    //    _attackTask.Add(new Step3Task(this.gameObject));
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    _attackTask.Update();
    //}

    void Start()
    {
        _tree = new Tree<BossEnemy>(new Selector<BossEnemy>(

            new Sequence<BossEnemy>(
                new IsInDanger(), //5
                new Heal()
            ),

            new Sequence<BossEnemy>(
                new IsHalfHealth(), //8
                new Attack2() // chase Player with regular speed
            ),

            new Sequence<BossEnemy>(
                new IsNinetyPercentHealth(), //14
                new Attack1() // chase Player with regular speed
            ),

            new Idle()
        ));
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

    // Update is called once per frame
    void Update()
    {
        _tree.Update(this);
    }

    private IEnumerator WaitAndHeal(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            lives += 0.1f;
            break;
        }
    }

    private void Healing()
    {
        var material = gameObject.GetComponent<Renderer>().material;
        material.color = Color.red;
        StartCoroutine(WaitAndHeal(0.5f));
    }

    //Conditions
    private class IsInDanger : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            return enemy.lives <= 5.0f;
        }
    }

    private class IsHalfHealth : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            return enemy.lives <= 8.0f;
        }
    }

    private class IsNinetyPercentHealth : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            return enemy.lives <= 14.0f;
        }
    }

    //Actions
    private class Heal : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            if (enemy.GetComponent<MoveCircle>() != null)
            {
                Destroy(enemy.GetComponent<MoveCircle>());
            }

            if (enemy.GetComponent<MoveLeftRight>() != null)
            {
                Destroy(enemy.GetComponent<MoveLeftRight>());
            }
            enemy.Healing();
            return true;
        }
    }

    private class Attack1 : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            var material = enemy.GetComponent<Renderer>().material;
            material.color = Color.black;
            if (enemy.GetComponent<MoveCircle>() != null)
            {
                Destroy(enemy.GetComponent<MoveCircle>());
            }
            if (enemy.GetComponent<MoveLeftRight>() == null)
            {
                enemy.gameObject.AddComponent<MoveLeftRight>();
            }
            return true;
        }
    }

    private class Attack2 : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            var material = enemy.GetComponent<Renderer>().material;
            material.color = Color.black;
            if (enemy.GetComponent<MoveLeftRight>() != null)
            {
                Destroy(enemy.GetComponent<MoveLeftRight>());
            }
            if (enemy.GetComponent<MoveCircle>() == null)
            {
                enemy.gameObject.AddComponent<MoveCircle>();
            }
            return true;
        }
    }

    private class Idle : Node<BossEnemy>
    {
        public override bool Update(BossEnemy enemy)
        {
            if (enemy.GetComponent<MoveCircle>() != null)
            {
                Destroy(enemy.GetComponent<MoveCircle>());
            }

            if (enemy.GetComponent<MoveLeftRight>() != null)
            {
                Destroy(enemy.GetComponent<MoveLeftRight>());
            }
            var material = enemy.GetComponent<Renderer>().material;
            material.color = Color.black;
            return true;
        }
    }

}
