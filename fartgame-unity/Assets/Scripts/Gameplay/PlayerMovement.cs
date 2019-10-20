using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;
    public float RotationSpeed = 1f;

    void Update()
    {
        var move = Vector3.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime;
        var rotation = Input.GetAxis("Horizontal") * RotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, rotation);
        transform.Translate(move);
    }
}
