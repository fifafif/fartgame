using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public bool IsMoving { get; private set; }

    public Vector3 Origin;
    public Vector3 Destination;
    public float Speed;

    void Start()
    {

    }

    public void MoveToDestination(Vector3 destination)
    {
        Origin = transform.position;
        Destination = destination;

        IsMoving = true;
    }

    void Update()
    {
        if (!IsMoving) return;

        if (HasReachedDestination())
        {
            IsMoving = false;
            transform.position = Destination;

            return;
        }

        transform.LookAt(Destination);

        var moveDir = Vector3.forward * Speed * Time.deltaTime;
        transform.Translate(moveDir);
    }

    public bool HasReachedDestination()
    {
        return (transform.position - Destination).sqrMagnitude <= 0.01f;
    }
}
