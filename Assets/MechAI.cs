using System;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UIElements;

public class MechAI : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float stopDistance = 2.0f;
    [SerializeField] private float shootTimeout = 2.0f;
    [SerializeField] private GameObject bulletTemplate;
    [SerializeField] private float shootPower = 1.0f;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioSource audio_player;

    private GameObject playerTarget;

    private Animator animator;

    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int ShootActivate = Animator.StringToHash("ShootActivate");

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
        StartCoroutine(WaitThenShoot());
    }

    void Hit()
    {
        maxHealth--;

        if (maxHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform1 = transform;
        
        if (playerTarget)
        {
            var targetPos = playerTarget.transform.position;
            targetPos.y -= targetPos.y - transform1.position.y;
            transform1.LookAt(targetPos);
            if ((transform1.position - playerTarget.transform.position).magnitude > stopDistance)
            {
                animator.SetFloat(Speed, moveSpeed);
                if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Walk")
                {
                    transform1.position += transform1.forward * (moveSpeed * Time.deltaTime);
                }
            }
            else
            {
                animator.SetFloat(Speed, 0.0f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTarget = other.gameObject;
        }
    }

    private IEnumerator WaitThenShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTimeout);

            if (playerTarget)
            {
                animator.SetTrigger(ShootActivate);
                shootTimeout = 7.0f;
            }
        }
    }

    private void Shoot()
    {
        if (playerTarget)
        {
            audio_player.PlayOneShot(shoot);
            var pos = transform.Find("ShootPos").transform;
            pos.LookAt(playerTarget.transform);
            GameObject newBullet = Instantiate(bulletTemplate, pos.position, pos.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(pos.forward * shootPower);
        }
    }
}
