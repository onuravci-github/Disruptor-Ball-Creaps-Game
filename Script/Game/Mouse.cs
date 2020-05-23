using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Mouse : MonoBehaviour
{
    private Camera maincamera;

    public float speed;
    private float speedX;
    private float speedY;
    
    private float downPositionX;
    private float downPositionY;

    private float nowPositionX;
    private float nowPositionY;

    public float angle;

    private int control;
    private float tempX;
    private float tempY;
    private float tempSqrt;

    public Rigidbody2D rigidBody;

    public GameObject ballRay;
    public GameObject downPositionObject;
    private GameObject downPositionobject;

    public static Vector2 SpeedBall = new Vector2(0f,0f);
    public static int updateSpeedBall;
    public static int isBallControl;
    public static int gameStart;

    public static int extraBallControl;

    public int firstShot;

    // Start is called before the first frame update
    void Start()
    {
        isBallControl = 0;
        gameStart = 0;
        firstShot = 0;
        extraBallControl = PlayerSettings.getExtraBallControl();
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rigidBody = this.GetComponent<Rigidbody2D>();
        downPositionobject = Instantiate(downPositionObject,this.transform.position,this.transform.rotation);
        downPositionobject.transform.localScale = new Vector3(0f,0f,1f);

    }

    // Update is called once per frame
    void Update()
    {

        if(isBallControl == 1 && Time.timeScale != 0 ){
            if(extraBallControl != 0 || firstShot == 0 ){
                if(Input.GetKey(KeyCode.Q)){
                    PlayerPrefs.DeleteAll();
                    PlayerSettings.setMainGold(50);
                }
                if(Input.GetKey(KeyCode.R)){
                    LevelControl.levelGold--;
                    SceneManager.LoadScene(1);
                }
                else if(Input.GetKey(KeyCode.Mouse0)){
                    if(control != 1){
                        NowMouseDown();
                        control = 1;
                    }
                    NowMouseUpdate();
                }
                else if(control == 1){
                    OnMouseUp();
                    control = 0;
                }
                else if(Input.anyKey ){
                    SceneManager.LoadScene(1);
                }
            }
            
            
            
        }
        if(updateSpeedBall == 0){
            SpeedBall = rigidBody.velocity;
        }

        if(Input.GetKey(KeyCode.N)){
                GameObject.FindObjectOfType<LevelControl>().Hile();
        }
        if(Input.GetKey(KeyCode.B)){
                GameObject.FindObjectOfType<LevelControl>().Hile2();
        }
        
    }

    void NowMouseDown()
    {
        
        downPositionX = (Input.mousePosition.x - Screen.width/2)/(Screen.width/maincamera.orthographicSize) ;
        downPositionY = (Input.mousePosition.y - Screen.height/2)/(Screen.width/maincamera.orthographicSize);

        downPositionobject.transform.position = new Vector3(downPositionX,downPositionY,1f);
        downPositionobject.transform.localScale = new Vector3(0.05f,0.05f,1f);

    }
//20524379888


    void OnMouseUp()
    {
        
	    gameStart = 1;
        ballRay.transform.localScale = new Vector3(0f,0f,1f);
        downPositionobject.transform.localScale = new Vector3(0f,0f,1f);
        BallAngle.text.fontSize = 1;

        if(tempSqrt >= 2){
            if(extraBallControl == 0){
                isBallControl = 0;
            }
            else{
                if(speed !=0){
                    extraBallControl--;
                    PlayerSettings.setExtraBallControl(PlayerSettings.getExtraBallControl()-1);
                }
                isBallControl = 1;
            }

            speed = 15;
            GameObject.FindObjectOfType<BallEffect>().InvokeRepeat();
            ExtraBallControl.startBallThisHide();
            
        }
        else if(tempSqrt >= 0.5f){
            if(extraBallControl == 0){
                isBallControl = 0;
            }
            else{
                if(speed !=0){
                    extraBallControl--;
                    PlayerSettings.setExtraBallControl(PlayerSettings.getExtraBallControl()-1);
                }
                isBallControl = 1;
            }
            speed = tempSqrt*7.5f ;
            GameObject.FindObjectOfType<BallEffect>().InvokeRepeat();
            ExtraBallControl.startBallThisHide();
        }
        else {
            if(speed == 0){
                speed = 0f;
            }
                
            GameObject.FindObjectOfType<BallEffect>().InvokeRepeatCancel();
        }
        rigidBody.velocity = new Vector2(-speed*Mathf.Cos(angle*Mathf.PI/180), -speed*Mathf.Sin(angle*Mathf.PI/180));
        rigidBody.angularVelocity = 90f;

        if(firstShot == 0 && speed !=0){
            firstShot = 1;

        }
    }

    void NowMouseUpdate(){

        nowPositionX = (Input.mousePosition.x - Screen.width/2)/(Screen.width/maincamera.orthographicSize);
        nowPositionY = (Input.mousePosition.y - Screen.height/2)/(Screen.width/maincamera.orthographicSize);

        tempX = (nowPositionX - downPositionX);
        tempY = (nowPositionY - downPositionY);

        angle = Mathf.Atan2(tempY,tempX)*180/Mathf.PI;

        //Debug.Log("Açı : " + (angle - 180));

        ballRay.transform.rotation = Quaternion.Euler(0f, 0f, 90f + angle);

        tempSqrt = Mathf.Sqrt((tempX*tempX + tempY*tempY));

        if(tempSqrt >= 2){
            ballRay.transform.localScale = new Vector3(1.25f,2.5f,1f);
            BallAngle.text.fontSize = 300;
        }
        else if(tempSqrt >= 1){
            ballRay.transform.localScale = new Vector3(0.5f + (tempSqrt-1)*0.75f, 1f + (tempSqrt-1)*1.5f,1f);
            BallAngle.text.fontSize = 300;
        }
        else {
            ballRay.transform.localScale = new Vector3(0f,0f,1f);
            BallAngle.text.fontSize = 1;
        }
    }



    public static void extraControl(){
        extraBallControl = PlayerSettings.getExtraBallControl();
    }
}
