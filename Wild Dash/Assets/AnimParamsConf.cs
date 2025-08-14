using UnityEngine;

[RequireComponent(typeof(Animator))] // This script requires an Animator component to be attached to the GameObject
public class AnimParamsConf : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetBoolTrue(string name)
    {
        Debug.Log("Boolean parameter set to true: " + name); // Log the boolean parameter for debugging
        _animator.SetBool(name, true); // Set the boolean parameter to true
    }
    public void SetBoolFalse(string name)
    {
        Debug.Log("Boolean parameter set to false: " + name); // Log the boolean parameter for debugging
        _animator.SetBool(name, false); // Set the boolean parameter to false
    }
    public void SetTriggerParameter(string name)
    {
        Debug.Log("Trigger parameter set: " + name); // Log the trigger parameter for debugging
        _animator.SetTrigger(name); // Set the trigger parameter
    }
}
