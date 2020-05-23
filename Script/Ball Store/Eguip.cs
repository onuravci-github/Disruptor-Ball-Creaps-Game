using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eguip : MonoBehaviour
{
    private Image image;

    public int numb;
    private int up;

    private int control;

    private static Color color1 = new Color(1f,1f,1f,1f);
    private static Color color2 = new Color(1f,1f,1f,0.5f);
    private static Color color3 = new Color(1f,1f,1f,0f);
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        up = (StorePage.pageNumber-1)*9;
        control = up + numb - 1;

        if(PlayerSettings.getActiveBall() != control){
            if(PlayerSettings.getBalls(control) != 0){
                PlayerSettings.setBalls(control,1);
            }
        }

        if(PlayerSettings.getBalls(control) == 1){
            image.color = color2;
        }
        else if(PlayerSettings.getBalls(control) == 2){
            image.color = color1;
        }
        else{
            image.color = color3;
        }

        
    }

    public void EguipBall(){
        if(PlayerSettings.getBalls(control) == 1){
            PlayerSettings.setBalls(control,2);
            PlayerSettings.setActiveBall(control);
        }

        else if(PlayerSettings.getBalls(control) == 2){
            PlayerSettings.setBalls(control,1);
            PlayerSettings.setBalls(0,0);
            PlayerSettings.setActiveBall(0);
        }
    }
}
