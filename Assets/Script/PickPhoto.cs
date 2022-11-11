using UnityEngine;
using UnityEngine.UI;

public class PickPhoto : MonoBehaviour
{
	public RawImage m_RawImage;



	public void OpenWithChroma()
	{
		NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
		{
			Debug.Log("Image path: " + path);
			if (path != null)
			{
				Texture2D texture = NativeGallery.LoadImageAtPath(path);

				m_RawImage.GetComponent<RawImage>().texture = texture;

				if (texture == null)
				{
					Debug.Log("Couldn't load texture from " + path);
					return;
				}
			}
		});
	}
}

