using UnityEngine;

public class Colors : MonoBehaviour
{
    public Color[] colors;

    public static Color[] colors1;
    public static Color[] colors2;


    void Awake()
    {   Gizmos.color = new Color(1f,1f,1f,0f);
        if(colors1 == null){
            colors1 = GameObject.FindGameObjectWithTag("Color 1").GetComponent<Colors>().colors;
            colors2 = GameObject.FindGameObjectWithTag("Color 2").GetComponent<Colors>().colors;
        }
    }
}
