using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouseInteraction : MonoBehaviour
{

    float positionSpeed = 2.5f;
    float rotationSpeed = 5f;
    float scaleSpeed = 2.5f;


    private Transform tf_Player;//플레이어 위치 정보 받아오기
    private GameObject gameObject;

    //Raycast 필요변수 선언
    private RaycastHit hitInfo;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float range;


    private Vector3 mOffset;
    private float mZCoord;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePoint = Input.mousePosition;

            float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
            gameObject.transform.Rotate(Vector3.down, XaxisRotation);

            float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;
            gameObject.transform.Rotate(Vector3.up, YaxisRotation);

        }
    }






    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();


    }





    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }



    /*float positionSpeed = 2.5f;
    float rotationSpeed = 2.5f;
    float scaleSpeed = 2.5f;

    // Start is called before the first frame update
    private void OnMouseDrag()
    {

        Time.timeScale = 0f;
        float XaxisRotation = Input.GetAxis("Mouse X") * positionSpeed;
        transform.Rotate(Vector3.down, XaxisRotation);

        float XaxisPosition = Input.GetAxis("Mouse ScrollWheel") * positionSpeed;
        this.transform.position = this.transform.position + new Vector3(1, 1, 0);

        float XaxisScale = Input.GetAxis("Mouse Y") * scaleSpeed;
        transform.localScale = transform.localScale + new Vector3(1, 0, 0);

        float YaxisScale = Input.GetAxis("RightV") * scaleSpeed;
        transform.localScale = transform.localScale + new Vector3(0, 1, 0);



        Time.timeScale = 1f;

    }*/

}
