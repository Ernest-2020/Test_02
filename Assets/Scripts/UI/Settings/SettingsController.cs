using System;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public event Action<CubeSettings> GetedSettings;
    [SerializeField] private AppView _view;

    private InputParser _parser;
    public CubeSettings _cubeSettings;
    private void Awake()
    {

        _view.OnStart += GetSettings;
    }

    private void GetSettings(string spawnTime, string distanse, string speed)
    {
        _parser = new InputParser();
            _cubeSettings = _parser.ParseSettings(spawnTime, distanse, speed);
        GetedSettings?.Invoke(_cubeSettings);
    }
}
