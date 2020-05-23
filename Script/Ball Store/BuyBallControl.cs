using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBallControl : MonoBehaviour
{
    private int up;
    private int[] control = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};

    public GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        up = (StorePage.pageNumber-1)*9;

        for (int i = 0; i < 9; i++)
        {
            control[i] = up + i;
        }
        
        for (int i = 0; i < 9; i++)
        {
            if(PlayerSettings.getBalls(control[i]) != 0) {
                gameObjects[i].SetActive(false);
            }
            else {
                gameObjects[i].SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        up = (StorePage.pageNumber-1)*9;

        for (int i = 0; i < 9; i++)
        {
            control[i] = up + i;
        }
        
        for (int i = 0; i < 9; i++)
        {
            if(PlayerSettings.getBalls(control[i]) != 0) {
                gameObjects[i].SetActive(false);
            }
            else {
                gameObjects[i].SetActive(true);
            }
        }
    }

    
}
