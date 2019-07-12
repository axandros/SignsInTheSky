using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private NodeMapper selectedNode = null;
    private int sensitivity = 50;

    [SerializeField]
    private GameObject _Constelation = null;

    [SerializeField]
    private MainMenu _Menu = null;

    private Constellation _constellation = null;

    public NodeMapper SelectedNode
    {
        get {return selectedNode; }
    }

    private Vector3 mousePosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        if(_Constelation != null)
        {
            _constellation = _Constelation.GetComponent<Constellation>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // On user click
        if (Input.GetMouseButtonDown(0))
        {
            SelectUnderCursor();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ClearUnderCursor();
        }

        // Camera Controls
      /*  Vector3 mouseDelta = mousePosition - Input.mousePosition;
        mousePosition = Input.mousePosition;
        if (Input.GetMouseButton(2))
        {
            Camera.main.transform.Translate(mouseDelta/sensitivity);
        }*/
    }

    void SelectUnderCursor()
    {
        NodeMapper node = FindNodeMapperUnderCursor();
        if (node != null)
        {
            if (selectedNode != null)
            {
                if (selectedNode.IsAdjacent(node))
                {
                    selectedNode.ConnectTo(node);
                    DeSelectNode();
                    if(_constellation != null && _constellation.CheckForSuccess())
                    {
                        Debug.Log("Win?");
                        Win();
                    }
                }
                else { DeSelectNode(); }
            }
            else if (selectedNode == null)
            {
                SelectNode(node);
            }
        }
        else { DeSelectNode(); }
    }

    void ClearUnderCursor()
    {
        NodeMapper node = FindNodeMapperUnderCursor();
        if (node != null)
        {
            node.ClearLine();
        }
    }

    private NodeMapper FindNodeMapperUnderCursor()
    {
        NodeMapper ret = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.transform != null)
        {
            GameObject obj = hit.collider.gameObject;
            ret = obj.GetComponent<NodeMapper>();
        }
        return ret;
    }

    private void Win()
    {
        if(_Menu != null && _Constelation != null)
        {
            //Debug.Log("Win conditionSuccess");
            _Menu.Win(_Constelation.name);
        }
        else
        {
            //Debug.Log("Win condition fail");
        }
    }

    private void SelectNode(NodeMapper node)
    {
        selectedNode = node;
        node.Select();
    }

    private void DeSelectNode()
    {
        if(selectedNode != null)
        {
            selectedNode.DeSelect();
            selectedNode = null;
        }
    }
}
