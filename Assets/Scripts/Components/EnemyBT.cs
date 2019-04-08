using System.Collections;
using BehaviorTree;
using UnityEngine;

public class EnemyBT : MonoBehaviour
{
    private Tree<EnemyBT> _tree;
    private float _visibilityRange = 5.0f;
    //private float _speed = 0.5f;
    //private GameObject _player;
    Rigidbody bulletRigidbody;
    //private const int lives = 3;
    //private int _liveleft = lives;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Enemy>().PointValue += 1;
        bulletRigidbody = Resources.Load<Rigidbody>("Bullet");
        _tree = new Tree<EnemyBT>(new Selector<EnemyBT>(

            new Sequence<EnemyBT>(
                new IsPlayerInDanger(),
                new IsPlayerInRange(),
                new HardAttack() // chase Player with higher speed
            ),

            new Sequence<EnemyBT>( 
                new IsPlayerInRange(), 
                new Attack() // chase Player with regular speed
            ),

            new Idle()
        ));
    }

    // Update is called once per frame
    void Update()
    {
        _tree.Update(this);
    }

    //private float _lastRange;

    private void ChaseTarget(float speed)
    {
        var material = gameObject.GetComponent<Renderer>().material;
        material.color = Color.white;
        var playerPos = Utility.GetCharpos();
        var playerDirection = (playerPos - transform.position).normalized;
        var body = GetComponent<Rigidbody>();
        body.AddForce(playerDirection * speed, ForceMode.Impulse);
    }

    // CONDITION
    private class IsPlayerInRange : Node<EnemyBT>
    {
        public override bool Update(EnemyBT enemy)
        {
            var playerPos = Utility.GetCharpos();
            var enemyPos = enemy.transform.position;
            return Vector3.Distance(playerPos, enemyPos) < enemy._visibilityRange;
        }
    }

    private class IsPlayerInDanger : Node<EnemyBT>
    {
        public override bool Update(EnemyBT enemy)
        {
            return Utility.GetPlayerLives() <= 5;
        }
    }

    private class IsPlayerOutOfRange : Node<EnemyBT>
    {
        public override bool Update(EnemyBT enemy)
        {
            var playerPos = Utility.GetCharpos();
            var enemyPos = enemy.transform.position;
            return Vector3.Distance(playerPos, enemyPos) >= enemy._visibilityRange;
        }
    }

    // ACTIONS
    private class HardAttack : Node<EnemyBT>
    {
        public override bool Update(EnemyBT enemy)
        {
            enemy.ChaseTarget(0.5f);
            return true;
        }
    }


    private class Attack : Node<EnemyBT>
    {
        public override bool Update(EnemyBT enemy)
        {
            enemy.ChaseTarget(0.1f);
            return true;
        }
    }

    private class Idle : Node<EnemyBT>
    {
        public override bool Update(EnemyBT enemy)
        {
            var material = enemy.GetComponent<Renderer>().material;
            material.color = Color.blue;
            return true;
        }
    }
}
