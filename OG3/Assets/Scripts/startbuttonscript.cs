﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startbuttonscript: MonoBehaviour
{
    [SerializeField] GameObject InputNamePanel;
    // Start is called before the first frame update
    void Start()
    {
        InputNamePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClicked_startButton()
    {
        InputNamePanel.SetActive(true);
        PlayerPrefs.SetInt("NUMBERLOAD", 0);
        PlayerPrefs.Save();
    }
}