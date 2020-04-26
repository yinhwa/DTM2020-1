using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName =  "New Item", menuName = "New Item/item")] //유니티상 우클릭하면 C# Script 생성 버튼 상위에 Item(ScriptableObject)가 등장하여 곧바로 해당 클래스가 생성됨
public class Item : ScriptableObject // MonoBehaviour (반드시 GameObject에 붙여야 효력) -> ScriptableObject(GameObject로 붙이지 않아도됨) 로 변경
{
    public string itemName; // 아이템의 이름 
    public ItemType itemType; // 아이템의 유형 (하단의 public enum ItemType 생성후 작성)
    public Sprite itemImage; //아이템의 이미지
    public GameObject itemPrefab; // 아이템의 프리팹

    public string weaponType; //"GUN", "PICKAXE" 등의 무기 유형
    public enum ItemType //아이템 열거, 유니티상 스크롤 목록으로 생성
    {
        Equipment,
        Used,
        Ingredient,
        ETC
    }



}
