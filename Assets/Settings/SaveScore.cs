using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    string playerName;
    int score;

    [Header("UI References")]
    public TMP_InputField nameInputField;
    public TMP_InputField scoreInputField;

    void Start()
    {
       
        TMP_InputField targetInputField = nameInputField != null ? nameInputField : gameObject.GetComponent<TMP_InputField>();

        if (targetInputField != null)
        {
            targetInputField.onEndEdit.AddListener(saveScore);
        }

        
        score = 1000;
    }

    void Update()
    {

    }

    public void saveScore(string textInField)
    {
        playerName = textInField;

        
        if (scoreInputField != null && int.TryParse(scoreInputField.text, out int parsedScore))
        {
            score = parsedScore;
        }

        StartCoroutine(connectToPHP());
    }

    IEnumerator connectToPHP()
    {
        string url = "http://localhost/updatescore_b.php";
        url += "?name=" + playerName + "&score=" + score;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error connecting to PHP: " + www.error);
            }
            else
            {
                print("DB updated successfully: " + www.downloadHandler.text);
            }
        }
    }
}
