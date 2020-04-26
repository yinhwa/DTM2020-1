using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour

{
    public Item item; // 획득한 아이템
    public int itemCount; // 획득 아이템 갯수
    public Image itemImage; // using UnityEngine.UI; 상단에 추가 // 아이템 이미지


    //필요 컴포넌트

    [SerializeField]
    private Text text_Count;

    [SerializeField]
    private GameObject go_CountImage;

    private void SetColor(float _alpha) // float타입으로 알파값 넘어오게함 -> 즉, 이미지 투명도 조절
    {
        Color color = itemImage.color; //컬러 선언; 아이템 이미지 컬러
        color.a = _alpha; //.a는 해당 이미지 컬러의 알파값 의미
        itemImage.color = color; // 실제 아이템 이미지를 color로 넣어줌
    }


    public void AddItem(Item _item, int _count = 1) //아이템 획득
    {

        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        //장비아이템의 경우 하늘색 동그라미 필요X; 재료만 하늘색 원 갯수 구분 필요

        if(item.itemType != Item.ItemType.Equipment) //장비가 아닐 경우에만 아래의 과정 진행 
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();

        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);

        }


        SetColor(1);
    }


    public void SetSlotCount(int _Count) // 슬롯상 아이템 갯수 변경 함수
    {
        itemCount += _Count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
            ClearSlot(); // 아이템 갯수가 0과 같거나 적을 경우, 슬롯창 비우기

    }

    private void ClearSlot() // 슬롯창 비우기/초기화
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0); //하늘색 원 투명
        
        text_Count.text = "0";
        go_CountImage.SetActive(false);
        
    }
     

}