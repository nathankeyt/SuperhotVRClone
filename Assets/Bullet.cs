using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("EnemyHitBox"))
        {
            Destroy(other.gameObject);
            
        }

        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

