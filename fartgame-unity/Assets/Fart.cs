using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fart : MonoBehaviour
{
    public ParticleSystem fartParticleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        fartParticleSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Boolean isFinished()
    {
        return !fartParticleSystem.isPlaying;
    }
}
