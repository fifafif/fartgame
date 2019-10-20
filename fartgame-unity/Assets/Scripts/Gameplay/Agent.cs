using UnityEngine;

public class Agent : MonoBehaviour
{
    public string Id;

    public AgentSystem System { get; private set; }

    public void Init(AgentSystem system)
    {
        System = system;
    }

    public float Distance(Agent other)
    {
        return (transform.position - other.transform.position).magnitude;
    }
}
