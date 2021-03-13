using UnityEngine;

public class PlayerMicControl : MonoBehaviour
{
    private BirdBehaviour _birdBehaviour;
    [SerializeField]
    private AudioSource _source;
    [SerializeField]
    private AudioMeasureCS _audioMeasure;

    private string selectedDevice;
    private bool started;
    private void Awake()
    {
        _birdBehaviour = GetComponent<BirdBehaviour>();
        if (Microphone.devices.Length ==  0)
        {
            Debug.LogError("No mic found!");
        }
        else
        {
            selectedDevice = Microphone.devices[0].ToString();
            _source.clip = Microphone.Start(selectedDevice, true, 10, AudioSettings.outputSampleRate);
        }
    }

    void Update()
    {
        if (Microphone.GetPosition(selectedDevice) <= 0)
        {
            return;
        }
        else
        {
            if(!started){
                started = true;
                _source.Play();
            }
        }
        if (_audioMeasure.GetDB() >= -5f)
        {
            //TODO: Scale with db loudness
            Debug.Log("DB::"+_audioMeasure.GetDB());
            _birdBehaviour.Flap();
            if (!LevelManager.Instance.levelStarted)
            {
                LevelManager.Instance.LevelStarted();
                
            }
        }
    }
}
