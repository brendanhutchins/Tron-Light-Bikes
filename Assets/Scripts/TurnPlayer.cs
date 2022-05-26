using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    public GameObject player;
    public CurrentDirection direction;

    private void OnDrawGizmos()
    {
        if (player != null)
        {
            if (player.gameObject.GetComponent<SpriteRenderer>().sprite.name == "MolinaBike_Up")
            {
                switch (direction)
                {
                    case CurrentDirection.Right:
                        Gizmos.DrawIcon(transform.position, "Molina Right.png", true, Color.cyan);
                        break;
                    case CurrentDirection.Down:
                        Gizmos.DrawIcon(transform.position, "Molina Down.png", true, Color.cyan);
                        break;
                    case CurrentDirection.Left:
                        Gizmos.DrawIcon(transform.position, "Molina Left.png", true, Color.cyan);
                        break;
                    case CurrentDirection.Up:
                        Gizmos.DrawIcon(transform.position, "Molina Up.png", true, Color.cyan);
                        break;
                }
            }
            else if (player.gameObject.GetComponent<SpriteRenderer>().sprite.name == "PinkBike_Up")
            {
                switch (direction)
                {
                    case CurrentDirection.Right:
                        Gizmos.DrawIcon(transform.position, "Molina Right.png", true, Color.magenta);
                        break;
                    case CurrentDirection.Down:
                        Gizmos.DrawIcon(transform.position, "Molina Down.png", true, Color.magenta);
                        break;
                    case CurrentDirection.Left:
                        Gizmos.DrawIcon(transform.position, "Molina Left.png", true, Color.magenta);
                        break;
                    case CurrentDirection.Up:
                        Gizmos.DrawIcon(transform.position, "Molina Up.png", true, Color.magenta);
                        break;
                }
            }
            else if (player.gameObject.GetComponent<SpriteRenderer>().sprite.name == "YellowBike_Up")
            {
                switch (direction)
                {
                    case CurrentDirection.Right:
                        Gizmos.DrawIcon(transform.position, "Molina Right.png", true, Color.yellow);
                        break;
                    case CurrentDirection.Down:
                        Gizmos.DrawIcon(transform.position, "Molina Down.png", true, Color.yellow);
                        break;
                    case CurrentDirection.Left:
                        Gizmos.DrawIcon(transform.position, "Molina Left.png", true, Color.yellow);
                        break;
                    case CurrentDirection.Up:
                        Gizmos.DrawIcon(transform.position, "Molina Up.png", true, Color.yellow);
                        break;
                }
            }
            else if (player.gameObject.GetComponent<SpriteRenderer>().sprite.name == "GreenBike_Up")
            {
                switch (direction)
                {
                    case CurrentDirection.Right:
                        Gizmos.DrawIcon(transform.position, "Molina Right.png", true, Color.green);
                        break;
                    case CurrentDirection.Down:
                        Gizmos.DrawIcon(transform.position, "Molina Down.png", true, Color.green);
                        break;
                    case CurrentDirection.Left:
                        Gizmos.DrawIcon(transform.position, "Molina Left.png", true, Color.green);
                        break;
                    case CurrentDirection.Up:
                        Gizmos.DrawIcon(transform.position, "Molina Up.png", true, Color.green);
                        break;
                }
            }
        }
    }
}
