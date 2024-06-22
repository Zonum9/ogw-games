using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFriends : MonoBehaviour
{
    [SerializeField] GameObject friendPanel;

    void Start()
    {
            
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            friendPanel.SetActive(!friendPanel.activeSelf);
        }
    }
}
