using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Update()
    {
        text.text = GameManager.score.ToString();
    }
}
