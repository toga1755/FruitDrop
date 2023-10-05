using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy2 : MonoBehaviour
{
    RandomCube randomcube;
    Camera1 camera1;
    line Line;
    float hx = default,hy = default,cx,cy,x,y,liney;

    public void Setcamera(Camera1 camera)
    {
        camera1 = camera;
    }
    public void Setline(line linecube){
        Line = linecube;
    }

    // Update is called once per frame
    void Update()
    {
        hx = camera1.x;//手の中心x座標
        hy = camera1.y;//手の中心y座標
        cx = transform.position.x;//キューブのx座標
        cy = Mathf.Abs(transform.position.y);//キューブのy座標(絶対値)
        x = Mathf.Abs(cx - hx);
        y = Mathf.Abs(cy - hy);
        liney = Line.y;
        string tagId = this.gameObject.tag;//タグの名前

        // Debug.Log(liney);

        if(hy >= liney && y <= 50){
            // Debug.Log("hit!! blue");
            GameObject pm = GameObject.Find ("Main Camera");
			pm.GetComponent <PointManager> ().hit(tagId);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "line"){
            Destroy(this.gameObject);
        }
    }
}
