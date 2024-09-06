using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletTemplate;
    public float shootPower = 100f;
    
    public InputActionReference trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        trigger.action.performed += Shoot;
    }

    void Shoot(InputAction.CallbackContext _)
    {
        GameObject newBullet = Instantiate(bulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
    }
}
