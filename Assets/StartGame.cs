using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private InputActionReference leftTrigger;
    [SerializeField] private InputActionReference rightTrigger;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        float leftTriggerHeld = leftTrigger.action.ReadValue<float>();
        float rightTriggerHeld = rightTrigger.action.ReadValue<float>();
        
        Debug.Log(leftTriggerHeld);
        Debug.Log(rightTriggerHeld);

        if (leftTriggerHeld > 0.5 && rightTriggerHeld > 0.5)
        {
            SceneManager.LoadScene("Scenes/MainScene");
        }
    }
}
