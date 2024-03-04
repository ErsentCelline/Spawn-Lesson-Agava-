using UnityEngine;

[System.Serializable]
public abstract class BaseSpawner<T> where T: class, ISpawnedObject
{
    [SerializeField]
    protected T _objectToSpawn;
    [SerializeField]
    protected SpawnData _spawnData;

    public abstract T Spawn();
}