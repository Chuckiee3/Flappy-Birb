using _GAME_.Scripts.Actions;
using Singleton;

public class LevelManager : PersistentSingleton<LevelManager>
{
    public bool levelStarted;

    public void LevelStarted()
    {
        if(levelStarted) return;
        levelStarted = true;
        GameFlow.TriggerLevelStarted();
    }
}
