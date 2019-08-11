using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    public GameObject musicBubblePrefab;
    public int amountOfBlobs = 12;
    public float radius = 10f;
    public float groundOffset = 8f;
    private List<GameObject> musicBubbles;


    // Start is called before the first frame update
    void Start()
    {

        // Spawn a musicBall for each song stem
        for (int i = 0; i < amountOfBlobs; i++)
        {

            float angle = i * Mathf.PI * 2f / amountOfBlobs;
            float x = gameObject.transform.position.x + Mathf.Cos(angle) * radius;
            float y = gameObject.transform.position.y + groundOffset;
            float z = Mathf.Sin(angle) * radius + gameObject.transform.position.z;

            Vector3 newPos = new Vector3(x, y, z);
     
            GameObject musicBubble = Instantiate(musicBubblePrefab, newPos, Quaternion.identity);
            AudioSource audio = musicBubble.GetComponent<AudioSource>();

            var audioClip = Resources.Load<AudioClip>("Cymba/" + i.ToString("0"));
            audio.clip = audioClip;
            audio.Play();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
