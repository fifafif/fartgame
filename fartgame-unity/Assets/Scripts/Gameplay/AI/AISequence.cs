using System;
using UnityEngine;

public class AISequence : MonoBehaviour
{
    [Serializable]
    public class Sequence
    {
        public enum Mode
        {
            Wait,
            Move
        }

        public Mode ModeType;
        public float WaitTimeSec;
        public Transform Destination;
    }

    public Sequence[] Sequences;

    private int currentSequenceIndex = -1;

    public Sequence GetCurrentSequence()
    {
        return Sequences[currentSequenceIndex];
    }

    public bool NextSequence()
    {
        ++currentSequenceIndex;

        return currentSequenceIndex < Sequences.Length;
    }

    public void ResetSequence()
    {
        currentSequenceIndex = 0;
    }
}
