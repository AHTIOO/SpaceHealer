using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    float camSpeed=1, zoomSpeed = 10, rotSpeed=10;
    float camPos;

  
    float dMaxAngle=45, dMinAngle=45;
    RaycastHit Hit;

    void CamPosXY() {
        byte X=0, Y=0;
        if (Input.mousePosition.x < 20 || Input.GetKey(KeyCode.A)) {
            if(transform.position.x > -csGlobal.width)
                transform.position -= new Vector3(camSpeed, 0, 0);
        }
        else if (Input.mousePosition.x > Screen.width-20 || Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < csGlobal.width)
                transform.position += new Vector3(camSpeed, 0, 0);
        }
        if (Input.mousePosition.y < 20 || Input.GetKey(KeyCode.S))
        {
            if (transform.position.z > -csGlobal.height)
                transform.position -= new Vector3(0, 0, camSpeed);
        }
        else if(Input.mousePosition.y > Screen.height - 20 || Input.GetKey(KeyCode.W))
        {
            if (transform.position.z < csGlobal.height)
                transform.position += new Vector3(0, 0, camSpeed);
        }
    }
    void CamPosZ()
    {
        float zoom;
        if ((zoom = Input.GetAxis("Mouse ScrollWheel")) != 0)
        {

            if (zoom > 0 && transform.position.y <  csGlobal.camZoomMax)
                transform.position += new Vector3(0, zoomSpeed * zoom, 0);
           else if (zoom < 0 && transform.position.y > csGlobal.camZoomMin)
                transform.position += new Vector3(0, zoomSpeed * zoom, 0);
        }
    }
    void CamPosR()
    {
        float angle=0;
        Vector3 point1=new Vector3(), point2 = new Vector3(), rot, dif;
        if (Input.GetMouseButtonDown(2))
        {
            point1 = Input.mousePosition;
            //print(point1);
        }
        if (Input.GetMouseButton(2))
        {
            point2 = Input.mousePosition;
            print(point2);
            dif = point1 - point2;
            angle += dif.x * rotSpeed ;
            //angle += dif.y * rotSpeed;
            Quaternion rotate   = transform.rotation * Quaternion.AngleAxis(angle, Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime / rotSpeed);


        }
       // if (Input.GetMouseButtonUp(2))
       // {

       // }

    }
        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //CamHeightPos();
        //print(Input.mousePosition);
        CamPosXY();
        CamPosZ();
        CamPosR();
    }

   
}
