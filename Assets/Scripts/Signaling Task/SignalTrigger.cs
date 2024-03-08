using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SignalTrigger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Skull>(out Skull component))
            _signaling.FadeIn();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Skull>(out Skull component))
            _signaling.FadeOut();
    }
}
