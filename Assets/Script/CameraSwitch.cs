using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject cameraOne;
    public GameObject cameraTwo;
 //   public GameObject cameraThree;

    AudioListener cameraOneAudioLis;
    AudioListener cameraTwoAudioLis;
    AudioListener cameraThreeAudioLis;

    // Use this for initialization
    void Start()
    {

        //Get Camera Listeners
        cameraOneAudioLis = cameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = cameraTwo.GetComponent<AudioListener>();
   //     cameraThreeAudioLis = cameraThree.GetComponent<AudioListener>();


        //Camera Position Set
        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        //Change Camera Keyboard
        switchCamera();
    }

    //UI JoyStick Method
    public void cameraPositonM()
    {
        cameraChangeCounter();
    }

    //Change Camera Keyboard
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
        {
            cameraChangeCounter();
        }
    }

    //Camera Counter
    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    //Camera change Logic
    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }

        //Set camera position database
        PlayerPrefs.SetInt("CameraPosition", camPosition);

        //Set camera position 1
        if (camPosition == 0)
        {
            cameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;
            Time.timeScale = 1f;

            cameraTwoAudioLis.enabled = false;
            cameraTwo.SetActive(false);

            //cameraThreeAudioLis.enabled = false;
            //cameraThree.SetActive(false);
        }

        //Set camera position 2
        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            Time.timeScale = 0f; //시간의 흐름 조정가능(timeScale), 0배속 처리


            cameraOneAudioLis.enabled = false;
            cameraOne.SetActive(false);

            //cameraThreeAudioLis.enabled = false;
            //cameraThree.SetActive(false);

        }

        //if (camposition == 2)
        //{
        //    camerathree.setactive(true);
        //    camerathreeaudiolis.enabled = true;

        //    cameraoneaudiolis.enabled = false;
        //    cameraone.setactive(false);

        //    cameratwoaudiolis.enabled = false;
        //    cameratwo.setactive(false);

        //}

    }
}
