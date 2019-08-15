using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererToPoint : MonoBehaviour
{
    LineRenderer lr = null;
    BoxCollider2D bc = null;

    [SerializeField]
    private Vector3 destination = Vector3.zero;

    //float time = 0.0f;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.useWorldSpace = true;
        lr.startWidth = Mathf.Max(transform.localScale.x / 5,0.2f);
        lr.endWidth = lr.startWidth * 0.7f;

        if (destination != Vector3.zero)
        {
            UpdateDestination(destination);
        }
        
    }

    private void Update()
    {
        /*
        time += Time.deltaTime;
        float rotationTime = 4.0f;
        float angle = (time / rotationTime) * 2*Mathf.PI;
        UpdateDestination(new Vector3(Mathf.Sin(time), Mathf.Cos(time),0));
        */
    }

    public void UpdateDestination(Vector3 destination)
    {
        this.destination = destination;
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, destination);
        lr.endWidth = lr.startWidth * 0.7f;
    }

    public void ClearLineRender()
    {
        //Debug.Log(transform.lo);
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.position);
    }
    
}
