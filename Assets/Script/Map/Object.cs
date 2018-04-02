using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Object 
{
    public int id;
    public int hp;
    public Sprite picture;
    public GameObject gUnit;
    public bool active;
    public Object(int id, int hp, Sprite picture, GameObject gUnit, bool active)
    {
        this.id = id;
        this.hp = hp;
        this.picture = picture;
        this.gUnit = gUnit;
        this.active = active;
    }
    // Use this for initialization
}