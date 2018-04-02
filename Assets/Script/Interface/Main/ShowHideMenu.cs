using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideMenu : MonoBehaviour {

 
    public int Current;
    
    public GameObject[] SubMenuList;
    void Start()
    {
       SubMenuList = GameObject.Find("Interface").GetComponent<MainInterface>().SubMenuList;
}
   



    public void ShowHideMenuFunction(int Current)
    {
        bool active = SubMenuList[Current].activeSelf;
        if (!active)
        {
            for (int i = 0; i < SubMenuList.Length; i++)
            {
                SubMenuList[i].SetActive(false);
            }
            SubMenuList[Current].SetActive(true);
            //active = true;

        }
        else
        {
            //active = false;
            SubMenuList[Current].SetActive(false);
        }
    }
}
