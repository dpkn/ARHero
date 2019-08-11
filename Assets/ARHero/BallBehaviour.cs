using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    private TempoManager tempoManager; 

    public Material idleMaterial;
    public Material focusUnoptimalMaterial;
    public Material focusOptimalMaterial;
    private Material focusMaterial;

    public bool isInFocus = false;
    // 0 = too early, 1 = perfect, 2 = too late
    private int ballState = 0;

    public MeshRenderer meshRenderer;
    public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        focusMaterial = focusUnoptimalMaterial;
        tempoManager = TempoManager.instance;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {   
    
        transform.position += Time.deltaTime * transform.forward * moveSpeed;
        moveSpeed = tempoManager.moveSpeed;

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
        if (ballState == 0)
        {
            tempoManager.score++;
        }
        else if(ballState == 1){
            tempoManager.score += 10;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        focusMaterial = focusOptimalMaterial;
        ballState = 1;

    }
    private void OnTriggerExit(Collider other)
    {

        focusMaterial = focusUnoptimalMaterial;
        ballState = 2;
        tempoManager.livesLeft--;
        Destroy(gameObject, 500);

    }


}
