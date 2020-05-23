using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{

    public static Color color1 = new Color(0.5f,0.980383f,0.59f,1f);
    public static Color color2 = new Color(0.9011321f,0.4362656f,0.4847966f,1f);
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerSettings.getSound() == 0){
            AudioListener.volume = 1f;
        }
        else {
            AudioListener.volume = 0f;
        }

        if(PlayerSettings.getSound() == 0){
            this.GetComponent<Image>().color = color1;
        }
        else{
            this.GetComponent<Image>().color = color2;
        }

    }


    public void SoundOnOff(){
        if(PlayerSettings.getSound() == 0){
            AudioListener.volume = 0f;
            PlayerSettings.setSound(1);
            this.GetComponent<Image>().color = color2;
        }
        else{
            this.GetComponent<AudioSource>().Play();
            AudioListener.volume = 1f;
            PlayerSettings.setSound(0);
            this.GetComponent<Image>().color = color1;
        }
    }

}
