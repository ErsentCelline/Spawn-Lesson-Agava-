using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct SpawnData
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform _spawnPoint;
    public readonly Transform Target => _target;

    public readonly Vector2 SpawnPoint => _spawnPoint.position;
}