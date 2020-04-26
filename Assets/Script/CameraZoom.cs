using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField]
    float m_zoomSpeed = 0f;
    [SerializeField]
    float m_zoomMax = 0f;
    [SerializeField]
    float m_zoomMin = 0f;

    // Start is called before the first frame update

    void CameraZooming()
    {
        float t_zoomDirection = Input.GetAxis("Mouse ScrollWheel");

        if(transform.position.y <= m_zoomMax && t_zoomDirection > 0)
            return;
        
        if(transform.position.y >= m_zoomMin && t_zoomDirection < 0)
            return;

        transform.position += transform.forward * t_zoomDirection * m_zoomSpeed;



    }

    void CameraMove()
    {
        if (Input.GetMouseButton(2))
        {
            float t_posX = Input.GetAxis("Mouse X");
            float t_posZ = Input.GetAxis("Mouse Y");
            transform.position += new Vector3(t_posX, 0, t_posZ);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraZooming();
        CameraMove();

        //if (Input.GetAxis("Mouse ScrollWheel") > 0)
        //{
        //    GetComponent<Camera>().fieldOfView--;
        //    GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y - .3f, transform.position.z + .3f);
        //}

        //if (Input.GetAxis("Mouse ScrollWheel") < 0)
        //{
        //    GetComponent<Camera>().fieldOfView++;
        //    GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z - .3f);
        

    }
}
