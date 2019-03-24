using GPP;
using UnityEngine;

public class Step1Task : Task
{
    private readonly GameObject _gameObject;

    public Step1Task(GameObject gameobject)
    {
        _gameObject = gameobject;
    }

    protected override void Init()
    {
        Debug.Log("Starting Step 1");
        _gameObject.AddComponent<MoveLeftRight>();

    }

    protected override void CleanUp()
    {
        Object.Destroy(_gameObject.GetComponent<MoveLeftRight>());
    }

    internal override void Update()
    {
        if(_gameObject.GetComponent<BossEnemy>().lives<=10){
            SetStatus(TaskStatus.Success);
        }
    }
}
