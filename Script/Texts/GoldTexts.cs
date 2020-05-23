using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldTexts : MonoBehaviour
{
    private Text text;
    public int function;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (function == 0)
        {
            text.text = PlayerSettings.getMainGold().ToString();
        }
        else
        {
            text.text = LevelControl.gainGold.ToString();
        }
        
    }
}
