using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuidingIntrfaceStart : MonoBehaviour {
    public GameObject ButtonPrefab;
    // Use this for initialization
    ObjectManager OM;
    GameObject ButtonObj;

    void Start () {
        int NumOfObj = 0;
        Quaternion Qnul;
        Qnul.w = 0;
        Qnul.x = 0;
        Qnul.y = 0;
        Qnul.z = 0;
        Vector3 UpVector, DownVector, ScaeVect=Vector3.zero;
        ScaeVect.Set(1, 1, 1);
        OM = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<ObjectManager>();
        int countObj = OM.AllObjects.Count;
        UpVector = ButtonPrefab.transform.position;
        DownVector = ButtonPrefab.transform.position;
        DownVector.y = DownVector.y - 60;
        for (int i = 0; i < countObj; i++) {
            if (OM.AllObjects[i].active) {
                if (NumOfObj % 2 == 0)
                {
                    ButtonObj = Instantiate(ButtonPrefab, Vector3.zero, Qnul);
                    ButtonObj.transform.SetParent( gameObject.transform);
                    ButtonObj.transform.localScale = ScaeVect;
                    ButtonObj.transform.localPosition = UpVector;
                    ButtonObj.transform.localRotation =Qnul ;
                    UpVector.x = UpVector.x + 60;

                }
                else {
                    ButtonObj = Instantiate(ButtonPrefab, Vector3.zero, Qnul);
                    ButtonObj.transform.SetParent(gameObject.transform);
                    ButtonObj.transform.localScale = ScaeVect;
                    ButtonObj.transform.localPosition = DownVector;
                    ButtonObj.transform.localRotation = Qnul;
                    DownVector.x = DownVector.x + 60;


                }
                NumOfObj++;
                ButtonObj.GetComponent<Image>().sprite= OM.AllObjects[i].picture;
        }
            
        }

    }
	
	// Update is called once per frame
	
}
