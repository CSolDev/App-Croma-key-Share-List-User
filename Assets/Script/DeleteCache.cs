using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCache : MonoBehaviour
{
    private void Start()
    {
        DeletCache();

    }
    public static void DeletCache()
    {
        string path = Application.temporaryCachePath;

        System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);

        foreach (System.IO.FileInfo file in di.GetFiles())
        {
            file.Delete();
        }

        foreach (System.IO.DirectoryInfo dir in di.GetDirectories())
        {
            dir.Delete(true);
        }
    }

}
