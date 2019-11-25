using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private int initial;
    [SerializeField]
    private GameObject objToPool;
    private Stack<GameObject> objPool;

    public ObjectPool(int initial, GameObject objToPool)
    {
        this.initial = initial;
        this.objToPool = objToPool;
        CreatePool();
    }

    private void CreatePool()
    {
        objPool = new Stack<GameObject>();
        for (int i = 0; i < initial; i++)
        {
            BuildObj();
        }
    }

    public GameObject GetPooledObject()
    {
        if (objPool.Count > 0)
        {
            GameObject obj = objPool.Pop();
            return obj;
        }
        BuildObj();
        return objPool.Pop();
    }

    private void BuildObj()
    {
        GameObject obj = (GameObject)Instantiate(objToPool);
        obj.SetActive(false);
        objPool.Push(obj);
    }
    public void PushObj(GameObject objToPush)
    {
        objPool.Push(objToPush);
    }
}
