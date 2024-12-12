using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DragnShoot_UI : MonoBehaviour
{
    public TMP_Text dragnshootText;
    void Start()
    {
        dragnshootText = GetComponent<TMP_Text>();
    }

    void FixedUpdate()
    {
        if (!UI_Controller.attempting && !UI_Controller.isUpgrade)
        {
            dragnshootText.color = new Color(255, 255, 255, 255);
        }else{
            dragnshootText.color = new Color(255, 255, 255, 0);
        }
    }
}
