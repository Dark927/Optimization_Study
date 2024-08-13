using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1.5f;

    private Animator _animator;
    private Transform _playerTransform;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Debug.Log("# Player is null! - " + gameObject.name);
        }

        _animator.speed = _speed;
    }

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 direction = _playerTransform.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        Quaternion rotation = Quaternion.LookRotation(direction);

        transform.rotation = rotation;
    }


}
