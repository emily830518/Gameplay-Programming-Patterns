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
    AudioClip startsound;
    AudioClip gameoversound;
    AudioClip getpointsound;
    AudioClip winsound;
    public int numEnemies = 3;
    //private readonly EnemyManager _manager = new EnemyManager();
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
            _gameState = value; EventManager.Instance.Fire(new GameStateChanged(_gameState,Score));
        }
    }
    private void Awake()
    {
        Services.Enemymanager = new EnemyManager();
    }

    // Start is called before the first frame update
    void Start()
    {
        startsound = Resources.Load<AudioClip>("Sound/startsound");
        gameoversound = Resources.Load<AudioClip>("Sound/gameoversound");
        getpointsound = Resources.Load<AudioClip>("Sound/getpointsound");
        winsound = Resources.Load<AudioClip>("Sound/winsound");

        SoundManager.instance.PlayMusic(startsound);

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

        Services.Enemymanager = null;

    }
    private void OnPlayerWin(PlayerWin evt)
    {
        SoundManager.instance.PlayMusic(winsound);

        State = GameState.Win;
    }
    private void OnPlayerDied(PlayerDied evt)
    {
        SoundManager.instance.PlayMusic(gameoversound);

        EndGame();
    }

    private void OnEnemyDied(EnemyDied evt)
    {
        SoundManager.instance.PlayMusic(getpointsound);

        Score += evt.PointValue;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CreateEnemy()
    {
        if (Services.Enemymanager != null)
        {
            while (Services.Enemymanager.Population < numEnemies)
            {
                yield return new WaitForSeconds(0.5f);
                Services.Enemymanager.Create();
            }
        }
    }

    private void CreateBossEnemy(){
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        go.gameObject.tag = "Enemy";
        go.transform.position = new Vector3(0,0,0);
        go.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        go.GetComponent<Renderer>().material.color = Color.black;
        var bossenemy = go.AddComponent<BossEnemy>();
    }

    private IEnumerator CheckEnemyPopulation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (Services.Enemymanager != null)
            {
                if (Services.Enemymanager.Population == 0 && Score >= 10)
                {
                    CreateBossEnemy();
                    break;
                }
                else if (Services.Enemymanager.Population == 0)
                {
                    StartCoroutine(CreateEnemy());
                }
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
