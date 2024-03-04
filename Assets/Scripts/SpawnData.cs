using UnityEngine;

[System.Serializable]
public struct SpawnData
{
    [SerializeField]
    private Vector2 _moveDirection;
    [SerializeField]
    private Transform _spawnPoint;
    public readonly Vector2 MoveDirection => _moveDirection;

    public readonly Vector2 SpawnPoint => _spawnPoint.position;
}