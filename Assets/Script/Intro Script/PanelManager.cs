using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour

{
    public GameObject Panel1;
    public GameObject Panel3;


    public void OpenInfoPanel()
    {
        if (Panel1 != null)
        {
            bool isActive = Panel1.activeSelf;
            Panel1.SetActive(!isActive);


        }
    }

    public void OpenLogInPanel()
    {
        if(Panel3 != null)
        {
            bool isActive = Panel3.activeSelf;
            Panel3.SetActive(!isActive);


        }
    }
}
