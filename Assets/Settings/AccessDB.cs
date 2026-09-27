using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccessDB: MonoBehaviour
{
    string url = "http://localhost/updatescore.php";
    IEnumerator Start()
    {
        WWW www = new WWW(url);
        yield return www;
        string result = www.text;
        print("data recieved" + result);
        GameObject.Find("high_scores").GetComponent<TextMeshProUGUI>().text = result;
    }
     void Update()
    {
        
    }
}
