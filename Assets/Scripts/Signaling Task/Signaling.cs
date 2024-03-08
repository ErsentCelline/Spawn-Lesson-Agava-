using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    public const int MaxVolume = 1;
    public const int MinVolume = 0;

    [SerializeField] private float _volumeChangeRate;

    private AudioSource _audio;
    private float _targetVolume;

    private IEnumerator SignalRoutine;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _targetVolume = 0;
    }

    public void FadeIn()
    {
        SignalRoutine = Signal();

        _targetVolume = MaxVolume;

        _audio.Play();
        StartCoroutine(SignalRoutine);
    }

    public void FadeOut()
    {
        if (_audio.isPlaying)
            StopCoroutine(SignalRoutine);

        _targetVolume = MinVolume;

        StartCoroutine(SignalRoutine);
    }

    private IEnumerator Signal()
    {
        while (_audio.volume != _targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }

        if (_audio.volume == MinVolume)
            _audio.Stop();
    }
}