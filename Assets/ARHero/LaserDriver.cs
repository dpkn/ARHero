using UnityEngine;
using System.Collections;

public class LaserDriver : MonoBehaviour
{
    // This is the raycast system for hitting the beat balls

    private Camera mainCamera;
    public float range = 100f;
    BallBehaviour previousTarget;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update, and shoot, is called once per frame
    void Update()
    {
       
        Shoot();
    }

    void Shoot()
    {
        // Set previous target out of focus
        if (previousTarget != null)
        {
            previousTarget.SetFocus(false);
            previousTarget = null;
        }

        RaycastHit hit;

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
         
            BallBehaviour target = hit.transform.GetComponent<BallBehaviour>();

            if (target != null)
            {

                // If the player wants to hit the ball, hit it, otherwise just highlight it.
                if (Input.GetMouseButtonDown(0))
                {
                    target.Hit();
                }
                else
                {
                    target.SetFocus(true);
                }
                previousTarget = target;
            }

        }

    }

}
