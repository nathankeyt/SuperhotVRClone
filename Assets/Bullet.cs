using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifetime = 5.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
    
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

