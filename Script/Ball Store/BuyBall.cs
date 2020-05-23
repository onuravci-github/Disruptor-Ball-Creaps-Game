using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBall : MonoBehaviour
{
    public int numb;
    private int up;
    private int control;

    // Start is called before the first frame update
    void Start()
    {
        up = (StorePage.pageNumber-1)*9;
        control = up + numb -1;
    }

    // Update is called once per frame
    void Update()
    {
        up = (StorePage.pageNumber-1)*9;
        control = up + numb -1;
    }


    public void Buy(){
        if(PlayerSettings.getMainGold() >= 10){
            PlayerSettings.setMainGold(PlayerSettings.getMainGold() - 10);
            PlayerSettings.setBalls(control,1);
        }
    }
}
