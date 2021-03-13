using Singleton;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameSettings : PersistentSingleton<GameSettings>
{
    [FoldoutGroup("Bird Movement")]
    [SerializeField] private float baseFlapForce;
    [FoldoutGroup("Bird Movement")]
    [SerializeField] private float maxFlapForce;
    [FoldoutGroup("Bird Movement")]
    [SerializeField] private float horizontalMovementSpeed;
    [FoldoutGroup("Level Generation")]
    [SerializeField] private float minYObstacle;
    [FoldoutGroup("Level Generation")]
    [SerializeField] private float maxYObstacle;
    [FoldoutGroup("Level Generation")]
    [SerializeField] private float minXDistObstacle;
    [FoldoutGroup("Level Generation")]
    [SerializeField] private float maxXDistObstacle;
    [FoldoutGroup("Level Generation")]
    [SerializeField] private float minHoleSize;
    [FoldoutGroup("Level Generation")]
    [SerializeField] private float maxHoleSize;
    

    public static float BaseFlapForce =>  Instance.baseFlapForce;
    public static float MaxFlapForce =>  Instance.maxFlapForce;
    public static float HorizontalMovementSpeed =>  Instance.horizontalMovementSpeed;
    public static float MinYObstacle =>  Instance.minYObstacle;
    public static float MaxYObstacle =>  Instance.maxYObstacle;
    public static float MinXDistObstacle =>  Instance.minXDistObstacle;
    public static float MaxXDistObstacle =>  Instance.maxXDistObstacle;
    public static float MinHoleSize =>  Instance.minHoleSize;
    public static float MaxHoleSize =>  Instance.maxHoleSize;

}
