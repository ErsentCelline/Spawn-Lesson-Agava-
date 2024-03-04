using UnityEngine;

[System.Serializable]
public class SkullSpawner
{
    [SerializeField]
    private Skull _objectToSpawn;
    [SerializeField]
    private SpawnData _spawnData;

    public Skull Spawn()
    {
        var skull = Object.Instantiate(_objectToSpawn, _spawnData.SpawnPoint, Quaternion.identity);
        skull.Initialize(_spawnData.MoveDirection);

        return skull;
    }
}