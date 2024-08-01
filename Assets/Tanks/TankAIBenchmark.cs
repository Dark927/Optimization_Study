using UnityEngine;

public class TankAIBenchmark : MonoBehaviour
{
    [SerializeField] private int _numberOfTanks;
    [SerializeField] private GameObject _tankPrefab;
    [SerializeField] private float _forwardSpeed = 0.01f;
    [SerializeField] private float _spawnPosSpreadXZ = 50f;

    private Transform[] _tanksTransform;
    private Transform _playerTransform;
    private string _playerTag = "Player";


    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag(_playerTag);

        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            Debug.Log($"# Error, {nameof(player)} is null. - {gameObject.name}.");
        }
    }

    private void Start()
    {
        _tanksTransform = new Transform[_numberOfTanks];

        for (int i = 0; i < _numberOfTanks; i++)
        {
            _tanksTransform[i] = Instantiate(_tankPrefab).transform;

            _tanksTransform[i].position = new Vector3(
                Random.Range(-_spawnPosSpreadXZ, _spawnPosSpreadXZ),
                0,
                Random.Range(-_spawnPosSpreadXZ, _spawnPosSpreadXZ));
        }
    }

    private void Update()
    {
        foreach (Transform tank in _tanksTransform)
        {
            tank.LookAt(_playerTransform.position);
            tank.Translate(0, 0, _forwardSpeed);
        }
    }
}
