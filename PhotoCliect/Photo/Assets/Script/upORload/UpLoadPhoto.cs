/** 
 *Copyright(C) 2017 by MMHD 
 *All rights reserved. 
 *FileName:     UpLoadPhoto.cs 
 *Author:       Joel 
 *Version:      1.0 
 *UnityVersion：4.6.9f1 
 *Date:         2017-12-13 
 *Description:    
 *History: By_307035570
*/
using UnityEngine;
using System.Collections;
using System;
using ZXing;
using ZXing.QrCode;
using UnityEngine.UI;
using LitJson;
using System.Text;


public class UpLoadPhoto : MonoBehaviour
{

    private Texture2D ImgQR;
    public Image img;
    public byte[] bytes;
    public int id;
    public Text num;
    //private string url = "http://app.maymotion.com/apps/chaoxing/wall/api.php?api=upl_user_photo";
    //  private string url = "http://app.maymotion.com/apps/yuhuan/photo/api.php?api=upl_photo";//台州志愿者
    private string url = "http://app.maymotion.com/apps/ceshi/photo/api.php?api=upl_photo";//Ahava上传预览图片的地址
    private string Printurl = "http://app.maymotion.com/open/wx0e61740295e3b17d/ahava/api.php?api=upl_photo1";//上传打印图片的地址
   // private string checkurl = "http://app.maymotion.com/open/wx6be19a2d21b2d544/zltp/api.php?api=get_user_data";
    // private string url = "http://app.maymotion.com/apps/lilai/photo/api.php?api=upl_photo";
    //private string url = "http://app.maymotion.com/apps/ndsy/wall/api.php?api=upl_user_photo";
    //测试版
    //private string url = "http://app.maymotion.com/open/wx6be19a2d21b2d544/wall/api.php?api=upl_user_photo";
    //private string url = "http://app.maymotion.com/open/wx6be19a2d21b2d544/shtp/api.php?api=upl_user_photo";//卖萌互动
    private PhotoDate photodate;
    public bool issshow = false;

   public  IEnumerator UpLoadPrint()
    {
        WWWForm form = new WWWForm();
        form.AddField("id ", id);
        form.AddBinaryData("photo", bytes);
        WWW www = new WWW(Printurl, form);
        yield return www;
        Debug.Log("Print"+www.text);
    }
    IEnumerator UpLoadImage()
    {
        WWWForm form = new WWWForm();
        form.AddField("id ", id);
        form.AddBinaryData("photo", bytes);
        Debug.Log(form);
        WWW www = new WWW(url, form);
        yield return www;

        Debug.Log(www.text);
        string jsondata = www.text;
        if (!IsUTF8Bytes(www.bytes))
            jsondata = UTF8Encoding.UTF8.GetString(www.bytes, 3, www.bytes.Length - 3);
        Debug.Log(jsondata);
        photodate = JsonMapper.ToObject<PhotoDate>(jsondata);

        if (photodate.err == 0)
        {
            string photopath = photodate.msg;//获取网址信息
            ImgQR = new Texture2D(256, 256);
            ImgQR.SetPixels32(Encode(photopath, 256, 256));//将网址转成二维码
            ImgQR.Apply();
        }

        Sprite sprite = Sprite.Create(ImgQR, new Rect(0, 0, ImgQR.width, ImgQR.height), new Vector2(0.5f, 0.5f));
        img.gameObject.SetActive(true);
        img.sprite = sprite;


    }

    public Color32[] Encode(string textForEncoding, int width, int height)
    {
        BarcodeWriter writer = new BarcodeWriter();
        writer.Format = BarcodeFormat.QR_CODE;
        writer.Options = new QrCodeEncodingOptions();
        writer.Options.Height = height;
        writer.Options.Width = width;
        writer.Options.Margin = 0;
        return writer.Write(textForEncoding);
    }
    /// <summary>
    /// 上传数据及下载二维码
    /// </summary>
    public void ShowQR()
    {
        StartCoroutine(UpLoadImage());
    }
    private bool IsUTF8Bytes(byte[] data)
    {
        int charByteCounter = 1; //计算当前正分析的字符应还有的字节数
        byte curByte; //当前分析的字节. 
        for (int i = 0; i < data.Length; i++)
        {
            curByte = data[i];
            if (charByteCounter == 1)
            {
                if (curByte >= 0x80)
                {
                    //判断当前 
                    while (((curByte <<= 1) & 0x80) != 0)
                    {
                        charByteCounter++;
                    }
                    //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X 
                    if (charByteCounter == 1 || charByteCounter > 6)
                    {
                        return false;
                    }
                }
            }
            else
            {
                //若是UTF-8 此时第一位必须为1 
                if ((curByte & 0xC0) != 0x80)
                {
                    return false;
                }
                charByteCounter--;
            }
        }
        if (charByteCounter > 1)
        {
            throw new Exception("非预期的byte格式");
        }
        return true;
    }
}

public class PhotoDate
{
    public int err;
    public string msg;
}
