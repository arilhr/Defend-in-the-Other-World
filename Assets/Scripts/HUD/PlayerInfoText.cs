using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoText : MonoBehaviour
{
    private Text infoText;
    private GameObject player;
    private GameObject tower;

    void Start() {
        player = PlayerManager.instance.player;
        tower = PlayerManager.instance.tower;
        infoText = GetComponent<Text>();
    }

    void Update() {
        infoText.text = "HP : " + player.GetComponent<PlayerController>().GetHP();
        infoText.text += "\nMP : " + player.GetComponent<PlayerController>().GetMP();
        infoText.text += "\nTOWER HP : " + tower.GetComponent<Tower>().GetHP();
    }
}