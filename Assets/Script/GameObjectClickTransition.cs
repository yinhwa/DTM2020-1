using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameObjectClickTransition : MonoBehaviour
{



    // 학술문화관 건물 클릭 후 곧바로 LoadScene 불러오기
    private void OnMouseDown()
    {
        SceneManager.LoadScene("CuratorMode");
    }



    //public string sceneName = "CuratorMode"; //이동할 Scene


    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (Physics.Raycast(ray, out hit, 100.0f))
    //        {
    //            if (hit.transform != null)
    //            {
    //                PrintName(hit.transform.gameObject);
    //            }
    //        }

    //    }

    //}

    //// Update is called once per frame
    //private void PrintName(GameObject go)
    //{
    //    print(go.name);
    //}
    //public void ClickStart(Rigidbody KAIST_Campus_학술문화관)
    //{
    //    Debug.Log("로딩");
    //    SceneManager.LoadScene(sceneName);
    //}
}
