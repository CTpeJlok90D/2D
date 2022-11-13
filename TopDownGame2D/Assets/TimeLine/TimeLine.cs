using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class TimeLine
{
    [SerializeField] private List<TimeLineEvent> _eventsOnTime;
    [SerializeField] private float _errorRate;

    public float Lenght => _eventsOnTime.Last().Time;

    public TimeLine(TimeLineEvent[] timeLineEvents, float errorRate = 0.2f)
    {
        _eventsOnTime = timeLineEvents.ToList();
        _errorRate = errorRate;
    }

    public IEnumerator StartTimerCorutine()
    {
        float _currentTime = 0;
        int currentEventNumber = 0;
        List<TimeLineEvent> events = _eventsOnTime.ToList();
        while (_currentTime < Lenght && events.Count > 0)
        {
            if (events[currentEventNumber].Time > _currentTime - _errorRate && events[currentEventNumber].Time < _currentTime + _errorRate)
            {
                events[0].Event.Invoke();
                events.Remove(events[currentEventNumber]);
            }
            _currentTime += Time.deltaTime;
            yield return null;
        }
    }
}
