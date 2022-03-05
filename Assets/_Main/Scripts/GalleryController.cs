using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using System.IO;

public class GalleryController : Singleton<GalleryController>
{
    void Start(){
    }
    // Save the image to Gallery/Photos
    public void SaveTexture(Texture2D texture, string name)
    {
        string fileName = name + ".png";

        DeleteExistedImage(fileName);

        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(texture, "DendeImages", fileName, (success, path) => Debug.Log("Media save result: " + success + " " + path));

    }

    private void DeleteExistedImage(string filename){
        
        string path = "/storage/emulated/0/DCIM/DendeImages/" + filename;
        // string path = "C:/Users/janua/Pictures/januarelsan profil pic - Copy.png";
        Texture2D texture = NativeGallery.LoadImageAtPath(path);
        if (texture == null)
        {
            return;
        }

        File.Delete(path);

        Debug.Log("File Deleted");


    }

    public Sprite PickImage(string fileName)
    {
        string fullFileName = fileName + ".png";
        string path = "/storage/emulated/0/DCIM/DendeImages/" + fullFileName;
        Texture2D texture = NativeGallery.LoadImageAtPath(path);
        if (texture == null)
        {
            Debug.Log("Couldn't load texture from " + path);
            return null;
        }

        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);      

        return sprite;

    }
}

