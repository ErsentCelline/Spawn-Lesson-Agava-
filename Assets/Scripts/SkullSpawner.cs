using UnityEngine;

[System.Serializable]
public class SkullSpawner : BaseSpawner<Skull>
{
    public override Skull Spawn()
    {
        var skull = Object.Instantiate(_objectToSpawn, _spawnData.SpawnPoint, Quaternion.identity);
        skull.Initialize(_spawnData.MoveDirection);

        return skull;
    }
}