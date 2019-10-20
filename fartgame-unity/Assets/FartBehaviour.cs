using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SoundBehaviour))]
public class FartBehaviour : MonoBehaviour
{
    public FartSystem FartSystem;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fart();
        }
    }


    void Fart()
    {
        FartSystem.SpawnFart(this.gameObject);
        GetComponent<SoundBehaviour>().PlaySound("fart_short");
    }
}