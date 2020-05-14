using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour

{
    public GameObject InfoPanel;
    public GameObject LogInPanel;
    public GameObject SignUpPanel; 
    public GameObject MyCurationPanel; 
    public GameObject SharedCurationPanel; 


    public void OpenInfoPanel()
    {
        if (InfoPanel != null)
        {
            bool isActive = InfoPanel.activeSelf;
            InfoPanel.SetActive(!isActive);
            LogInPanel.SetActive(false);
            SignUpPanel.SetActive(false);
            MyCurationPanel.SetActive(false);



        }
    }

    public void OpenLogInPanel()
    {
        if(LogInPanel != null)
        {
            bool isActive = LogInPanel.activeSelf;
            LogInPanel.SetActive(!isActive);
            InfoPanel.SetActive(false);
            SignUpPanel.SetActive(false);
            MyCurationPanel.SetActive(false);

        }
    }
    public void OpenSignUpPanel()
    {
        if(SignUpPanel != null)
        {
            bool isActive = SignUpPanel.activeSelf;
            SignUpPanel.SetActive(!isActive);
            InfoPanel.SetActive(false);
            LogInPanel.SetActive(false);
            MyCurationPanel.SetActive(false);

        }
    }

    public void OpenMyCurationPanel()
    {
        if (MyCurationPanel != null)
        {
            bool isActive = MyCurationPanel.activeSelf;
            MyCurationPanel.SetActive(!isActive);
            InfoPanel.SetActive(false);
            LogInPanel.SetActive(false);
            SignUpPanel.SetActive(false);

        }
    }

}
