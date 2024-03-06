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

    public void SetTargetVolume(float value)
    {
        _targetVolume = value;

        if (_audio.isPlaying == false )
            _audio.Play();

        StartCoroutine(Signal());
    }

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _targetVolume = 0;
    }

    private IEnumerator Signal()
    {
        while (_audio.volume != _targetVolume)
        {
            _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }

        if (_targetVolume == MinVolume && _audio.volume == MinVolume)
            _audio.Stop();
    }
}