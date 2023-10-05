using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class titlerank : MonoBehaviour
{
    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位" };
    int[] rankingValue = new int[3];
    
    [SerializeField, Header("表示させるポイント")]
    TextMeshProUGUI[] rankingText=new TextMeshProUGUI[3];

    // Start is called before the first frame update
    void Start()
    {
        GetRanking();

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
        }
    }

    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
        }
    }
}
