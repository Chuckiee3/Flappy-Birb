using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Settings", menuName = "Settings/Game", order = 0)]
public class GameSettingsSO : ScriptableObject
{
    [FoldoutGroup("Bird Movement")]
    public float baseFlapForce;
    [FoldoutGroup("Bird Movement")]
    public float maxFlapForce;
    [FoldoutGroup("Bird Movement")]
     public float horizontalMovementSpeed;

     [FoldoutGroup("Player Movement")] public float playerFlapCooldown;
     [FoldoutGroup("Volume Settings")] public float minDBToFlap;
     [FoldoutGroup("Volume Settings")] public float maxDB;
     
     
    [FoldoutGroup("Level Generation")]
     public float minYObstacle;
    [FoldoutGroup("Level Generation")]
     public float maxYObstacle;
    [FoldoutGroup("Level Generation")]
     public float minXDistObstacle;
    [FoldoutGroup("Level Generation")]
    public float maxXDistObstacle;
    [FoldoutGroup("Level Generation")]
     public float minHoleSize;
    [FoldoutGroup("Level Generation")]
     public float maxHoleSize;

     [FoldoutGroup("AI")] 
     public float aiLookAheadDistance;

     [FoldoutGroup("AI")] public float minUpDistanceToFlap;
     [FoldoutGroup("AI")] public float groundCheckDistance;
     [FoldoutGroup("AI")]public float aiRandomFlapChance;
     [FoldoutGroup("AI")]
     public LayerMask _aiHelper;
     
     
     [FoldoutGroup("General")] 
     public LayerMask obstacleLayer;

}
