//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Drawing.Printing;
//using System.Drawing;
//using System.IO;

//public class Print : MonoBehaviour {

//   // public CutBackStart cbs;
//    public Stream stream;
//	//public NumControl nc;
//	//public SelectNum sn;
//    public GameObject cam;
//    // Use this for initialization
//    void Start () {
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//	private void printDocument1_PrintPage(object sender, PrintPageEventArgs evt)
//	{
//		System.Drawing.Image layoutImage = System.Drawing.Image.FromStream(stream);
//		Rectangle destRect = new Rectangle(18, 12, 555, 375);
//		evt.Graphics.DrawImage(layoutImage, destRect, 0,0, layoutImage.Width, layoutImage.Height, System.Drawing.GraphicsUnit.Pixel);
//	}

//	public void printBtnClick()
//	{
//		PrintDocument printDocument = new PrintDocument();
//		printDocument.DefaultPageSettings.PaperSize = new PaperSize ("paper", 555,375);
//        printDocument.PrinterSettings.PrinterName = "Canon SELPHY CP1200 MS";
//        //printDocument.PrinterSettings.PrinterName = "EPSON Stylus photo R330";
//        //printDocument.PrinterSettings.PrinterName = "EPSON L310 Series";
//        printDocument.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
//		printDocument.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
//		printDocument.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
//		printDocument.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
//		printDocument.PrintPage += printDocument1_PrintPage;
//		try
//		{
//			printDocument.Print();
//		}
//		catch (InvalidPrinterException)
//		{
//			Debug.Log("1");
//		}
//		finally
//		{
//			printDocument.Dispose();
//		}
//		Back ();
//	}

//	public void Back()
//	{
//		nc.InitNum ();
//		sn.InitNum ();
//        CutBackStart.index = 30;
//        GameControl._instance.gamestate = GameState.Check;
//        //GameControl._instance.gamestate = GameState.Begin;
//    }

//    public void GotoCheck()
//    {
//        nc.InitNum();
//        sn.InitNum();
//        CutBackStart.index = 30;
//        GameControl._instance.gamestate = GameState.Select;
//        if (!cam.activeSelf)
//        {
//            cam.SetActive(true);
//        }
//    }
//}
