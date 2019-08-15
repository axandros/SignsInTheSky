using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    // The connections between nodes in the graph.

    // An edge should have...

    private LineRenderer LR = null;  // The visual component
    private BoxCollider2D BC = null;   // To pick up the destruction request.

    // Start is called before the first frame update
    void Start()
    {
        LR = GetComponent<LineRenderer>();
        BC = GetComponentInChildren<BoxCollider2D>();
        
        SetColliderInfo();
    }

    /*
    private void Update()
    {
        
    }

    */
   

    public void Remove()
    {
        Debug.Log("Remove Called");
        Destroy(this.transform.gameObject);
    }


    private void SetColliderInfo()
    {
        // Set Rotation
        float radians = Mathf.Atan2(LR.GetPosition(1).x, LR.GetPosition(1).y);
        float degrees = Mathf.Rad2Deg * radians;
        Debug.Log("Degrees: " + degrees);
        BC.transform.rotation = Quaternion.AngleAxis(degrees, new Vector3(0.0f, 0.0f, 1.0f));

        // Set Position - Halfway between start and end of the Line
        float X = LR.GetPosition(1).x / 2;
        float Y = LR.GetPosition(1).y / 2;

        BC.transform.localPosition = new Vector3(X, Y, 0.0f); //+ this.transform.localPosition;

        // Set Scale - Half of Distance
        float dist = 4.24264f;// Mathf.Sqrt((X*X)+(Y*Y));
        BC.transform.localScale = new Vector3(dist,1.0f,1.0f);
    }
}
