using System.Collections.Generic;
using UnityEngine;

namespace TPS.Share
{
    public class Timer : MonoBehaviour
    {
        private class TimeEvent
        {
            public float TimeToExecute;
            public CallBack Method;

        }

        private List<TimeEvent> events;


        public delegate void CallBack();

        void Awake()
        {

            events = new List<TimeEvent>();

        }

        public void Add(CallBack method, float inSeconds)
        {

            events.Add(new TimeEvent
            {
                Method = method,
                TimeToExecute = Time.time + inSeconds
            });

        }

        void Update()
        {

            if (events.Count == 0)
            {
                return;
            }

            for (int i = 0; i < events.Count; i++)
            {

                if (events[i].TimeToExecute <= Time.time)
                {
                    events[i].Method();
                    events.Remove(events[i]);
                }

            }

        }
    }
}