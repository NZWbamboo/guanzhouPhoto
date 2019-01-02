using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

public class BootScript : MonoBehaviour
{

    private string checkurl = "http://app.maymotion.com/open/wx0e61740295e3b17d/ahava/api.php?api=get_user_data";//获取用户信息的URL
    private string clrurl = "http://app.maymotion.com/open/wx0e61740295e3b17d/ahava/api.php?api=cle_user_data";//清除用户信息URL

    private void OnEnable()
    {
        StartCoroutine(Clr());
    }
    IEnumerator Clr()
    {
        WWW www = new WWW(clrurl);
        yield return www;
        //Debug.Log (www.text);
        if (www.error == null)
        {
            try
            {
              JsonData  clrdate = JsonMapper.ToObject(www.text);
                if ((int)clrdate["err"] == 0)
                {
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        else
        {
            Debug.Log(www.error + "222");
        }
    }


void Start()
    {
        InvokeRepeating("GetAwake", 1, 3);
    }
   
    private void GetAwake()
    {
        if (Gamemanger.isAwaken)//如果在唤醒界面
        {
            StartCoroutine("Receiver");
            //TODO 接受扫码
        }
    }
    IEnumerator Receiver()
    {
        WWW www = new WWW(checkurl);
        yield return www;
        //Debug.LogError(www.text);
        JsonData photodate = JsonMapper.ToObject(www.text);
        Gamemanger.isAwaken = (int)photodate["err"] == 2;//如果返回的是不是2就进入页面
       // Debug.LogWarning(Gamemanger.isAwaken);
        if (!Gamemanger.isAwaken)
        {
            GameObject.Find("awakenPage").GetComponent<BootScript>().Boot();
        }
    }
   public  void Boot()
    {
        GameObject PhotoPanel = Resources.Load<GameObject>("UIPrefabs/PhotoPanel 1");
        Instantiate<GameObject>(PhotoPanel, transform.parent).name = "PhotoPanel";
        GameObject selectFrame = Resources.Load<GameObject>("UIPrefabs/selectFrame_one");
        Instantiate<GameObject>(selectFrame, transform.parent);
        Destroy(this.gameObject);
    }
}

