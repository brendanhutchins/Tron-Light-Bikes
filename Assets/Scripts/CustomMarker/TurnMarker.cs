using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TurnMarker : Marker, INotification, INotificationOptionProvider, Direction
{
    [SerializeField] private CurrentDirection direction;
    //[SerializeField] private float pausePerLetter = 0.1f;

    [Space(20)]
    [SerializeField] private bool retroactive = false;
    [SerializeField] private bool emitOnce = false;

    public PropertyName id => new PropertyName();
    public CurrentDirection CurrentDirection => direction;

    public NotificationFlags flags =>
        (retroactive ? NotificationFlags.Retroactive : default) |
        (emitOnce ? NotificationFlags.TriggerOnce : default);

}

