using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSprite : MonoBehaviour
{
    public Sprite [] sprites;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = sprites[StorePage.pageNumber-1];
    }
}
