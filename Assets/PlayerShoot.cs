using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletTemplate;
<<<<<<< HEAD
<<<<<<< HEAD
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioSource audio_player;
=======
    [SerializeField] private Transform bulletSpawnPoint;
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
=======
    [SerializeField] private Transform bulletSpawnPoint;
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
    public float shootPower = 100f;
    
    public InputActionReference trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        trigger.action.performed += Shoot;
    }

    void Shoot(InputAction.CallbackContext _)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        audio_player.PlayOneShot(shoot);
        GameObject newBullet = Instantiate(bulletTemplate, transform.position, transform.rotation);
=======
        GameObject newBullet = Instantiate(bulletTemplate, bulletSpawnPoint.position, transform.rotation);
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
=======
        GameObject newBullet = Instantiate(bulletTemplate, bulletSpawnPoint.position, transform.rotation);
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }
}
