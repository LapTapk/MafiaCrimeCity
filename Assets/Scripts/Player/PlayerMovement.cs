using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove = true;

    private Vector2 _movement = Vector2.zero;
    public Vector2 Movement
    {
        get => _movement;
        set
        {
            var valueIsValid = CordIsValid(value.x) && CordIsValid(value.y);

            if (!valueIsValid)
                throw new UnityException("All cords of Movement Vector must be integer in range of [-1;1]");
            else
                _movement = value;

            bool CordIsValid(float x) => x == 0 || x == -1 || x == 1;
        }
    }
    
    [SerializeField] public PlayerMovementModifier _modifier;
    public PlayerMovementModifier Modifier => _modifier; 

    [HideInInspector] public Vector2 LookingPoint;
    [SerializeField] private float _speed;
    private float _defaultCameraZ;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _defaultCameraZ = Camera.main.transform.position.z;
    }

    private void Update()
    {
        LookAtMouse();
    }

    private void FixedUpdate()
    {
        _rb.velocity = _movement * ((CanMove ? 1 : 0) * _speed * _modifier.TotalValue);
        MoveCamera();
    }

    private void LookAtMouse()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var angle = Vector2.Angle(Vector2.right, mousePosition - transform.position);
        transform.eulerAngles = new Vector3(0f, 0f, transform.position.y < mousePosition.y ? angle : -angle);
    }

    private void MoveCamera()
    {
        var pos = transform.position;
        pos.z = _defaultCameraZ;
        Camera.main.transform.position = pos;
    }
}
