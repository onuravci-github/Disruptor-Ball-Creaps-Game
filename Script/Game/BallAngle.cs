using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallAngle : MonoBehaviour
{
    public static Text text;
    private Mouse mouse;
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        if(GameObject.FindObjectOfType<Mouse>() != null){
            mouse = GameObject.FindObjectOfType<Mouse>();
        }
        text.fontSize = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindObjectOfType<Mouse>() != null && mouse == null){
            mouse = GameObject.FindObjectOfType<Mouse>();
        }
        else if(mouse != null){
            text.text =  (mouse.angle + 180).ToString("F1") + "°";
        }
        
    }
}
