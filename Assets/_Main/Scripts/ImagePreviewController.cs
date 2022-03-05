using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePreviewController : Singleton<ImagePreviewController>
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Image mainImage;

    private PicButton targetPicButton;

    public void ShowNewImagePreview(PicButton picButton, Sprite sprite)
    {
        targetPicButton = picButton;

        panel.SetActive(true);
        mainImage.sprite = sprite;

        float aspectRatio = mainImage.sprite.rect.width / mainImage.sprite.rect.height;
        var fitter = mainImage.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;

    }

    public void ShowCurrentImagePreview(PicButton picButton, Sprite sprite)
    {
        targetPicButton = picButton;

        panel.SetActive(true);
        mainImage.sprite = sprite;

        float aspectRatio = mainImage.sprite.rect.width / mainImage.sprite.rect.height;
        var fitter = mainImage.GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = aspectRatio;

    }

    public void Retake(){
        panel.SetActive(false);
        targetPicButton.SetRetake();
    }

    public void AcceptImage(){
        Debug.Log("Accept Image");
        targetPicButton.AcceptImage(mainImage.sprite);
        panel.SetActive(false);
    }
}
