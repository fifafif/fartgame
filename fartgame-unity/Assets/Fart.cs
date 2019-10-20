using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fart : MonoBehaviour
{
    public ParticleSystem fartParticleSystem;
    public int particlesToEmit = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Emit()
    {
        fartParticleSystem.Play();
        fartParticleSystem.Emit(particlesToEmit);
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
