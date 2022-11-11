using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    public RawImage m_RawImage;


    public void TakeAndSavePhoto()
    {
        TakePicture(1080);
    }

    private void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
                m_RawImage.GetComponent<RawImage>().texture = texture;

                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }    
                    SavePhotoGallery(texture);
            }
        }, maxSize);
        Debug.Log("Permission result: " + permission);
    }


    private static void SavePhotoGallery(Texture2D texture)
    {
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery
        (texture, "GalleryFotoInicial", "FotoUsuario.png", (success, path) => Debug.Log("Media save result: " + success + " " + path));

        Debug.Log("Permission result: " + permission);
    }
}

