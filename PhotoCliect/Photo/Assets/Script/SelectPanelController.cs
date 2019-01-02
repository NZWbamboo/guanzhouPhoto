using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SelectPanelController : MonoBehaviour
{
    public List<Transform> framePanelGroup;
    public static int Frameint = -1;
    private Transform frame;
    public Button lift, right;
    public bool AUTO=false;
    void Start()
    {
        lift = transform.Find("Lift").GetComponent<Button>();
        right = transform.Find("Right").GetComponent<Button>();
        //GameObject PHOTO = this.transform.Find("Photo").gameObject;
        //if (PHOTO)
        //{
        //    PHOTO.GetComponent<Button>().onClick.AddListener(Photo);
        //}
     
    }
    int index = 0;
    float time = 0;

    private void Update()
    {
        if (AUTO)
        {
            time += Time.deltaTime;
            if (time > 3)
            {
                Switch(1);
                time = 0;
            }
        }
       
    }
    /// <summary>
    /// 用于切换相框
    /// </summary>
    /// <param name="direction">1向左,-1向右</param>

    public void Switch(int direction)
    {
        SoundManager.instance.audioSource.Play();
        Transform farme = framePanelGroup[Mathf.Abs(index) % 4];
        lift.enabled = false;
        right.enabled = false;

       // DOTween.Kill("Out");
        Sequence tweening = DOTween.Sequence();
       tweening.Append( farme.DOLocalMoveX(1150 * direction, 0.4f).SetId("Out").SetEase(Ease.OutBack));

        switch (direction)
        {
            case 1:
                index++;
                farme = framePanelGroup[Mathf.Abs(index) % 4];
                farme.transform.localPosition = new Vector3(-1150, 0, 0);
                break;
            case -1:
                index--;
                farme = framePanelGroup[Mathf.Abs(index) % 4];
                farme.transform.localPosition = new Vector3(1150, 0, 0);
                break;
            default:
                break;
        }
        tweening.Append(farme.DOLocalMoveX(0, 0.5f).SetId("In").SetEase(Ease.OutBack));

        #region 前用代码
        // lift.enabled = false;
        //right.enabled = false;

        // DOTween.Kill("Out");
        // Sequence tweening = DOTween.Sequence();
        // //framePanelGroup[0].DOLocalMoveX(-300* direction, 0.2f);
        //  tweening.Append( framePanelGroup[0].DOLocalMoveX(1024 * direction, 0.3f).SetId("Out").SetEase(Ease.OutBack));
        // ///  framePanelGroup[0].DOLocalMoveX(1024* direction, 0.3f);//先移出
        // switch (direction)
        // {
        //     case 1:
        //         framePanelGroup.Add(framePanelGroup[0]);

        //         framePanelGroup.Remove(framePanelGroup[0]);

        //         framePanelGroup[0].transform.localPosition = new Vector3(-1024, 0, 0);
        //         break;
        //     case -1:
        //         framePanelGroup.Insert(0, framePanelGroup[framePanelGroup.Count - 1]);

        //         framePanelGroup.RemoveAt(framePanelGroup.Count - 1);

        //         framePanelGroup[0].transform.localPosition = new Vector3(1024, 0, 0);
        //         break;
        //     default:
        //         break;
        // }
        //  // Debug.Log(1);



        // tweening.Append(framePanelGroup[0].DOLocalMoveX(0, 0.5f).SetId("In").SetEase(Ease.OutBack));
        //再移入

        #endregion
        //设置按钮的等待时间
        Invoke("ButtonEnable", 0.7f);
    }
  //  开启按钮
    private void ButtonEnable()
    {
        lift.enabled = true;
        right.enabled = true;
    }
    //选择相框
    public  void Photo()
    {
        SoundManager.instance.audioSource.Play();
        frame = transform.root.Find("PhotoPanel").transform.Find("Frame");
        frame.GetComponent<Animator>().SetTrigger(Mathf.Abs(index%4).ToString());
        Destroy(this.gameObject);

    }

}
