using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Hitbox : MonoBehaviour {
    public int damage = 1;
    public bool destroyOnHit;
    
}
