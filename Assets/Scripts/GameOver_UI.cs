using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOver_UI : MonoBehaviour
{
    public TMP_Text gameOverText;
    public AudioClip audioClip;

    void Start()
    {
        gameObject.SetActive(false);
    }

    void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
