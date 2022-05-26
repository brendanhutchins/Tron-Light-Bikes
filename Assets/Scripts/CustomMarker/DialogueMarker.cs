using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class DialogueMarker : Marker, INotification, INotificationOptionProvider
{
    [SerializeField] private string message = "";
    [SerializeField] private float pausePerLetter = 0.1f;

    [Space(20)]
    [SerializeField] private bool retroactive = false;
    [SerializeField] private bool emitOnce = false;


    // TextColor
    // TextAlignment
    // SpeakerPortrait
    // etc

    public PropertyName id => new PropertyName();
    public string Message => message;
    public float PausePerLetter => pausePerLetter;

    public NotificationFlags flags =>
        (retroactive ? NotificationFlags.Retroactive : default) |
        (emitOnce ? NotificationFlags.TriggerOnce : default);
}
