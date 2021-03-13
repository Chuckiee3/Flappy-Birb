using System;
using _GAME_.Scripts.Actions;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIControl : MonoBehaviour
{
    private BirdBehaviour _birdBehaviour;
    public GameSettingsSO settings;
    private float flapCooldown;
    private bool recentlyFlapped;
    private float rerollDelay;
    private bool recentlyRolled;

    

    private void Awake()
    {
        _birdBehaviour = GetComponent<BirdBehaviour>();
    }

    void Update()
    {
        if(!_birdBehaviour.isAlive) return;
        if (recentlyFlapped)
        {
            flapCooldown -= Time.deltaTime;
            if (flapCooldown <= 0)
            {
                recentlyFlapped = false;
            }
        }

        if (recentlyRolled)
        {
            rerollDelay -= Time.deltaTime;
            if (rerollDelay <= 0)
            {
                recentlyRolled = false;
            }
        }
        //First 2 methods return shouldFlap
        if (BetweenObstaclesAndFarFromTop())
        {
            Debug.Log("In Obstacle");
            _birdBehaviour.Flap(Random.Range(1,1.25f));
        }
        else if(TooCloseToGround())
        {
            Debug.Log("Too close to ground");
            _birdBehaviour.Flap(Random.Range(1.25f,1.5f));
            
        }else if (HasObstacleAhead())
        {
            Debug.Log("Has obstacle");
            if (HoleAbove())
            {
                if (!recentlyFlapped)
                {
                    recentlyFlapped = true;
                    flapCooldown = Random.Range(0.2f, .7f);
                    _birdBehaviour.Flap(Random.Range(1.0f,1.5f));
                } 
            }
        }
        else if(!recentlyRolled && ShouldRandomFlap())
        {
            Debug.Log("Random flap");
            if (!recentlyFlapped)
            {
                recentlyFlapped = true;
                flapCooldown = Random.Range(0.1f, .3f);
                _birdBehaviour.Flap(Random.Range(1.0f,1.5f));
            } 
        }
        
    }

    private bool ShouldRandomFlap()
    {
        recentlyRolled = true;
        rerollDelay = Random.Range(0.5f, 1f);
        return Random.Range(0f, 1f) < settings.aiRandomFlapChance;
    }

    private bool HoleAbove()
    {
        return transform.position.y < ObstacleManager.Instance.nextHolePos.position.y;
    }

    private bool HasObstacleAhead()
    {
        return Physics2D.Raycast(transform.position, Vector2.up, settings.minUpDistanceToFlap, settings.obstacleLayer, 0,10).collider != null;
        
    }

    private bool TooCloseToGround()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, settings.groundCheckDistance, settings.obstacleLayer,0,10).collider != null;
    }

    private bool BetweenObstaclesAndFarFromTop()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.up, settings.minUpDistanceToFlap, settings.obstacleLayer,0,10);
        if (hit.collider != null)
        {
            var dist = hit.point.y - transform.position.y;
            if (dist <= settings.minUpDistanceToFlap)
            {
                return true;
            }
        }
        return false;
        
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, transform.position + Vector3.right * settings.aiLookAheadDistance,Color.green);
        Debug.DrawLine(transform.position, transform.position + Vector3.up * settings.minUpDistanceToFlap, Color.green);
        Debug.DrawLine(transform.position, transform.position + Vector3.down * settings.groundCheckDistance, Color.green);
    }

#endif
}
