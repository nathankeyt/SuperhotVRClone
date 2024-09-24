using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private GameObject playerOrigin;

    [SerializeField] private LayerMask teleportMask;

    [SerializeField] private InputActionReference teleportButtonPress;
    // Start is called before the first frame update
    void Start()
    {
        teleportButtonPress.action.performed += OnRaycast;
    }

    void OnRaycast(InputAction.CallbackContext _)
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            Mathf.Infinity,
            teleportMask);

        if (didHit)
        {
            playerOrigin.transform.position = hit.collider.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
