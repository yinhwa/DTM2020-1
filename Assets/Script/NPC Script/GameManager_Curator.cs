using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager_Curator : MonoBehaviour
{

    public static bool canPlayerMove = true; //플레이어 움직임 제어; 시작부터 움직일 수 있어야하므로 true;
    public static bool isOpenMenu = false; //인벤토리 활성화 여부
    public static bool isOpenCraftManual = false; //건축 메뉴 활성화 여부 

    public static bool isPause = false; //메뉴 호출시 true됨

    //메뉴 UI 호출
    private bool isActivated = false; //닫힌 상태로 시작하므로 기본값은 false

    [SerializeField]
    private GameObject go_BaseUI=null; // 기본 베이스 ui


    // Start is called before the first frame update
    void Start()
    {
        //시작 화면
        //Cursor.lockState = CursorLockMode.Locked; //커서를 가운데에 고정시켜 잠그기
        //Cursor.visible = false; //커서 안보이게 만들기


    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            GameObject.Find("UserInfo").GetComponent<Text>().text = GameManager.Instance.user_name + " " + GameManager.Instance.user_org_pos + "님\n saved time: 0000.00.00 00:00";
        } catch
        {

        }
        try
        {
            GameObject.Find("UserInfo2").GetComponent<Text>().text = GameManager.Instance.user_name + " " + GameManager.Instance.user_org_pos + "'s collection";
        } catch
        {

        }


        if (Input.GetKeyDown(KeyCode.Tab)) // && !isPreviewActivated) //으로 처리하면 중복 생성 방지가능 
        {
            Window();

            /*if (isOpenInventory || isOpenCraftManual || isPause) //n개 중 하나 조건 충족시
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                canPlayerMove = false;
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                canPlayerMove = true;
            }
            */
        }
    }




    private void Window()
    {
        if (!isActivated)
            OpenWindow();
        else
            CloseWindow();

    }

    private void OpenWindow()
    {
        isActivated = true;
        go_BaseUI.SetActive(true);


    }
    private void CloseWindow()
    {
        isActivated = false;
        go_BaseUI.SetActive(false);
    }


}

