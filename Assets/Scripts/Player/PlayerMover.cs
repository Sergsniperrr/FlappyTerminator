using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Vector3 _startPosition = new(-2f, 0.5f, 0f);

    private float _maxCoordinateY = 3.78f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();

        ResetPosition();
        _rigidbody.velocity = new Vector2(_speed, 0f);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update()
    {
        if (_input.IsMoveUpKeyPress)
        {
            _rigidbody.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        if (transform.position.y > _maxCoordinateY)
            transform.position = new Vector3(transform.position.x, _maxCoordinateY, 0);

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void EnablePhisic()
    {
        _collider.enabled = true;
        _rigidbody.constraints = RigidbodyConstraints2D.None;

    }

    public void DisablePhisic()
    {
        _collider.enabled = false;
        _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    public void ResetPosition()
    {
        transform.SetPositionAndRotation(_startPosition, Quaternion.Euler(Vector3.zero));
    }

    public void ResetVelocityOnY()
    {
        Vector2 velocity = new(_rigidbody.velocity.x, 0);

        _rigidbody.velocity = velocity;
    }
}
