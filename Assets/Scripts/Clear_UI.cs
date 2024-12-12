using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clear_UI : MonoBehaviour
{
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
