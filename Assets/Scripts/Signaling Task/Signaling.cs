using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Signaling : MonoBehaviour
{
    public const int MaxVolume = 1;
    public const int MinVolume = 0;

    [SerializeField]
    private float _volumeChangeRate;

    private AudioSource _audio;
    private float _targetVolume;

    public void SetTargetVolume(float value)
        => _targetVolume = value;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _targetVolume = 0;
    }

    private void Update()
    {
        _audio.volume = Mathf.MoveTowards(_audio.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);

        if (_targetVolume == MinVolume && _audio.volume == MinVolume)
            gameObject.SetActive(false);
    }
}