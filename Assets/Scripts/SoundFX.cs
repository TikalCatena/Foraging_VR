using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
    public AudioSource ambiance;

    public void Start()
    {
        ambiance.Play();
    }


}
