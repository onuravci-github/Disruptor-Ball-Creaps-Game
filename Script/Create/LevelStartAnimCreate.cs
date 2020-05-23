using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartAnimCreate : MonoBehaviour
{
   public GameObject createObjects;

    public void Creater(){
        GameObject myPrf = Instantiate(createObjects, createObjects.transform.position,this.transform.rotation) as GameObject;
        myPrf.transform.parent = transform;
        myPrf.SetActive(true);
    }
}
