using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Unit {
    public int id;
    public int hp;
    public int picture;
    public GameObject gUnit;
    public unitClass Class;
    public Vector3 targPoint;
    public float speed=1;
    public Unit(int id, int hp, int picture, GameObject gUnit, unitClass Class) {
        this.id = id;
        this.hp = hp;
        this.picture = picture;
        this.gUnit = gUnit;
        this.Class = Class;
    }
    public enum unitClass    : byte
    {
        Tecnic,
        Medic,
        Guard
        
           
    }
}