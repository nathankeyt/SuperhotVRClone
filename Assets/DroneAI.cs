using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private GameObject bulletTemplate;
    [SerializeField] private float shootTimeout = 3.0f;
    [SerializeField] private float stopDistance = 10.0f;
    public float shootPower = 100f;

    private GameObject playerTarget;


    private void Start()
    {
        StartCoroutine(WaitThenShoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget)
        {
            Transform transform1 = transform;
            transform1.LookAt(playerTarget.transform.position);
            if ((transform1.position - playerTarget.transform.position).magnitude > stopDistance)
            {
                transform1.position += transform1.forward * (moveSpeed * Time.deltaTime);
            }
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerTarget = other.gameObject;
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(bulletTemplate, transform.position + (transform.forward * 0.6f), transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }

    private IEnumerator WaitThenShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTimeout);
            Shoot();
        }
    }
}