using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wave : MonoBehaviour
{
    TMP_Text waveText;
    void Start()
    {
        waveText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        waveText.text = "Wave: " + UI_Controller.maxWave + " / " + UI_Controller.wave;
    }
}
