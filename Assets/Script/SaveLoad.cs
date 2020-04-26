using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//input output data출력



//정보 직렬화
[System.Serializable]
public class SavaData
{
    public Vector3 playerPos;
    public Vector3 playerRot; //플레이어 뷰잉 각도 저장
    public Vector3 gameObjectPos; 
    public Vector3 gameObjectRot; 



}


public class SaveLoad : MonoBehaviour
{

    private SavaData saveData = new SavaData();

//    private string SAVE_DATA_DIRECTORY;
//    private string SAVE_FILENAME = "/SaveFile.txt/";

    //private PlayerController thePlayer;
    //private CraftManual theGameObject;


    // Start is called before the first frame update
    void Start()
    {
//        SAVE_DATA_DIRECTORY = Application.dataPath + "/Saves/"; //게임 프로젝트가 담겨있는 폴더, 즉 Asset 폴더 + Save폴더 디렉토리 생성하여 여기에 저장
        if (!Directory.Exists(Application.dataPath + "/Saves/"))
            //using System.IO; 입력후 디렉토리 생성; 해당 디렉토리가 있는지 여부 확인
            Directory.CreateDirectory(Application.dataPath + "/Saves/"); //디렉토리가 없을 경우 자동으로 /Saves/에 생성
        Debug.Log("SaveLoad_Start");
    }



    public void SaveData()
    {
        Debug.Log("SaveLoad_SaveData");
        //thePlayer = FindObjectOfType<PlayerController>(); //플레이어 위치 발견
        //saveData.playerPos = thePlayer.transform.position;
        //saveData.playerRot = thePlayer.transform.eulerAngles; // rotation의 Vector3 값을 호출하는것이므로 eulerAngles

        //theGameObject = FindObjectOfType<CraftManual>();
        //saveData.gameObjectPos = theGameObject.transform.position;
        //saveData.gameObjectRot = theGameObject.transform.eulerAngles;


        string json = JsonUtility.ToJson(saveData); //파일을 물리적으로 이동; Json Utility중 JSON으로 바꾸는것 활용, player의 위치를 json화

        File.WriteAllText(Application.dataPath + "/Saves/SaveFile.txt", json);

        Debug.Log("저장완료");
        Debug.Log(json);


    }

    public void LoadData()
    {
        Debug.Log("SaveLoad_SaveData");
        if (File.Exists(Application.dataPath + "/Saves/SaveFile.txt"))
        {
            string loadJson = File.ReadAllText(Application.dataPath + "/Saves/SaveFile.txt"); //strong loadJson을 만들어읽어올 파일 정보 담음
            saveData = JsonUtility.FromJson<SavaData>(loadJson); //string으로 만들어진 loadJson을 json화하는 것
            //thePlayer = FindObjectOfType<PlayerController>();
            //thePlayer.transform.position = saveData.playerPos;
            Debug.Log("로드완료");
        }
        else
       
            Debug.Log("세이브 파일이 없습니다");
    }
}
