using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NodeMapper : MonoBehaviour
{
    //Connection Variables
    //TODO: Consolidate Adjacent and Correct to pair/tuple.  Does this work in the editor?
    //[SerializeField]
    private List<GameObject> Adjacent = null;
    //[SerializeField]
    private List<bool> CorrectConnection = null;

    //[SerializeField]
    //private List<NodePair> AdjacencyList = null;

    private List<NodeMapper> neighbors = null;

    [SerializeField]
    private List<NodeMapper> CorrectConnect = null;

    private int correctCount = 0;
    private bool IsLeaf
    {
        get { return (correctCount == 1); }
    }
    // If IsEmpty, then there are no valid connections.
    private bool IsEmpty
    {
        get { return (correctCount == 0); }
    }
    private int connection = -1;

    // Line Renderer(s)

    private LineRendererToPoint lr = null;
    [SerializeField]
    private LineRenderer baseLR = null;
    private List<LineRenderer> Lines = null;

    // Animation/Art
    [SerializeField]
    private SpriteRenderer SelectSprite = null;
    [SerializeField]
    private Color selectColor = new Color(1-255/255,1-243/255,1-143/255, 1.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        // Fill in needed components
        lr = GetComponent<LineRendererToPoint>();
        neighbors = new List<NodeMapper>();

        if (Adjacent != null)
        {
            for (int i = 0; i <= Adjacent.Count; i++)
            {
                NodeMapper nm = Adjacent[i].GetComponent<NodeMapper>();
                if (nm != null)
                {
                    neighbors.Add(nm);
                }
                if (CorrectConnection[i])
                {
                    correctCount++;
                }
            }
        }
        if(SelectSprite != null)
        {
            SelectSprite.enabled = true;
            //selectColor = SelectSprite.material.color;
            DeSelect();
        }
    }

    public void ConnectTo(NodeMapper nm)
    {
        /*
        int index = neighbors.IndexOf(nm);
        if (index > -1)
        {
            connection = index;
            //Debug.Log(nm.transform.position);
            lr.UpdateDestination(nm.transform.position);
        }
        */


        if (nm != null)
        {
            // Create New Line Renderer
            LineRenderer newLR = CreateLineRenderer();
            // Give LR Reference to connecting node
            nm.AcceptConnection(nm,newLR);
        }
    }

    public void ClearLine()
    {
        connection = -1;
        lr.ClearLineRender();
    }

    /*
     * Getters / Queries
     */
    // IsConnectedTo - Is there an active connection between this node and another given node.
    // Optional out parameter will say if a connection is possible.
    public bool IsConnectedTo(NodeMapper nm)
    {
        bool opt = false;
        return IsConnectedTo(nm, out opt);
    }
    public bool IsConnectedTo(NodeMapper nm, out bool adjacent)
    {
        adjacent = false;
        bool ret = false;
        int index = neighbors.IndexOf(nm);
        if (index > -1)
        {
            adjacent = true;
            ret = (index == connection);
        }
        return ret;
    }

    public bool IsAdjacentButNotConnecting(NodeMapper nm)
    {
        bool ret = false;
        int index = neighbors.IndexOf(nm);
        if (index > -1)
        {
            ret = !(connection == index);
        }
        return ret;
    }
    public bool IsAdjacent(NodeMapper nm)
    { return neighbors.Contains(nm); }
    
    public bool IsCorrectConnections()
    {
        //TODO: Change to new System
        //Readout();
        bool ret = false;
        if(connection == -1)
        {
            if (IsEmpty)
            {
                ret = true;
            }
            if (IsLeaf)
            {
                //Is a correct connection pointing at us?
                for(int i = 0; i < CorrectConnection.Count && ret!=true; i++)
                {
                    if (CorrectConnection[i] && neighbors[i].IsConnectedTo(this))
                    {
                        ret = true;
                    }
                }
            }
        }
        else if(CorrectConnection[connection] && !neighbors[connection].IsConnectedTo(this))
        {
            ret = true;
        }
        return ret;
    }

    public void Readout()
    {
        Debug.Log(transform.name + ": " + IsEmpty + " " + connection + " " + (connection!=-1?(CorrectConnection[connection]?"true":"false"):"null"));
    }

    /*
     * 'Setters'
     * */
    public void Select()
    {
        if (SelectSprite != null)
        {
            SelectSprite.color = selectColor;
        }
    }

    public void DeSelect()
    {
        if(SelectSprite != null)
        {
            SelectSprite.color = new Color(1, 1, 1, 0);
        }
    }


    public LineRenderer CreateLineRenderer()
    {
        LineRenderer newLR = Instantiate<LineRenderer>(baseLR, this.transform);
        Lines.Add(newLR);
        return newLR;
    }

    public void AcceptConnection(NodeMapper nm, LineRenderer newLR)
    {
    }
}
