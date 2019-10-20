using UnityEngine;

public class FartDetector : MonoBehaviour
{
    public class FartDetectionData
    {
        public float Distance;
        public float Strength;
        public float Noise;
    }

    private AIAgent aiAgent;
    private GameObject lastFartSource;

    private void Awake()
    {
        aiAgent = GetComponent<AIAgent>();
    }

    public void NewFartDetected(GameObject source)
    {
        lastFartSource = source;

        var strength = Mathf.Max(5 - (source.transform.position - transform.position).magnitude, 0f);

        var data = new FartDetectionData
        {
            Strength = strength
        };

        aiAgent.FartDetected(data);

        Debug.Log("OnFartDetected" + source);
    }

    public void OnFartDetected(GameObject source)
    {
        if (source == lastFartSource) return;

        NewFartDetected(source);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter" + collision.gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("OnTriggerEnter" + collision.gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("OnTriggerEnter" + other.gameObject);

        OnFartDetected(other);
    }
}
