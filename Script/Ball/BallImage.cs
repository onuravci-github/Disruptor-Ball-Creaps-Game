using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallImage : MonoBehaviour
{
    public Sprite [] sprites;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = sprites[PlayerSettings.getActiveBall()];
    }

}
