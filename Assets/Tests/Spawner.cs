using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject ballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        GameObject ball = Instantiate(ballPrefab,transform);
       ball.transform.parent = transform.parent;
        ball.transform.position = transform.position;
    }
}
