using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy3 : MonoBehaviour
{
    line Line;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -800f)
        {
            Destroy(gameObject);
        }        
    }
    public void Setline(line linecube){
        Line = linecube;
    }

    void OnTriggerEnter(Collider other)
    {
        string tagId = this.gameObject.tag;//タグの名前
        if (other.gameObject.CompareTag("Akawaku"))
        {
            // Debug.Log("hit!!");
            GameObject pm = GameObject.Find ("Main Camera");
            pm.GetComponent <PointManager> ().hit(tagId);
            Destroy(gameObject);
        }
        if (tagId == "blue" && other.gameObject.tag == "line"){
            Destroy(this.gameObject);
        }
    }
}
