using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.System
{
    public class EventAggregator 
    {
        public static void Post<T>(object sender, T eventHandler)
        {
            EventAggregatorInner<T>.Post(sender, eventHandler);
        }

        public static void Subscribe<T>(Action<object, T> action)
        {
            EventAggregatorInner<T>.Event += action;
        }
        public static void Unsubscribe<T>(Action<object, T> action)
        {
            EventAggregatorInner<T>.Event -= action;
        }

        private static class EventAggregatorInner<T>
        {
            public static Action<object, T> Event;

            public static void Post(object sender, T eventHandler)
            {
                Event?.Invoke(sender, eventHandler);
            }
        }
    }
}
