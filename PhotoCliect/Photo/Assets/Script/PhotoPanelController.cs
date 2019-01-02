using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using DG.Tweening;

public class PhotoPanelController : MonoBehaviour
{
    public GameObject time;
    public GameObject whiteScreen;
    // Use this for initialization
    private Transform PhotoBut;
    void Start()
    {
        PhotoBut = this.transform.Find("PhotoBut");
        PhotoBut.GetComponent<Button>().onClick.AddListener(PhotoButS);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("拍照");
            PhotoButS();
        }
    }
    void PhotoButS()
    {
        StartCoroutine(UploadPNG());
        PhotoBut.gameObject.SetActive(false);
        time.SetActive(true);
    }
    private Texture2D t2;
    JPGEncoder encoder;
    
    IEnumerator UploadPNG()
    {
        yield return new WaitForSeconds(4.2f);
        //   DestroyImmediate(time);
        time.SetActive(false);
        yield return new WaitForEndOfFrame();

        int width = Screen.width;
        int height = Screen.height;
        t2 = new Texture2D((int)(width), (int)(height - 300), TextureFormat.RGB24, false);//要保存图片的大小

        t2.ReadPixels(new Rect((int)(0), (int)(300), (int)width, (int)(height - 300)), 0, 0, false);
        t2.Apply();
        encoder = new JPGEncoder(t2, 50);//将纹理格式转成encoder格式
        encoder.doEncoding();//对纹理进行编码
        byte[] byt = t2.EncodeToJPG();
        GameObject EndPanel = Resources.Load<GameObject>("UIPrefabs/EndPanel");
        GameObject End = Instantiate<GameObject>(EndPanel, this.transform.parent);
        End.transform.Find("PhotoPic").GetComponent<Image>().sprite = Sprite.Create(t2, new Rect(0, 0, (int)width, (int)(height - 300)), new Vector2(0, 0));

        End.transform.Find("PhotoPic").DOScale(new Vector2(0.5f, 0.5f), 0.5f);
        up = GameObject.Find("UPorLoad").GetComponent<UpLoadPhoto>();
        up.img = End.transform.Find("Code").GetComponent<Image>();
        UpPhoto();
       // whiteScreen.SetActive(true);
       // Destroy(whiteScreen, 0.5f);
        yield return new WaitForSeconds(0.5f);
        End.SetActive(true);
        //    GetWebCamera.camTexture.Stop();
        //this.gameObject.SetActive(false);
        // Destroy(gameObject);
        ResetPhotoPage();
    }
    void ResetPhotoPage()
    {
        PhotoBut.gameObject.SetActive(true);
        // time.SetActive(true);
    }
    public UpLoadPhoto up;

    public void UpPhoto()
    {
        up.bytes = encoder.GetBytes();
        up.ShowQR();
    }

}
