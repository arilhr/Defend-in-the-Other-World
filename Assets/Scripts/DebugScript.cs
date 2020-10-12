using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    private Text debugText;
    public GameObject player;

    void Start() {
        debugText = GetComponent<Text>();
    }

    void Update() {
        debugText.text = ""; 
    }
}
