using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private static bool created = false;
    public GameObject musicObject;
    public static int control = 0;

    void Awake()
    {

        
    }
    // Update is called once per frame
    void Start(){
	//Debug.Log(SceneManager.GetActiveScene().buildIndex);
	if(SceneManager.GetActiveScene().buildIndex == 1){
		if (!created)
        	{
			musicObject = this.gameObject;
			//Debug.Log("9999999");
            		DontDestroyOnLoad(musicObject);
            		created = true;
            		//Debug.Log("Awake: " + this.gameObject);
        	}
        	else {
            		Destroy(this.gameObject);
		}
	if(control ==1){
	   GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Play();
	   control = 0;
	   }
	}
	else if(SceneManager.GetActiveScene().buildIndex != 1){
		if(GameObject.FindGameObjectWithTag("Music") != null)
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().Stop();
			control =1;
	}
	
        this.GetComponent<AudioSource>().Play();
    }
}
