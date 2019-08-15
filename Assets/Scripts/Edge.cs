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
    
    void Destroy()
    {
        Debug.Log(transform.parent);
    }


    private void SetColliderInfo()
    {
        float radians = Mathf.Atan2(LR.GetPosition(1).x, LR.GetPosition(1).y);
        float degrees = Mathf.Rad2Deg * radians;
        Debug.Log("Degrees: " + degrees);
        BC.transform.rotation = Quaternion.AngleAxis(degrees, new Vector3(0.0f, 0.0f, 1.0f));

        // TODO: Set Position - Halfway between start and end of the Line
        // TODO: Set Scale - Half of Distance
    }
}
