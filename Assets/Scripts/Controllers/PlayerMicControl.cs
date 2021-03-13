using System;
using UnityEngine;

public class PlayerMicControl : MonoBehaviour
{
    private BirdBehaviour _birdBehaviour;
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioMeasureCS _audioMeasure;

    private string selectedDevice;
    private float flapCooldown;
    private bool recentlyFlapped;
    private void Awake()
    {
        _birdBehaviour = GetComponent<BirdBehaviour>();
        
    }

    protected void Start()
    {
        
        int min = 0;
        int max = 0;
        while(Microphone.devices.Length == 0){}
        Microphone.GetDeviceCaps(Microphone.devices[0], out min, out max);
        _source.clip = Microphone.Start(Microphone.devices[0], true, 10, AudioSettings.outputSampleRate);
       
        while (!(Microphone.GetPosition(null) > 1))
        {

        }
        _source.loop = true;
        _source.Play();
    }

    void Update()
    {
        
        
        if (recentlyFlapped)
        {
            flapCooldown -= Time.deltaTime;
            if (flapCooldown < 0)
            {
                recentlyFlapped = false;
            }
        }
        if (!recentlyFlapped && _audioMeasure.GetDB() >= GameSettings.minDBToFlap)
        {
            var mapped = _audioMeasure.GetDB().Remap(GameSettings.minDBToFlap, GameSettings.maxDB,
                GameSettings.BaseFlapForce, GameSettings.MaxFlapForce);
            Debug.Log("DB: "+ _audioMeasure.GetDB() + "-forcE:" + mapped);
            recentlyFlapped = true;
            flapCooldown = GameSettings.PlayerFlapCooldown;
            
            
            _birdBehaviour.Flap(mapped);
            if (!LevelManager.Instance.levelStarted)
            {
                LevelManager.Instance.LevelStarted();
                
            }
        }
    }

    public float GetDB()
    {
        return _audioMeasure.GetDB();
    }
}
