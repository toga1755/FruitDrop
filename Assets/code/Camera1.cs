using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OpenCvSharp;

public class Camera1 : MonoBehaviour
{
    WebCamTexture webcam;
    int width = 1280;//1280
    int height = 720;//720
    int fps = 30;
    public float x = 0.0f;
    public float y = 0.0f;
    Texture2D outTexture;

    public void stopcamera(){
        webcam.Stop();
    }

    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcam = new WebCamTexture(devices[0].name, this.width, this.height, this.fps);
        // GetComponent<Renderer>().material.mainTexture = webcam;
        webcam.Play();
        outTexture = new Texture2D(this.width, this.height, TextureFormat.ARGB32, false);
        GetComponent<Renderer>().sharedMaterial.mainTexture = outTexture;

    }

    // Update is called once per frame
    void Update()
    {
        Mat mat = OpenCvSharp.Unity.TextureToMat(webcam);

        Mat mask = new Mat();

        Cv2.CvtColor(mat,mask,ColorConversionCodes.BGR2HSV);//色の違いわからんぬ　折り紙式ならHSVの方が分かりやすそう...
        // Mat YCrCb_maskin = mask.InRange(new Scalar(0,135,85), new Scalar(255,180,135));//空間(texture??)が狭いとくっつくわこれ
        
        //青色
        // Mat YCrCb_maskin = mask.InRange(new Scalar(100,50,100), new Scalar(120,255,255));

        //緑色
        // Mat YCrCb_maskin = mask.InRange(new Scalar(30,50,80), new Scalar(100,255,255));

        //黄色
        //Mat YCrCb_maskin = mask.InRange(new Scalar(15,50,100), new Scalar(30,255,255));

        //赤色
        Mat YCrCb_maskin = mask.InRange(new Scalar(170,50,100), new Scalar(180,255,255)); //顔も反応する可能性アリ

        //黒色
        // Mat YCrCb_maskin = mask.InRange(new Scalar(0,150,0), new Scalar(180,255,30));

        YCrCb_maskin.MorphologyEx(MorphTypes.Open, new Mat(3,3,MatType.CV_8UC1));
        OpenCvSharp.Point[][] contours;
        OpenCvSharp.HierarchyIndex[] hierarchy;
        Cv2.FindContours(YCrCb_maskin,out contours,out hierarchy,RetrievalModes.External, ContourApproximationModes.ApproxNone);//輪郭を見つけるhttps://imagingsolution.net/program/python/opencv-python/opencv-python-findcontours/
        foreach(var cnt in contours){//forの配列バージョンhttps://learn.microsoft.com/ja-jp/dotnet/csharp/programming-guide/arrays/using-foreach-with-arrays
            var area = Cv2.ContourArea(cnt);//面積求めるhttps://imagingsolution.net/program/python/opencv-python/contourarea/
            //タプルというのを使って複数の戻り値を受け取っているhttps://www.fenet.jp/dotnet/column/language/8281/
            if (area >100){
                var rect = Cv2.BoundingRect(cnt);//左上のxy座標と高さと幅の取得、傾いたバージョンもあるhttps://imagingsolution.net/program/python/opencv-python/contour_bounding_rect/
                //Cv2.DrawContours(mat,contours,-1, new Scalar(0,0,255),2);
                Cv2.Rectangle(mat,rect,new Scalar(0,0,255),3);//赤い四角形を書くhttps://shikaku-mafia.com/opencv-rectangle/
                // Debug.Log(rect);
                // Debug.Log(rect.X);
                // Debug.Log(rect.Y);
                // Debug.Log(rect.Width);
                // Debug.Log(rect.Height);
                x = rect.X + (rect.Width / 2);
                y = rect.Y + (rect.Height / 2);
                // Debug.Log(rect +"::"+ x + "::" + y);
            }
        }

        OpenCvSharp.Unity.MatToTexture(mat, outTexture);//画面全体表示
    }
}

/*
高さ720
幅1280
右上がx:0,y:0
右下がx:0,y:720
左上がx:1280,y:0
左下がx:1280,y720
多分左右反転しているから
*/