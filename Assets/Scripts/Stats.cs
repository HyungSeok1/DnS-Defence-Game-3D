using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stats : MonoBehaviour
{

    public TMP_Text statsText;
    void Awake()
    {
        statsText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        statsText.text = "Drag Power: " + UI_Controller.dragPower + "\n\nAttack Power: " + UI_Controller.attackPower + "\n\nMax Attempts(10pt): " + UI_Controller.maxAttempt;
    }
}
