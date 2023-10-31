using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour {
    int point;
    string username;
    string[] ranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
    int[] rankingValue = new int[5];
    string[] nameValue = new string[5];

    //string[] dotranking = { "ランキング1位", "ランキング2位", "ランキング3位", "ランキング4位", "ランキング5位" };
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

        if (username == "dotcube")
        {
            DotGetRanking();
            DotSetRanking(point);
        } 
        else 
        {
            GetRanking();
            SetRanking(point);
        }
        
        for (int i = 0; i < rankingText.Length; i++)
        {
                //rankingText[i].text = rankingValue[i].ToString();
                //rankingText[i].text = $"{rankingValue[i]}. {nameValue[i]}: {rankingValue[i]}"; // 名前、ランキング、スコアを表示
            rankingText[i].text = $"{nameValue[i]}: {rankingValue[i]}"; // 名前とスコアを表示
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

    void DotGetRanking()
    {
        // "dotcube" のランキング呼び出し
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = PlayerPrefs.GetInt("DotCube" + ranking[i]); // 例: "DotCubeランキング1位"
            nameValue[i] = PlayerPrefs.GetString("DotCube名前" + ranking[i]); // 例: "DotCube名前ランキング1位"
        }
    }


    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
        // 新しい値を一時的に格納するための配列を作成
        int[] newRankingValues = new int[5];
        string[] newRankingNames = new string[5];

        // ユーザーのスコアがランキングに配置されたかどうかを確認するブール値を初期化
        bool userScorePlaced = false;

        for (int i = 0; i < ranking.Length; i++)
        {
            // ユーザーのスコアが現在のランキング値以上で、まだ配置されていない場合
            if (_value >= rankingValue[i] && !userScorePlaced)
            {
                // ユーザーのスコアと名前をこの位置に配置
                newRankingValues[i] = _value;
                newRankingNames[i] = username;

                // ユーザーのスコアが配置済みであることをマーク
                userScorePlaced = true;

                i++; // ランキング内の次の位置に移動
            }

            // ユーザーのスコアがまだ配置されていない場合、残りのランキングをコピー
            if (i < ranking.Length)
            {
                newRankingValues[i] = rankingValue[i - (userScorePlaced ? 1 : 0)];
                newRankingNames[i] = nameValue[i - (userScorePlaced ? 1 : 0)];
            }
        }

        // 新しいランキングを保存
        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = newRankingValues[i];
            nameValue[i] = newRankingNames[i];
            PlayerPrefs.SetInt(ranking[i], rankingValue[i]);
            PlayerPrefs.SetString("名前" + ranking[i], nameValue[i]);
        }
    }

    void DotSetRanking(int _value)
    {
        // "dotcube" のランキング書き込み
        int[] newRankingValues = new int[5];
        string[] newRankingNames = new string[5];

        bool userScorePlaced = false;

        for (int i = 0; i < ranking.Length; i++)
        {
            if (_value >= rankingValue[i] && !userScorePlaced)
            {
                newRankingValues[i] = _value;
                newRankingNames[i] = username;

                userScorePlaced = true;

                i++;
            }

            if (i < ranking.Length)
            {
                newRankingValues[i] = rankingValue[i - (userScorePlaced ? 1 : 0)];
                newRankingNames[i] = nameValue[i - (userScorePlaced ? 1 : 0)];
            }
        }

        for (int i = 0; i < ranking.Length; i++)
        {
            rankingValue[i] = newRankingValues[i];
            nameValue[i] = newRankingNames[i];
            PlayerPrefs.SetInt("DotCube" + ranking[i], rankingValue[i]);
            PlayerPrefs.SetString("DotCube名前" + ranking[i], nameValue[i]);
        }
    }

}
