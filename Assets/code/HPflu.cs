using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPflu : MonoBehaviour
{
    public GameObject[] heartArray = new GameObject[3];
    private int heartCount;
    GameObject hp;
    [SerializeField]Camera1 webcam;

    // Start is called before the first frame update
    void Start()
    {
        this.hp = GameObject.Find("Heart");
        heartCount = 3;
    }

    public void HPdelete()
    {
        heartCount--;

        if(heartCount == 2)
        {
        heartArray[2].gameObject.SetActive(false);
        heartArray[1].gameObject.SetActive(true);
        heartArray[0].gameObject.SetActive(true);
        }
        if(heartCount == 1)
        {
        heartArray[2].gameObject.SetActive(false);
        heartArray[1].gameObject.SetActive(false);
        heartArray[0].gameObject.SetActive(true);
        }

        if(heartCount == 0)
        {
        heartArray[2].gameObject.SetActive(false);
        heartArray[1].gameObject.SetActive(false);
        heartArray[0].gameObject.SetActive(false);
        webcam.stopcamera();
        SceneManager.LoadScene("result");
        }
    }

    public void HPadd()
    {
        
        heartCount++;
        

        if(heartCount == 3)
        {
        heartArray[2].gameObject.SetActive(true);
        heartArray[1].gameObject.SetActive(true);
        heartArray[0].gameObject.SetActive(true);
        }
        if(heartCount == 2)
        {
        heartArray[2].gameObject.SetActive(false);
        heartArray[1].gameObject.SetActive(true);
        heartArray[0].gameObject.SetActive(true);
        }
        if(heartCount == 1)
        {
        heartArray[2].gameObject.SetActive(false);
        heartArray[1].gameObject.SetActive(false);
        heartArray[0].gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
