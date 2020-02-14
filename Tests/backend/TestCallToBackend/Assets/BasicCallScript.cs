using System;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class BasicCallScript : MonoBehaviour
{

    public InputField inputField;
    public Text text;

    void Start()
    {
        inputField = GetComponentInChildren<InputField>();
        text = GetComponentInChildren<Text>();
    }

    public void onClick()
    {
        string port = "44314";
        if (inputField.text != string.Empty)
        {
            port = inputField.text;
        }

        string host = "https://localhost:" + port + "/api/Test";

        text.text = getData(host);
    }


    private string getData(string host)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(host);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        return jsonResponse;
    }

}
