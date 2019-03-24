using System.Collections;
using UnityEngine;

public enum GameState
{
    Playing,
    Over,
    Win
}

public class GameProcess : MonoBehaviour
{
    public int numEnemies = 3;
    private readonly EnemyManager _manager = new EnemyManager();
    private int _score;
    private int Score
    {
        get => _score;
        set
        {
            _score = value;
            EventManager.Instance.Fire(new ScoreChanged(_score));
        }
    }

    private GameState _gameState = GameState.Over;
    private GameState State
    {
        get => _gameState;
        set
        {
            _gameState = value; EventManager.Instance.Fire(new GameStateChanged(_gameState));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
        EventManager.Instance.AddHandler<EnemyDied>(OnEnemyDied);
        EventManager.Instance.AddHandler<PlayerDied>(OnPlayerDied);
        EventManager.Instance.AddHandler<PlayerWin>(OnPlayerWin);

    }

    private void OnDestroy()
    {
        // Always unregister event handlers...
        EventManager.Instance.RemoveHandler<EnemyDied>(OnEnemyDied);
        EventManager.Instance.RemoveHandler<PlayerDied>(OnPlayerDied);
        EventManager.Instance.RemoveHandler<PlayerWin>(OnPlayerWin);

    }
    private void OnPlayerWin(PlayerWin evt)
    {
        State = GameState.Win;
    }
    private void OnPlayerDied(PlayerDied evt)
    {
        EndGame();
    }

    private void OnEnemyDied(EnemyDied evt)
    {
        Score += evt.PointValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CreateEnemy()
    {
        while (_manager.Population < numEnemies)
        {
            yield return new WaitForSeconds(0.5f);
            _manager.Create();
        }
    }

    private void CreateBossEnemy(){
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.gameObject.tag = "Enemy";
        go.transform.position = new Vector3(0,0,0);
        go.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        go.GetComponent<Renderer>().material.color = Color.black;
        var bossenemy = go.AddComponent<BossEnemy>();
        //go.AddComponent<ShootTarget>();
    }

    private IEnumerator CheckEnemyPopulation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (_manager.Population == 0 && Score >= 10){
                CreateBossEnemy();
                break;
            }
            else if (_manager.Population == 0)
            {
                StartCoroutine(CreateEnemy());
            }
        }
    }

    private void StartGame()
    {
        Score = 0;
        State = GameState.Playing;
        StartCoroutine(CheckEnemyPopulation());
    }

    private void EndGame()
    {
        State = GameState.Over;
    }
}
