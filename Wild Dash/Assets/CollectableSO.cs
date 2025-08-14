using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectable", menuName = "Collectable/Create New Collectable")]
public class CollectableSO : ScriptableObject
{
    public string CollectableName = "New Collectable"; //Name of the collectable
    public int CollectablePoints = 10; //Points awarded for collecting this item
    public Sprite CollectableSprite; //Visual representation of the collectable
}
