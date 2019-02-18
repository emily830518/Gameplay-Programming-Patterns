using UnityEngine;

public class EnemyManager : Manager<Enemy>
{
    protected override Enemy CreateObject()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        var enemy = go.AddComponent<Enemy>();
        Enemy.CreateEntity(go);
        // When we create a Wanderer we let it know that this is its manager
        enemy.Manager = this;
        return enemy;
    }

    protected override void DestroyObject(Enemy e)
    {
        GameObject.Destroy(e.gameObject);
    }
}
