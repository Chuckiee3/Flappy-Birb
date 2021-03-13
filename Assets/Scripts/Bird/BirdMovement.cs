using _GAME_.Scripts.Actions;
using UnityEngine;

[RequireComponent(typeof(BirdBehaviour))]
public class BirdMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private BirdBehaviour _birdBehaviour;
    public Vector3 Velocity => _rigidbody2D.velocity;

    #region Event Registration
    private void OnEnable()
    {
        GameFlow.levelStarted += StartMoving;
    }


    private void OnDisable()
    {
        GameFlow.levelStarted -= StartMoving;
    }
    #endregion
    
    private void StartMoving()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        Flap();
    }
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _birdBehaviour = GetComponent<BirdBehaviour>();
    }

    public void Flap(float forceMultiplier = 1)
    {
        if(!_birdBehaviour.isAlive) return;
        var vel = _rigidbody2D.velocity;
        vel.y = 0;
        _rigidbody2D.velocity = vel;
        _rigidbody2D.AddForce(GameSettings.BaseFlapForce * forceMultiplier * Vector2.up, ForceMode2D.Impulse );
    }

    public void StopMovement()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        _rigidbody2D.velocity =Vector2.zero;
        
    }

}
