 using UnityEngine;

 public class AudioMeasureCS : MonoBehaviour
 {
     public float RmsValue;
     public float DbValue;
     public float PitchValue;
 
     private const int QSamples = 1024;
     private const float RefValue = 0.1f;
     private const float Threshold = 0.02f;
 
     float[] _samples;
     private float[] _spectrum;
     private float _fSample;

     public AudioSource source;
     void Start()
     {
         _samples = new float[QSamples];
         _spectrum = new float[QSamples];
         _fSample = AudioSettings.outputSampleRate;
     }

     public float GetDB()
     {
         source.GetOutputData(_samples, 0); // fill array with samples
         int i;
         float sum = 0;
         for (i = 0; i < QSamples; i++)
         {
             sum += _samples[i] * _samples[i]; // sum squared samples
         }
         RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
         return 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
     }
 }