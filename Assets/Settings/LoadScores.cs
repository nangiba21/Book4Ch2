using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro; 

public class LoadScores : MonoBehaviour
{
    public TMP_Text scoreDisplayBox; 

    void Start()
    {
        StartCoroutine(GetScoresFromPHP());
    }

    IEnumerator GetScoresFromPHP()
    {
        string uri = "http://localhost/display.php";
        using (UnityWebRequest www = UnityWebRequest.Get(uri))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error loading" + www.error);
           }
           else
           {
               if (scoreDisplayBox != null)
               {
                   scoreDisplayBox.text = www.downloadHandler.text;
                    Debug.Log("everythings displayed");
               }
               else
                {
                    Debug.LogError("its empty");
                }
            }
        }
    }
}