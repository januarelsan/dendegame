using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite[] buttonSprites;    

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("AudioIsOn"))
        {
            PlayerPrefs.SetInt("AudioIsOn",1);
        }

        if(buttonImage != null)
            buttonImage.sprite = buttonSprites[PlayerPrefs.GetInt("AudioIsOn")];

        AudioListener.volume = PlayerPrefs.GetInt("AudioIsOn");
        
    }

    public void ChangeAudioIsOn(){
        if(PlayerPrefs.GetInt("AudioIsOn") == 1){
            PlayerPrefs.SetInt("AudioIsOn",0);
        } else {
            PlayerPrefs.SetInt("AudioIsOn",1);
        }

        if(buttonImage != null)
            buttonImage.sprite = buttonSprites[PlayerPrefs.GetInt("AudioIsOn")];

        AudioListener.volume = PlayerPrefs.GetInt("AudioIsOn");
    }
}
