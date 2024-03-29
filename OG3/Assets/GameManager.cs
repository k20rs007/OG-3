using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int[] getimage = new int[6];

    public int[] getcontent = new int[6];
    public int storyindex;

    public int coin;

    //GameManager内変数
    string[] key = new string[6];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        coin = PlayerPrefs.GetInt("COIN", 0);
        indexload(getimage);
        //getimage[1] = PlayerPrefs.GetInt("key1", 0);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //ゲームが閉じる
    void OnApplicationQuit()
    {
        string coinkey = "COIN";
        PlayerPrefs.SetInt(coinkey, coin);
        PlayerPrefs.Save();

        indexsave(getimage);
        //PlayerPrefs.SetInt("key0", getimage[0]);
        PlayerPrefs.Save();
    }

    //配列セーブ
    void indexsave(int[]save)
    {
        key = new string[save.Length];
        for(int i = 0; i < save.Length;i++)
        {
            key[i] = "key" + i.ToString();
            PlayerPrefs.SetInt(key[i], save[i]);
            PlayerPrefs.Save();
        }
    }

    //配列ロード
    void indexload(int[]load)
    {
        for(int i = 0; i < load.Length;i++)
        {
            key[i] = "key" + i.ToString();
            getimage[i] = PlayerPrefs.GetInt(key[i], 0);
        }
    }
}
