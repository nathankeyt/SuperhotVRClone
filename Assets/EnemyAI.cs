using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0.1f;

    private GameObject playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget)
        {
            Transform transform1 = transform;
            transform1.LookAt(playerTarget.transform.position);
            if ((transform1.position - playerTarget.transform.position).magnitude > 0.1f)
            {
                transform1.position += transform1.forward * (moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerTarget = other.gameObject;
    }
}
