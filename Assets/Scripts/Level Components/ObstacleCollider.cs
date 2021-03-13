using System;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    public bool isBottom;
    private Collider _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Bird"))
        {
            BirdBehaviour birdBehaviour;
            if (other.gameObject.TryGetComponent(out birdBehaviour))
            {
                birdBehaviour.HitObstacle(_collider);
                if (isBottom)
                {
                    birdBehaviour.HitBottom();
                }
            }
        }
    }

    
}
