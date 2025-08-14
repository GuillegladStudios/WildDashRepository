using UnityEngine;

[CreateAssetMenu(fileName = "NewObstacle", menuName = "Obstacle/Create New Obstacle")]
public class ObstacleSO : ScriptableObject
{
    public string ObstacleName = "New Obstacle"; // Nombre del obst�culo
    public int ObstacleDamage = 1; // Da�o causado por el obst�culo
    public Sprite ObstacleSprite; // Representaci�n visual del obst�culo
}
