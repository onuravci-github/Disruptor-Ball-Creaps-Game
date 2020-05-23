using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        text.text = "Stage " + (PlayerSettings.getActiveLevel()+1).ToString();
    }
}
