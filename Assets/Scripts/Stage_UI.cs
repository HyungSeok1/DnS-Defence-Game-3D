using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Stage_UI : MonoBehaviour
{
    TMP_Text stageText;
    void Start()
    {
        stageText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        stageText.text = "Stage: " + UI_Controller.maxStage + " / " + UI_Controller.stage;
    }
}
