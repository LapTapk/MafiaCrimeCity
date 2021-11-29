using UnityEngine;
using Pathfinding;

public class EnemyPath : AIPath
{
    private Rigidbody2D _rb;

    protected override void Awake()
    {
        base.Awake();
        _rb = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();

        if (!canMove)
            _rb.constraints = RigidbodyConstraints2D.FreezePosition;
        else
            _rb.constraints = RigidbodyConstraints2D.None;

        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        var playerPosition = PlayerInstance.Instance.transform.position;
        var angle = Vector2.Angle(Vector2.up, playerPosition - transform.position);
        rotation = Quaternion.Euler(0f, 0f, (transform.position.x > playerPosition.x ? angle : -angle) - 50);
    }
}
