using _GAME_.Scripts.Actions;
using UnityEngine;

public class AIHelperTrigger : MonoBehaviour
{
   public bool passed;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if(passed) return;
      if (other.CompareTag("Bird"))
      {
         passed = true;
         GameFlow.TriggerPassedObstacle();
      }
   }

}
