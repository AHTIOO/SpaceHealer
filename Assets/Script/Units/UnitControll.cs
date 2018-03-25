    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//csGlobal csGlob;

public class UnitControll : MonoBehaviour {
    Vector3 spoint1, point1, point2, campos1, campos2;
   // int layerMaskDef = 1 << 0;
    float height, width;
    public Rect selectRect, selectRectGUI;
    public Texture2D selectedTecsture;
    public bool dragMouse = false;
    UnitManager UM;
    Camera cam;
    // Use this for initialization
    void Start () {
       // csGlob = GameObject.FindObjectOfType(typeof(csGlobal)) as csGlobal;
        UM = gameObject.GetComponent<UnitManager>();
        dragMouse = false;
        cam = GetComponent<Camera>();

    }

    // Update is called once per frame



    void Update () {
        float tmp;
        UnitMovement();
        if (Input.GetMouseButtonDown(0)) {
            Clear();
            spoint1 = ReyTakePosition();
            campos1 = transform.position;
            csGlobal.isDrag = true;
            dragMouse = true;
            //print(spoint1);
         
            point1.z = 0;
            point2.z = 0;
            }
        if (Input.GetMouseButton(0))
        {    
            campos2 = campos1 - transform.position;
          // print(campos2);
            point1.x = spoint1.x + campos2.x;
            point1.y = spoint1.y + campos2.z;
            //print(point1);
            point2 = ReyTakePosition();
            dragMouse =true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragMouse = false;
            Select();
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            var pos = ReyTakePosition();
                if (UM.UnitSelected.Count != 0) for (int i = 0; i < UM.UnitSelected.Count; i++) {

                    UM.UnitSelected[i].targPoint = pos;
                   UM.UnitSelected[i].targPoint.y = csGlobal.currentFloor+0.5f;




                }



        }
    }
    private void OnGUI()
    {
        if (dragMouse==true) {
            width = point2.x - point1.x;
            height = (Screen.height - point2.y) - (Screen.height - point1.y);
            selectRectGUI = new Rect(point1.x, Screen.height - point1.y, width, height);
            GUI.DrawTexture(selectRectGUI, selectedTecsture, ScaleMode.StretchToFill, true);
           // print(selectRect);
        }
    }
    private void UnitMovement() {
        Vector3 movement = new Vector3(0, 0, 0), dif= new Vector3(0,0,0);
       
        for (int i = 0; i < UM.UnitSelected.Count; i++) { 
            dif = UM.UnitSelected[i].targPoint - UM.UnitSelected[i].gUnit.transform.position;
        if (UM.UnitSelected[i].targPoint != Vector3.zero) {
                if(UM.UnitSelected[i].targPoint.x!=0)
                if (Mathf.Abs(dif.x) > UM.UnitSelected[i].speed)
                      movement.x = Mathf.Sign(dif.x) * UM.UnitSelected[i].speed;
                  else
                  { movement.x = dif.x;
                      UM.UnitSelected[i].targPoint.x = 0;
                  }
                if (UM.UnitSelected[i].targPoint.y != 0)
                    if (Mathf.Abs(dif.y ) > UM.UnitSelected[i].speed)
                      movement.y = Mathf.Sign(dif.y) * UM.UnitSelected[i].speed;
                  else { 
                      movement.y = dif.y;
                      UM.UnitSelected[i].targPoint.y = 0;
                  }
                if (UM.UnitSelected[i].targPoint.z != 0)
                    if (Mathf.Abs(dif.z) > UM.UnitSelected[i].speed)
                      movement.z = Mathf.Sign(dif.z) * UM.UnitSelected[i].speed;
                  else { 
                      movement.z = dif.z;
                      UM.UnitSelected[i].targPoint.z = 0;
                  }
                 
             //   movement = UM.UnitSelected[i].targPoint - UM.UnitSelected[i].gUnit.transform.position;
                UM.UnitSelected[i].gUnit.transform.position += movement;
            }
        }


    }
    private void Select()
    {
        float tmp;
        if (point1.x > point2.x)
        {
            tmp = point1.x;
            point1.x = point2.x;
            point2.x = tmp;
        }
        width = point2.x - point1.x;
        if (point1.y < point2.y)
        {
            tmp = point1.y;
            point1.y = point2.y;
            point2.y = tmp;
        }
        height = (Screen.height - point2.y) - (Screen.height - point1.y);
        selectRect = new Rect(point1.x, Screen.height - point1.y, width, height);
        for (int i = 0; i< UM.Units.Count; i++) {
            if (selectRect.Contains(cam.WorldToScreenPoint(UM.Units[i].gUnit.transform.position))) {
                UM.UnitSelected.Add(UM.Units[i]);
            }

        }
    }
    private void Clear() {

        UM.UnitSelected.Clear();
    }
    private Vector3 ReyTakePosition()
    {
        var pos = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            
            pos = hit.point;
            pos.x = pos.x + Screen.width / 2;
            pos.y = pos.y + Screen.height / 2;
            print(pos);
            if (pos.x > csGlobal.width / 2) {
                pos.x = csGlobal.width / 2;
            } else if
                (pos.x < -csGlobal.width / 2)
            {
                pos.x = -csGlobal.width / 2;
            }
            if (pos.z > csGlobal.height / 2)
            {
                pos.z = csGlobal.height / 2;
            }
            else if
              (pos.z < -csGlobal.height / 2)
            {
                pos.z = -csGlobal.height / 2;
            }
            pos.y = csGlobal.currentFloor;


            pos.x = Mathf.Round(pos.x);
            pos.y = Mathf.Round(pos.y);
            pos.z = Mathf.Round(pos.z);
        }
        return pos;
    }
}
