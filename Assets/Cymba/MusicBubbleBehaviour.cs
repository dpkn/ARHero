using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class describes the individual behaviour of one music bubble.
// It contains play, pause and start methods as well as reacting to music

public class MusicBubbleBehaviour : MonoBehaviour
{

    private AudioSource audio;
    private int qSamples = 1024;
    private float refValue = 0.1f;
    private float rmsValue;
    private float dbValue;
    private float volume = 2;

    float[] samples = new float[1024];


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        GetVolume();
        float newScale = 1 + (volume * rmsValue);
        gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);

    }

    void GetVolume()
    {
        audio.GetOutputData(samples, 0); // fill array with samples
        int i;
        float sum = 0;

        for (i = 0; i < qSamples; i++)
        {
            sum += samples[i] * samples[i]; // sum squared samples
        }
        rmsValue = Mathf.Sqrt(sum / qSamples); // rms = square root of average
        dbValue = 20 * Mathf.Log10(rmsValue / refValue); // calculate dB
        if (dbValue < -160) dbValue = -160; // clamp it to -160dB min
    }

}
