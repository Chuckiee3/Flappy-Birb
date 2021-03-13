using Sirenix.OdinInspector;
using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform top;
    [SerializeField]
    private Transform bottom;
    [Button]
    public void OpenHoleWithSize(float holeSize)
    {
        //5 -> half of pipe length
        if (top.position.y + holeSize / 2 -5 > GameSettings.MaxYObstacle)
        {
            var pos = bottom.localPosition;
            pos.y = -holeSize - 5; 
            bottom.localPosition = pos;
            pos = top.localPosition;
            pos.y =  5;
            top.localPosition = pos;
        }else if (bottom.position.y - holeSize / 2  + 5< GameSettings.MinYObstacle)
        {
            var pos = top.localPosition;
            pos.y = holeSize + 5;
            top.localPosition = pos;
            
            pos = bottom.localPosition;
            pos.y = - 5; 
            bottom.localPosition = pos;
        }
        else
        {
            var pos = top.localPosition;
            pos.y = (holeSize/2) + 5;
            top.localPosition = pos;
            
            pos = bottom.localPosition;
            pos.y = (-holeSize/2) - 5; 
            bottom.localPosition = pos;
        }
    }
}
