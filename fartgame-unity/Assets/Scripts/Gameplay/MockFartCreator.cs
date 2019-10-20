using UnityEngine;

public class MockFartCreator : MonoBehaviour
{
    private Agent agent;

    private void Awake()
    {
        agent = GetComponent<Agent>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fart();
        }
    }

    public void Fart()
    {
        agent.System.Agents.ForEach(a =>
        {
            if (a != agent
                && agent.Distance(a) < 2f)
            {
                var detector = a.GetComponent<FartDetector>();
                detector?.NewFartDetected(gameObject);
            }
        });
    }
}
