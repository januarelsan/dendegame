using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Image[] images;

    private int capturedImageIndex;
    public void TakePicture()
    {
        int maxSize = 512;

        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
       {
           Debug.Log("Image path: " + path);
           if (path != null)
           {
            // Create a Texture2D from the captured image
            Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize);
               if (texture == null)
               {
                   Debug.Log("Couldn't load texture from " + path);
                   return;
               }

            Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);            

            images[capturedImageIndex].sprite = sprite;
            // capturedImageIndex++;

            // If a procedural texture is not destroyed manually, 
            // it will only be freed after a scene change
            Destroy(texture, 5f);
           }
       }, maxSize);

        Debug.Log("Permission result: " + permission);
    }
}
