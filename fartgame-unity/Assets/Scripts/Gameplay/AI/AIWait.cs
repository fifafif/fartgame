using UnityEngine;

public class AIWait : MonoBehaviour
{
    public float WaitTimeSec;
    public float WaitTimeLeftSec;

    public void SetWaitTime(float waitTimeSec)
    {
        WaitTimeSec = WaitTimeLeftSec = waitTimeSec;
    }

    void Update()
    {
        WaitTimeLeftSec -= Time.deltaTime;
    }

    public bool HasFinished()
    {
        return WaitTimeLeftSec <= 0f;
    }
}
