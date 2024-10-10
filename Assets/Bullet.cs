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
<<<<<<< HEAD
            Destroy(other.transform.parent.gameObject);
=======
<<<<<<< HEAD
<<<<<<< HEAD
            Destroy(other.transform.parent.gameObject);
=======
            Destroy(other.gameObject);
>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
=======
            Destroy(other.gameObject);
>>>>>>> 227bb835d132d9ef5d3a891470092936494b2b26
>>>>>>> 4c87775237fccded9d2e1efbaa80fbd976839e9e
            
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

