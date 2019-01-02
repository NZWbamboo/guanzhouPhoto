using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{

    // Use this for initialization
    Button Print, Exit, restart;
    Transform TipPage;
    UpLoadPhoto loadPhoto;
    void Start()
    {
        Print = transform.Find("Print").GetComponent<Button>();
        Exit = transform.Find("Exit").GetComponent<Button>();
        restart = transform.Find("restart").GetComponent<Button>();
        loadPhoto = GameObject.Find("UPorLoad").GetComponent<UpLoadPhoto>();
        TipPage = transform.Find("TipPage");
        Print.onClick.AddListener(PrintBut);
        Exit.onClick.AddListener(ExitBut);
        restart.onClick.AddListener(restartBut);
        // PhotoPic = transform.Find("PhotoPic");
    }
    void PrintBut()
    {
       // SoundManager.instance.audioSource.Play();
        TipPage.gameObject.SetActive(true);
        Print.enabled = false;
        StartCoroutine(loadPhoto.UpLoadPrint());
    }
    void ExitBut()
    {
        StartCoroutine(loadSence());
       
    }
    IEnumerator loadSence()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);
    }
    void restartBut()
    {
      
        GameObject PhotoPanel = Resources.Load<GameObject>("GZPrefabs/PhotoPanel");

        Instantiate<GameObject>(PhotoPanel, transform.parent).name = "PhotoPane";

        Destroy(this.gameObject);
    }


}
