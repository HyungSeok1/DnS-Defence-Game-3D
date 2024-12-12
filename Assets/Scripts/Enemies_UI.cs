using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Enemies_UI : MonoBehaviour
{
    TMP_Text enemiesText;
    void Start()
    {
        enemiesText = GetComponent<TMP_Text>();
    }
    void Update()
    {
        enemiesText.text = "Enemies\t" + UI_Controller.maxEnemies + " / " + UI_Controller.enemies;
    }
}
