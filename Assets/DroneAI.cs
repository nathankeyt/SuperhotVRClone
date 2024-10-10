using System;
using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
using Unity.VisualScripting;
=======
<<<<<<< HEAD
using Unity.VisualScripting;
=======
>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
using UnityEngine;
using UnityEngine.Events;

public class DroneAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private GameObject bulletTemplate;
    [SerializeField] private float shootTimeout = 3.0f;
    [SerializeField] private float stopDistance = 10.0f;
    [SerializeField] public UnityEvent deathEvent;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioSource audio_player;
    
    public float shootPower = 100f;

    private GameObject playerTarget;

<<<<<<< HEAD
=======
<<<<<<< HEAD
=======

>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
    private void Start()
    {
        deathEvent ??= new UnityEvent();

        StartCoroutine(WaitThenShoot());
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        Transform transform1 = transform;
        
        if (playerTarget)
        {
=======
<<<<<<< HEAD
        Transform transform1 = transform;
        if (playerTarget)
        {
            
=======
        if (playerTarget)
        {
            Transform transform1 = transform;
>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
            transform1.LookAt(playerTarget.transform.position);
            if ((transform1.position - playerTarget.transform.position).magnitude > stopDistance)
            {
                transform1.position += transform1.forward * (moveSpeed * Time.deltaTime);
            }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
            
            
>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        playerTarget = other.gameObject;
    }

    private void Shoot()
    {
        audio_player.PlayOneShot(shoot);
        GameObject newBullet = Instantiate(bulletTemplate, transform.position + (transform.forward * 0.6f), transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }

    private IEnumerator WaitThenShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTimeout);
<<<<<<< HEAD

=======
<<<<<<< HEAD
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
            if (playerTarget)
            {
                Shoot();
            }
<<<<<<< HEAD
=======
=======
            Shoot();
>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
        }
    }

    private void OnDestroy()
    {
        deathEvent.Invoke();
    }
}