using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TempoManager : MonoBehaviour
{
    public float BPM = 125;
    private float _lastSyncTime = 0;
    private uint _beatsSinceSync = 0;
    public float startDelay = 0;
    public AudioSource audio1;
    public AudioSource audio2;
    public AudioSource audio3;
    public AudioSource audio4;
    public AudioSource audio5;
    public AudioSource audio6;
    public AudioSource audio7;

    public Spawner spawner;
  //  public Text text;

    void Start()
    {
        SyncBPM();
        double initTime = AudioSettings.dspTime;
        audio1.PlayScheduled(initTime + startDelay);
        audio2.PlayScheduled(initTime + startDelay);
        audio3.PlayScheduled(initTime + startDelay);
        audio4.PlayScheduled(initTime + startDelay);
        audio5.PlayScheduled(initTime + startDelay);
        audio6.PlayScheduled(initTime + startDelay);
        audio7.PlayScheduled(initTime + startDelay);
    }
    void Update()
    {
        //Check beat timer and trigger beat if neccessary
        if (Time.time > _lastSyncTime + (BeatsPerMinuteToDelay(BPM) * _beatsSinceSync))
        {
            Beat();
        }

       // text.text = _beatsSinceSync.ToString("0");
    }
    private static float BeatsPerMinuteToDelay(float beatsPerMinute)
    {
        //beats per second = beatsPerMinute / 60
        return 1.0f / (beatsPerMinute / 60.0f);
    }
    private void Beat()
    {
        _beatsSinceSync++;

        if (_beatsSinceSync % 4 == 0)
        {
            spawner.Spawn();
        }

    }
    /// <summary>
    /// Restart BPM timer
    /// </summary>
    public void SyncBPM()
    {
        _lastSyncTime = Time.time;
        _beatsSinceSync = 0;
        Beat(); //NB: beat is now synced immedately instead of after a 1 beat delay
    }
}