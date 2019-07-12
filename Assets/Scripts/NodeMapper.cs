using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMapper : MonoBehaviour
{
    //Connection Variables
    //TODO: Consolidate Adjacent and Correct to pair/tuple.  Does this work in the editor?
    [SerializeField]
    private List<GameObject> Adjacent = null;
    [SerializeField]
    private List<bool> CorrectConnection = null;

    private List<NodeMapper> neighbors = null;

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
        lr = GetComponent<LineRendererToPoint>();
        neighbors = new List<NodeMapper>();
        
        for(int i = 0; i < Adjacent.Count; i++)
        {
            NodeMapper nm = Adjacent[i].GetComponent<NodeMapper>();
            if (nm != null) {
                neighbors.Add(nm);
            }
            if (CorrectConnection[i])
            {
                correctCount++;
            }
        }
        if(SelectSprite != null)
        {
            SelectSprite.enabled = true;
            //selectColor = SelectSprite.material.color;
            DeSelect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectTo(NodeMapper nm)
    {
        int index = neighbors.IndexOf(nm);
        if (index > -1)
        {
            connection = index;
            //Debug.Log(nm.transform.position);
            lr.UpdateDestination(nm.transform.position);
        }
    }

    public void ClearLine()
    {
        connection = -1;
        lr.ClearLineRender();
    }

    // Getters

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


    public void CreateLineRenderer()
    {
        LineRenderer newLR = Instantiate<LineRenderer>(baseLR, this.transform);
        Lines.Add(newLR);
    }

    //public AcceptConnection(NodeMapper nm){}
}
