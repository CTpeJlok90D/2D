using System;
using UnityEngine.Events;

[Serializable]
public struct TimeLineEvent
{
    public UnityEvent Event;
    public float Time;

    public TimeLineEvent(UnityEvent Event, float time)
    {
        this.Event = Event;
        Time = time;
    }
}