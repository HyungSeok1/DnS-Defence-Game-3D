using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Points : MonoBehaviour
{
    public TMP_Text pointsText;
    void Awake()
    {
        pointsText = GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        pointsText.text = "Points: " + UI_Controller.points;
    }
}
