using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation : MonoBehaviour
{
    SpriteRenderer SR = null;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { StarReadout(); }
        /*    if (CheckForSuccess())
            {
                //SR.color = Color.white;
                Debug.Log("Win");
            }*/
    }

    public bool CheckForSuccess()
    {
        int count = 0;
        //foreach (Transform child in transform)
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            NodeMapper nm = child.GetComponent<NodeMapper>();
            if (nm != null)
            {
                if (nm.IsCorrectConnections()) { count++; }
            }
        }
        Debug.Log(count + " / " + transform.childCount);
        return (count==transform.childCount);
    }

    public void StarReadout()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            NodeMapper nm = child.GetComponent<NodeMapper>();
            if (nm != null)
            {
                string str = nm.name + ": " + (nm.IsCorrectConnections() ? "Correct" : "Incorrect");
                Debug.Log(str);
            }
        }
    }
}
