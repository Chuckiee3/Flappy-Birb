using _GAME_.Scripts.Actions;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private Transform[] bgs;
    [SerializeField] private Transform[] bottoms;
    
    private float diffX;
    private float diffXBottom;
    private bool shouldMove;
    private int len;
    private int lenBot;
    public float DiffX => diffX;
    public float DiffXBottom => diffX;

    private void OnEnable()
    {
        GameFlow.levelStarted += StartMoving;
        GameFlow.levelFailed += StopMoving;
        GameFlow.levelRestarted += ResetPositions;
    }

    private void OnDisable()
    {
        GameFlow.levelStarted -= StartMoving;
        GameFlow.levelFailed -= StopMoving;
        GameFlow.levelRestarted -= ResetPositions;
    }

    private void ResetPositions()
    {
        for (int i = 0; i < len; i++)
        {
            var pos = bgs[i].transform.position;
            pos.x =  diffX * i;
            bgs[i].transform.position = pos;
        }
        for (int i = 0; i < lenBot; i++)
        {
            var pos = bottoms[i].transform.position;
            pos.x =  diffXBottom * i;
            bottoms[i].transform.position = pos;
        }
    }

    private void StopMoving()
    {
        shouldMove = false;
    }
    private void StartMoving()
    {
        shouldMove = true;
    }

    void Start()
    {
        AlignImages();
    }

    private void AlignImages()
    {
        diffX = bgs[0].localScale.x * 2.880015f;
        len = bgs.Length;
        for (int i = 1; i < len; i++)
        {
            var pos = bgs[i].transform.position;
            pos.x =  diffX * i;
            bgs[i].transform.position = pos;
        }
        
        
        diffXBottom = bottoms[0].localScale.x * 3.360016f;
        lenBot = bottoms.Length;
        for (int i = 1; i < lenBot; i++)
        {
            var pos = bottoms[i].transform.position;
            pos.x =  diffX * i;
            bottoms[i].transform.position = pos;
        }
    }

    private void Update()
    {
        if(!shouldMove) return;
        var movement = Vector3.left * (Time.deltaTime * GameSettings.HorizontalMovementSpeed);
        for (int i = 0; i < lenBot; i++)
        {
            bottoms[i].Translate(movement);
        }
        for (int i = 0; i < lenBot; i++)
        {
            if (bottoms[i].transform.position.x < -diffXBottom)
            {
                MoveIthBottomToEnd(i);
            }
        }
        for (int i = 0; i < len; i++)
        {
            bgs[i].Translate(movement);
        }
        for (int i = 0; i < len; i++)
        {
            if (bgs[i].transform.position.x < -diffX)
            {
                MoveIthBgToEnd(i);
            }
        }
    }

    private void MoveIthBottomToEnd(int i)
    {
        float maxX = float.MinValue;
        for (int j = 0; j < lenBot; j++)
        {
            if (maxX < bottoms[j].transform.position.x)
            {
                maxX = bottoms[j].transform.position.x;
            }
        }
        var pos = bottoms[i].transform.position;
        pos.x =  maxX + diffX;
        bottoms[i].transform.position = pos;
    }

    private void MoveIthBgToEnd(int i)
    {
        float maxX = float.MinValue;
        for (int j = 0; j < len; j++)
        {
            if (maxX < bgs[j].transform.position.x)
            {
                maxX = bgs[j].transform.position.x;
            }
        }
        var pos = bgs[i].transform.position;
        pos.x =  maxX + diffX;
        bgs[i].transform.position = pos;
    }
    

}
