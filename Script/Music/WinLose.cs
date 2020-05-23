using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public AudioSource[] audios;
    public static AudioSource[] audior;
    // Start is called before the first frame update
    void Start()
    {
        audior = audios;
    }   

}
