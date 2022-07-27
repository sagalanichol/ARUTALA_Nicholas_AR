using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class ShareOnSocialMedia : MonoBehaviour
{
    public Text infoText;

    public void ShotShare()
    {
        StartCoroutine(TakeScreenshotAndShare());
    }

    private IEnumerator TakeScreenshotAndShare()
    {
        infoText.text = "Screenshot on going!";
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "Arutala AR.png");
        File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

        new NativeShare().AddFile(filePath)
            .SetSubject("ARUTALA Logo.").SetText("Hello, this is my ARUTALA Logo.")
            .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
            .Share();
        infoText.text = "Screenshot success!";
    }

    public void Start()
    {
        infoText.text = "Please scan image target!";
    }

    public void OnTargetFound()
    {
        infoText.text = "Image target found!";
    }

    public void OnARDisplayed()
    {
        infoText.text = "AR Displayed!";
    }

    public void ExitAPP()
    {
        infoText.text = "Exiting Application!";
        Application.Quit();
    }
}
