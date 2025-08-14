using UnityEngine;

[CreateAssetMenu(fileName = "NewObstacle", menuName = "Obstacle/Create New Obstacle")]
public class ObstacleSO : ScriptableObject
{
    public string ObstacleName = "New Obstacle"; // Nombre del obstáculo
    public int ObstacleDamage = 1; // Daño causado por el obstáculo
    public Sprite ObstacleSprite; // Representación visual del obstáculo
}
