using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanger : MonoBehaviour {

    float time=0;
  public   static bool isAwaken=true;
    
	// Update is called once per frame
    /// <summary>
    /// 设置待机
    /// </summary>
    
	void Update () {
        if (!isAwaken)
        {
            if (Input.GetMouseButtonDown(0))
            {
                time = 0;
            }
            time += Time.deltaTime;
           // Debug.Log(time);
            if (time > 30)
            {
                
                GetWebCamera.camTexture.Stop();
                isAwaken = true;
                SceneManager.LoadScene(0);
            
            }
        }
	}
}
