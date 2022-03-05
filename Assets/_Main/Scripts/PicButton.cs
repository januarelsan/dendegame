using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicButton : MonoBehaviour
{
    [SerializeField]
    private Image image;

    private bool hasImage;

    private string filename;

    void Awake()
    {
        filename = "Image_" + gameObject.name;

        image.sprite = GalleryController.Instance.PickImage(filename);

        if (image.sprite != null)
            hasImage = true;

        image.gameObject.SetActive(hasImage);
    }

    public void Click()
    {
        if (!hasImage)
        {
            CameraController.Instance.TakePicture(this);
        }
        else
        {
            ImagePreviewController.Instance.ShowCurrentImagePreview(this, image.sprite);
        }
    }

    public void AcceptImage(Sprite sprite)
    {
        image.sprite = sprite;

        float aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
        var fitter = image.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;

        image.gameObject.SetActive(true);

        if (!hasImage)
        {
            //save to gallery
            GalleryController.Instance.SaveTexture(sprite.texture, filename);
            hasImage = true;
        }
    }

    public void SetRetake()
    {
        hasImage = false;
        Click();
    }

    public Image GetImage()
    {
        return image;
    }

    

}
