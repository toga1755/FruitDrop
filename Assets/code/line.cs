using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    public float y = default;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        y = myTransform.position.y;

        float sin = Mathf.Sin(Time.time) * 50 + -360;
        gameObject.transform.position = new Vector3(640,sin,70);
    }
}
