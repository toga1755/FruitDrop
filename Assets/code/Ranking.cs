using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour {
    int point;
    string username;
    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];
    string[] nameValue = new string[5];

    string[] dotranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    public TextMeshProUGUI cubeText;

    [SerializeField, Header("表示させるポイント")]
    TextMeshProUGUI[] rankingText=new TextMeshProUGUI[5];

    [SerializeField, Header("表示させる名前")]
    TextMeshProUGUI[] nameText=new TextMeshProUGUI[5];

    // Use this for initialization
    void Start ()
    {
        point = PointManager.getscore();
        username = InputName.getname();

        // point = 5000;
        // username = "しょうたろう";

        cubeText.text =username + "さんは\n" + point + " Cube\n" + "獲得しました"; 

        if (username != "dotcube") {
            GetRanking();
            SetRanking(point);
            for (int i = 0; i < rankingText.Length; i++)
            {
                //rankingText[i].text = rankingValue[i].ToString();
                //rankingText[i].text = $"{rankingValue[i]}. {nameValue[i]}: {rankingValue[i]}"; // 名前、ランキング、スコアを表示
                rankingText[i].text = $"{nameValue[i]}: {rankingValue[i]}"; // 名前とスコアを表示
            }
        } else {
            DotGetRanking();
            DotSetRanking(point);
            for (int i = 0; i < rankingText.Length; i++)
            {
                //rankingText[i].text = rankingValue[i].ToString();
                //rankingText[i].text = $"{rankingValue[i]}. {nameValue[i]}: {rankingValue[i]}"; // 名前、ランキング、スコアを表示
                rankingText[i].text = $"{nameValue[i]}: {rankingValue[i]}"; // 名前とスコアを表示
            }
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(ranking[i]);
            nameValue[i]=PlayerPrefs.GetString("名前" + ranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                    var nameKey = "名前" + ranking[i];
                    nameValue[i] = username;
                    PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
                    PlayerPrefs.SetString(nameKey,nameValue[i]);
                }
        }

        /*//入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
        }*/
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void DotGetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i]=PlayerPrefs.GetInt(dotranking[i]);
            nameValue[i]=PlayerPrefs.GetString("名前" + dotranking[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void DotSetRanking(int _value)
    {
        //書き込み用
        for (int i = 0; i < ranking.Length; i++)
        {
                //取得した値とRankingの値を比較して入れ替え
                if (_value>rankingValue[i])
                {
                    var change = rankingValue[i];
                    rankingValue[i] = _value;
                    _value = change;
                    var dotnameKey = "名前" + dotranking[i];
                    nameValue[i] = username;
                    PlayerPrefs.SetInt(dotranking[i], rankingValue[i]);
                    PlayerPrefs.SetString(dotnameKey,nameValue[i]);
                }
        }
    }
}
