using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    protected List<T> _�bjects = new List<T>();

    public ObjectPool(List<T> objects)
    {
        _�bjects = objects;
    }

    public bool TrySpawn(Vector3 position, out T spawned)
    {
       
        foreach (var obj in _�bjects)
        {
            if (obj.gameObject. activeSelf == false)
            {
                obj.transform.position = position;
                obj.gameObject.SetActive(true);
                spawned = obj;

                return true;
            }
        }

        spawned = null;
        return false;
    }

    public List<T> GetObjects() => new List<T>(_�bjects);

    public void Reset()
    {
        foreach (var obj in _�bjects)
        {
            obj.gameObject.SetActive(false);
        }
    }   
}