using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ball"){
            LevelControl.GameOver = 1;
        }
        else if(other.tag == "Ball Effect"){
            Destroy(other.gameObject);
        }

    }
}
