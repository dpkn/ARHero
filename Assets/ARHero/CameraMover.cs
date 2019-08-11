using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{
    Camera theCamera;
    public float sensitivity = 0.1f;

    // Use this for initialization
    void Start()
    {
        theCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
   
        Vector3 vp = theCamera.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, theCamera.nearClipPlane));
        vp.x -= 0.5f;
        vp.y -= 0.5f;
        vp.x *= sensitivity;
        vp.y *= sensitivity;
        vp.x += 0.5f;
        vp.y += 0.5f;
        Vector3 sp = theCamera.ViewportToScreenPoint(vp);

        Vector3 v = theCamera.ScreenToWorldPoint(sp);
        transform.LookAt(v, Vector3.up);
    }
}


