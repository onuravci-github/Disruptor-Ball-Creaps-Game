using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffect : MonoBehaviour
{
    public GameObject [] createObjects;
    public float repeating;
    
    public void Creater(){
        GameObject myPrf = Instantiate(createObjects[PlayerSettings.getActiveEffect()], this.transform.position,this.transform.rotation) as GameObject;
        myPrf.SetActive(true);
        myPrf.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(Mouse.SpeedBall.x + Mouse.SpeedBall.x*Mathf.Cos(60),Mouse.SpeedBall.x - Mouse.SpeedBall.x*Mathf.Cos(60))/4,Random.Range(Mouse.SpeedBall.y + Mouse.SpeedBall.y*Mathf.Cos(60),Mouse.SpeedBall.y - Mouse.SpeedBall.y*Mathf.Cos(60))/4,0f);
        //myPrf.GetComponent<Rigidbody2D>().velocity = new Vector3(5f,5f,1f);
        myPrf.GetComponent<Rigidbody2D>().angularVelocity = 45; 
    }

    public void InvokeRepeat(){
        InvokeRepeating("Creater",0.1f,repeating);
    }

    public void InvokeRepeatCancel(){
        CancelInvoke("Creater");
    }
}
