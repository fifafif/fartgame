using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move *= Speed * Time.deltaTime;
        transform.Translate(move);
    }
}
