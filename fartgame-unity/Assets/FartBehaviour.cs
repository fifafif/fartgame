using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundBehaviour))]
public class FartBehaviour : MonoBehaviour
{
    public FartSystem FartSystem;
    public int initialFartParticleCount;
    public int continuousFartParticleCount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fart(initialFartParticleCount);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            EmitFart(continuousFartParticleCount);
        }
    }

    private void EmitFart(int amount)
    {
        FartSystem.SpawnFart(this.gameObject, amount);
    }

    void Fart(int amount)
    {
        GetComponent<SoundBehaviour>().PlaySound("fart_short");
        EmitFart(amount);
    }
}