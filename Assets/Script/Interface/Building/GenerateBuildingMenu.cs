using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBuildingMenu : MonoBehaviour {
    public GameObject Content;
    public GameObject[] menuobj;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CreateMenuBuilding() {
        for (int i = 0; i < menuobj.Length/2; i++ ) {
            for (int j = 0; i < (menuobj.Length-1) / 2; i++)
            {
                Debug.Log(i);
                Debug.Log(j);

            }

        }


        
    }
}
