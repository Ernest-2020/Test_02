using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    private ListExecuteObject _listExecuteObject;

    private void Awake()
    {
        _listExecuteObject = new ListExecuteObject();
        _listExecuteObject.AddExecuteObject(_cubeSpawner);
        _cubeSpawner.CubeSpawned += AddCubeInListExecuteObjects;
    }

    private void AddCubeInListExecuteObjects(Cube cube)
    {
        _listExecuteObject.AddExecuteObject(cube);
    }

    private void Update()
    {
        for (var i = 0; i < _listExecuteObject.Length; i++)
        {
            var interactiveObject = _listExecuteObject[i];

            if (interactiveObject == null)
            {
                continue;
            }
            interactiveObject.Execute();
        }

    }
}
