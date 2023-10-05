using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Destroy1 : MonoBehaviour
{
	Camera1 camera1;
    float hx = default,hy = default,cx,cy,x,y;

    public void Setcamera(Camera1 camera)
    {
        camera1 = camera;
    }

    void Update()
    {
        hx = camera1.x;//手の中心x座標
        hy = camera1.y;//手の中心y座標
        cx = transform.position.x;//キューブのx座標
        cy = -1 * transform.position.y;//キューブのy座標(絶対値)
        x = Mathf.Abs(cx - hx);
        y = Mathf.Abs(cy - hy);
        string tagId = this.gameObject.tag;//タグの名前
        
        if(x <= 50 && y <= 50){
            // Debug.Log("hit!!");
            GameObject pm = GameObject.Find ("Main Camera");
			pm.GetComponent <PointManager> ().hit(tagId);
            Destroy(gameObject);
        }

        if(transform.position.y <= -800f)
        {
            // if (this.gameObject.CompareTag("red")){
            //     GameObject hpd = GameObject.Find ("HPflu");
            //     hpd.GetComponent <HPflu> ().HPdelete();
            // }
            Destroy(gameObject);
        }
    }
}