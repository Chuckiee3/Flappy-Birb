using Singleton;
using UnityEngine;

public class GameSettings : PersistentSingleton<GameSettings>
{
    [SerializeField] private GameSettingsSO _settingsSo;
    public static float PlayerFlapCooldown => Instance._settingsSo.playerFlapCooldown;

    public static float BaseFlapForce =>  Instance._settingsSo.baseFlapForce;
    public static float MaxFlapForce =>  Instance._settingsSo.maxFlapForce;
    public static float HorizontalMovementSpeed =>  Instance._settingsSo.horizontalMovementSpeed;
    public static float MinYObstacle =>  Instance._settingsSo.minYObstacle;
    public static float MaxYObstacle =>  Instance._settingsSo.maxYObstacle;
    public static float MinXDistObstacle =>  Instance._settingsSo.minXDistObstacle;
    public static float MaxXDistObstacle =>  Instance._settingsSo.maxXDistObstacle;
    public static float MinHoleSize =>  Instance._settingsSo.minHoleSize;
    public static float MaxHoleSize =>  Instance._settingsSo.maxHoleSize;
    public static float minDBToFlap => Instance._settingsSo.minDBToFlap;
    public static float maxDB => Instance._settingsSo.maxDB;
}
