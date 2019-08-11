using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This component loads audio data nad displays it in the game object's text field
public class LivesHelper : MonoBehaviour
{
    private TempoManager tempoManager;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        tempoManager = TempoManager.instance;
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        text.text = "Lives left:" + tempoManager.livesLeft;
    }

}
