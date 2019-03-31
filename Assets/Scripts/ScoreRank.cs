using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreRank : MonoBehaviour
{
    private readonly List<int> topFive=new List<int>();
    private string SCORE ="";
    // Start is called before the first frame update
    void Start()
    {
        var gameobject = GameObject.Find("ScoreRecord");
        var record = gameobject.GetComponent<ScoreRecord>();
        if (record != null)
        {
            foreach (var score in record.Top_five)
            {
                topFive.Add(score);
            }
            topFive.Reverse();
            if (topFive.Count > 0)
            {
                fillScore();
            }
        }
    }

    void fillScore(){
        for (int i = 0; i < topFive.Count; i++){
            SCORE = SCORE + " " + topFive[i].ToString()+"\n";
        }
        for (int i = topFive.Count; i < 5; i++){
            SCORE = SCORE + "--------------------------------------\n";
        }
        GetComponent<TextMeshProUGUI>().text = SCORE;
    }
}
