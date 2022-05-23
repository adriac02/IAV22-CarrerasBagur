using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    OpenAITest targetAI;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setAI(OpenAITest t)
    {
        targetAI = t;
    }
    public void sendString(string s)
    {
        targetAI.processEntry(s);
    }
}
