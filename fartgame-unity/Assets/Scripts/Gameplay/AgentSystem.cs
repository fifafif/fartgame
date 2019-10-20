using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AgentSystem : MonoBehaviour
{
    public List<Agent> Agents;

    public void Awake()
    {
        CollectAgents();
    }

    private void CollectAgents()
    {
        Agents = FindObjectsOfType<Agent>().ToList();

        Agents.ForEach(a => a.Init(this));
    }
}
