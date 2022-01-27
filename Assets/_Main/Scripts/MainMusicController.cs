using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicController : MonoBehaviour
{
    private static MainMusicController musicInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (musicInstance == null)
        {
            musicInstance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
}
