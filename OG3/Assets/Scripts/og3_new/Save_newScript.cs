using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save_newScript : MonoBehaviour
{
    [SerializeField] GameObject[] savebuttons = new GameObject[8];
    bool[] savenum = new bool[8];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("��l���̖��O�F" + GameManager.instance.heroinename + "�X�g�[���[�ԍ��F" + GameManager.instance.storynum + "��O�̃V�[���F" + GameManager.instance.beforescene);
    }

    public void onClicked_closebutton()
    {
        GameManager.instance.beforescene = 2;
        SceneManager.LoadScene("startscene_new");
    }

    
    public void onClicked_returnbutton()
    {
        GameManager.instance.beforescene = 2;
    }

    
}
