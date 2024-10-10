using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private DroneAI[] enemies;
    [SerializeField] private GameObject mech;

    private int openThreshold;
    // Start is called before the first frame update
    void Start()
    {
        openThreshold = enemies.Length;
        
        foreach (var enemy in enemies)
        {
            enemy.deathEvent.AddListener(OnEnemyDeath);
        }
    }

    void OnEnemyDeath()
    {
        openThreshold--;

        if (openThreshold <= 0)
        {
            mech.SetActive(true);
            Open();
        }
    }

    void Open()
    {
        transform.DOMoveY(1.6f, 5);
    }
    // Update is called once per frame
}
