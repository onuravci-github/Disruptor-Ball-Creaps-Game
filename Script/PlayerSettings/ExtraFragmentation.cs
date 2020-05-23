using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraFragmentation : MonoBehaviour
{

    public int function;
    private Image image;
    public static Color color1 = new Color(1f,1f,1f,0.5f);
    public static Color color2 = new Color(1f,1f,1f,1f);
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerSettings.getExtraFragmentaton() == 0){
            if(function != 0){
                image.color = color1;
            }
            else {
                image.color = color2;
            }
        }
        else if(PlayerSettings.getExtraFragmentaton() == 1){
            if(function != 1){
                image.color = color1;
            }
            else {
                image.color = color2;
            }
        }
        else {
            if(function != 2){
                image.color = color1;
            }
            else {
                image.color = color2;
            }
        }

    }

    public void ExtraFrag(){
        if(function == 0){
            PlayerSettings.setExtraFragmentaton(0);
        }
        else if(function == 1){
            PlayerSettings.setExtraFragmentaton(1);
        }
        else if(function == 2){
            PlayerSettings.setExtraFragmentaton(2);
        }

        this.GetComponent<AudioSource>().Play();
    }
}
