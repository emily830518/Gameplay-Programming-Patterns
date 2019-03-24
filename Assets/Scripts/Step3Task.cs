using GPP;
using UnityEngine;

public class Step3Task : Task
{
    private readonly GameObject _gameObject;

    public Step3Task(GameObject gameobject)
    {
        _gameObject = gameobject;
    }

    protected override void Init()
    {
        Debug.Log("Starting Step 3");
        _gameObject.AddComponent<MoveCircle>();
        _gameObject.AddComponent<ScalebyTime>();
    }

    protected override void CleanUp()
    {
        Object.Destroy(_gameObject.GetComponent<MoveCircle>());
        Object.Destroy(_gameObject.GetComponent<ScalebyTime>());
        Object.Destroy(_gameObject);
    }

    internal override void Update()
    {
        if (_gameObject.GetComponent<BossEnemy>().lives <= 0)
        {
            SetStatus(TaskStatus.Success);
        }
    }
}
