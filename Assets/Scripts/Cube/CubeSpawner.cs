using System;
using UnityEngine;

public class CubeSpawner : MonoBehaviour,IExecute
{
    public event Action<Cube> CubeSpawned;

    [SerializeField] private Cube _prefabCube;
    [SerializeField] private SettingsController _settingsController;
    [SerializeField] private Transform _cubeContainer;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _startSpawnCube;

    private Pool<Cube> _cubePool;
    private CubeSettings _cubeSettings;
    private float _spawnTime;
    private float _cureentTime;


    private void Awake()
    {
        _cubePool = new Pool<Cube>(_cubeContainer, _startSpawnCube, _prefabCube);
        _settingsController.GetedSettings += GetSettigs;
    }

    private void Spawn(CubeSettings settings)
    {
        if (settings!=null)
        {
            Cube cube = _cubePool.GetFreeObject();
            cube.Init(_spawnPoint.position, settings.Speed, settings.Distance);
            CubeSpawned?.Invoke(cube);
        }
 
    }

    private void SpawnTimer()
    {
        _cureentTime += Time.deltaTime;
        if (_cureentTime >= _spawnTime)
        {
            _cureentTime = 0;
            Spawn(_cubeSettings);
        }
    }

    public void Execute()
    {
        SpawnTimer();
    }
    private void GetSettigs(CubeSettings settings)
    {
        _cubeSettings = settings;
        _spawnTime = settings.TimeSpawn;
    }

}
