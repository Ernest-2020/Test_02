using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[Serializable]
public class Pool<T> where T : Component
{
    private Transform _container;
    private T[] _prefabs;

    private List<T> _objects;

    public Pool(Transform container, int startCount, params T[] prefabs)
    {
        _container = container;
        _prefabs = prefabs;
        InitializePool(startCount);
    }

    private void InitializePool(int count)
    {
        _objects = new List<T>();
        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private bool HasFreeObject(out T obj)
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            GameObject gameObject = _objects[i].gameObject;
            if (!_objects[i].gameObject.activeInHierarchy)
            {
                obj = _objects[i];
                _objects[i].gameObject.SetActive(true);
                return true;
            }
        }
        obj = null;
        return false;
    }

    private void AddObjectInPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Add(obj);
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        T createObject = Object.Instantiate(_prefabs[Random.Range(0, _prefabs.Length)],_container);
        AddObjectInPool(createObject);
        return createObject;
    }

    public T GetFreeObject()
    {
        if (HasFreeObject(out T element))
        {
            return element;
        }
        else
        {
            return CreateObject(true);
        }
    }
}
