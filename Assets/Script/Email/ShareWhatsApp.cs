using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;

public class ShareWhatsApp : MonoBehaviour
{
	public Button shareButton;
	private string packageName = "com.whatsapp";
	private bool isFocus = false;
	private bool isProcessing = false;
	public Text mobilNumber;
	String mobileNumber;
	public string AttachmentFilename = "Screenshot.jpg";

	void Start()
	{
		shareButton.onClick.AddListener(ShareText);
	}

	void OnApplicationFocus(bool focus)
	{
		isFocus = focus;
	}

	private void ShareText()
	{

#if UNITY_ANDROID
		if (!isProcessing)
		{
			if (CheckIfAppInstalled())
			{
				StartCoroutine(ShareTextToWhatsContact());
			}
		}
#else
		Debug.Log("No sharing set up for this platform.");
#endif
	}

	private bool CheckIfAppInstalled()
	{

#if UNITY_ANDROID

		AndroidJavaClass unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		AndroidJavaObject context = unityActivity.GetStatic<AndroidJavaObject>("currentActivity");

		AndroidJavaObject packageManager = context.Call<AndroidJavaObject>("getPackageManager");

		AndroidJavaObject appsList = packageManager.Call<AndroidJavaObject>("getInstalledPackages", 1);

		int size = appsList.Call<int>("size");

		for (int i = 0; i < size; i++)
		{
			AndroidJavaObject appInfo = appsList.Call<AndroidJavaObject>("get", i);
			string packageNew = appInfo.Get<string>("packageName");

			if (packageNew.CompareTo(packageName) == 0)
			{
				return true;
			}
		}

		return false;

#endif
	}

#if UNITY_ANDROID
	public IEnumerator ShareTextToWhatsContact()
	{

		isProcessing = true;

		if (!Application.isEditor)
		{
			//var url = "https://api.whatsapp.com/send?phone=" + mobilNumber.text;
			mobileNumber = mobilNumber.text;

			string filePath = Path.Combine(Application.temporaryCachePath, "FotoFIT2022.png");
			new NativeShare().AddFile(filePath)

		.SetSubject("Subject goes here").SetText(" " )
		.SetUrl("https://api.whatsapp.com/send?phone=" + mobilNumber.text)
				.SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
		.Share();
			if (NativeShare.TargetExists("com.whatsapp"))
				new NativeShare().AddFile(filePath).AddTarget("com.whatsapp").Share();
		}

		yield return new WaitUntil(() => isFocus);
		isProcessing = false;
	}

#endif
}