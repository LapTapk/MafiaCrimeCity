using UnityEngine;
using Pathfinding;

public class EnemyDestinationSetter : AIDestinationSetter
{
    private void Start()
    {
        target = PlayerInstance.Instance.transform;
    }
}
