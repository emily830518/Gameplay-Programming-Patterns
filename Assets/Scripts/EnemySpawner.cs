using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numEnemies = 5;
    private readonly EnemyManager _manager = new EnemyManager();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckEnemyPopulation());
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

    private IEnumerator CheckEnemyPopulation()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (_manager.Population == 0)
            {
                StartCoroutine(CreateEnemy());
            }
        }
    }
}
