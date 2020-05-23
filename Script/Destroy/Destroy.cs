using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void Destroyer(){
        Destroy(this.gameObject);
    }


    public void CreateStart(){
        GameObject.FindGameObjectWithTag("Block Create").GetComponent<Create>().Creater();
        GameObject.FindGameObjectWithTag("Ball Create").GetComponent<Create>().Creater();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != "Ball"){
            Destroy(this.gameObject);
        }
    }


    public void AudioSourcePlay(){
        this.GetComponent<AudioSource>().Play();
    }
}
