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

        try
        {


            //var api = new OpenAI_API.OpenAIAPI("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", Engine.Curie);
            //var result = await api.Completions.CreateCompletionAsync("How are you boy?\n", temperature: 0.1);
            //Debug.Log("=" + result.ToString());
        }
        catch(System.Exception e)
        {
            Debug.LogError(e.Message);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
