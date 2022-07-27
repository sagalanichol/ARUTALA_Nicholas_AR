using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class ShareOnSocialMedia : MonoBehaviour
{
	string path = Path.Combine (Directory.GetCurrentDirectory(), "ARUTALA.png");

	public void Share ()
	{
		new NativeShare ()
			.AddFile (path)
			.SetSubject ("ARUTALA Logo")
			.SetText ("Result of screenshot from ARUTALA_Nicholas_AR")
			.Share ();
	}

    public void Screenshot()
    {
        ScreenCapture.CaptureScreenshot(path);
    }
}
