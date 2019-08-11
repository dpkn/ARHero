using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public Material idleMaterial;
    public Material focusUnoptimalMaterial;
    public Material focusOptimalMaterial;

    public bool isInFocus = false;
    public MeshRenderer meshRenderer;
    public float moveSpeed = 1f;

    private Material focusMaterial;

    // Start is called before the first frame update
    void Start()
    {
        focusMaterial = focusUnoptimalMaterial;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * moveSpeed;
        
    }

    public void SetFocus(bool focus)
    {
        isInFocus = focus;
        if (isInFocus)
        {
            meshRenderer.material = focusMaterial;
        }
        else
        {   
            meshRenderer.material = idleMaterial;
        }
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {

       // Debug.Log(other.name);
        focusMaterial = focusOptimalMaterial;
        Destroy(gameObject, 2000);
    }


}
