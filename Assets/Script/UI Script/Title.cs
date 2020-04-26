//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Title : MonoBehaviour
//{

//    public string sceneName = "CuratorMode"; //이동할 Scene

//    public static Title instance;

//    ///public SaveLoad theSaveLoad;



//    private void Awake()
//    {


//        //싱글턴singleton 확보
//        if (instance == null)
//        {
//            instance = this;
//            //DontDestroyOnLoad(gameObject);
//        }
//        else if(instance != this)
//        {
//            Destroy(this.gameObject);
//        }
//        //DontDestroyOnLoad(gameObject);

//    }




//    public void ClickStart()
//    {
//        Debug.Log("로딩");
//        SceneManager.LoadScene(sceneName);
//    }

//    public void ClickLoad()
//    {
//        Debug.Log("로딩");

//        StartCoroutine(LoadCoroutine());


//    }

//    IEnumerator LoadCoroutine()
//    {
//        //SceneManager.LoadScene(sceneName);
//        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

//        while (!operation.isDone)
//        {
//            yield return null; //AsyncOperation 로딩 끝날때까지 대기
//        }

//        //theSaveLoad = FindObjectOfType<SaveLoad>();
//        //theSaveLoad.LoadData();

//        //Destroy(gameObject);
//    }

//    public void ClickExit()
//    {
//        Debug.Log("게임종료");
//        Application.Quit();
//    }

//    //void SavePosition()
//    //{
//    //    PlayerPrefs.SetFloat("posX", this.transform.position.x);
//    //    PlayerPrefs.SetFloat("posY", this.transform.position.y);
//    //    PlayerPrefs.SetFloat("posZ", this.transform.position.z);
//    //    PlayerPrefs.SetFloat("rotX", this.transform.eulerAngles.x);
//    //    PlayerPrefs.SetFloat("rotY", this.transform.eulerAngles.y);
//    //    PlayerPrefs.SetFloat("rotZ", this.transform.eulerAngles.z);
//    //    PlayerPrefs.SetFloat("scaleX", this.transform.localScale.x);
//    //    PlayerPrefs.SetFloat("scaleY", this.transform.localScale.y);
//    //    PlayerPrefs.SetFloat("scaleZ", this.transform.localScale.z);


//    //}

//    //void LoadPosition()
//    //{
//    //    transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
//    //    transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("rotX"), PlayerPrefs.GetFloat("rotY"), PlayerPrefs.GetFloat("rotZ"));
//    //    transform.localScale = new Vector3(PlayerPrefs.GetFloat("scaleX"), PlayerPrefs.GetFloat("scaleY"), PlayerPrefs.GetFloat("scaleZ"));
//    //}

//}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public string sceneName = "CuratorMode"; //이동할 Scene

    public static Title instance;

    public SaveLoad theSaveLoad;
    //public SaveLoad theSaveLoadDada;

    public Text myText;
    public Text idText;
    public Text pwText;



    private void Awake()
    {


        //싱글턴singleton 확보
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    public void ClickLogin()
    {
        //myText.GetComponent<Text>().text = "sfdsfsdf";

        //myText.GetComponent<Text>().text = idText.GetComponent<Text>().text;
        //Debug.Log(DatabaseEssential.DatabaseManager.instance.Count("member"));
        Debug.Log(DatabaseEssential.DatabaseManager.instance.Login(idText.GetComponent<Text>().text, pwText.GetComponent<Text>().text));
        if(DatabaseEssential.DatabaseManager.instance.Login(idText.GetComponent<Text>().text, pwText.GetComponent<Text>().text))
        {
            myText.GetComponent<Text>().text = DatabaseEssential.DatabaseManager.instance.GetUserInfo(idText.GetComponent<Text>().text)+"님 안녕하세요!.";
        } else
        {
            myText.GetComponent<Text>().text = "로그인 실패";
        }
    }


    public void ClickStart()
    {
        Debug.Log("로딩");
        SceneManager.LoadScene(sceneName);
    }

    public void ClickLoad()
    {
        Debug.Log("로딩");

        StartCoroutine(LoadCoroutine());


    }

    IEnumerator LoadCoroutine()
    {
        //SceneManager.LoadScene(sceneName);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            yield return null; //AsyncOperation 로딩 끝날때까지 대기
        }

        theSaveLoad = FindObjectOfType<SaveLoad>();
        theSaveLoad.LoadData();

        Destroy(gameObject);
    }

    public void ClickExit()
    {
        Debug.Log("게임종료");
        Application.Quit();
    }

    //void SavePosition()
    //{
    //    PlayerPrefs.SetFloat("posX", this.transform.position.x);
    //    PlayerPrefs.SetFloat("posY", this.transform.position.y);
    //    PlayerPrefs.SetFloat("posZ", this.transform.position.z);
    //    PlayerPrefs.SetFloat("rotX", this.transform.eulerAngles.x);
    //    PlayerPrefs.SetFloat("rotY", this.transform.eulerAngles.y);
    //    PlayerPrefs.SetFloat("rotZ", this.transform.eulerAngles.z);
    //    PlayerPrefs.SetFloat("scaleX", this.transform.localScale.x);
    //    PlayerPrefs.SetFloat("scaleY", this.transform.localScale.y);
    //    PlayerPrefs.SetFloat("scaleZ", this.transform.localScale.z);


    //}

    //void LoadPosition()
    //{
    //    transform.position = new Vector3(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"), PlayerPrefs.GetFloat("posZ"));
    //    transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("rotX"), PlayerPrefs.GetFloat("rotY"), PlayerPrefs.GetFloat("rotZ"));
    //    transform.localScale = new Vector3(PlayerPrefs.GetFloat("scaleX"), PlayerPrefs.GetFloat("scaleY"), PlayerPrefs.GetFloat("scaleZ"));
    //}

}