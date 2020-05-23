using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroySelect : MonoBehaviour
{
    private Transform rect;
    private float size;

    public int level;
    public Text text;
    public GameObject[] Object ;
    public int position;
    private int control;

    public static float[] positions = {0f,0f,0f,0f,0f};
    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<Transform>();
        if(position != 0){
            positions[position - 1 ] = rect.position.x;
            level = position + this.GetComponentInParent<SelectLevelMouse>().updateLevel + 1 -3 ;
            //Debug.Log("Destroy Select Level = " + level);
        }
        text.text = level.ToString();
        control = 0;
        if(level <= 0 || level > 61 ){
            this.transform.localScale = new Vector3(0f,0f,0f);
        }
        if(transform.position.x > 3.5f || transform.position.x < -3.5f){
            control = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {  
        
        //Debug.Log("Position = " + rect.position.x);
        
        if(position == 0){text.text = level.ToString();}

        if(rect.position.x > 0) { size = 0.4f - (rect.position.x)/3.5f/10;}
        else if(rect.position.x < 0 ){size = 0.4f + (rect.position.x)/3.5f/10;}
        else { size = 0.4f;}
        

        if(!(transform.position.x > 3.5f || transform.position.x < -3.5f)){
            control = 0;
        }

        if(rect.position.x < -5.25f){
            Destroy(this.gameObject);
        }
        if(rect.position.x > +5.25f){
            Destroy(this.gameObject);
        }

        if(control == 0 ){
            if(rect.position.x < -3.5f){
                control = 1;
                GameObject myPrf = Instantiate(Object[1], new Vector3(5.25f + (3.5f+this.transform.position.x),3.5f,1f),this.transform.rotation) as GameObject;
                myPrf.transform.parent = transform.parent;
                myPrf.GetComponent<DestroySelect>().level = this.level + 5 ;
                // + da yaratman gerek yarattığım buradakinin levelinin + 5 ine eşit
            }
            if(rect.position.x > 3.5f){
                control = 1;
                GameObject myPrf = Instantiate(Object[0], new Vector3(-5.25f - (3.5f-this.transform.position.x),3.5f,1f),this.transform.rotation) as GameObject;
                myPrf.transform.parent = transform.parent;
                myPrf.GetComponent<DestroySelect>().level = this.level - 5 ;
                // - de yaratman gerek yarattığım buradakinin levelinin - 5 ine eşit
            }
        }

        if(SelectLevelMouse.UpdatePosition == 1){
            
            if(rect.position.x < -4.375f ){
                Destroy(this.gameObject);
            }
            else if(rect.position.x < -2.625f ){
                rect.position = new Vector3(-3.5f,3.5f,1f);
            }
            else if(rect.position.x < -0.875f  ){
                rect.position = new Vector3(-1.75f,3.5f,1f);
            }
            else if(rect.position.x < 0.875f){
                rect.position = new Vector3(0,3.5f,1f);
            }
            else if(rect.position.x < 2.625f){
                rect.position = new Vector3(1.75f,3.5f,1f);
            }
            else if(rect.position.x < 4.375f){
                rect.position = new Vector3(3.5f,3.5f,1f);
            }
            else if(rect.position.x < 5.25f ){
                Destroy(this.gameObject);
            }
            else if(rect.position.x <6.125f ){
                Destroy(this.gameObject);
            }
            
        }

        if(level <= 0 || level > 61 ){
            this.transform.localScale = new Vector3(0f,0f,0f);
        }
        else
            rect.localScale = new Vector3(size,size,1f);
    }
}
