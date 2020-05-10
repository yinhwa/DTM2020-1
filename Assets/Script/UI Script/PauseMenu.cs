using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string sceneName = "introCampus";

   [SerializeField]
    private GameObject PauseMenuPanel=null;

    [SerializeField]
    private SaveLoad theSaveLoad=null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager_Curator.isPause)
                CallPauseMenu();
            else
                ClosePauseMenu(); 
        }
        
    }

    private void CallPauseMenu()
    {
        GameManager_Curator.isPause = true;
        PauseMenuPanel.SetActive(true);
    
        Time.timeScale = 0f; //시간의 흐름 조정가능(timeScale), 0배속 처리
         
    }

    private void ClosePauseMenu()
    {
        GameManager_Curator.isPause = false;
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1f; //시간의 흐름 조정가능(timeScale), 정상속도 처리
    }

    public void ClickSHome()
    {
        Debug.Log("로딩");
        SceneManager.LoadScene(sceneName);
    }

    public void ClickSave()
    {
        Debug.Log("세이브");
        theSaveLoad.SaveData(); //세이브데이터 호출
        SceneManager.LoadScene("introCampus");
    }
    public void ClickLoad()
    {
        Debug.Log("로드");
        theSaveLoad.LoadData();
    }

    public void ClickExit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }
}
