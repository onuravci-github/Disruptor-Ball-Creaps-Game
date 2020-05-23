using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public GameObject[] gameObjects;

    private int control;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects[0].SetActive(true);
        gameObjects[1].SetActive(false);
        gameObjects[2].SetActive(false);
        control = 0;
    }


    public void Play(){
        if(control == 0){
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(true);
            gameObjects[2].SetActive(false);
            control = 1;
        }
        else if (control == 1)
        {
            gameObjects[0].SetActive(false);
            gameObjects[1].SetActive(false);
            gameObjects[2].SetActive(true);
            control = 2;
	    PlayerSettings.setIsGameOpen(1);
        }
        else{
            Time.timeScale = 1f;
            control = 0;
            SceneManager.LoadScene(1);
        }
    }
}
