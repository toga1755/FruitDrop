using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCube : MonoBehaviour
{
    // 生成するプレハブ格納用
    public GameObject red;
    public GameObject green;
    public GameObject blue;
    public GameObject apple;
    public GameObject ogange;
    public GameObject bakudan;
    public GameObject dotcube;
    //int redc = 0, greenc = 0, 
    int bluec = 0;
    private int number;
    public float time;
    private float t;
    [SerializeField]Camera1 camera1;
    [SerializeField]line Line;
 
    // Start is called before the first frame update
    void Start()
    {
        t = time;
    }
 
    // Update is called once per frame
    void Update()
    {
        t -=Time.deltaTime;
        if(t < 0.0f)
        {
            t = time;
            //redc = GameObject.FindGameObjectsWithTag("red").Length;
            //greenc = GameObject.FindGameObjectsWithTag("green").Length;
            // bluec = GameObject.FindGameObjectsWithTag("blue").Length;

            number = Random.Range (0, 20);

            //シーンにプレハブを生成
            if(number == 0 )
            {
                bluec = GameObject.FindGameObjectsWithTag("blue").Length;
                if(bluec < 1){
                    // プレハブの位置をランダムで設定
                    float x = Random.Range(250f, 1000f);
                    Vector3 pos = new Vector3(x, 100f, 70f);
    
                    // プレハブを生成
                    GameObject cube = Instantiate(dotcube, pos, Quaternion.Euler(-30, -240, 30));
                    cube.GetComponent<Destroy1>().Setcamera(camera1);
                }
            }else if(number == 1 || number == 2)
            {
                // プレハブの位置を設定
                Vector3 pos = new Vector3(640, 100.0f, 70.0f);
                // プレハブを生成
                GameObject cube = Instantiate(blue, pos, Quaternion.identity);
                cube.GetComponent<Destroy2>().Setcamera(camera1);
                cube.GetComponent<Destroy2>().Setline(Line);
            }else if(number >= 3 && number <= 6)
            {
                bluec = GameObject.FindGameObjectsWithTag("blue").Length;
                if(bluec < 1){
                    // プレハブの位置をランダムで設定
                    float x = Random.Range(250f, 1000f);
                    Vector3 pos = new Vector3(x, 100f, 70f);
    
                    // プレハブを生成
                    GameObject cube = Instantiate(bakudan, pos, Quaternion.Euler(40, 0, 0));
                    cube.GetComponent<Destroy1>().Setcamera(camera1);
                }
            }else if(number >= 7 && number <= 13)
            {
                bluec = GameObject.FindGameObjectsWithTag("blue").Length;
                if(bluec < 1){
                    // プレハブの位置をランダムで設定
                    float x = Random.Range(250f, 1000f);
                    Vector3 pos = new Vector3(x, 100f, 70f);
        
                    // プレハブを生成
                    GameObject cube = Instantiate(apple, pos,Quaternion.Euler(50, 0, 0));
                    cube.GetComponent<Destroy1>().Setcamera(camera1);
                }
            }else if(number >= 14 && number <= 20)
            {
                bluec = GameObject.FindGameObjectsWithTag("blue").Length;
                if(bluec < 1){
                    // プレハブの位置をランダムで設定
                    float x = Random.Range(250f, 1000f);
                    Vector3 pos = new Vector3(x, 100f, 70f);
    
                    // プレハブを生成
                    GameObject cube = Instantiate(ogange, pos, Quaternion.Euler(55, 0, 0));
                    cube.GetComponent<Destroy1>().Setcamera(camera1);
                }
            }
        }
    }
}