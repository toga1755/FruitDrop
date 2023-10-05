using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour {
    int point;
    string username;
    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];

    string[] nameranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    string[] nameValue = new string[5];
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

        GetRanking();

        SetRanking(point);

        for (int i = 0; i < rankingText.Length; i++)
        {
            rankingText[i].text = rankingValue[i].ToString();
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
                }
        }

        //入れ替えた値を保存
        for (int i = 0; i < ranking.Length; i++)
        {
            PlayerPrefs.SetInt(ranking[i],rankingValue[i]);
        }
    }
}
