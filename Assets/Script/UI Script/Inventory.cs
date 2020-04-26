using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool inventoryActivated = false; // Inventory가 활성화true가 되었을 때 1) 카메라 움직임, 손 움직임 등 방지, 2) Tab 버튼으로 인벤토리 창 켜기/꺼기

    //필요 컴포넌트
    [SerializeField]
    private GameObject go_InventoryBase; //키 눌렀을 때 활성화 

    [SerializeField]
    private GameObject go_SlotsParent; //H창상 부모 객체인 Grid Setting 프리팹

    private Slot[] slots; //H창상 자식 객체인 Slot(0~19)들

    // Start is called before the first frame update
    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>(); //위의 private Slot[] slots; 배열 안에 자식 객체 정보가 입력됨 
    }

    // Update is called once per frame
    void Update()
    {
        TryOpenInventory(); //I버튼 누를때마다 인벤토리 활성화
    }

    private void TryOpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            inventoryActivated = !inventoryActivated;

            if (inventoryActivated)
                OpenInventory(); //InventoryActivated 가 true일 경우, 인벤토리창 오픈
            else
                CloseInventory();
        }
    }

    private void OpenInventory(){
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }

    public void AcquireItem(Item _item, int _count) //아이템 갯수 늘리기; 빈 슬롯에 아이템 채우기
    {
        //장비템인지 아닌지 조건 확인; 장비템의 경우 아이템 갯수 증가 필요 X므로
        if(Item.ItemType.Equipment != _item.itemType)
        {

            for (int i = 0; i < slots.Length; i++) //슬롯의 길이(갯수)만큼 추가
            {
                if (slots[i].item != null) //item slot창이 null이 아닐 경우(즉, 인벤상에 아이템이 있을 경우)에만 적용 
                {
                    if (slots[i].item.itemName == _item.itemName) //item 변수 하의 itemName 변수와 파라미터상의 _item.itenName이 일치할 경우에, 즉 이미 해당 아이템이 존재하는 경우 
                    {
                        slots[i].SetSlotCount(_count); // 해당 아이템의 갯수만 추가
                        return;

                    }

                }
            }

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == null) // 인벤 상에 해당 아이템이 없을 경우, 즉 item이 null일 경우 빈슬롯 찾아서 아이템 생성
                {
                    slots[i].AddItem(_item, _count);
                    return;

                }
            }
        }
    }
}
