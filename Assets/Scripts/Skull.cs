using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Skull : MonoBehaviour, ISpawnedObject
{
    [SerializeField, Range(1f, 5f)]
    private float _movementSpeed;

    private Vector2 _movementDirection;
    private SpriteRenderer _spriteRenderer;

    public void Initialize(Vector2 moveDirection)
    {
        _movementDirection = moveDirection;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        _spriteRenderer.flipX = _movementDirection.x < 0;

        transform.Translate(_movementSpeed * Time.deltaTime * _movementDirection);
    }
}