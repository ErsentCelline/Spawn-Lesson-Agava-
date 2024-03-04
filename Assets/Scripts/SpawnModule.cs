using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnModule : MonoBehaviour
{
    [SerializeField]
    private List<SkullSpawner> _skullSpawners;
    [SerializeField, Range(1, 8)]
    private float _spawnRate;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var wait = new WaitForSeconds(_spawnRate);

        while (gameObject.activeInHierarchy)
        {
            _skullSpawners[Random.Range(0, _skullSpawners.Count)].Spawn();

            yield return wait;
        }
    }
}