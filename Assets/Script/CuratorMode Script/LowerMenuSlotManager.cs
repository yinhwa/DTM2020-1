using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable] //직렬화
public class Craft
{
    public string craftName; // 이름
    public Sprite craftImage; //이미지
    public string craftDes; //설명
    public GameObject go_Prefab; // 실제 설치될 프리팹
    public GameObject go_PreviewPrefab; // 미리보기 프리팹


}

public class LowerMenuSlotManager : MonoBehaviour
{
    //상태변수
    private bool isActivated = false; //닫힌 상태로 시작하므로 기본값은 false
    private bool isPreviewActivated = false;

    [SerializeField]
    private GameObject go_PanelUI; // 기본 베이스 UI




    [SerializeField]
    private Craft[] architecture_button;
    [SerializeField]
    private Craft[] landscape_button;
    [SerializeField]
    private Craft[] interaction_button;


    private GameObject go_Preview; // 미리보기 프리팹을 담을 변수
    public GameObject go_Prefab; // 미리보기 프리팹 변수 선언


    //public craft[] getcrafts() { return architecture_craft; } //세이브 로딩을 위한 정보

    //public void LoadToCraftManual(go_Prefab.transform.position, ); 

    [SerializeField]
    private Transform tf_Player;//플레이어 위치 정보 받아오기

    //Raycast 필요변수 선언
    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;


    //건축 시스템 UI 탭 및 페이지 필요변수 선언
    private int tabNumber = 0; //모닥불탭 건축탭 구분
    private int page = 1;
    private int selectedSlotNumber;
    private Craft[] craft_SelectedTab;


    //필요한 UI Slot 요소
    [SerializeField]
    private GameObject[] go_Slots;
    [SerializeField]
    private Image[] image_slot;
    [SerializeField]
    private Text[] text_slotName;
    //    [SerializeField]
    //    private Text[] text_slotDes;


    public void Start()
    {
        //        architectureButton = GetComponent<Button>();
        //   Button architectureButton = GameObject.Find("버튼이름").getComponent<Button>();

        tabNumber = 0;
        page = 1;
        TabSlotSetting(architecture_button); //기본화면 artwork화면으로
    }

    public void TabSetting(int _tabNumber)
    {
        tabNumber = _tabNumber;
        page = 1; //다른 페이지 넘어갔다가 해당 버튼으로 돌아왔을 때 페이지 초기화

        switch (tabNumber)
        {
            case 0:

                TabSlotSetting(architecture_button);
                break; //아트워크 세팅

            case 1:
                TabSlotSetting(landscape_button);

                break; //Landscape Setting
            case 2:
                TabSlotSetting(interaction_button);

                break; //Magic Setting


        }
    }

    public void RightPageSetting()
    {

        if (page == 1) //< (craft_SelectedTab.Length / go_Slots.Length) + 1) //최대페이지
            page++;
        else
            page = 1;
        Debug.Log(page);
        TabSlotSetting(craft_SelectedTab);


    }

    public void LeftPageSetting()
    {
        if (page != 1)
            page--;
        else
            page = (craft_SelectedTab.Length / go_Slots.Length) + 1;

        Debug.Log(page);
        TabSlotSetting(craft_SelectedTab);



    }

    private void ClearSlot()
    {
        for (int i = 0; i < go_Slots.Length; i++)
        {
            image_slot[i].sprite = null;
            text_slotName[i].text = "";
            //            text_slotDes[i].text = "";
            go_Slots[i].SetActive(false);

        }
    }

    private void TabSlotSetting(Craft[] _craft_tab)
    {

        ClearSlot();
        craft_SelectedTab = _craft_tab;
        int numSlotinPage = 7;
        if (craft_SelectedTab.Length <= numSlotinPage)
        {
            page = 1;
        }
        int numSlotinCurrentPage = 7;
        Debug.Log("wtf" + craft_SelectedTab.Length / ((page) * numSlotinPage));
        if (craft_SelectedTab.Length / ((page) * numSlotinPage) >= 1)
        {
            //case when more than one page is needed
            numSlotinCurrentPage = 7;
        }
        else
        {
            //case when less than numSlotinPage is needed
            numSlotinCurrentPage = craft_SelectedTab.Length - ((page - 1) * numSlotinPage);
        }
        int remainSlot = craft_SelectedTab.Length;
        int numPage = (int)(craft_SelectedTab.Length / numSlotinPage) + 1;
        Debug.Log("go slot?" + craft_SelectedTab.Length);
        for (int j = 0; j < craft_SelectedTab.Length; j++)
        {
            Debug.Log("curr page " + page + "slots " + numSlotinCurrentPage + "j" + j);

            go_Slots[j].SetActive(true);

            image_slot[j].sprite = craft_SelectedTab[j + (page - 1) * numSlotinPage].craftImage;
            text_slotName[j].text = craft_SelectedTab[j + (page - 1) * numSlotinPage].craftName;
            if (j == numSlotinCurrentPage - 1)
            {
                break;
            }


        }
    }




    public void SlotClick(int _slotNumber) //매개변수인 slotNumber로 어떤 slot이 클릭되는지 확인, 매개변수는 슬롯창마다 매겨진 숫자
    {
        selectedSlotNumber = _slotNumber + (page - 1) * go_Slots.Length;

        go_Preview = Instantiate(craft_SelectedTab[selectedSlotNumber].go_PreviewPrefab, tf_Player.position + tf_Player.forward, Quaternion.identity); //craft_fire 탭에 있는 슬롯 넘버 배열을 생성, 시선에 따라 prefab도 플레이어의 위치에 따라 플레이어의 시야 앞에서 움직임, 회전값(Quaternion)은 identity에 따라 적용
        go_Prefab = craft_SelectedTab[selectedSlotNumber].go_Prefab;

        isPreviewActivated = true;
        go_PanelUI.SetActive(true); //미리보기가 등장하는 동안 슬롯창 끄기

        //isPreviewActivated = true;
    }



    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Tab)) // && !isPreviewActivated) //으로 처리하면 중복 생성 방지가능 
        //{
        //    Window();

        //}


        if (isPreviewActivated) // isPreview활성화되면 PreviewPositionUpdate
            PreviewPositionUpdate();

        if (Input.GetButtonDown("Fire1") && isPreviewActivated)
            Build();

        if (Input.GetKeyDown(KeyCode.F2))

            Cancel(); //프리뷰 보는 중에 Escape 누르면 프리뷰 취소






    }

    private void Build()
    {
        if (isPreviewActivated && go_Preview.GetComponent<PreviewObject>().IsBuildable()) //PreviewObject.cs에 작성한 내용을 go_Privew에 담아 isBuildable의 true값 여부 확인
        {
            Instantiate(go_Prefab, go_Preview.transform.position, go_Preview.transform.rotation);//Raycast를 쏴서 맞춘 위치, 회전값은 quaternion.identity
            //hitInfo.point -> go_Preview.transform.position
            //Quaternion.identity 지우고, Q,E로 회전된 값(rotation) 입력
            Destroy(go_Preview); //프리뷰프리팹 삭제

            isActivated = true; //*20.03.01 true로 수정
            isPreviewActivated = false;
            go_Preview = null;
            go_Prefab = null;
        }
    }

    private void PreviewPositionUpdate()
    {
        if (Physics.Raycast(tf_Player.position, tf_Player.forward, out hitInfo, range, layerMask)) //플레이어의 위치, 전방에쏜 레이저광선, 광선에 대한 정보를 hitInfo에 저장, 사정거리만큼 레이저 쏨, 레이어마스크에 걸리는게 있으면 부딪히게 만듦 
        {

            if (hitInfo.transform != null) //hitInfo.transform이 null이 아니면, hitInfo.point에 레이저를 쏴서 맞은 곳의 실제좌표 Venctor3를 반환; Preview의 포지션을 _location으로 반환
            {

                //Debug.Log("Hit info?" + hitInfo.);
                Vector3 _location = hitInfo.point;

                //Debug.Log("Raycast pos"+ _location);


                if (Input.GetKeyDown(KeyCode.Alpha1))
                    go_Preview.transform.Rotate(0, -15f, 0f); //-15도로 회전
                if (Input.GetKeyDown(KeyCode.Alpha2))
                    go_Preview.transform.Rotate(0, +15f, 0f); //+15도로 회전
                if (Input.GetKeyDown(KeyCode.Alpha3))
                    go_Preview.transform.Rotate(-15f, 0f, 0f); //-15도로 회전
                if (Input.GetKeyDown(KeyCode.Alpha4))
                    go_Preview.transform.Rotate(+15f, 0f, 0f); //+15도로 회전


                _location.Set(Mathf.Round(_location.x / 0.1f) * 0.1f, Mathf.Round(_location.y / 0.1f) * 0.1f, Mathf.Round(_location.z)); //Mathf.Round()정수형에 가깝게 반올림/내림 처리
                                                                                                                                         //y값의 경우 0.1단위로 이동됨

                go_Preview.transform.position = _location; //Raycast의 위치에 설치되도록 설정




            }

        }
    }


    private void Cancel()
    {
        if (isPreviewActivated)
            Destroy(go_Preview); //프리뷰가 있을 경우에만 파괴

        isActivated = false;
        isPreviewActivated = false;
        go_Preview = null;
        //go_PanelUI.SetActive(false); //상태 초기화
    }

    //private void Window()
    //{
    //    if (!isActivated)
    //        OpenWindow();
    //    else
    //        CloseWindow();

    //}

    //private void OpenWindow()
    //{
    //        isActivated = true;
    //        go_PanelUI.SetActive(true);


    //}
    //private void CloseWindow()
    //{
    //    isActivated = false;
    //    go_PanelUI.SetActive(false);
    //}
}
