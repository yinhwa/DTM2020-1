using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager_CuratorMode : MonoBehaviour

{
    public GameObject MuseumCataloguePanel;
    public GameObject LowerMenuPanel;
    public GameObject PauseMenuPanel;


    public void OpenMuseumCataloguePanel()
    {
        if (MuseumCataloguePanel != null)
        {
            bool isActive = MuseumCataloguePanel.activeSelf;
            MuseumCataloguePanel.SetActive(!isActive);
            LowerMenuPanel.SetActive(false);
            PauseMenuPanel.SetActive(false);

        }
    }

    public void OpenLowerMenuPanel()
    {
        if (LowerMenuPanel != null)
        {
            bool isActive = LowerMenuPanel.activeSelf;
            LowerMenuPanel.SetActive(!isActive);
            MuseumCataloguePanel.SetActive(false);
            PauseMenuPanel.SetActive(false);
 
        }
    }
    public void OpenPauseMenuPanel()
    {
        if (PauseMenuPanel != null)
        {
            bool isActive = PauseMenuPanel.activeSelf;
            PauseMenuPanel.SetActive(!isActive);
            LowerMenuPanel.SetActive(false);
       
        }
    }

}
