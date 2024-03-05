using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    private const int MaxVolume = 1;
    private const int MinVolume = 0;

    [SerializeField]
    private float _volumeChangeRate;

    private AudioSource _audio;
    private float _targetVolume;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _targetVolume = 0;
    }

    private void Update()
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetVolume = MaxVolume;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _targetVolume = MinVolume;
    }
}