using UnityEngine;

public class AIAgent : MonoBehaviour
{
    private AIMovement movement;
    private AISequence sequence;
    private AIWait wait;
    private AIFartDetection fartDetection;

    public enum State
    {
        None = -1,
        Move,
        Wait,
        FartDetected,
    }

    public State CurrentState = State.None;

    private AISequence.Sequence currentSequence;

    private void Awake()
    {
        movement = GetComponent<AIMovement>();
        sequence = GetComponent<AISequence>();
        wait = GetComponent<AIWait>();
        fartDetection = GetComponent<AIFartDetection>();
    }

    private void Start()
    {
        Begin();
    }

    public void Begin()
    {
        BeginNextSequence();
    }

    private void BeginNextSequence()
    {
        if (!sequence.NextSequence())
        {
            sequence.ResetSequence();
        }

        SetNextSequence(sequence.GetCurrentSequence());
    }

    private void SetNextSequence(AISequence.Sequence sequence)
    {
        currentSequence = sequence;
        if (sequence.ModeType == AISequence.Sequence.Mode.Move)
        {
            movement.MoveToDestination(sequence.Destination.position);
            CurrentState = State.Move;
        }
        else if (sequence.ModeType == AISequence.Sequence.Mode.Wait)
        {
            wait.SetWaitTime(sequence.WaitTimeSec);
            CurrentState = State.Wait;
        }
    }

    private void SetStateFromSequence(AISequence.Sequence sequence)
    {
        if (sequence.ModeType == AISequence.Sequence.Mode.Move)
        {
            CurrentState = State.Move;
        }
        else if (sequence.ModeType == AISequence.Sequence.Mode.Wait)
        {
            CurrentState = State.Wait;
        }
    }

    public void FartDetected(FartDetector.FartDetectionData data)
    {
        CurrentState = State.FartDetected;

        fartDetection.FartDetected(data);
    }

    private void UpdateState()
    {
        if (currentSequence == null) return;

        switch (CurrentState)
        {
            case State.Move:

                if (movement.HasReachedDestination())
                {
                    BeginNextSequence();
                }

                break;

            case State.Wait:

                if (wait.HasFinished())
                {
                    BeginNextSequence();
                }

                break;

            case State.FartDetected:

                if (fartDetection.HasFinished())
                {
                    SetStateFromSequence(currentSequence);
                }

                break;
        }
    }

    void Update()
    {
        UpdateState();
    }
}
