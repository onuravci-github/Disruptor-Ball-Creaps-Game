using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCreater : MonoBehaviour
{
    public int Life;
    public int angularVelocity;
    public int createObjectNumb;
    
    public float objectScaleX;
    public float objectScaleY;

    public GameObject [] blockObjects;

    // Start is called before the first frame update
    void Start()
    {
        if(this.GetComponent<Animator>() != null)
        this.GetComponent<Animator>().enabled = false;
        Create();
    }

    private void Create(){
        GameObject myPrf = Instantiate(blockObjects[createObjectNumb], this.transform.position,this.transform.rotation) as GameObject;
        myPrf.transform.parent = transform;
        myPrf.transform.localScale = new Vector3(myPrf.transform.localScale.x*objectScaleX,myPrf.transform.localScale.y*objectScaleY,1f);
        myPrf.SetActive(true);
    }


    public void AnimatorDestroy(){
        Destroy(this.GetComponent<Animator>());
    }
}
