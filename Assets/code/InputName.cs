using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    //オブジェクトと結びつける
    public TMP_InputField inputField;
    public static string username = "NoName";

    // Start is called before the first frame update
    void Start()
    {
        //Componentを扱えるようにする
        inputField = inputField.GetComponent<TMP_InputField> ();
    }

    public void InputText(){
        //テキストにinputFieldの内容を反映
        string inputText = inputField.text;

        //文字数を制限する(10文字)
        if (inputText.Length > 10) {
            inputText = inputText.Substring(0,10);
            inputField.text = inputText; // 入力フィールドのテキストを更新
        }

        username = inputField.text;
        Invoke("SceneMove", 3.0f);
    }
    private void SceneMove()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public static string getname()
	{
		return username;
	}
}
