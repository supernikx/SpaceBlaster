using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectTypes
{
    standardBullet,
    enemy,
}

[System.Serializable]
public class PoolObjects
{
    public GameObject prefab;
    public int ammount;
    public ObjectTypes objectType;
}

public class PoolManager : MonoBehaviour {
    public static PoolManager instance;
    public List<PoolObjects> poolObjects = new List<PoolObjects>();
    Vector3 poolPosition = new Vector3(1000, 1000, 1000);
    Dictionary<ObjectTypes, List<IPoolManager>> poolDictionary;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        poolDictionary = new Dictionary<ObjectTypes, List<IPoolManager>>();
        foreach (PoolObjects obj in poolObjects)
        {
            List<IPoolManager> objectsToAdd = new List<IPoolManager>();
            Transform spawnParent = new GameObject(obj.objectType.ToString()).transform;
            spawnParent.parent = transform;
            for (int i = 0; i < obj.ammount; i++)
            {
                GameObject instantiateObject = Instantiate(obj.prefab,spawnParent);
                IPoolManager instantiateObjectInterface = instantiateObject.GetComponent<IPoolManager>();
                instantiateObjectInterface.OnObjectDestroy += OnObjectDestroy;
                instantiateObjectInterface.OnObjectSpawn += OnObjectSpawn;
                OnObjectDestroy(instantiateObjectInterface);
                objectsToAdd.Add(instantiateObjectInterface);
            }
            poolDictionary.Add(obj.objectType, objectsToAdd);
        }
    }

    private void OnObjectDestroy(IPoolManager objectToDestroy)
    {
        objectToDestroy.Currentstate = State.InPool;
        objectToDestroy.ownerObject = null;
        objectToDestroy.gameObject.transform.position = poolPosition;
    }

    private void OnObjectSpawn(IPoolManager objectToSpawn)
    {
        objectToSpawn.Currentstate = State.InUse;
    }

    public GameObject GetPooledObject(ObjectTypes type, GameObject callingObject)
    {
        foreach (IPoolManager _object in poolDictionary[type])
        {
            if (_object.Currentstate == State.InPool)
            {
                _object.ownerObject = callingObject;
                return _object.gameObject;
            }
        }
        Debug.Log("Nessun "+type+" disponibile");
        return null;
    }

    private void OnDisable()
    {
        foreach (ObjectTypes type in poolDictionary.Keys)
        {
            foreach (IPoolManager pooledObject in poolDictionary[type])
            {
                pooledObject.OnObjectDestroy -= OnObjectDestroy;
                pooledObject.OnObjectSpawn -= OnObjectSpawn;
            }
        }
    }
}
