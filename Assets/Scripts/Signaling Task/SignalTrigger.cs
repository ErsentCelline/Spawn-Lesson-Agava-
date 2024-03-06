using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SignalTrigger : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case ObjectTags.Enemy:
                _signaling.SetEnabled(true);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case ObjectTags.Enemy:
                _signaling.SetEnabled(false);
                break;
        }
    }
}
