using UnityEngine;

public class Cube : MonoBehaviour,IExecute
{

    private float _speed;
    private float _maxDistance;
    private Vector3 _spawnPosition;

    public void Execute()
    {
        Move();
        CheckDistance();
    }

    public void Init(Vector3 spawnPosition,float speed, float distance)
    {
        _spawnPosition = spawnPosition;
        _speed = speed;
        _maxDistance = distance;
        transform.position = spawnPosition;
    }

    private void Move()
    {
        Vector3 direction = Vector3.forward;
        transform.Translate(direction* _speed*Time.deltaTime);
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(_spawnPosition, transform.position);
        if (distance >= _maxDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
