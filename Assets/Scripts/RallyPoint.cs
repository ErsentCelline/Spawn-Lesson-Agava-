using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyPoint : MonoBehaviour
{
    [SerializeField]
    private Vector2Int[] _movePoints;
    [SerializeField, Range(1, 5)]
    private float _movementSpeed;

    private IEnumerator<Vector2Int> _route;

    private Vector2 _targetPoint;

    private void Awake()
    {
        IEnumerable<Vector2Int> temp = _movePoints;
        _route = temp.GetEnumerator();

        SetNextTargetPoint();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPoint, _movementSpeed * Time.deltaTime);

        if ((Vector2)transform.position == _targetPoint)
            SetNextTargetPoint();
    }

    private void SetNextTargetPoint()
    {
        if (_route.MoveNext() == false)
        {
            _route.Reset();
            _route.MoveNext();

            _targetPoint = _route.Current;
        }

        _targetPoint = _route.Current;
    }
}
