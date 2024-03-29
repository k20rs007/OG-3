﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NamecompleteButtonScript : MonoBehaviour
{
    public InputField _inputName;
    public String heroineName;
    [SerializeField] GameObject InputNamePanel;
    [SerializeField] GameObject LoadingPanel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("NAMEINPUT", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClicked_NamecompleteButton()
    {
        LoadingPanel.SetActive(true);
        heroineName = _inputName.text;
        //Debug.Log(heroineName);
        
        PlayerPrefs.SetString("INPUTNAME", heroineName);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main scene");
    }
}
