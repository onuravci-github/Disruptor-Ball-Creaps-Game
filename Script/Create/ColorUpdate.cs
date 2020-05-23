using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUpdate : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    BlockLife blockLife;

    private int life;
    public int function;
    // Start is called before the first frame update
    void Start()
    {


	if(PlayerSettings.getActiveLevel() < 2) {
		Invoke("Starter",0.1f);
	}
	else {
		spriteRenderer = this.GetComponent<SpriteRenderer>();
        	blockLife = this.GetComponentInParent<BlockLife>();

        	life = blockLife.life;
	}
        
    }
    void Starter(){
	spriteRenderer = this.GetComponent<SpriteRenderer>();
        blockLife = this.GetComponentInParent<BlockLife>();

        life = blockLife.life;

    }

    // Update is called once per frame
    void Update()
    {

	if(spriteRenderer == null){
		spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	if(blockLife == null){
		blockLife = this.GetComponentInParent<BlockLife>();

	}
	
        life = blockLife.life;
        
        if(function == 0){
            if (life != 0) {
                spriteRenderer.color = Colors.colors1[life];
            }
            else
                spriteRenderer.color = Colors.colors1[1];
        }
        else if(function == 1){
            if (life != 0) {
                spriteRenderer.color = Colors.colors2[life];
            }
            else
                spriteRenderer.color = Colors.colors2[1];
        }
        
    }
}
