using System;
using _GAME_.Scripts.Actions;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
public class BirdBehaviour : MonoBehaviour
{
    public bool isAlive { get; private set; }
    private bool isPlayer;
    private BirdMovement _birdMovement;
    private Collider _collider;

    private void Awake()
    {
        _birdMovement = GetComponent<BirdMovement>();
        _collider = GetComponent<Collider>();
        isPlayer = TryGetComponent<PlayerControl>(out var playerControl);
        isAlive = true;
    }

    public void HitObstacle(Collider obstacleCollider)
    {
        Debug.Log("Hit?");
        if(!isAlive) return;
        
        isAlive = false;
        if (isPlayer)
        {
            Debug.Log("playeR?_?");
            GameFlow.TriggerLevelFailed();
        }
        else
        {
            Debug.Log("not playeR?_?");
            GameFlow.TriggerBirdDown();
        }
    }

    public void Flap(float forceMultiplier = 1)
    {
        _birdMovement.Flap();
    }

  
}
