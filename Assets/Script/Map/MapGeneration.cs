
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {
    int width = csGlobal.width;
    int height = csGlobal.height;
    int depth = csGlobal.depth;
    //public GameObject MapContainer;
    public GameObject FloorPrefab;
    public List<Object> BaseObject = new List<Object>();
    byte[,,] map;
    GameObject[,,] Gmap;
    GameObject[] Floors;
    public Camera MainCam;
    // Use this for initialization
    void Start () {
        //transform.position = new Vector3(width / 2, 0, height / 2);
        
        map = new byte[width+1, depth+1, height+1];
        Gmap = new GameObject[width + 1, depth + 1, height + 1];
        Floors = new GameObject[depth];
        MainCam.transform.position = new Vector3(0, csGlobal.currentFloor * 5, 0); 
        mapGeneration();
        changeFloorsVisibility();
      
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Q)) {
            floorUp();

        } else if (Input.GetKey(KeyCode.E))
        {
            floorDown();
        }

    }
    public void floorUp()
    {    
        if(csGlobal.currentFloor!=depth-1) { 
        csGlobal.currentFloor++;
        changeFloorsVisibility();
        MainCam.transform.position -= new Vector3(0, 1, 0);
          
        }
    }
    public void floorDown()
    {
        if (csGlobal.currentFloor != 0)
        {
            csGlobal.currentFloor--;
            changeFloorsVisibility();
            MainCam.transform.position += new Vector3(0, 1, 0);
        }
    }
    public void changeFloorsVisibility()
    {
        if (csGlobal.isShownDownLayer)
        {
            for (int i = 0; i < depth; i++)
                if (i < csGlobal.currentFloor + 1)
                {
                    Floors[i].SetActive(true);
                }
                else
                {
                    Floors[i].SetActive(false);
                }

        }
        else
        {
            for (int i = 0; i < depth; i++)
                if (i == csGlobal.currentFloor)
                {
                    Floors[i].SetActive(true);
                    
                }
                else
                {
                    Floors[i].SetActive(false);
                }
        }
    }
    public void mapGeneration() {
        Vector3 floorpos = new Vector3(-50, 0, -50);
        Vector3 objpos = floorpos;
        Quaternion floorQuat = new Quaternion(0, 0, 0, 0);
        for (int i = 0; i < depth; i++)
        {
            floorpos.y = i;
            Floors[i] = Instantiate(FloorPrefab, floorpos, floorQuat);
            Floors[i].transform.SetParent(this.transform);
            for (int j = 0; j < height; j++)
                for (int k = 0; k < width; k++)
                {
                    objpos = new Vector3(-(width/2) + k,  i, -(height / 2) + j);
                    if (j == i || k == i || j == height - i || k == width - i)
                        map[j, i, k] = 2;
                    if (j > i && k > i && j < height - i && k < width - i)
                        map[j, i, k] = 1;
                    if (map[j, i, k] != 0)
                    {
                        Gmap[k, i, j] = Instantiate(BaseObject[map[j, i, k] - 1].gUnit, objpos, BaseObject[map[j, i, k] - 1].gUnit.transform.rotation);
                        Gmap[k, i, j].transform.SetParent(Floors[i].transform);

                    }
                }
            Floors[i].SetActive(false);
        }
    }
}
