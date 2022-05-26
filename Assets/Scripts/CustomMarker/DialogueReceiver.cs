using UnityEngine;
using UnityEngine.Playables;

public class DialogueReceiver : MonoBehaviour, INotificationReceiver
{
    [SerializeField] private DialogueAnimator dialogueAnimator;

    public void OnNotify(Playable origin, INotification notification, object context)
    {
        if(notification is DialogueMarker dialogueMarker && dialogueAnimator != null)
        {
            //var newDialogue = new Dialogue
            //{
            //    Message = dialogueMarker.Message,
            //    PausePerLetter
            //}
        }
    }
}
