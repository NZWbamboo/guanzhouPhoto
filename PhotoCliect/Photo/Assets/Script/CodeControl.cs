using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LitJson;

public class CodeControl : MonoBehaviour
{
    public Image code;
    private string getcodeurl = "http://app.maymotion.com/open/wx0e61740295e3b17d/ahava/api.php?api=get_init_data";//获取公众号的二维码
    private int error;
    private int getcodeerror;
    private string codeurl;

    void Awake()
    {
        code.enabled = false;
    }

    void Start()
    {
        StartCoroutine(LoadQrcodeUrl());
    }


    IEnumerator LoadQrcodeUrl()
    {
        WWW www = new WWW(getcodeurl);
        yield return www;
        if (www.error == null)
        {
            Debug.Log (www.text);
            JsonData jd = JsonMapper.ToObject(www.text);
            getcodeerror = int.Parse(jd["err"].ToString());
            if (getcodeerror == 0)
            {
                codeurl = jd["msg"].ToString();
                if (codeurl != null)
                {
                    StartCoroutine(LoadQrcode());
                }
            }
        }
    }


    IEnumerator LoadQrcode()
    {
        WWW www = new WWW(codeurl);
        yield return www;
        Texture2D tex = null;
        if (www.error == null)
        {
            tex = www.texture;
        }
        if (tex != null)
        {
            Sprite markTemp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
            code.enabled = true;
            code.sprite = markTemp;
        }
    }
}
