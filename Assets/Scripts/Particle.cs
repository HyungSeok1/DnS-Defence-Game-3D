using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public AudioClip audioClip;
    void Awake()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        Destroy(gameObject, 1f);
    }
}
