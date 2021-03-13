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
        if(!isAlive) return;
        
        isAlive = false;
        if (isPlayer)
        {
            GameFlow.TriggerLevelFailed();
        }
        else
        {
            GameFlow.TriggerBirdDown();
        }
    }

    public void Flap(float forceMultiplier = 1)
    {
        _birdMovement.Flap();
    }


    public void HitBottom()
    {
        _birdMovement.StopMovement();
    }
}
