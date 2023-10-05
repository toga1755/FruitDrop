using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{
    
    [SerializeField]Camera1 webcam;
    public void OnClick(){
        //カメラoff
        webcam.stopcamera();
        // メインシーンへ移動
        SceneManager.LoadScene("title");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
