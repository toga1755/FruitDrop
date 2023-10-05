using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour

{
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI CountText;
    public float totalTime = 3;
    int retime;
    float countdown = 3f;
    int count;
    [SerializeField]Camera1 webcam;

   // Start is called before the first frame update
   void Start()
   {
    totalTime = totalTime * 60;
   }

   // Update is called once per frame
   void Update()
   {
        if(countdown >= 0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();
        }
        if(countdown <= 0)
        {
            CountText.text = "";
            totalTime -= Time.deltaTime;
            retime = (int)totalTime;
            var span = new TimeSpan(0, 0, (int)totalTime);
            timeText.text = span.ToString(@"mm\:ss");
            if(retime == 0)
            {
                webcam.stopcamera();
                SceneManager.LoadScene("result");
            }
        }
   }
}