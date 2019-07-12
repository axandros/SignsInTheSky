using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyDisplay : MonoBehaviour
{
    [SerializeField]
    Text tex = null;

    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        tex = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        string strToDis = "Player Not Found";
        if (player != null)
        {
            strToDis = "Selected: ";
            PlayerController pc = player.GetComponent<PlayerController>();
            NodeMapper nm = pc.SelectedNode;
            if (nm != null)
            {
                GameObject sn = nm.gameObject;
                if (sn != null)
                {
                    strToDis += sn.name;
                }
            }
        }
        
        UpdateText(strToDis);

    }

    public void UpdateText(string newText)
    {
        tex.text = newText;
    }
}
