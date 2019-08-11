using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TempoManager : MonoBehaviour
{

    // Make the tempomanager a singleton so its easily callable from anywhere in the system
    #region singleton
    public static TempoManager instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    public float BPM = 125;
    private float lastSyncTime = 0;
    private uint beatsSinceSync = 0;
    public float startDelay = 0;

    public List<AudioSource> backgroundAudioSources = new List<AudioSource>();
    public List<Spawner> spawners = new List<Spawner>();

    // How often a beat ball is spawn. (4 = every 4 beats)
    public int difficultyLevel = 4;

    public int score = 0;
    public int livesLeft = 3;
    public float moveSpeed = 10f;

    void Start()
    {
        SyncBPM();

        // Start all audio tracks at the same time so they sound in sync
        double initTime = AudioSettings.dspTime;

        foreach (AudioSource player in backgroundAudioSources)
        {
            player.PlayScheduled(initTime + startDelay);
        }
    }
    void Update()
    {
        //Check beat timer and trigger beat if neccessary
        if (Time.time > lastSyncTime + (BeatsPerMinuteToDelay(BPM) * beatsSinceSync))
        {
            Beat();

        }

        // Reset if dead
        if (livesLeft < 0)
        {
            livesLeft = 3;
            score = 0;
            difficultyLevel = 4;
            SyncBPM();
        }

        // Gradually make the game harder
        if(score > 50 && difficultyLevel >= 4)
        {
            difficultyLevel = 3;
        }else if(score > 100 && difficultyLevel >= 3)
        {
            difficultyLevel = 2;
        }else if(score > 150 && difficultyLevel >= 2)
        {
            difficultyLevel = 1;
        }

        // After dispensing every beat, make the speed faster 
        if (difficultyLevel == 1)
        {
            moveSpeed = 10 + 10 * (score / 500);
        }
    }
    // Function to convert BPM to Delay
    private static float BeatsPerMinuteToDelay(float beatsPerMinute)
    {
        //beats per second = beatsPerMinute / 60
        return 1.0f / (beatsPerMinute / 60.0f);
    }

    // Function that happens every beat 
    private void Beat()
    {
        beatsSinceSync++;

        if (beatsSinceSync % difficultyLevel == 0)
        {
            var beatDeterminator = Random.value;
            if (beatDeterminator <= 0.33)
            {
                spawners[0].Spawn();
            }
            else if (beatDeterminator< 0.66)
            {
                spawners[1].Spawn();
            }
            else
            {
                spawners[2].Spawn();
            }

        }

    }

    public void SyncBPM()
    {
        lastSyncTime = Time.time;
        beatsSinceSync = 0;
        Beat();
    }
}