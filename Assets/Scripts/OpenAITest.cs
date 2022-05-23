using OpenAI_API;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class OpenAITest : MonoBehaviour
{
    public bool USINGLOG;
    public int MAXLOGS;
    [Range(0f,1f)]
    public float TEMPERATURE;
    Queue<string> logs = new Queue<string>();
    public string[] stop;
    

    // Start is called before the first frame update
    OpenAIAPI api;
    void Start()
    {
        var task = StartAsync();
    }
    async Task StartAsync()
    {
        Debug.Log("Running");

        try
        {


            api = new OpenAI_API.OpenAIAPI("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", Engine.Curie);
            //var result = await api.Completions.CreateCompletionAsync("How are you boy?\n", temperature: 0.1);
            //Debug.Log("=" + result.ToString());
        }
        catch(System.Exception e)
        {
            Debug.LogError(e.Message);
        }

    }

    async Task ReplyLog()
    {
        try
        {
            string prompt = "";
            foreach (string st in logs)
            {
                prompt += st;
            }

            var result = await api.Completions.CreateCompletionAsync(prompt, max_tokens:256, temperature: TEMPERATURE, stopSequences: stop);

            if (logs.Count == MAXLOGS)
            {
                logs.Dequeue();
            }
            logs.Enqueue(result.ToString());

            Debug.Log(result.ToString());
        }
        catch(System.Exception e){
            Debug.LogError(e.Message);
        }
    }

    async Task Reply(string s)
    {
        try
        {
            var result = await api.Completions.CreateCompletionAsync(s, max_tokens: 256, temperature: TEMPERATURE, stopSequences: stop);

            Debug.Log(result.ToString());
        }
        catch (System.Exception e)
        {
            Debug.LogError(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void processEntry(string s)
    {
        Debug.Log(s);
        s = "\n- " + s + "\n- ";
        if (USINGLOG)
        {
            if (logs.Count == MAXLOGS)
            {
                logs.Dequeue();
            }
            logs.Enqueue(s);
            var task = ReplyLog();
        }
        else
        {
            var task = Reply(s);
        }
        
        
        
    }
}
