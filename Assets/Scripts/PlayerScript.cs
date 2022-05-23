using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public InputField inputField;
    Rigidbody rb;
    FirstPersonMovement fpm;
    Jump jump;
    Crouch crouch;

    bool talk = false;
    bool isTalking = false;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        fpm = GetComponent<FirstPersonMovement>();
        jump = GetComponent<Jump>();
        crouch = GetComponent<Crouch>();
    }

    // Update is called once per frame
    void Update()
    {
        if(talk == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (isTalking)
                {
                    isTalking = false;
                    inputField.text = "";
                    fpm.enabled = true;
                    jump.enabled = true;
                    crouch.enabled = true;
                }
                else
                {
                    isTalking = true;
                    fpm.enabled = false;
                    jump.enabled = false;
                    crouch.enabled = false;
                    inputField.Select();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<OpenAITest>() != null)
        {
            GameManager.Instance.setAI(other.GetComponentInParent<OpenAITest>());
            Debug.Log("Entrado");
            talk = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<OpenAITest>() != null)
        {
            Debug.Log("Salido");
            talk = false;
        }
    }
}
