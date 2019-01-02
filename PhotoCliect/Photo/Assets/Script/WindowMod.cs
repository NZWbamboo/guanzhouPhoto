using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Xml;

public class WindowMod : MonoBehaviour
{
    int pX, pY, sX, sY, Y;
    public Rect screenPosition;
    [DllImport("user32.dll")]
    static extern IntPtr SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);
    [DllImport("user32.dll")]
    static extern bool SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
    [DllImport("user32.dll")]
    static extern IntPtr GetActiveWindow();
    const int SWP_SHOWWINDOW = 0x0040;
    const int GWL_STYLE = -16;
    const int WS_BORDER = 1;
    const int WS_POPUP = 0x800000;
    const int HWND_TOPMOST = -1;
    IntPtr T;

    GameObject Manager;
    //config
    XmlDocument xDoc;
    XmlNode nodes;


    void Start()
    {
        xDoc = new XmlDocument();
        xDoc.Load(Application.dataPath + "/Config/Screen.xml");
        nodes = xDoc.FirstChild;
        foreach (XmlNode node in nodes.ChildNodes)
        {
            if (node.Name == "width")
            {
                sX = Int32.Parse(node.InnerText);
            }
            if (node.Name == "height")
            {
                sY = Int32.Parse(node.InnerText);
            }
            if (node.Name == "position_X")
            {
                pX = Int32.Parse(node.InnerText);
            }
            if (node.Name == "position_Y")
            {
                pY = Int32.Parse(node.InnerText);
            }
            if (node.Name == "out")
            {
                Y = Int32.Parse(node.InnerText);
            }
        }

        //		pX = 0;
        //		pY = 0;
        //		sX = 1366;
        //		sY = 768;
        T = GetActiveWindow();
        SetWindowLong(GetActiveWindow(), GWL_STYLE, WS_BORDER);
        bool result = SetWindowPos(GetActiveWindow(), HWND_TOPMOST, (int)screenPosition.x, (int)screenPosition.y + Y, (int)screenPosition.width + sX, (int)screenPosition.height + sY, SWP_SHOWWINDOW);
		StartCoroutine (WaitScreenIn());
	}

    
    public void ScreenIn()
    {
        SetWindowLong(T, GWL_STYLE, WS_BORDER);
        bool result = SetWindowPos(T, HWND_TOPMOST, (int)screenPosition.x + pX, (int)screenPosition.y + pY, (int)screenPosition.width + sX, (int)screenPosition.height + sY, SWP_SHOWWINDOW);
       
    }
    public void ScreenOut()
    {
        SetWindowLong(T, GWL_STYLE, WS_BORDER);
        bool result = SetWindowPos(T, HWND_TOPMOST, (int)screenPosition.x, (int)screenPosition.y + Y, (int)screenPosition.width + sX, (int)screenPosition.height + sY, SWP_SHOWWINDOW);
       
    }


	IEnumerator WaitScreenIn()
	{
		yield return new WaitForSeconds (2f);
		ScreenIn ();
	}
}



