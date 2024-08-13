using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    Transform _headTransform;
    private Vector3 _input;
    private float _sqrMinSpeed = 0.01f;

    private void Awake()
    {
        PlayerHead head = GetComponentInChildren<PlayerHead>();

        if (head != null)
        {
            _headTransform = head.transform;
        }
    }

    private void Update()
    {
        ReadPlayerInput();
        TryMove();
    }

    private void TryMove()
    {
        if(_input.sqrMagnitude > _sqrMinSpeed)
        {
            Move();
        }
    }

    private void Move()
    {
        _input = _headTransform.TransformDirection(_input);
        _input.y = 0f;
        _input.Normalize();

        transform.Translate(_speed * Time.deltaTime * _input, Space.World);
    }

    private void ReadPlayerInput()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.z = Input.GetAxis("Vertical");
    }
}