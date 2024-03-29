﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Qdata;

public class Story : MonoBehaviour
{
    private Text _story; //ストーリーテキスト
    private Text _name;
    private Text _inputName;
    private Text _monthtext;
    private Text _logtext;
    public Text _selectbuttontext3;
    public Text _selectbuttontext1;
    public Text _selectbuttontext2;
    private AudioSource Soundbgm; //bgm
    public GameObject charactercenter;
    public GameObject characterright;
    public GameObject characterleft;
    public GameObject background;
    public GameObject textbox;
    public GameObject still;
    public GameObject month;
    public GameObject monthtxtback;
    public Sprite clearSprite;
    public Sprite ouziSprite;
    public Sprite rukiaSprite;
    public Sprite hikaruSprite;
    public Sprite ouziojiSprite;
    public Sprite rukiaojiSprite;
    public Sprite hikaruojiSprite;
    public Sprite ouzismileSprite;
    public Sprite hikarutroubleSprite;
    public Sprite ouziojismileSprite;
    public Sprite ouziojiangrySprite;
    public Sprite ouziojitroubleSprite;
    public Sprite ouziojithink_openSprite;
    public Sprite ouziojithink_closeSprite;
    public Sprite ouziojishockSprite;
    public Sprite rukiatroubleSprite;
    public Sprite rukiaojismileSprite;
    public Sprite statueSprite;
    //背景
    public Sprite back_classroomSprite;
    public Sprite back_corridorSprite;
    public Sprite back_stairsSprite;
    public Sprite back_gardenSprite;
    public Sprite back_schoolSprite;
    public Sprite back_dispensarySprite;
    public Sprite back_gymSprite;
    public Sprite back_seaSprite;
    public Sprite back_ground_noonSprite;
    public Sprite back_ground_eveningSprite;
    public Sprite back_shoploadSprite;
    public Sprite back_fancyshopSprite;
    public Sprite back_cafeSprite;
    public Sprite back_heroineroom_noonSprite;
    public Sprite back_heroineroom_nightSprite;
    public Sprite back_garageSprite;
    public Sprite back_classroom_afternoonSprite;
    public Sprite back_garden_afternoonSprite;
    public Sprite back_myroom_midnightSprite;
    public Sprite back_myroom_morningSprite;
    public Sprite back_myroom_nightSprite;
    public Sprite blackSprite;

    //スチル
    public Sprite still_clearSprite;
    public Sprite still_AprilSprite;
    public Sprite still_May_hikaruSprite;
    public Sprite still_June_ouziSprite;
    public Sprite still_July_rukiaSprite;
    public Sprite still_July_ouziSprite;
    public Sprite still_July_hikaruSprite;
    public Sprite still_August_hikaruSprite;
    public Sprite still_August_ouziSprite;
    //月
    public Sprite month_clearSprite;
    public Sprite month_MaySprite;
    public Sprite month_JuneSprite;
    public Sprite month_JulySprite;
    public Sprite month_AugustSprite;
    public Sprite month_SeptemberSprite;
    public Sprite month_OctoberSprite;
    public Sprite month_NovemberSprite;
    public Sprite month_DecemberSprite;
    public Sprite month_JanuarySprite;
    public Sprite month_FebruarySprite;

    //名前の色
    public Sprite text_own;
    public Sprite text_ouzi;
    public Sprite text_hikaru;
    public Sprite text_rukia;
    public Sprite text_mob;
    public Sprite text_monologue; //心の声

    //選択ボタンの色
    public Sprite select_now;
    public Sprite select_not;


    public string moveanimationsr;
    private string centersr;
    private string rightsr;
    private string leftsr;
    private string backsr;
    private string stillsr;
    private string colorsr;
    private string bgm_state_sr;
    private string bgm_num_sr;
    private string se_num_sr;
    private string selectdisp_sr;
    private string selectbutton_num_sr;
    private string monthsr;
    private string textcolorsr;
    private string animationsr;
    private String heroineName;
    private String logheroineName;
    //private String characternamelength;
    private String logcharacterName;
    //private String logstory;

    public int story_num_csv = 0;

    public static int selectpanelState;
    public static int index_read; //読み取り用
    public static int index_skip; //skip用

    public static int startscene; //スタート画面の画像切り替え、ミニゲームボタン用

    public AudioClip bgm1; //ikemen_theme
    public AudioClip bgm2; //dark
    public AudioClip bgm3; //shock
    public AudioClip bgm4; //cafe
    public AudioClip bgm5; //street
    public AudioClip bgm6; //fancyshop
    public AudioClip bgm7; //room

    public AudioClip[] cv;
    public AudioClip se1;
    public AudioClip Jingle;
    public AudioClip se2;

    AudioSource[] sounds;

    GameObject _Screenbutton;//button
    public TextAsset storyText; //csvストーリーデータ
    private string _storyArray;
    private List<Qdata> _qdataList = new List<Qdata>();

    //logのcsv用
    public TextAsset logstoryText; //csvlogstorytextデータ
    private string _logstoryArray;
    private List<Logdata> _logdataList = new List<Logdata>();
    int logNum = 0; //story数
    //int logtextprintcount = 0;
    public string logspace = "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0" + "\u00A0";
    //log用終わり


    public int qstory = 0; //storyの番号
    public int qNum = 0; //story数
    public int savenum = 0;
    public int menucount = 0;
    public int nameinput = 0;
    public static int automode = 0;
    public float novelSpeed; //表示の速さ
    private int click = 0;
    public int messageCount = 0;

    public float sevolume;
    public float bgmvolume;
    static int seMutecount = 0;
    static int bgmMutecount = 0;

    [SerializeField] GameObject ScreenButton;
    [SerializeField] GameObject SelectButtonPanel;
    [SerializeField] GameObject logPanel;
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject cannotskipAlertPanel;
    [SerializeField] GameObject LoadingPanel;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject Selectbutton_1;
    [SerializeField] GameObject Selectbutton_2;
    [SerializeField] GameObject SelectButton_3;
    [SerializeField] GameObject menubutton;
    [SerializeField] GameObject monthtext;
    [SerializeField] GameObject monthTextPanel;
    [SerializeField] GameObject movePanel;

    [SerializeField] GameObject[]autosetbutton = new GameObject[5];

    [SerializeField] GameObject[]textsetbutton = new GameObject[5];

    [SerializeField] GameObject[]sesetbutton = new GameObject[5];

    [SerializeField] GameObject[]bgmsetbutton = new GameObject[5];

    public Sprite settingbuttonimg;

    private int selected = 0;

    private int ouzi_point = 0;
    private int hikaru_point = 0;
    private int rukia_point = 0;

    //private bool stopStorybool = false;

    //設定画面
    public Image speedslide;
    static float speedbar_x;
    public Image seslide;
    public Image bgmslide;
    public Vector2 MousePos;
    public Canvas canvas;
    public RectTransform canvasRect;
    static int novelspeedcount = 4;
    static int sevolumecount = 4;
    static int bgmvolumecount = 4;
    static int autospeedcount = 4;
    public Image autoslide;
    static float autoslidebar_x;
    float time;
    bool autoclick;


    private bool storystop = false;

    // Start is called before the first frame update
    void Start()
    {

        //設定画面用
        //speedslide = GameObject.Find("slideonimage").GetComponent<Image>();
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();

        if (startscene == 1)
        {
            //スタート画面の切り替え
            PlayerPrefs.SetInt("START", 1);
            PlayerPrefs.Save();
        }
        else
        {
            //スタート画面の切り替え
            PlayerPrefs.SetInt("START", 0);
            PlayerPrefs.Save();
        }


        //BGM初期状態
        sounds = GetComponents<AudioSource>();
        bgmvolume = 0.7f;
        sevolume = 0.7f;
        sounds[0].volume = bgmvolume;
        sounds[1].volume = sevolume;
        sounds[0].clip = bgm1;
        sounds[0].Play();

        //選択肢パネル非表示
        SelectButtonPanel.SetActive(false);

        logPanel.SetActive(true);

        _story = GameObject.Find("MainText").GetComponent<Text>();
        _name = GameObject.Find("NameText").GetComponent<Text>();
        _monthtext = GameObject.Find("monthtext").GetComponent<Text>();
        _logtext = GameObject.Find("logtext").GetComponent<Text>();

        //logパネル非表示
        logPanel.SetActive(false);

        //_inputName = GameObject.Find("InputField").GetComponent<Text>();
        _Screenbutton = GameObject.Find("Screenbutton");

        PlayerPrefs.SetInt("SAVE", 0);
        PlayerPrefs.Save();

        qstory = PlayerPrefs.GetInt("NUMBERLOAD");
        nameinput = PlayerPrefs.GetInt("NAMEINPUT");
        
        if(nameinput == 0)
        {
            heroineName = PlayerPrefs.GetString("INPUTNAME");
            //Debug.Log("名前" + heroineName);
        } else
        {
            heroineName = PlayerPrefs.GetString("INPUTNAME2");
            //Debug.Log("名前だよ" + heroineName);
        }

        heroineName = PlayerPrefs.GetString("INPUTNAME");
        logheroineName = heroineName;
        int namelength = System.Text.Encoding.GetEncoding(932).GetByteCount(heroineName);
        //Debug.Log(heroineName);
        if(namelength != 12)
        {
            int spacecount = 12 - namelength;
            for (int i = 0; i < spacecount; i++)
            {
                logheroineName += "\u00A0";
            }
            //Debug.Log(logheroineName);
        }

        //csvファイルからテキストを読み込み
        _storyArray = storyText.text.Replace(" ", "\u00A0");
        _storyArray = storyText.text.Replace("@", heroineName);
        StringReader sr = new StringReader(_storyArray);
        sr.ReadLine();
        while (sr.Peek() > -1)
        {
            string line = sr.ReadLine();
            _qdataList.Add(new Qdata(line));
            qNum++;           
        }
        //print("A");
          //最初のストーリーをセット
        //確認のためにConsoleに出力
        foreach (Qdata q in _qdataList)
        {
            q.WriteDebugLog();
        }

        //log用
        //log用のcsvファイルからテキストを読み込み
        _logstoryArray = logstoryText.text.Replace(" ", "");
        //_logstoryArray = logstoryText.text.Replace("?", "\u0030");
        StringReader logr = new StringReader(_logstoryArray);
        logr.ReadLine();
        while (logr.Peek() > -1)
        {
            string line = logr.ReadLine();
            _logdataList.Add(new Logdata(line));
            logNum++;
        }
        foreach (Logdata q in _logdataList)
        {
            //q.WriteDebugLog_logstory();
        }
        //

        StartCoroutine(Novel(qstory++));




    }

    private IEnumerator Novel(int index)
    {
        //Debug.Log("index:" + index + " , index_read:" + index_read + " , index_skip:" + index_skip + " , qstory:" + qstory + "ouzi_point: " + ouzi_point + "hikaru_point: " + hikaru_point + "rukia_point: " + rukia_point);
        PlayerPrefs.SetString("MOVETEXT", _qdataList[index].moveanimation);
        PlayerPrefs.Save();
        Debug.Log(automode);

        //skip用
        index_read = index;

        //文化祭で選んだキャラクター
        int character_schoolfestival = 0; //おうじ:1　ひかる:2　るきあ:3

        if(startbuttonscript.start == true)
        {
            index = 0;
            index_read = 0;
            index_skip = 0;
            startbuttonscript.start = false;
        }
        //index_skip = index_read;
        //qstory = index + 1;

        if (SkipselectPanelScript.clicked_skip == true) {
            if(SkipselectPanelScript.first == true)
            {
                LoadingPanel.SetActive(false);
                index_read = index;
                index = index_skip;
                qstory = index_skip;
                SkipselectPanelScript.first = false;
            }
            else if(SkipselectPanelScript.first == false)
            {
                index_skip++;
                qstory = index_skip;
                index = index_skip;
                index_read = index;
            }
        }

        //選択肢で飛んだ先から次の話に飛ぶところまとめ
        if (index == 96 && selected == 1) //ひかる買い物からおうじ誕プレへ飛ぶ
        {
            index_read = index;
            index_skip = 103-1;
            qstory = index_skip;
            index = index_skip;
        }

        if (index == 126 && selected == 3) //おうじ誕プレから６月へ飛ぶ
        {
            index_read = index;
            index_skip = 142-1;
            qstory = index_skip;
            index = index_skip;
        }
        if (index == 134 && selected == 1) //おうじ誕プレから６月へ飛ぶ
        {
            index_read = index;
            index_skip = 142-1;
            qstory = index_skip;
            index = index_skip;
        }
        if (index == 186 && selected == 1) //おうじパンケーキから７月へ飛ぶ
        {
            index_read = index;
            index_skip = 191-1;
            qstory = index_skip;
            index = index_skip;
        }
        if(index == 318 && !(ouzi_point < 3) && ouzi_point > 0) //おうじOK
        {
            index_read = index;
            index_skip = 401 - 1;
            qstory = index_skip;
            index = index_skip;
            character_schoolfestival = 1;
            //stopStorybool = true;
            //yield break;
        }
        if (index == 323 && ouzi_point < 3 && ouzi_point > 0) //おうじBAD
        {
            index_read = index;
            index_skip = 401 - 1;
            qstory = index_skip;
            index = index_skip;
            character_schoolfestival = 1;
            //stopStorybool = true;
            //yield break;
        }
        if (index == 355 && !(hikaru_point < 3) && hikaru_point > 0) //ひかるOK
        {
            index_read = index;
            index_skip = 401 - 1;
            qstory = index_skip;
            index = index_skip;
            character_schoolfestival = 2;
            //stopStorybool = true;
            //yield break;
        }
        if (index == 363 && hikaru_point < 3 && hikaru_point > 0) //ひかるBAD
        {
            index_read = index;
            index_skip = 401 - 1;
            qstory = index_skip;
            index = index_skip;
            character_schoolfestival = 2;
            //stopStorybool = true;
            //yield break;
        }
        if (index == 391 && !(rukia_point < 3) && rukia_point > 0) //るきあOK
        {
            index_read = index;
            index_skip = 401 - 1;
            qstory = index_skip;
            index = index_skip;
            character_schoolfestival = 3;
            //stopStorybool = true;
            //yield break;
        }
        if (index == 400 && rukia_point < 3 && rukia_point > 0) //るきあBAD
        {
            index_read = index;
            index_skip = 401 - 1;
            qstory = index_skip;
            index = index_skip;
            character_schoolfestival = 3;
            //stopStorybool = true;
            //yield break;
        }
        if(index == 416) //12月 るきあ
        {
            index_read = index;
            if (rukia_point < 3)
            {
                index_skip = 425 - 1;
            } else if(rukia_point == 0)
            {
                index_skip = 448 - 1;
            }
            qstory = index_skip;
            index = index_skip;
        }
        if (index == 477) //12月 おうじ
        {
            index_read = index;
            if (ouzi_point < 3)
            {
                index_skip = 485 - 1;
            }
            else if (ouzi_point == 0)
            {
                index_skip = 509 - 1;
            }
            qstory = index_skip;
            index = index_skip;
        }
        if (index == 535) //12月 ひかる
        {
            index_read = index;
            if (hikaru_point < 3)
            {
                index_skip = 543 - 1;
            }
            else if (hikaru_point == 0)
            {
                index_skip = 568 - 1;
            }
            qstory = index_skip;
            index = index_skip;
        }
        if(index == 323 - 1 || index == 363 - 1 || index == 400 - 1 || index == 440 - 1 || index == 457 - 1 || index == 465 - 1 || index == 473 - 1 || index == 493 - 1 || index == 517 - 1 || index == 524 - 1 || index == 531 - 1 || index == 560 - 1 || index == 577 - 1 || index == 586 - 1 || index == 593 - 1 || index == 602 - 1)
        {
            Debug.Log("エンディング");
            yield break;
        }

        /*
        if (index == 314) //おうじ文化祭からラスト
        {
            index_read = index;
            index_skip = 390;
            qstory = index_skip;
            index = index_skip;
        }
        if (index == 354) //ひかる文化祭からラスト
        {
            index_read = index;
            index_skip = 390;
            qstory = index_skip;
            index = index_skip;
        }
        */

        //Debug.Log(index_read);

        messageCount = 0; //表示中の文字数
        _story.text = "";


        //SE
        se_num_sr = _qdataList[index].se_num;
        if (int.Parse(se_num_sr) == 1)
        {
            sounds[1].PlayOneShot(se1);
        }
        if (int.Parse(se_num_sr) == 2)
        {
            sounds[1].PlayOneShot(Jingle);
        }
        if (int.Parse(se_num_sr) == 3)
        {
            sounds[1].PlayOneShot(se2);
        }

        //CV
        //Debug.Log(index);
        //sounds[2].PlayOneShot(cv[index]);

        //BGM種類
        bgm_num_sr = _qdataList[index].bgm_num;
        if (int.Parse(bgm_num_sr) == 1)
        {
            sounds[0].clip = bgm1;
        }
        if (int.Parse(bgm_num_sr) == 2)
        {
            sounds[0].clip = bgm2;
        }
        if (int.Parse(bgm_num_sr) == 3)
        {
            sounds[0].clip = bgm3;
        }
        if (int.Parse(bgm_num_sr) == 4)
        {
            sounds[0].clip = bgm4;
        }
        if (int.Parse(bgm_num_sr) == 5)
        {
            sounds[0].clip = bgm5;
        }
        if (int.Parse(bgm_num_sr) == 6)
        {
            sounds[0].clip = bgm6;
        }
        if (int.Parse(bgm_num_sr) == 7)
        {
            sounds[0].clip = bgm7;
        }


        //BGM状態
        bgm_state_sr = _qdataList[index].bgm_state;
        if (int.Parse(bgm_state_sr) == 1)
        {
            sounds[0].Play();
        }
        if (int.Parse(bgm_state_sr) == 2)
        {
            sounds[0].Stop();
        }

        //アニメーション系
        animationsr = _qdataList[index].animation;
        if(int.Parse(animationsr) != 3 || int.Parse(animationsr) != 2)
        {
            //movePanel.SetActive(false);

        }

        if (int.Parse(animationsr) == 0)
        {
            textbox.SetActive(true);
            monthtxtback.SetActive(true);
            FadeScript.isFadeOut = false;
            if (automode == 3)
            {
                automode = 0;
            }
        }
        else if (int.Parse(animationsr) == 1)
        {
            FadeScript.isFadeOut = true; //暗くなる
            fadeanimation();
            if (automode == 0)
            {
                automode = 3;
            }
        }
        else if (int.Parse(animationsr) == 2)
        {
            textbox.SetActive(false);
            monthtxtback.SetActive(false);
            FadeScript.isFadeIn = true; //明るくなる
            if (automode == 0)
            {
                automode = 3;
            }
        }
        else if(int.Parse(animationsr) == 3)
        {
            textbox.SetActive(false);
            monthtxtback.SetActive(false);
            if (automode == 0)
            {
                automode = 3;
            }
            //movePanel.SetActive(true);
            string animName = "Animations/moveimage";
            int animpos = 1;
            GameObject animObj = Instantiate((GameObject)Resources.Load(animName), new Vector3(), Quaternion.identity);
            if(animpos == 1)
            {
                animObj.transform.SetParent(this.transform);
                //animObj.transform.parent = movePanel.transform;
                animObj.GetComponent<RectTransform>().localPosition = Vector3.zero;
            }
        }




        SelectButton_3.SetActive(true);

        //選択肢が３つ以外の時はSelectButton_3を表示しない
        selectbutton_num_sr = _qdataList[index].selectbutton_num;
        //Debug.Log("selectbutton_num_sr: " + selectbutton_num_sr);
        if (int.Parse(selectbutton_num_sr) != 3)
        {
            //Debug.Log(selectbutton_num_sr);
            SelectButton_3.SetActive(false);
        }

        //選択肢パネル表示
        selectdisp_sr = _qdataList[index].selectdisp;
        selectpanelState = 0;
        if (int.Parse(selectdisp_sr) == 1)
        {
            automode = 0;
            selectpanelState = 1;
            novelSpeed = 0;
            ScreenButton.SetActive(false);
            SelectButtonPanel.SetActive(true);
            _selectbuttontext3.text = _qdataList[index].selectbuttontext3;
            _selectbuttontext1.text = _qdataList[index].selectbuttontext1;
            _selectbuttontext2.text = _qdataList[index].selectbuttontext2;
            if (selected == 0)
            {
                SelectButtonPanel.SetActive(true);
                ScreenButton.SetActive(false);
            }
        }

        //一枚絵
        stillsr = _qdataList[index].stillimage;
        Image stillimage = (Image)still.GetComponent<Image>();
        if(int.Parse(stillsr) == 0)
        {
            menubutton.SetActive(true);
        } else
        {
            menubutton.SetActive(false);
        }

        if (int.Parse(stillsr) == 0)
        {
            stillimage.sprite = still_clearSprite;
        }
        else if (int.Parse(stillsr) == 4)
        {
            GameManager.instance.getimage[0] = 1;
            stillimage.sprite = still_AprilSprite;   
        }
        else if (int.Parse(stillsr) == 5)
        {
            GameManager.instance.getimage[1] = 1;
            stillimage.sprite = still_May_hikaruSprite;
        }
        else if (int.Parse(stillsr) == 6)
        {
            GameManager.instance.getimage[2] = 1;
            stillimage.sprite = still_June_ouziSprite;
        }
        else if (int.Parse(stillsr) == 71)
        {
            GameManager.instance.getimage[3] = 1;
            stillimage.sprite = still_July_rukiaSprite; //7月
        }
        else if (int.Parse(stillsr) == 72)
        {
            GameManager.instance.getimage[4] = 1;
            stillimage.sprite = still_July_ouziSprite; //7月
        }
        else if (int.Parse(stillsr) == 73)
        {
            GameManager.instance.getimage[5] = 1;
            stillimage.sprite = still_July_hikaruSprite; //7月
        }
        else if (int.Parse(stillsr) == 81)
        {
            stillimage.sprite = still_August_ouziSprite; //8月おうじ
        }

        //月のはじめの画像
        monthsr = _qdataList[index].monthimage;
        Image monthimage = (Image)month.GetComponent<Image>();
        if (int.Parse(monthsr) == 0 && int.Parse(stillsr) == 0)
        {
            monthtext.SetActive(true);
            menubutton.SetActive(true);
        }
        else
        {
            monthtext.SetActive(false);
            menubutton.SetActive(false);
        }
        if (int.Parse(monthsr) == 0)
        {
            monthimage.sprite = month_clearSprite;
            month.SetActive(false);
        }
        if (int.Parse(monthsr) == 5)
        {
            monthimage.sprite = month_MaySprite;
            month.SetActive(true);
            startscene = 1;
            //スタート画面の切り替え
            PlayerPrefs.SetInt("START", 1);
            PlayerPrefs.Save();
        }
        if(int.Parse(monthsr) == 6)
        {
            monthimage.sprite = month_JuneSprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 7)
        {
            monthimage.sprite = month_JulySprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 8)
        {
            monthimage.sprite = month_AugustSprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 9)
        {
            monthimage.sprite = month_SeptemberSprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 10)
        {
            monthimage.sprite = month_OctoberSprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 11)
        {
            monthimage.sprite = month_NovemberSprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 12)
        {
            monthimage.sprite = month_DecemberSprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 1)
        {
            monthimage.sprite = month_JanuarySprite;
            month.SetActive(true);
        }
        if (int.Parse(monthsr) == 2)
        {
            monthimage.sprite = month_FebruarySprite;
            month.SetActive(true);
        }

        //背景
        backsr = _qdataList[index].backimage;
        Image backimage = (Image)background.GetComponent<Image>();
        if (int.Parse(backsr) == 1)
        {
            backimage.sprite = back_corridorSprite;
        }
        else if (int.Parse(backsr) == 2)
        {
            backimage.sprite = back_stairsSprite;
        }
        else if (int.Parse(backsr) == 0)
        {
            backimage.sprite = back_classroomSprite;
        }
        else if (int.Parse(backsr) == 3)
        {
            backimage.sprite = back_gardenSprite;
        }
        else if (int.Parse(backsr) == 4)
        {
            backimage.sprite = back_schoolSprite;
        }
        else if (int.Parse(backsr) == 5)
        {
            backimage.sprite = back_dispensarySprite;
        }
        else if (int.Parse(backsr) == 24)
        {
            backimage.sprite = blackSprite;
        }
        else if (int.Parse(backsr) == 6)
        {
            backimage.sprite = back_gymSprite;
        }
        else if (int.Parse(backsr) == 30)
        {
            backimage.sprite = still_AprilSprite;
        }
        else if (int.Parse(backsr) == 31)
        {
            backimage.sprite = still_May_hikaruSprite;
        }
        else if (int.Parse(backsr) == 8) {
            backimage.sprite = back_shoploadSprite;
        }
        else if (int.Parse(backsr) == 9)
        {
            backimage.sprite = back_fancyshopSprite;
        }
        else if (int.Parse(backsr) == 12)
        {
            backimage.sprite = back_heroineroom_nightSprite;
        }
        else if (int.Parse(backsr) == 11)
        {
            backimage.sprite = back_heroineroom_noonSprite;
        }
        else if (int.Parse(backsr) == 7)
        {
            backimage.sprite = back_ground_noonSprite;
        }
        else if (int.Parse(backsr) == 10)
        {
            backimage.sprite = back_cafeSprite;
        }
        else if (int.Parse(backsr) == 13)
        {
            backimage.sprite = back_garageSprite;
        }
        else if (int.Parse(backsr) == 14)
        {
            backimage.sprite = back_classroom_afternoonSprite;
        }
        else if (int.Parse(backsr) == 15)
        { 
            backimage.sprite = back_garden_afternoonSprite;
        }
        else if (int.Parse(backsr) == 16)
        {
            backimage.sprite = back_myroom_midnightSprite;
        }
        else if (int.Parse(backsr) == 17)
        {
            backimage.sprite = back_myroom_morningSprite;
        }
        else if (int.Parse(backsr) == 18)
        {
            backimage.sprite = back_myroom_nightSprite;
        }
        else if (int.Parse(backsr) == 71)
        {
            backimage.sprite = still_July_rukiaSprite;
        }
        else if (int.Parse(backsr) == 72)
        {
            backimage.sprite = still_July_ouziSprite;
        }
        else if (int.Parse(backsr) == 73)
        {
            backimage.sprite = still_July_hikaruSprite;
        }

        //センター画像
        centersr = _qdataList[index].centerimage;
        Image centerCharacter = (Image)charactercenter.GetComponent<Image>();
        if (int.Parse(centersr) == 1)
        {
            centerCharacter.sprite = ouziSprite;
        } else if (int.Parse(centersr) == 2)
        {
            centerCharacter.sprite = rukiaSprite;
        }
        else if (int.Parse(centersr) == 0)
        {
            centerCharacter.sprite = clearSprite;
        }
        else if (int.Parse(centersr) == 3)
        {
            centerCharacter.sprite = hikaruSprite;
        }
        else if (int.Parse(centersr) == 4)
        {
            centerCharacter.sprite = ouziojiSprite;
        }
        else if (int.Parse(centersr) == 5)
        {
            centerCharacter.sprite = rukiaojiSprite;
        }
        else if (int.Parse(centersr) == 6)
        {
            centerCharacter.sprite = hikaruojiSprite;
        }
        else if (int.Parse(centersr) == 7)
        {
            centerCharacter.sprite = ouzismileSprite;
        }
        else if(int.Parse(centersr) == 8)
        {
            centerCharacter.sprite = hikarutroubleSprite;
        }
        else if (int.Parse(centersr) == 9)
        { 
            centerCharacter.sprite = ouziojismileSprite;
        }
        else if (int.Parse(centersr) == 10)
        {
            centerCharacter.sprite = ouziojiangrySprite;
        }
        else if (int.Parse(centersr) == 11)
        {
            centerCharacter.sprite = ouziojitroubleSprite;
        }
        else if (int.Parse(centersr) == 12)
        {
            centerCharacter.sprite = rukiatroubleSprite;
        }
        else if (int.Parse(centersr) == 13)
        {
            centerCharacter.sprite = rukiaojismileSprite;
        }
        else if(int.Parse(centersr) == 14)
        {
            centerCharacter.sprite = ouziojishockSprite;
        }
        else if (int.Parse(centersr) == 15)
        {
            centerCharacter.sprite = ouziojithink_openSprite;
        }
        else if (int.Parse(centersr) == 16)
        {
            centerCharacter.sprite = ouziojithink_closeSprite;
        }
        else if (int.Parse(centersr) == 24)
        {
            centerCharacter.sprite = statueSprite;
        }

        //ライト画像
        rightsr = _qdataList[index].rightimage;
        Image rightCharacter = (Image)characterright.GetComponent<Image>();
        if (int.Parse(rightsr) == 1)
        {
            rightCharacter.sprite = ouziSprite;
        }
        else if (int.Parse(rightsr) == 2)
        {
            rightCharacter.sprite = rukiaSprite;
        }
        else if (int.Parse(rightsr) == 0)
        {
            rightCharacter.sprite = clearSprite;
        }
        else if (int.Parse(rightsr) == 3)
        {
            rightCharacter.sprite = hikaruSprite;
        }
        else if (int.Parse(rightsr) == 4)
        {
            rightCharacter.sprite = ouziojiSprite;
        }
        else if (int.Parse(rightsr) == 5)
        {
            rightCharacter.sprite = rukiaojiSprite;
        }
        else if (int.Parse(rightsr) == 6)
        {
            rightCharacter.sprite = hikaruojiSprite;
        }
        else if (int.Parse(centersr) == 7)
        {
            rightCharacter.sprite = ouzismileSprite;
        }
        else if (int.Parse(centersr) == 8)
        {
            rightCharacter.sprite = hikarutroubleSprite;
        }
        else if (int.Parse(centersr) == 9)
        {
            rightCharacter.sprite = ouziojismileSprite;
        }
        else if (int.Parse(centersr) == 10)
        {
            rightCharacter.sprite = ouziojiangrySprite;
        }
        else if (int.Parse(centersr) == 11)
        {
            rightCharacter.sprite = ouziojitroubleSprite;
        }
        else if (int.Parse(centersr) == 12)
        {
            rightCharacter.sprite = rukiatroubleSprite;
        }
        else if (int.Parse(centersr) == 13)
        {
            rightCharacter.sprite = rukiaojismileSprite;
        }
        else if (int.Parse(centersr) == 14)
        {
            rightCharacter.sprite = ouziojishockSprite;
        }
        else if (int.Parse(centersr) == 15)
        {
            rightCharacter.sprite = ouziojithink_openSprite;
        }
        else if (int.Parse(centersr) == 16)
        {
            rightCharacter.sprite = ouziojithink_closeSprite;
        }
        else if (int.Parse(rightsr) == 24)
        {
            rightCharacter.sprite = statueSprite;
        }

        //レフト画像
        leftsr = _qdataList[index].leftimage;
        Image leftCharacter = (Image)characterleft.GetComponent<Image>();
        if (int.Parse(leftsr) == 1)
        {
            leftCharacter.sprite = ouziSprite;
        }
        else if (int.Parse(leftsr) == 2)
        {
            leftCharacter.sprite = rukiaSprite;
        }
        else if (int.Parse(leftsr) == 0)
        {
            leftCharacter.sprite = clearSprite;
        }
        else if (int.Parse(leftsr) == 3)
        {
            leftCharacter.sprite = hikaruSprite;
        }
        else if (int.Parse(leftsr) == 4)
        {
            leftCharacter.sprite = ouziojiSprite;
        }
        else if (int.Parse(leftsr) == 5)
        {
            leftCharacter.sprite = rukiaojiSprite;
        }
        else if (int.Parse(leftsr) == 6)
        {
            leftCharacter.sprite = hikaruojiSprite;
        }
        else if (int.Parse(centersr) == 7)
        {
            leftCharacter.sprite = ouzismileSprite;
        }
        else if (int.Parse(centersr) == 8)
        {
            leftCharacter.sprite = hikarutroubleSprite;
        }
        else if (int.Parse(centersr) == 9)
        {
            leftCharacter.sprite = ouziojismileSprite;
        }
        else if (int.Parse(centersr) == 10)
        {
            leftCharacter.sprite = ouziojiangrySprite;
        }
        else if (int.Parse(centersr) == 11)
        {
            leftCharacter.sprite = ouziojitroubleSprite;
        }
        else if (int.Parse(centersr) == 12)
        {
            leftCharacter.sprite = rukiatroubleSprite;
        }
        else if (int.Parse(centersr) == 13)
        {
            leftCharacter.sprite = rukiaojismileSprite;
        }
        else if (int.Parse(centersr) == 14)
        {
            leftCharacter.sprite = ouziojishockSprite;
        }
        else if (int.Parse(centersr) == 15)
        {
            leftCharacter.sprite = ouziojithink_openSprite;
        }
        else if (int.Parse(centersr) == 16)
        {
            leftCharacter.sprite = ouziojithink_closeSprite;
        }
        else if (int.Parse(leftsr) == 24)
        {
            leftCharacter.sprite = statueSprite;
        }
        //画像の色
        colorsr = _qdataList[index].charactercolor;
        if(int.Parse(colorsr) == 0)
        {
            centerCharacter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            rightCharacter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            leftCharacter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }else if(int.Parse(colorsr) == 1)
        {
            centerCharacter.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            rightCharacter.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            leftCharacter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }else if(int.Parse(colorsr) == 2)
        {
            centerCharacter.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            rightCharacter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            leftCharacter.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }
        else
        {
            centerCharacter.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            rightCharacter.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            leftCharacter.GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        }

        //テキストボックスの色
        textcolorsr= _qdataList[index].textcolor;
        Image textboximage = (Image)textbox.GetComponent<Image>();
        monthTextPanel.SetActive(true);
        if (int.Parse(textcolorsr) == 1)
        {
            textboximage.sprite = text_ouzi;
        }
        else if (int.Parse(textcolorsr) == 2)
        {
            textboximage.sprite = text_rukia;
        }
        else if (int.Parse(textcolorsr) == 3)
        {
            textboximage.sprite = text_hikaru;
        }
        else if (int.Parse(textcolorsr) == 4)
        {
            textboximage.sprite = text_mob;
        }
        else if (int.Parse(textcolorsr) == 6)
        {
            textboximage.sprite = text_monologue;
        }
        else if (int.Parse(textcolorsr) == 5)
        {
            textboximage.sprite = clearSprite;
            monthTextPanel.SetActive(false);
        }
        else if (int.Parse(textcolorsr) == 0)
        {
            textboximage.sprite = text_own;
        }



        //名前
        if (int.Parse(textcolorsr) == 0)
        {
            _name.text = heroineName;
        }
        else if(int.Parse(textcolorsr) == 6)
        {
            _name.text = "";
        }
        else
        {
            _name.text = _qdataList[index].nameText;
        }
        
        //左上の月の表示
        if(index < 50)
        {
            _monthtext.text = "4月";
        } else if(index >= 50 && index < 140)
        {
            _monthtext.text = "5月";
        }
        else if (index >= 140 && index < 191)
        {
            _monthtext.text = "6月";
        }
        else if (index >= 191 && index < 262)
        {
            _monthtext.text = "7月";
        }
        else if (index >= 262 && index < 287)
        {
            _monthtext.text = "10月";
        }
        else if (index >= 287 && index < 400)
        {
            _monthtext.text = "11月";
        }


        //ストーリーテキスト表示
        index_read = index; //skip用

        while (_qdataList[index].storyText.Length > messageCount)
        {
                _story.text += _qdataList[index].storyText[messageCount];
                messageCount++;
                yield return new WaitForSeconds(novelSpeed);
        }
        if(_qdataList[index].storyText.Length == messageCount)
        {
            click = 1;
            if(novelspeedcount == 1)
            {
                novelSpeed = 0.3f;
            } else if(novelspeedcount == 2)
            {
                novelSpeed = 0.2f;
            } else if(novelspeedcount == 3)
            {
                novelSpeed = 0.15f;
            } else if(novelspeedcount == 4)
            {
                novelSpeed = 0.1f;
            } else
            {
                novelSpeed = 0.05f;
            }
            
            //全文表示され終わったらlogにテキストを追加
            if(_qdataList[index].nameText == "えみ")
            {
                _logtext.text += logheroineName;
            } else
            {
                int characternamelength = System.Text.Encoding.GetEncoding(932).GetByteCount(_qdataList[index].nameText);
                logcharacterName = _qdataList[index].nameText;
                if (characternamelength != 12)
                {
                    int spacecount = 12 - characternamelength;
                    for (int i = 0; i < spacecount; i++)
                    {
                        logcharacterName += "\u00A0";
                    }
                }
                _logtext.text += logcharacterName;
            }
            
            _logtext.text += _logdataList[index].logstorytext1;
            _logtext.text += "\n";
            if(_logdataList[index].logstorytext2 != "0")
            {
                _logtext.text += logspace;
                _logtext.text += _logdataList[index].logstorytext2;
                _logtext.text += "\n";
            }

            if (_logdataList[index].logstorytext3 != "0")
            {
                _logtext.text += logspace;
                _logtext.text += _logdataList[index].logstorytext3;
                _logtext.text += "\n";
            }

            if (_logdataList[index].logstorytext4 != "0")
            {
                _logtext.text += logspace;
                _logtext.text += _logdataList[index].logstorytext4;
                _logtext.text += "\n";
            }

            if (_logdataList[index].logstorytext5 != "0")
            {
                _logtext.text += logspace;
                _logtext.text += _logdataList[index].logstorytext5;
                _logtext.text += "\n";
            }

            if (_logdataList[index].logstorytext6 != "0")
            {
                _logtext.text += logspace;
                _logtext.text += _logdataList[index].logstorytext6;
                _logtext.text += "\n";
            }
            _logtext.text += "\n";
        }

        //index_read = index;

//オートモード
        if (qNum > qstory && (automode == 1 || automode == 3))
        {
            sounds[2].Stop();

            if (!(selected == 1 && qstory == 91) && MenuPanel.activeSelf == false)
            {
                autoclick = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Menu();
        auto();
        //Debug.Log(MousePos.y);
        //Debug.Log("qstory:" + qstory);
    }
    public void onClicked_closebutton()
    {
        MenuPanel.SetActive(false);
        if(automode == 4)
        {
            automode = 1;
            if (_qdataList[index_read].storyText.Length == messageCount)
            {
                StartCoroutine(Novel(qstory++));
            }
        }
    }
    public void onClick_Menu()
    {
        //Debug.Log(menucount);
        if (MenuPanel.activeSelf == true)
        {           
            menucount++;
        } else if(MenuPanel.activeSelf == false)
        {
            if(menucount != 0)
           {
                menucount--;
            }
        }
        if ( MenuPanel.activeSelf == false && menucount == 0)
        {
            if (automode == 1 || automode == 3)
            {
                automode = 4;
            }
            savenum = 1;
            PlayerPrefs.SetInt("SAVE", savenum);
            PlayerPrefs.Save();
            PlayerPrefs.SetInt("NUMBER", qstory);
            PlayerPrefs.Save();
            MenuPanel.SetActive(true);
        } else if(MenuPanel.activeSelf == true && menucount > 30)
        {
            menucount = 30;
            MenuPanel.SetActive(false);
            
            //skip用
                //cannotskipAlertPanel.SetActive(false);
            //
        }

    }

    public void onClick_Screenbutton()
    {

        if (automode == 0 || automode == 4)
        {
            if(automode == 4)
            {
                automode = 0;
            }
            if (click == 0)
            {
                novelSpeed = 0;
            }
            if (qNum > qstory && click == 1)
            {
                sounds[2].Stop();
                //StartCoroutine(Novel(qstory++));
                //click = 0;

                //if (selected != 0) {
                //    selected = 0;
                //}
                if (!( index_skip == 602))  //とめるところ selected == 2 &&  || stopStorybool == true)
                {
                    StartCoroutine(Novel(qstory++));
                    click = 0;
                }
            }
        }
    }

    //選択肢ボタン選択時の動き
    public void onClick_SelectButton_3()
    {
        //Debug.Log("3がおされている");
        selected = 3;

        if(index_read == 297)  //おうじ①
        {
            ouzi_point += 1;
            index_skip = 299 - 2;
        }
         else if (index_read == 343)  //ひかる①
        {
            hikaru_point += 0;
            index_skip = 345 - 2;
        }
        else if (index_read == 377)  //るきあ①
        {
            rukia_point += 1;
            Debug.Log("るきあポイント1加算");
            index_skip = 379 - 2;
        }
        else if (index_read == 411)  //12月 るきあ
        {
            index_skip = 413 - 2;
        }
        SelectButtonPanel.SetActive(false);
        ScreenButton.SetActive(true);
        onClick_Screenbutton();
        selectbutton1_Exit();
        selectbutton2_Exit();
        selectbutton3_Exit();
    }

    public void onClick_SelectButton_1()
    {
        SkipselectPanelScript.clicked_skip = true;
        //Debug.Log("1がおされている");
        selected = 1;
        //qstoryは調整する
        if(index_read == 67) //ひかると勉強(5月)
        {
            index_skip = 69-2;
        }
        else if(index_read == 118)  //おうじに誕プレ(5月)
        {
            index_skip = 127-2;
        }
        else if(index_read == 289) //文化祭
        {
            index_skip = 324-2;
        }
        else if (index_read == 297)
        {
            ouzi_point += 2;
            index_skip = 299 - 2;
        }
        else if (index_read == 299)
        {
            ouzi_point += 1;
            index_skip = 301 - 2;
            if (ouzi_point < 3)
            {
                index_skip = 319 - 2;
            }
        }
        else if (index_read == 343) //ひかる①
        {
            hikaru_point += 1;
            index_skip = 345 - 2;
        }
        else if (index_read == 345) //ひかる②
        {
            hikaru_point += 2;
            index_skip = 347 - 2;
            if (hikaru_point < 3)
            {
                index_skip = 356 - 2;
            }
        }
        else if (index_read == 377)  //るきあ①
        {
            rukia_point += 0;
            index_skip = 379 - 2;
        }
        
        else if (index_read == 380) //るきあ②
        {
            rukia_point += 1;
            index_skip = 382 - 2;
            if (rukia_point < 3)
            {
                index_skip = 392 - 2;
            }
        }
        else if (index_read == 411)  //12月 おうじ
        {
            index_skip = 474 - 2;
        }
        SelectButtonPanel.SetActive(false);
        ScreenButton.SetActive(true);
        onClick_Screenbutton();
        selectbutton1_Exit();
        selectbutton2_Exit();
        selectbutton3_Exit();
    }

    public void onClick_SelectButton_2()
    {
        SkipselectPanelScript.clicked_skip = true;
        //Debug.Log("2がおされている");
        //Debug.Log(index_read);
        selected = 2;
        //qstoryは調整する
        if (index_read == 67)
        {
            index_skip = 97-2;
        }
        else if (index_read == 115)
        {
            index_skip = 127;
        }
        else if(index_read == 118)
        {
            index_skip = 135 - 2;
        }
        else if (index_read == 155)
        {
            index_skip = 187 - 2;
        }
        else if (index_read == 289) //文化祭
        {
            index_skip = 364-2;
        }
        else if (index_read == 297) //おうじ①
        {
            ouzi_point += 0;
            index_skip = 299 - 2;
        }
        else if (index_read == 299) //おうじ②
        {
            ouzi_point += 2;
            index_skip = 301 - 2;
            if (ouzi_point < 3)
            {
                index_skip = 319 - 2;
            }
        }
        else if (index_read == 343) //ひかる①
        {
            hikaru_point += 2;
            index_skip = 345 - 2;
        }
        else if (index_read == 345) //ひかる②
        {
            hikaru_point += 1;
            index_skip = 347 - 2;
            if (hikaru_point < 3)
            {
                index_skip = 356 - 2;
            }
        }
        else if (index_read == 377)  //るきあ①
        {
            rukia_point += 2;
            index_skip = 379 - 2;
        }
        else if (index_read == 380) //るきあ②
        {
            rukia_point += 2;
            index_skip = 382 - 2;
            if (rukia_point < 3)
            {
                index_skip = 392 - 2;
            }
        }
        else if (index_read == 411)  //12月 ひかる
        {
            index_skip = 532 - 2;
        }
        SelectButtonPanel.SetActive(false);
        ScreenButton.SetActive(true);
        onClick_Screenbutton();
        selectbutton1_Exit();
        selectbutton2_Exit();
        selectbutton3_Exit();
    }


    public void onClicked_settingbutton()
    {
        MenuPanel.SetActive(false);
        settingPanel.SetActive(true);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, canvas.worldCamera, out MousePos);

        for(int i = 0; i < 5; i++)
        {
            textsetbutton[i].GetComponent<Image>().sprite = null;
            autosetbutton[i].GetComponent<Image>().sprite = null;
            bgmsetbutton[i].GetComponent<Image>().sprite = null;
            sesetbutton[i].GetComponent<Image>().sprite = null;
        }
        
        for(int i = 1; i < 6;i++)
        {
            if(novelspeedcount == i)
            {
                textsetbutton[i - 1].GetComponent<Image>().sprite = settingbuttonimg;
            }
            if(autospeedcount == i)
            {
                autosetbutton[i - 1].GetComponent<Image>().sprite = settingbuttonimg;
            }
            if(sevolumecount == i)
            {
                sesetbutton[i - 1].GetComponent<Image>().sprite = settingbuttonimg;
            }
            if(bgmvolumecount == i)
            {
                bgmsetbutton[i - 1].GetComponent<Image>().sprite = settingbuttonimg;
            }
        }

    }


    public void onClicked_textspeed(int number)
    {
        for (int i = 0; i < 5; i++)
        {
            textsetbutton[i].GetComponent<Image>().sprite = null;
        }
        switch (number)
        {
            case 1:
                textsetbutton[0].GetComponent<Image>().sprite = settingbuttonimg;
                novelspeedcount = 1;
                break;
            case 2:
                textsetbutton[1].GetComponent<Image>().sprite = settingbuttonimg;
                novelspeedcount = 2;
                break;
            case 3:
                textsetbutton[2].GetComponent<Image>().sprite = settingbuttonimg;
                novelspeedcount = 3;
                break;
            case 4:
                textsetbutton[3].GetComponent<Image>().sprite = settingbuttonimg;
                novelspeedcount = 4;
                break;
            case 5:
                textsetbutton[4].GetComponent<Image>().sprite = settingbuttonimg;
                novelspeedcount = 5;
                break;
        }
    }

    public void onClicked_autospeed(int number)
    {
        for (int i = 0; i < 5; i++)
        {
            autosetbutton[i].GetComponent<Image>().sprite = null;
        }
        switch (number)
        {
            case 1:
                autosetbutton[0].GetComponent<Image>().sprite = settingbuttonimg;
                autospeedcount = 1;
                break;
            case 2:
                autosetbutton[1].GetComponent<Image>().sprite = settingbuttonimg;
                autospeedcount = 2;
                break;
            case 3:
                autosetbutton[2].GetComponent<Image>().sprite = settingbuttonimg;
                autospeedcount = 3;
                break;
            case 4:
                autosetbutton[3].GetComponent<Image>().sprite = settingbuttonimg;
                autospeedcount = 4;
                break;
            case 5:
                autosetbutton[4].GetComponent<Image>().sprite = settingbuttonimg;
                autospeedcount = 5;
                break;
        }
    }

    public void onClicked_sevol(int number)
    {
        for (int i = 0; i < 5; i++)
        {
            sesetbutton[i].GetComponent<Image>().sprite = null;
        }
        switch (number)
        {
            case 1:
                sesetbutton[0].GetComponent<Image>().sprite = settingbuttonimg;
                sevolumecount = 1;
                sevolume = 0.1f;
                break;
            case 2:
                sesetbutton[1].GetComponent<Image>().sprite = settingbuttonimg;
                sevolumecount = 2;
                sevolume = 0.25f;
                break;
            case 3:
                sesetbutton[2].GetComponent<Image>().sprite = settingbuttonimg;
                sevolumecount = 3;
                sevolume = 0.5f;
                break;
            case 4:
                sesetbutton[3].GetComponent<Image>().sprite = settingbuttonimg;
                sevolumecount = 4;
                sevolume = 0.7f;
                break;
            case 5:
                sesetbutton[4].GetComponent<Image>().sprite = settingbuttonimg;
                sevolumecount = 5;
                sevolume = 1;
                break;
        }
        sounds[1].volume = sevolume;
    }

    public void onClicked_bgmvol(int number)
    {
        for (int i = 0; i < 5; i++)
        {
            bgmsetbutton[i].GetComponent<Image>().sprite = null;
        }
        switch (number)
        {
            case 1:
                bgmsetbutton[0].GetComponent<Image>().sprite = settingbuttonimg;
                bgmvolumecount = 1;
                bgmvolume = 0.1f;
                break;
            case 2:
                bgmsetbutton[1].GetComponent<Image>().sprite = settingbuttonimg;
                bgmvolumecount = 2;
                bgmvolume = 0.25f;
                break;
            case 3:
                bgmsetbutton[2].GetComponent<Image>().sprite = settingbuttonimg;
                bgmvolumecount = 3;
                bgmvolume = 0.5f;
                break;
            case 4:
                bgmsetbutton[3].GetComponent<Image>().sprite = settingbuttonimg;
                bgmvolumecount = 4;
                bgmvolume = 0.7f;
                break;
            case 5:
                bgmsetbutton[4].GetComponent<Image>().sprite = settingbuttonimg;
                bgmvolumecount = 5;
                bgmvolume = 1;
                break;
        }
        sounds[0].volume = bgmvolume;
    }


    public void OnClicked_SEMuteButton()
    {
        if(seMutecount == 0)
        {
            sounds[1].volume = 0;
            seMutecount = 1;
        } else if(seMutecount == 1)
        {
            sounds[1].volume = sevolume;
            seMutecount = 0;
        }
        
    }

    public void OnClicked_BGMMuteButton()
    {
        if (bgmMutecount == 0)
        {
            sounds[0].volume = 0;
            bgmMutecount = 1;
        }
        else if (bgmMutecount == 1)
        {
            sounds[0].volume = bgmvolume;
            bgmMutecount = 0;
        }
    }

    public void onClicked_settingreturnbutton()
    {
        settingPanel.SetActive(false);
        
        MenuPanel.SetActive(true);
    }

    public void onClicked_Autobutton()
    {
        MenuPanel.SetActive(false);
        if (automode == 0)
        {
            automode = 1;
            if (_qdataList[index_read].storyText.Length == messageCount)
            {
                StartCoroutine(Novel(qstory++));
            }
        }
        else
        {
            automode = 0;
            autoclick = false;
            time = 0;
        }
    }

    public void selectbutton1_Event()
    {
        Image selectbutton1 = (Image)Selectbutton_1.GetComponent<Image>();
        selectbutton1.sprite = select_now;
    }

    public void selectbutton2_Event()
    {
        Image selectbutton2 = (Image)Selectbutton_2.GetComponent<Image>();
        selectbutton2.sprite = select_now;
    }

    public void selectbutton3_Event()
    {
        Image selectbutton3 = (Image)SelectButton_3.GetComponent<Image>();
        selectbutton3.sprite = select_now;
    }

    public void selectbutton1_Exit()
    {
        Image selectbutton1 = (Image)Selectbutton_1.GetComponent<Image>();
        selectbutton1.sprite = select_not;
    }

    public void selectbutton2_Exit()
    {
        Image selectbutton2 = (Image)Selectbutton_2.GetComponent<Image>();
        selectbutton2.sprite = select_not;
    }

    public void selectbutton3_Exit()
    {
        Image selectbutton3 = (Image)SelectButton_3.GetComponent<Image>();
        selectbutton3.sprite = select_not;
    }

    void fadeanimation()
    {
        GameObject prefab = (GameObject)Resources.Load("Prefabs/fadePanel1");
        GameObject cloneObject = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        cloneObject.transform.SetParent(canvas.transform, false);
    }
    void auto()
    {
        if (autoclick == true)
        {
            time += Time.deltaTime;
            //Debug.Log("time:" + time);
            if(autospeedcount == 1)
            {
                if (time > 1.5f)
                {
                    StartCoroutine(Novel(qstory++));
                    click = 0;
                    autoclick = false;
                    time = 0;
                }
            } else if(autospeedcount == 2)
            {
                if (time > 1)
                {
                    StartCoroutine(Novel(qstory++));
                    click = 0;
                    autoclick = false;
                    time = 0;
                }
            } else if(autospeedcount == 3)
            {
                if (time > 0.9f)
                {
                    StartCoroutine(Novel(qstory++));
                    click = 0;
                    autoclick = false;
                    time = 0;
                }
            } else if(autospeedcount == 4)
            {
                if (time > 0.7f)
                {
                    StartCoroutine(Novel(qstory++));
                    click = 0;
                    autoclick = false;
                    time = 0;
                }
            } else
            {
                if (time > 0.5f)
                {
                    StartCoroutine(Novel(qstory++));
                    click = 0;
                    autoclick = false;
                    time = 0;
                }
            }

        }
    }



}

//質問を管理するクラス
public class Qdata
{
    int number;
    public string storyText;
    public string nameText;
    public string centerimage;
    public string rightimage;
    public string leftimage;
    public string backimage;
    public string stillimage;
    public string charactercolor;
    public string bgm_state;
    public string bgm_num;
    public string se_num;
    public string selectdisp;
    public string selectbutton_num;
    public string monthimage;
    public string selectbuttontext3;
    public string selectbuttontext1;
    public string selectbuttontext2;
    public string textcolor;
    public string animation;
    public string moveanimation;


    public Qdata(string txt)
    {
        string[] spTxt = txt.Split(',');
        if (spTxt.Length == 21)
        {
            number = int.Parse(spTxt[0]);
            storyText = spTxt[1];
            nameText = spTxt[2];
            centerimage = spTxt[3];
            rightimage = spTxt[4];
            leftimage = spTxt[5];
            backimage = spTxt[6];
            stillimage = spTxt[7];
            charactercolor = spTxt[8];
            bgm_state = spTxt[9];
            bgm_num = spTxt[10];
            se_num = spTxt[11];
            selectdisp = spTxt[12];
            selectbutton_num = spTxt[13];
            monthimage = spTxt[14];
            selectbuttontext3 = spTxt[15];
            selectbuttontext1 = spTxt[16];
            selectbuttontext2 = spTxt[17];
            textcolor = spTxt[18];
            animation = spTxt[19];
            moveanimation = spTxt[20];
        }
    }

    public void WriteDebugLog()
    {
        //Debug.Log(number + "\t" + storyText + "\t" + centerimage + "\t" + nameText + "\t" + selectbuttontext1 + "\t" + selectbuttontext2);
    }

    public class Logdata
    {
        int textnumber;
        public string logstorytext1;
        public string logstorytext2;
        public string logstorytext3;
        public string logstorytext4;
        public string logstorytext5;
        public string logstorytext6;
        int lengthcount;
        public string mainstory;
        public int check;
        public int nokori1;
        public int nokori2;
        public int nokori3;
        public int nokori4;
        public int nokori5;
        public int nokori6;

        public Logdata(string txt)
        {
            string[] spTxt = txt.Split(',');
            if (spTxt.Length == 16)
            {
                textnumber = int.Parse(spTxt[0]);
                logstorytext1 = spTxt[1];
                logstorytext2 = spTxt[2];
                logstorytext3 = spTxt[3];
                logstorytext4 = spTxt[4];
                logstorytext5 = spTxt[5];
                logstorytext6 = spTxt[6];
                lengthcount = int.Parse(spTxt[7]);
                mainstory = spTxt[8];
                check = int.Parse(spTxt[9]);
                nokori1 = int.Parse(spTxt[10]);
                nokori2 = int.Parse(spTxt[11]);
                nokori3 = int.Parse(spTxt[12]);
                nokori4 = int.Parse(spTxt[13]);
                nokori5 = int.Parse(spTxt[14]);
                nokori6 = int.Parse(spTxt[15]);
            }
        }

        public void WriteDebugLog_logstory()
        {
            //Debug.Log(logstorytext1 + "\t" + logstorytext2 + "\t" + logstorytext3 + "\t" + logstorytext4 + "\t" + logstorytext5 + "\t" + logstorytext6);
        }
    }

}
