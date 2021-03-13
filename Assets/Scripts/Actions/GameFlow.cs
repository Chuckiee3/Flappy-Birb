using System;

namespace _GAME_.Scripts.Actions
{
    public static class GameFlow
    {
        public static Action levelCreated;
        public static Action levelStarted;
        public static Action levelCompleted;
        public static Action levelFailed;
        public static Action levelRestarted;
        public static Action cinematicStarted;
        public static Action cinematicFinished;
        public static Action birdDown;
        public static Action passedObstacle;

        public static void TriggerCinematicStarted()
        {
            cinematicStarted?.Invoke();
        }public static void TriggerCinematicFinished()
        {
            cinematicFinished?.Invoke();
        }
        public static void TriggerLevelRestarted()
        {
            levelRestarted?.Invoke();
        }
      
        public static void TriggerLevelCreated()
        {
            levelCreated?.Invoke();
        }
        public static void TriggerLevelStarted()
        {
            levelStarted?.Invoke();
        }
        public static void TriggerLevelCompleted()
        {
            levelCompleted?.Invoke();
        }
        public static void TriggerLevelFailed()
        {
            levelFailed?.Invoke();
        }


        public static void TriggerBirdDown()
        {
            birdDown?.Invoke();
        }

        public static void TriggerPassedObstacle()
        {
            passedObstacle?.Invoke();
        }
    }
}
