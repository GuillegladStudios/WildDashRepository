using UnityEngine;
using UnityEngine.Events;

public class OnEnableBehaviour : MonoBehaviour
{
    public UnityEvent OnEnableEvent; // Event to be invoked on enable

    private void OnEnable()
    {
        OnEnableEvent?.Invoke(); // Invoke the event if it is not null
    }
}
