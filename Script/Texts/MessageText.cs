using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageText : MonoBehaviour
{
    private Text text;

    private string [] strs = {"Let's Go !","Good Luck !","Never Give Up !","Be Careful !",
    "Go !!!", "Fast !!!", "Perfect" , "Awesome" ,"!!! OMG !!!","HUH" , "Enjoyable","You Can Do It","Relax" };
    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        
        text.text = strs[Random.Range(0,12)];
        if(PlayerSettings.getActiveLevel() == 0){
           text.text = strs[0]; 
        }
    }
}
