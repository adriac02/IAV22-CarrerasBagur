using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public InputField inputField;
    Rigidbody rb;

    bool talk = false;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(talk == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                inputField.Select();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInParent<OpenAITest>() != null)
        {
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
