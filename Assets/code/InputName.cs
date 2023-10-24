/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    public TMP_InputField inputField;
    public static string username = "NoName";
    private bool inputLocked = false;
    private bool flg = true;

    void Start()
    {
        // イベントハンドラを登録して、ユーザーの入力をリアルタイムで処理
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    public void InputText()
    {
        // もし入力がロックされている場合は何もしない
        if (inputLocked)
        {
            return;
        }

        // シーン遷移
        StartCoroutine(DelayedSceneMove());
    }

    private void OnInputValueChanged(string inputText)
    {
        // 入力が変更されたときに呼ばれるハンドラ
        // ユーザーの入力中も処理できるようにする
        // ここで入力のバリデーションを実行することも可能
        
        //テキストにinputFieldの内容を反映
        inputText = inputField.text;

        //文字数を制限する(10文字)
        if (inputText.Length > 10) {
            inputText = inputText.Substring(0,10);
            inputField.text = inputText; // 入力フィールドのテキストを更新
            flg = false;
        } else {
            inputField.text = inputText; // 入力フィールドのテキストを更新
            flg = true;
        }

        // ユーザー名を設定
        username = inputField.text;
        Debug.Log("Input Text Length: " + inputText.Length);
    }

    private IEnumerator DelayedSceneMove()
    {
        // シーン遷移を遅延させてユーザーの入力を受け入れる時間を確保
        inputLocked = true; // 入力をロック
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("SampleScene");
    }

    public static string getname()
    {
        return username;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class InputName : MonoBehaviour
{
    public TMP_InputField inputField;
    public static string username = "NoName";
    private bool inputLocked = false;
    private bool flg = true;

    // Start is called before the first frame update
    void Start()
    {
        // イベントハンドラを登録して、ユーザーの入力をリアルタイムで処理
        inputField.onValueChanged.AddListener(OnInputValueChanged);
    }

    void Update()
    {
        // エンターキーが押されたらシーン遷移
        if (flg && Input.GetKeyDown(KeyCode.Return))
        {
            InputText();
        }
    }

    public void InputText()
    {
        // もし入力がロックされている場合は何もしない
        if (inputLocked)
        {
            return;
        }

        // シーン遷移
        StartCoroutine(DelayedSceneMove());
    }

    private void OnInputValueChanged(string inputText)
    {
        // テキストにinputFieldの内容を反映
        inputText = inputField.text;

        // 改行（改行コード）を削除
        inputText = inputText.Replace("\n", "");

        // 文字数を制限する(10文字)
        if (inputText.Length > 10) {
            inputText = inputText.Substring(0, 10);
            flg = false;
        } else {
            flg = true;
        }

        inputField.text = inputText; // 入力フィールドのテキストを更新

        // ユーザー名を設定
        username = inputField.text;
        Debug.Log("Input Text Length: " + inputText.Length);
    }

    private IEnumerator DelayedSceneMove()
    {
        // シーン遷移を遅延させてユーザーの入力を受け入れる時間を確保
        inputLocked = true; // 入力をロック
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }

    public static string getname()
    {
        return username;
    }
}
