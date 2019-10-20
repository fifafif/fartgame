using System.Collections.Generic;
using UnityEngine;

public class AIFartDetection : MonoBehaviour
{
    public float WaitTimeSec = 1f;
    public float Radius = 1f;

    private float waitTimeLeftSec;
    private Agent agent;

    public class PotentialFarter
    {
        public Agent Agent;
        public int FartTimesWhenAround;
    }

    private List<PotentialFarter> potentialFarters = new List<PotentialFarter>();
    private Dictionary<Agent, PotentialFarter> potentialMap = new Dictionary<Agent, PotentialFarter>();

    private void Awake()
    {
        agent = GetComponent<Agent>();
    }

    void Update()
    {
        waitTimeLeftSec -= Time.deltaTime;
    }

    public void FartDetected(FartDetector.FartDetectionData data)
    {
        waitTimeLeftSec = WaitTimeSec;

        FindPotentialAgents();

        Debug.Log("FART");
    }

    private void FindPotentialAgents()
    {
        var potentails = new List<Agent>();

        foreach (var other in agent.System.Agents)
        {
            if (other == agent) continue;

            if (agent.Distance(other) <= Radius)
            {
                potentails.Add(other);
            }
        }

        if (potentails.Count == 1)
        {
            FarterDiscovered(potentails[0]);
        }
        else
        {
            potentails.ForEach(a => RegisterPotentialFarter(a));
        }
    }

    private void FarterDiscovered(Agent farter)
    {
        Debug.Log("FARTER DISCOVERED! " + farter);
    }

    private void RegisterPotentialFarter(Agent potential)
    {
        if (!potentialMap.TryGetValue(potential, out var farter))
        {
            farter = new PotentialFarter
            {
                Agent = potential
            };
        }

        ++farter.FartTimesWhenAround;
    }

    public bool HasFinished()
    {
        return waitTimeLeftSec <= 0f;
    }
}
