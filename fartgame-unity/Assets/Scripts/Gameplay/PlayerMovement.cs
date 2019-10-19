using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("horizontal"), 0f, Input.GetAxis("horizontal"));
        move *= Speed * Time.deltaTime;
        transform.Translate(move);
    }
}
