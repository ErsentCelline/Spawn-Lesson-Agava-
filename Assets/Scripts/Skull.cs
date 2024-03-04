using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Skull : MonoBehaviour
{
    [SerializeField, Range(1f, 5f)]
    private float _movementSpeed;

    private SpriteRenderer _spriteRenderer;
    private Transform _target;

    public void Initialize(Transform target)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _target = target;
    }

    private void Update()
    {
        _spriteRenderer.flipX = _target.position.x < transform.position.x;

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _movementSpeed * Time.deltaTime);
    }
}