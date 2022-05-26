using System;
using UnityEngine;
using UnityEngine.Playables;
using System.Linq;
using UnityEngine.Timeline;

public class TurnReceiver : MonoBehaviour, INotificationReceiver
{
    public SignalAssetEventPair[] signalAssetEventPairs;

    [Serializable]
    public class SignalAssetEventPair
    {
        public Marker marker;
        public ParameterizedEvent events;

        [Serializable]
        public class ParameterizedEvent : Enemy { }
    }

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if (notification is TurnMarker turn)
        {
            //var newDirection = new CurrentDirection
            //{
                
            //
        }
    }
}
