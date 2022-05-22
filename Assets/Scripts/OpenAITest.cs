using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class OpenAITest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var task = StartAsync();
    }
    async Task StartAsync()
    {
        Debug.Log("Running");

        var api = new OpenAI_API.OpenAIAPI("sk - 3R56KcFUFrIdtnE9bGKiT3BlbkFJjFad0wJygF79tykDSDdW", Engine.Davinci);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
