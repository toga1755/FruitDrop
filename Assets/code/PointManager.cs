using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour {

	public TextMeshProUGUI scoreText; // スコアの UI
	public static int score; // スコア
	public AudioClip upSE;
	public AudioClip downSE;
 
	void Start () 
	{
		// UI を初期化
    score = 0;
	}
 
	void Update () {
	}
 
	//敵を撃つ
	public void hit(string i) {

	  if(i == "bakudan")
		{
			AudioSource.PlayClipAtPoint( downSE, transform.position);
			GameObject hpd = GameObject.Find ("HPflu");
			hpd.GetComponent <HPflu> ().HPdelete();
			// スコアを加算します
      score = score - 50;
      // UI の表示を更新します
      SetCountText ();
		}
		if(i == "blue")
		{
			AudioSource.PlayClipAtPoint( downSE, transform.position);
			GameObject hpd = GameObject.Find ("HPflu");
			hpd.GetComponent <HPflu> ().HPdelete();
			// スコアを加算します
      score = score - 150;
      // UI の表示を更新します
      SetCountText ();
		}

		if(i == "apple" || i == "orange") {
			AudioSource.PlayClipAtPoint( upSE, transform.position);
			// スコアを加算します
      score = score + 100;
      // UI の表示を更新します
      SetCountText ();
		}
		if(i == "dotcube") {
			AudioSource.PlayClipAtPoint( upSE, transform.position);
			// スコアを加算します
      score = score + 200;
      // UI の表示を更新します
      SetCountText ();
		}
		
		// UI の表示を更新する
		void SetCountText()
		{
		// スコアの表示を更新
		scoreText.text = score.ToString() + " Cube";
		}
	}

	public static int getscore()
	{
		return score;
	}
}
 