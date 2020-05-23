using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraBallControl : MonoBehaviour
{
    public static int ballStart;
    // Start is called before the first frame update
    void Start()
    {
        ballStart = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(ballStart == 1){
            this.gameObject.SetActive(false);
        }
    }

    public void ExtraControlADD(){
        if(PlayerSettings.getMainGold() >= 10){
            PlayerSettings.setMainGold(PlayerSettings.getMainGold() - 10 );
            PlayerSettings.setExtraBallControl(PlayerSettings.getExtraBallControl() + 1);
            Mouse.extraControl();
        }
        
    }
    
    public void ExtraControlDEC(){
        if(PlayerSettings.getExtraBallControl() >= 1){
            PlayerSettings.setMainGold(PlayerSettings.getMainGold() + 10 );
            PlayerSettings.setExtraBallControl(PlayerSettings.getExtraBallControl() - 1);
            Mouse.extraControl();
        }
    }



    public static void startBallThisHide(){
        ballStart = 1;
    }
}
