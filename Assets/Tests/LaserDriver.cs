using UnityEngine;
using System.Collections;

public class LaserDriver : MonoBehaviour
{
    /*  public LineRenderer laserLineRenderer;
      public float laserWidth = 0.1f;
      public float laserMaxLength = 5f;

      void Start()
      {
          Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
          laserLineRenderer.SetPositions(initLaserPositions);
          laserLineRenderer.startWidth = laserWidth;
          laserLineRenderer.endWidth = laserWidth;
      }

      void Update()
      {

              ShootLaserFromTargetPosition(transform.position, Vector3.forward, laserMaxLength);
              laserLineRenderer.enabled = true;

      }

      void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
      {
          Ray ray = new Ray(targetPosition, direction);
          RaycastHit raycastHit;
          Vector3 endPosition = targetPosition + (length * direction);

          if (Physics.Raycast(ray, out raycastHit, length))
          {
              endPosition = raycastHit.point;
          }

          laserLineRenderer.SetPosition(0, targetPosition);
          laserLineRenderer.SetPosition(1, endPosition);
      }*/
    private Camera mainCamera;
    public float range = 100f;
    BallBehaviour previousTarget;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       
        Shoot();
    }

    void Shoot()
    {
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
