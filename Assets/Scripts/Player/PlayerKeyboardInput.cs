using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour
{
    private PlayerMovement _mover;
    private PlayerMovementModifier _moverModifier;
    private bool IsAiming => Input.GetMouseButton(1);

    private void Awake()
    {
        _mover = GetComponent<PlayerMovement>();
        _moverModifier = GetComponent<PlayerMovementModifier>();
    }

    private void Update()
    {
        SetMovement();
        SetLookingPoint();
        _moverModifier.IsAiming = IsAiming;
    }

    private void SetLookingPoint()
    {
        var mouseScreenPos = Input.mousePosition;
        _mover.LookingPoint = Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    private void SetMovement()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        _mover.Movement = new Vector2(x, y);
    }
}
