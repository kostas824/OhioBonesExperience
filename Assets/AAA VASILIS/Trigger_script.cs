using UnityEngine;
using UnityEngine.Events;

public class ColliderTriggerResponse : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

#pragma warning disable
    [SerializeField] string tag;
#pragma warning enable

    [SerializeField] UnityEvent onEnterEvent;
    [SerializeField] UnityEvent onExitEvent;

    void OnTriggerEnter(Collider collision)
    {
        if (!string.IsNullOrEmpty(tag) && collision.tag != tag) return;
        onEnterEvent?.Invoke();
    }

    void OnTriggerExit(Collider collision)
    {
        if (!string.IsNullOrEmpty(tag) && collision.tag != tag) return;
        onExitEvent?.Invoke();
    }
}