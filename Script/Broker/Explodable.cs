using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[RequireComponent(typeof(Rigidbody2D))]
public class Explodable : MonoBehaviour
{
    public System.Action<List<GameObject>> OnFragmentsGenerated;

    public bool allowRuntimeFragmentation = false;
    public int extraPoints = 0;
    public int subshatterSteps = 0;

    public string fragmentLayer = "Default";
    public string sortingLayerName = "Default";
    public int orderInLayer = 0;

    public enum ShatterType
    {
        Triangle,
        Voronoi
    };
    public ShatterType shatterType;
    public List<GameObject> fragments = new List<GameObject>();
    private List<List<Vector2>> polygons = new List<List<Vector2>>();
   
    private float tempScaleX;
    private float tempScaleY;

    private void Awake() {
       
        extraPoints = extraPoints + PlayerSettings.getExtraFragmentaton()*12;
        
    }
    /// <summary>
    /// Creates fragments if necessary and destroys original gameobject
    /// </summary>
    public void explode()
    {
        //if fragments were not created before runtime then create them now
        if (fragments.Count == 0 && allowRuntimeFragmentation)
        {
            generateFragments();
        }
        //otherwise unparent and activate them
        else
        {
            var explodeObject = Instantiate(this.GetComponent<BlockLife>().emptyObject,this.transform.position,this.transform.rotation);
            
            
            //explodeObject.transform.localScale = this.GetComponentInParent<BlockCreater>().transform.localScale;
            //explodeObject.transform.localScale = new Vector3(this.transform.localScale.x*this.GetComponentInParent<BlockCreater>().gameObject.transform.localScale.x,this.transform.localScale.y*this.GetComponentInParent<BlockCreater>().gameObject.transform.localScale.y,1f);
            foreach (GameObject frag in fragments)
            {   
                frag.transform.parent = explodeObject.transform;
                
                //frag.transform.position = new Vector3(frag.transform.position.x/tempScaleX,frag.transform.position.y/tempScaleY,1f);
                //frag.transform.parent = explodeObject.transform;
                //frag.transform.localScale = new Vector3(this.transform.localScale.x/tempScaleX,this.transform.localScale.y/tempScaleY,1f);
                frag.SetActive(true);
                frag.GetComponent<Rigidbody2D>().gravityScale = 0f;
                
                frag.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(Mouse.SpeedBall.x + Mouse.SpeedBall.x*Mathf.Cos(60),Mouse.SpeedBall.x - Mouse.SpeedBall.x*Mathf.Cos(60))/4,Random.Range(Mouse.SpeedBall.y + Mouse.SpeedBall.y*Mathf.Cos(60),Mouse.SpeedBall.y - Mouse.SpeedBall.y*Mathf.Cos(60))/4,0f);
                frag.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(90,180);
            }
        }
        //if fragments exist destroy the original
        if (fragments.Count > 0)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// Creates fragments and then disables them
    /// </summary>
    public void fragmentInEditor()
    {
        if (fragments.Count > 0)
        {
            deleteFragments();
        }
        generateFragments();
        setPolygonsForDrawing();

        //int x = 0;
        foreach (GameObject frag in fragments)
        {
            frag.transform.parent = transform;
            frag.GetComponent<PolygonCollider2D>().isTrigger = true;

            //frag.transform.position = new Vector3(frag.transform.position.x + frag.transform.position.x*Mathf.Sin(this.GetComponentInParent<BlockCreater>().transform.rotation.z),frag.transform.position.y + frag.transform.position.x*Mathf.Sin(this.GetComponentInParent<BlockCreater>().transform.rotation.z),1f);
            //frag.transform.rotation = new Quaternion(0f,0f,0f,0f);
            /*if(x == 0 ){   
                tempScaleX = frag.transform.localScale.x;
                tempScaleY = frag.transform.localScale.y;
                Debug.Log("XXXX = " + tempScaleX);
                x = 1;
            }*/
            //frag.transform.position = new Vector3(frag.transform.position.x/tempScaleX,frag.transform.position.y/tempScaleY,1f);
            //frag.transform.position = new Vector3((frag.transform.position.x/tempScaleX) - this.GetComponentInParent<BlockCreater>().transform.position.x/this.GetComponentInParent<BlockCreater>().transform.localScale.x/this.GetComponentInParent<BlockLife>().transform.localScale.x,(frag.transform.position.y/tempScaleY) - this.GetComponentInParent<BlockCreater>().transform.position.y/this.GetComponentInParent<BlockCreater>().transform.localScale.y/this.GetComponentInParent<BlockLife>().transform.localScale.y,1f);
            //frag.transform.position = new Vector3(frag.transform.position.x*this.GetComponentInParent<BlockCreater>().transform.localScale.x,frag.transform.position.y*this.GetComponentInParent<BlockCreater>().transform.localScale.y,1f);
            frag.SetActive(false);
        }
    }
    public void deleteFragments()
    {
        foreach (GameObject frag in fragments)
        {
            if (Application.isEditor)
            {
                DestroyImmediate(frag);
            }
            else
            {
                Destroy(frag);
            }
        }
        fragments.Clear();
        polygons.Clear();
    }
    /// <summary>
    /// Turns Gameobject into multiple fragments
    /// </summary>
    private void generateFragments()
    {
        fragments = new List<GameObject>();
        switch (shatterType)
        {
            case ShatterType.Triangle:
                fragments = SpriteExploder.GenerateTriangularPieces(gameObject, extraPoints, subshatterSteps);
                break;
            case ShatterType.Voronoi:
                fragments = SpriteExploder.GenerateVoronoiPieces(gameObject, extraPoints, subshatterSteps);
                break;
            default:
                Debug.Log("invalid choice");
                break;
        }
        //sets additional aspects of the fragments
        foreach (GameObject p in fragments)
        {
            if (p != null)
            {
                p.layer = LayerMask.NameToLayer(fragmentLayer);
                p.GetComponent<Renderer>().sortingLayerName = sortingLayerName;
                p.GetComponent<Renderer>().sortingOrder = orderInLayer;
                
            }
        }

        foreach (ExplodableAddon addon in GetComponents<ExplodableAddon>())
        {
            if (addon.enabled)
            {
                addon.OnFragmentsGenerated(fragments);
            }
        }
    }
    private void setPolygonsForDrawing()
    {
        polygons.Clear();
        List<Vector2> polygon;

        foreach (GameObject frag in fragments)
        {
            polygon = new List<Vector2>();
            foreach (Vector2 point in frag.GetComponent<PolygonCollider2D>().points)
            {
                Vector2 offset = rotateAroundPivot((Vector2)frag.transform.position, (Vector2)transform.position, Quaternion.Inverse(transform.rotation)) - (Vector2)transform.position;
                offset.x /= transform.localScale.x;
                offset.y /= transform.localScale.y;
                polygon.Add(point + offset);
            }
            polygons.Add(polygon);
        }
    }
    private Vector2 rotateAroundPivot(Vector2 point, Vector2 pivot, Quaternion angle)
    {
        Vector2 dir = point - pivot;
        dir = angle * dir;
        point = dir + pivot;
        return point;
    }

    void OnDrawGizmos()
    {
        /*if (Application.isEditor)
        {
            if (polygons.Count == 0 && fragments.Count != 0)
            {
                setPolygonsForDrawing();
            }

            Gizmos.color = Color.blue;
            Gizmos.matrix = transform.localToWorldMatrix;
            Vector2 offset = (Vector2)transform.position * 0;
            foreach (List<Vector2> polygon in polygons)
            {
                for (int i = 0; i < polygon.Count; i++)
                {
                    if (i + 1 == polygon.Count)
                    {
                        Gizmos.DrawLine(polygon[i] + offset, polygon[0] + offset);
                    }
                    else
                    {
                        Gizmos.DrawLine(polygon[i] + offset, polygon[i + 1] + offset);
                    }
                }
            }
        }*/
    }
}