using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLife : MonoBehaviour
{
    public int life;
    private float angularVelocity;

    private Explodable explodable;

    public GameObject emptyObject;

    public GameObject[] audios;

    // Start is called before the first frame update
    void Start()
    {
        life = this.GetComponentInParent<BlockCreater>().Life;   
        angularVelocity = this.GetComponentInParent<BlockCreater>().angularVelocity ;
        explodable = GetComponent<Explodable>();
        this.GetComponent<Rigidbody2D>().angularVelocity = angularVelocity;

        Quaternion tempRotation = this.GetComponentInParent<BlockCreater>().transform.rotation;
        //Debug.Log(tempRotation);

        this.GetComponentInParent<BlockCreater>().transform.rotation = new Quaternion(0f,0f,0f,0f);
        explodable.fragmentInEditor();
        this.GetComponentInParent<BlockCreater>().transform.rotation = tempRotation;
        this.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0f);
        if(this.GetComponentInParent<Animator>() != null)
        this.GetComponentInParent<Animator>().enabled = true;

    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(life > 1){ 
            life = life - 1;
            var a = Instantiate(audios[Random.Range(0,4)],this.transform.position,this.transform.rotation);
            a.GetComponent<AudioSource>().Play();
        }
        else if(life == 1){
            Mouse.updateSpeedBall = 1;
            Invoke("Explode",0.05f);
        }
    }
    
    public void Destroy(){
        Destroy(this.gameObject);
    }

    void Explode(){
        this.GetComponent<SpriteRenderer>().color = Colors.colors1[1];
        //explodable.fragmentInEditor();
        explodable.explode();
        var a = Instantiate(audios[Random.Range(0,4)],this.transform.position,this.transform.rotation);
        a.GetComponent<AudioSource>().Play();
        
        Mouse.updateSpeedBall = 0;
    }
}

