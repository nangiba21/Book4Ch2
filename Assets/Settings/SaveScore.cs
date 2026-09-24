using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.WebRequestMethods;
using TMPro;

public class SaveScore : MonoBehaviour
{
    string playerName;
    int score;



    void Start()
    {
        gameObject.GetComponent<TMP_InputField>().onEndEdit.AddListener(saveScore);
        score = 1000;
    }
     void Update()
    {
        
    }

     public void saveScore(string textInField)
    {
        playerName = textInField;
        print("Starting to save score for user" + textInField);
        StartCoroutine(connectToPHP());
    }
    
    IEnumerator connectToPHP()
    {
        string url = "http://localhost/updatescore_b.php";
        url += "?name=" + playerName + "&score=" + score;
        WWW www = new WWW(url);
        yield return www;
        print("DB updated");
    }
}
