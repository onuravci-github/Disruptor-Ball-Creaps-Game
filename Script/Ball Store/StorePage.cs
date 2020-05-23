using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorePage : MonoBehaviour
{
    public static int pageNumber = 1;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        pageNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(text != null){
            text.text = pageNumber.ToString();
        }
    }


    public void NextPage(){
        
        if(pageNumber <= 6){
            pageNumber++;
        }
    }
    public void BeforePage(){
        if(pageNumber >= 2){
            pageNumber--;
        }
    }
}
