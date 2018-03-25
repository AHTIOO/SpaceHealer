using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Object 
{
    public int id;
    public int hp;
    public int picture;
    public GameObject gUnit;
    public Object(int id, int hp, int picture, GameObject gUnit)
    {
        this.id = id;
        this.hp = hp;
        this.picture = picture;
        this.gUnit = gUnit;
        
    }
    // Use this for initialization
}