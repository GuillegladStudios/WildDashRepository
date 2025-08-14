using UnityEngine;

public class ActivateChildren : MonoBehaviour
{
    public void ActivateAllChildren()
    {
        foreach (Transform child in transform) // Iterate through each child Transform of the current GameObject
        {
            child.gameObject.SetActive(true); // Activate each child GameObject
        }
    }
}
