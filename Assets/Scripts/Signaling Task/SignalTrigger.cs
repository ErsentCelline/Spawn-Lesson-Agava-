using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SignalTrigger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _signaling.gameObject.SetActive(true);
        _signaling.SetTargetVolume(Signaling.MaxVolume);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _signaling.SetTargetVolume(Signaling.MinVolume);
    }
}
