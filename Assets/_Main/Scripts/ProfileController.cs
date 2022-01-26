using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileController : MonoBehaviour
{
    [SerializeField] private InputField nameInputField;
    [SerializeField] private InputField ageInputField;
    [SerializeField] private Toggle boyToggle;
    [SerializeField] private Toggle girlToggle;
    [SerializeField] private GameObject profilePanel;

    public void SaveProfile()
    {
        PlayerPrefs.SetString("ProfileName", nameInputField.text);
        PlayerPrefs.SetString("ProfileAge", ageInputField.text);

        if (boyToggle.isOn)
        {
            PlayerPrefs.SetString("ProfileGender", "boy");
        }
        else
        {
            PlayerPrefs.SetString("ProfileGender", "girl");
        }

        PlayerPrefs.SetInt("ProfileFilled", 1);

    }

    public void LoadProfileData()
    {
        if (PlayerPrefs.GetInt("ProfileFilled") == 1)
        {
            nameInputField.text = PlayerPrefs.GetString("ProfileName");
            ageInputField.text = PlayerPrefs.GetString("ProfileAge");

            if (PlayerPrefs.GetString("ProfileGender") == "boy")
            {
                boyToggle.isOn = true;
            }
            else
            {
                girlToggle.isOn = true;
            }
        }
    }

    public void CheckProfileFilled()
    {
        if (PlayerPrefs.GetInt("ProfileFilled") == 0)
        {
            profilePanel.SetActive(true);
        }
        else
        {
            SceneController.Instance.GoToScene("MissionSelect");
        }
    }
}
