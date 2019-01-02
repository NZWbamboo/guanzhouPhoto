///** 
// *Copyright(C) 2017 by MMHD 
// *All rights reserved. 
// *FileName:     NumControl.cs 
// *Author:       Joel 
// *Version:      1.0 
// *UnityVersion：4.6.9f1 
// *Date:         2017-12-13 
// *Description:    
// *History: By_307035570
//*/

//using UnityEngine;
//using System.Collections;
//using UnityEngine.UI;
//using System.IO;

//public class CutScreen : MonoBehaviour
//{
//   // public CutBackStart cbs;
//   // public UpLoadPhoto up;
//    public Sprite[] nums;
//    public Image time;
//    private int index;
//    private Texture2D t2;
//    private float playtimer = 1f;
//    private float playtime = 0f;
//    public Image photo;
//    public GameObject numgo;
//    public GameObject mask;
//    public GameObject YNbg;
//    public GameObject cam;
//    public GameObject CloseBtn;
//    //public GameObject card;
//    // Use this for initialization
//    void Start()
//    {
//        index = 5;
//        time.sprite = nums[index];
//    }


//    // Update is called once per frame
//    void Update()
//    {

        
//            playtime += Time.deltaTime;
//            if (playtime >= playtimer)
//            {
//                index--;
//              //  sound.ins.PlayVox(1);
//                playtime = 0;
//                if (index == 0)
//                {
//                    numgo.gameObject.SetActive(false);
//                    //numgo.transform.parent.gameObject.SetActive(false);
//                    CloseBtn.SetActive(false);
//                    mask.gameObject.SetActive(false);
//                  //  sound.ins.PlayVox(2);
//                    StartCoroutine(UploadPNG());
//                }
//                time.sprite = nums[index];
//            }
//        }
    
//    JPGEncoder encoder;

//    IEnumerator UploadPNG()
//    {
//        yield return new WaitForEndOfFrame();
//        if (t2)
//        {
//            Destroy(t2);
//            t2 = null;
//        }
//        int width = Screen.width;
//        int height = Screen.height;
//        //t2 = new Texture2D((int)(width * 0.84375f), height, TextureFormat.RGB24, false);//要保存图片的大小
//        //t2.ReadPixels(new Rect((int)(width * 0.078165f), 0, (int)(width * 0.84375f), height), 0, 0, false);
//        //t2 = new Texture2D(width, (int)(height / 3.16f), TextureFormat.RGB24, false);//要保存图片的大小
//        //t2.ReadPixels(new Rect(0, (int)(height / 1.742f), width, (int)(height / 3.15f)), 0, 0, false);
//        t2 = new Texture2D((int)(width), (int)(height), TextureFormat.RGB24, false);//要保存图片的大小
//        t2.ReadPixels(new Rect((int)(0), (int)(0), (int)width, (int)(height)), 0, 0, false);

//        t2.Apply();

//        encoder = new JPGEncoder(t2, 50);
//        encoder.doEncoding();
//        while (!encoder.isDone)
//            yield return null;

//        photo.sprite = Sprite.Create(t2, new Rect(0, 0, (int)width, (int)height), new Vector2(0, 0));
//        byte[] byt = t2.EncodeToJPG();
//        Print pr = FindObjectOfType<Print>();
//        MemoryStream ms = new MemoryStream(byt);
//        pr.stream = ms;
//     //   GameControl._instance.gamestate = GameState.End;
//        UpPhoto();
//    }


//    public void UpPhoto()
//    {
//      //  up.bytes = encoder.GetBytes();
//      //  up.ShowQR();
//       // CutBackStart.index = 30;
//    }

//    public void InitNum()
//    {
//        numgo.gameObject.SetActive(false);
//        mask.gameObject.SetActive(true);
//        playtime = 0;
//        index = 5;
//        time.sprite = nums[index];
//    }
//}
