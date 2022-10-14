using System.Collections;
using System.Collections.Generic;

public sealed class ListExecuteObject : IEnumerator, IEnumerable
{

    private List<IExecute> _interactiveObjects;
    private int _index = -1;


    public void AddExecuteObject(IExecute execute)
    {
        if (_interactiveObjects == null)
        {
            _interactiveObjects = new List<IExecute>();
            _interactiveObjects.Add(execute);

            return;
        }
        if (_interactiveObjects.IndexOf(execute) == -1)
        {
            _interactiveObjects.Add(execute);
        }
        else
        {
            return;
        }
    }

    public IExecute this[int index]
    {
        get => _interactiveObjects[index];
        private set => _interactiveObjects[index] = value;
    }

    public int Length => _interactiveObjects.Count;

    public bool MoveNext()
    {
        if (_index == _interactiveObjects.Count - 1)
        {
            Reset();
            return false;
        }

        _index++;
        return true;
    }

    public void Reset() => _index = -1;

    public object Current => _interactiveObjects[_index];

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

