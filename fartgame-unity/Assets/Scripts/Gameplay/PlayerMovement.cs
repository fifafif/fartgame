using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;

    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move *= Speed * Time.deltaTime;
        transform.Translate(move);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    GetComponent<SoundBehaviour>().PlaySound("fart_short");
        //}
    }
}
