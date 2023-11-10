using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save_newScript : MonoBehaviour
{
    [SerializeField] GameObject[] savebuttons = new GameObject[4];

    String[] heroinname = new string[4];
    int[] storynum = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < heroinname.Length;i++)
        {
            heroinname[i] = PlayerPrefs.GetString("heroin" + i);
            storynum[i] = PlayerPrefs.GetInt("storynum" + i);
            savebuttons[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = "��l���̖��O�F" + heroinname[i] + "�X�g�[���[�ԍ��F" + storynum[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("��O�̃V�[���F" + GameManager.instance.beforescene);
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

    public void onClicked_savebutton(int number)
    {
        if (GameManager.instance.beforescene == 1)
        {
            //�Z�[�u����
            PlayerPrefs.SetString("heroin" + number, GameManager.instance.heroinename);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("storynum" + number, GameManager.instance.storynum);
            PlayerPrefs.Save();
            savebuttons[number].transform.GetChild(0).gameObject.GetComponent<Text>().text = "��l���̖��O�F" + GameManager.instance.heroinename + "�X�g�[���[�ԍ��F" + GameManager.instance.storynum;
            Time.timeScale = 1;
            //Debug.Log("�Z�[�u�F��l���̖��O�F" + GameManager.instance.heroinename + "�X�g�[���[�ԍ��F" + GameManager.instance.storynum + "��O�̃V�[���F" + GameManager.instance.beforescene);
        } else
        {
            GameManager.instance.heroinename = heroinname[number];
            GameManager.instance.storynum = storynum[number];
            if(GameManager.instance.storynum != 0)
            {
                SceneManager.LoadScene("Mainscene_new");
            }
            Time.timeScale = 1;
            Debug.Log("���[�h�F��l���̖��O�F" + GameManager.instance.heroinename + "�X�g�[���[�ԍ��F" + GameManager.instance.storynum + "��O�̃V�[���F" + GameManager.instance.beforescene);
        }
    }

}
