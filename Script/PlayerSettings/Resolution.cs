using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Resolution : MonoBehaviour
{

    public float rateScreen;
    // Start is called before the first frame update
    void Start()
    {
	ResolutionScreen();
    }
    void ResolutionScreen(){
        rateScreen = (Screen.height*1f)/(Screen.width*1f);
        if(rateScreen >= 2310f/1080f){
            this.transform.localScale = new Vector3(0.95f,1f,1f);
        }
        if(rateScreen <= 1920f/1080f){
            this.transform.localScale = new Vector3(1.06f,1f,1f);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android){
            if (Input.GetKey(KeyCode.Escape)) {
                SceneManager.LoadScene(0);
            }
        }
    }
}
