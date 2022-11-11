using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Save : MonoBehaviour
{

	public GameObject Panel;
	public GameObject Panel2;
	public void SavePhoto()
	{
		StartCoroutine(TakeScreenshot());
	}

	private IEnumerator TakeScreenshot()
	{
		Panel.SetActive(false);
		Panel2.SetActive(true);
		yield return new WaitForSeconds(1);
		yield return new WaitForEndOfFrame();

		Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();


		string filePath = Path.Combine(Application.temporaryCachePath, "FotoFIT2022.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());


		NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(ss, "GalleryFotoFit", "FotoFIT2022.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));





		// To avoid memory leaks
		Destroy(ss);
		yield return new WaitForSeconds(1);
		Panel.SetActive(true);
		Panel2.SetActive(false);
	}

}


