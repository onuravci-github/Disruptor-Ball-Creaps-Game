using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelMouse : MonoBehaviour
{
    public static int UpdatePosition;
    public static int UpdateCreate;


    private float downPositionX;
    private float updatePositionX;
    Camera maincamera;

    private int control ;

    public int updateLevel;
    public int count = 0;

    public GameObject Object;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        updateLevel = PlayerSettings.getActiveLevel();
        //Debug.Log("Slect Level Mouse update Level = "+ updateLevel);
        Invoke("camfind",0.3f);
    }
    void camfind(){
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0){
            //Debug.Log(PlayerSettings.getLevel());
            if(Input.GetKey(KeyCode.Mouse0)){    
                if (control == 1)
                {
                    NowMouseUpdate(); 
                }     
            }
        
            foreach (var item in this.GetComponentsInChildren<DestroySelect>())
            {
                count ++;
                if(item.transform.position.x <= 0.3f &&  item.transform.position.x > -0.3f){
                    updateLevel = item.level -1;
                }
            }
            
            PlayerSettings.setActivelevel(updateLevel); 
        
            if(count <5){
                foreach (var item in this.GetComponentsInChildren<DestroySelect>())
                {
                    Destroy(item.gameObject);
                }
                GameObject myPrf = Instantiate(Object, this.transform.position,this.transform.rotation) as GameObject;
                myPrf.transform.parent = transform;
            }
            count = 0;              

            
        }
        
        
        /*if(Time.timeScale == 0){
            transform.localScale = new Vector3(1f,1f,1f);
        }
        else
            transform.localScale = new Vector3(0f,0f,1f);*/
        //Debug.Log("000 ==="+(updatePositionX - downPositionX));
    }

    private void OnMouseDown() {
        UpdateCreate = 1;
        control = 1;
        UpdatePosition = 0;
        
        downPositionX = (Input.mousePosition.x - Screen.width/2)/(Screen.width/maincamera.orthographicSize)/100 ;
        //Debug.Log(downPositionX);
    }
    private void NowMouseUpdate() {
          
        //updatePositionX = (Input.mousePosition.x - Screen.width/2)/(Screen.width/maincamera.orthographicSize)/100 ;
        //Debug.Log("mmm"+updatePositionX);
        //if(updatePositionX - downPositionX >0){
        if(downPositionX >  0 && updateLevel < PlayerSettings.getLevel()){
            //Debug.Log(updateLevel);
            //Debug.Log(PlayerSettings.getLevel());
            foreach (var item in this.GetComponentsInChildren<DestroySelect>())
            {
                //item.transform.position = new Vector3(item.transform.position.x - (updatePositionX - downPositionX),item.transform.position.y,1f);
                item.transform.position = new Vector3(item.transform.position.x - 0.2f,item.transform.position.y,1f);
            }
        }
        //else if(updatePositionX - downPositionX < 0){
        if(downPositionX <0 && PlayerSettings.getActiveLevel() != 0 ){ 
            //Debug.Log(updateLevel);
            //Debug.Log(PlayerSettings.getLevel());
            foreach (var item in this.GetComponentsInChildren<DestroySelect>())
            {
               
                //item.transform.position = new Vector3(item.transform.position.x - (updatePositionX + downPositionX),item.transform.position.y,1f);
                item.transform.position = new Vector3(item.transform.position.x + 0.2f,item.transform.position.y,1f);
            }
        }

        
        
    }
    private void OnMouseUp() {
        //PlayerSettings.setlevel(PlayerSettings.getActiveLevel());
        UpdatePosition = 1;
        control = 0;
        downPositionX = 0f;
        updatePositionX = 0f;

        
    }
}
