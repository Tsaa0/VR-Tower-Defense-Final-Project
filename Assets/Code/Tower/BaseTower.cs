using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(SphereCollider))]
public abstract class BaseTower : Entity {
    public float detectionRadius = 10;
    public int damage = 1;
    public int cost = 1;
    public float attackCooldown = 1f; //in seconds
    public float currentAttackCooldown;
    public GameObject spawnedObject;
    public bool active = false;

    public void Start() {
        detectionRadius *= transform.localScale.magnitude;
        GetComponent<SphereCollider>().radius = detectionRadius;
    }

    protected abstract void Attack();
    
    
}