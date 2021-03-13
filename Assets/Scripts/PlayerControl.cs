using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private BirdBehaviour _birdBehaviour;

    private void Awake()
    {
        _birdBehaviour = GetComponent<BirdBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _birdBehaviour.Flap();
            if (!LevelManager.Instance.levelStarted)
            {
                LevelManager.Instance.LevelStarted();
                
            }
        }
    }
}
