using UnityEngine;

public class BirdVisualController : MonoBehaviour
{
    [SerializeField]
    private BirdMovement _birdMovement;
    [SerializeField]
    private BirdBehaviour _birdBehaviour;
    [SerializeField]
    private Transform model;
    void Start()
    {
        _birdBehaviour = GetComponent<BirdBehaviour>();
        _birdMovement = GetComponent<BirdMovement>();
    }

    void Update()
    {
        if(!_birdBehaviour.isAlive) return;
        model.rotation = Quaternion.Euler(0,0, Mathf.Clamp(_birdMovement.Velocity.y * 10f, -60,60f));
    }
}
