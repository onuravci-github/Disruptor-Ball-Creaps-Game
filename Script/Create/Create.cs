using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Create : MonoBehaviour
{
    public GameObject [] createObjects;

    // Start is called before the first frame update
    void Start()
    {
        if(this.tag != "Block Create" && this.tag != "Ball Create"){
            Creater();
        }
        
    }

    public void Creater(){
        
	if(this.tag == "Game Screen"){
            GameObject myPrf = Instantiate(createObjects[0], createObjects[0].transform.position,this.transform.rotation) as GameObject;
            myPrf.transform.parent = transform;
            myPrf.GetComponent<RectTransform>().localScale = new Vector3(myPrf.transform.localScale.x/100,myPrf.transform.localScale.x/100,1f);
            myPrf.GetComponent<RectTransform>().localPosition = new Vector3(myPrf.transform.localPosition.x/100,myPrf.transform.localPosition.y/100,1f);
            myPrf.SetActive(true);
            
        }


        if(this.tag == "Respawn"){
            GameObject myPrf = Instantiate(createObjects[PlayerSettings.getActiveLevel()], createObjects[PlayerSettings.getActiveLevel()].transform.position,this.transform.rotation) as GameObject;
            myPrf.transform.parent = transform;
            myPrf.GetComponent<RectTransform>().localScale = new Vector3(myPrf.transform.localScale.x/100,myPrf.transform.localScale.x/100,1f);
            myPrf.GetComponent<RectTransform>().localPosition = new Vector3(myPrf.transform.localPosition.x/100,myPrf.transform.localPosition.y/100,1f);
            myPrf.SetActive(true);
            
        }
        else if(this.tag != "Ball Creater"){
            GameObject myPrf = Instantiate(createObjects[PlayerSettings.getActiveLevel()], createObjects[PlayerSettings.getActiveLevel()].transform.position,this.transform.rotation) as GameObject;
            myPrf.transform.parent = transform;
            myPrf.SetActive(true);
            LevelControl.isGameStart = 1 ;
            Invoke("BallControlStart",0.5f);
        }
        else{
            GameObject myPrf = Instantiate(createObjects[0], this.transform.position,this.transform.rotation) as GameObject;
            myPrf.transform.parent = transform;
            myPrf.SetActive(true);
            LevelControl.isGameStart = 1 ;
            Invoke("BallControlStart",0.5f);
        }
    }


    private void BallControlStart(){
        Mouse.isBallControl = 1;
    }
}
