using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    protected List<GameObject> Objects = new List<GameObject>();

    public ObjectPool(List<GameObject> objects)
    {
        Objects = objects;
    }

    public bool TrySpawn(Vector3 position, out GameObject gameObject)
    {
        foreach (var obj in Objects)
        {
            if (obj.active == false)
            {
                obj.transform.position = position;
                obj.SetActive(true);
                gameObject = obj;

                return true;
            }
        }

        gameObject = null;
        return false;
    }

    public List<GameObject> GetObjects() => new List<GameObject>(Objects);

    public void Reset()
    {
        foreach (var obj in Objects)
        {
            obj.SetActive(false);
        }
    }   
}