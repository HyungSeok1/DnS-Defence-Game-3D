using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Attempts : MonoBehaviour
{
    TMP_Text attemptText;
    void Start()
    {
        attemptText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        attemptText.text = "Attempts: " + UI_Controller.maxAttempt + " / " + UI_Controller.attempt;
    }
}
