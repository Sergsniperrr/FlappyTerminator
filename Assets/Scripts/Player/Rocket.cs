using UnityEngine;

public class Rocket : MonoBehaviour, IRemovable
{
    [SerializeField] private float _speed;

    private bool _canMove;
    private bool _canLaunch = true;

    private void Start()
    {
        Remove();
    }

    private void Update()
    {
        if (_canMove)
            transform.Translate(_speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Explode();

            Remove();
        }
    }

    public void Launch(Transform startTransform)
    {
        if (_canLaunch == false)
            return;

        transform.SetPositionAndRotation(startTransform.position, startTransform.rotation);

        _canMove = true;
        _canLaunch = false;
    }

    public void Remove()
    {
        float positionY = -6f;
        Vector3 screenOutPosition = Vector3.zero;

        screenOutPosition.y = positionY;

        _canMove = false;
        _canLaunch = true;

        transform.position = screenOutPosition;
    }
}
