using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollControl : MonoBehaviour
{
    public GameObject gmobject;
    public int function;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(function == 0){
            if(Time.timeScale == 0) {
                gmobject.SetActive(true);
            }
            if(Time.timeScale == 1) {
                gmobject.SetActive(false);
            }
        }
        if(function == 1){
            if(Time.timeScale == 1) {
                gmobject.SetActive(true);
            }
            if(Time.timeScale == 0) {
                gmobject.SetActive(false);
            }
        }
        

    }
}
