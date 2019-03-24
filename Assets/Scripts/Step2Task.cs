using GPP;
using UnityEngine;

public class Step2Task : Task
{
    private readonly GameObject _gameObject;

    public Step2Task(GameObject gameobject)
    {
        _gameObject = gameobject;
    }

    protected override void Init()
    {
        Debug.Log("Starting Step 2");
        _gameObject.AddComponent<MoveCircle>();
    }

    protected override void CleanUp()
    {
        Object.Destroy(_gameObject.GetComponent<MoveCircle>());
    }

    internal override void Update()
    {
        if (_gameObject.GetComponent<BossEnemy>().lives <= 5)
        {
            SetStatus(TaskStatus.Success);
        }
    }
}