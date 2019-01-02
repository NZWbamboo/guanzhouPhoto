using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWebCamera : MonoBehaviour
{
    //    public Vector2 resolution = new Vector2(1920, 1080);
    //    public int fps = 30;
    //    public RawImage rawimage;
    //    public static  WebCamTexture webcam;


    //    void Awake()
    //    {
    //        //Application.targetFrameRate = 50;

    //    }
    //#if UNITY_WEBPLAYER
    //	IEnumerator Start() {
    //	yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
    //	Init();
    //	}
    //#else
    //    void Start()
    //    {
    //        Init();
    //    }
    //#endif

    //    void Init()
    //    {
    //        //Set Plane to Screen Resolution
    //        float screenAspect = (float)Screen.width / (float)Screen.height;

    //        if (fps > 0)
    //        {
    //            webcam = new WebCamTexture((int)resolution.x, (int)resolution.y, fps);
    //        }
    //        else
    //        {
    //            webcam = new WebCamTexture((int)resolution.x, (int)resolution.y);
    //        }

    //        if (webcam)
    //        {
    //            webcam.Play();
    //            Debug.Log("Webcam capture started at " + webcam.width + "x" + webcam.height);
    //            rawimage.texture = webcam;
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Could not initialize a camera at " + (int)resolution.x + "x" + (int)resolution.y);
    //        }
    //    }

    //    void OnEnable()
    //    {
    //        if (webcam)
    //        {
    //            webcam.Play();
    //            rawimage.texture = webcam;
    //        }
    //    }

    //    void OnDisable()
    //    {
    //        if (webcam)
    //        {
    //            webcam.Stop();
    //        }
    //    }
    public string deviceName;
    public static WebCamTexture camTexture;
    RawImage rawimage;

    void Start()
    {
        rawimage = GetComponent<RawImage>();
        StartCoroutine(StartC());
    }
    IEnumerator StartC()
    {
        //Debug.Log(11);
        //等待用户允许访问
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        //如果用户允许访问，开始获取图像
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            //先获取设备
            WebCamDevice[] devices = WebCamTexture.devices;
            deviceName = devices[0].name;
            //然后获取图像
            camTexture = new WebCamTexture(deviceName, 2160, 3840, 30);
            //将获取的图像赋值
            rawimage.texture = camTexture;
            //开始实施获取
            camTexture.Play();

        }
    }
}
