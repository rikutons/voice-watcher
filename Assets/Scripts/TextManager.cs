using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;  // 追加しましょう

public class TextManager : MonoBehaviour
{


    public GameObject talk_text = null; // キャンパスを読み込む;
    public GameObject Panel; //吹き出しを読み込む
    public GameObject Topic_box; //トピックエフェクトをだす箱を読み込む
    public GameObject Topic_text; //トピックエフェクトを読み込む
    GameObject TextHandler;
    TextHandler script;

    GameObject VoiceRecognizer;
    //VoiceRecognizer voice;

    GameObject RawImage;
    //FaceDetectorScene face;

    RawImage position;
    int count;
    int text_x;
    int text_y;
    int BeforeRandom = 0;
    int Silent;
    public float SilentTimes = 0;
    public float time = 0;


    // 初期化
    void Start()
    {
        //TextHandlerオブジェクトを読み込む
        TextHandler = GameObject.Find("TextHandler");
        //TextHandlerオブジェクト内のTextHandlerスクリプトを読み込む
        script = TextHandler.GetComponent<TextHandler>();

        //VoiceRecognizerオブジェクトを読み込む
        VoiceRecognizer = GameObject.Find("VoiceRecognizer");
        //VoiceRecognizerオブジェクト内のVoiceRecognizerスクリプトを読み込む
        //voice = VoiceRecognizer.GetComponent<VoiceRecognizer>();
    }

    //吹き出しを消す関数
    void DestroyTopicBox()
    {
        if (time >= 4)
        {
            Topic_box.SetActive(false);
        }
        //UnityEngine.Debug.Log("a");
    }

    //ランダムなトピックを代入する関数
    string RandomTopicInit()
    {
        int random = (Random.Range(1, 7));
        string randomtopic = "null";
        //UnityEngine.Debug.Log(random);
        if(random == BeforeRandom)
        {
            //randomtopic = ("同じ乱数");
            randomtopic = RandomTopicInit();
        }
        else if(random == 1)
        {
            randomtopic = ("今日何食べた？");
        }
        else if (random == 2)
        {
            randomtopic = ("おすすめのコンビニお菓子は？");
        }
        else if (random == 3)
        {
            randomtopic = ("好きなYouTuberは？");
        }
        else if (random == 4)
        {
            randomtopic = ("出身はどこ？");
        }
        else if (random == 5)
        {
            randomtopic = ("最近あった出来事は？");
        }
        else if (random == 6)
        {
            randomtopic = ("休みの日は何をしてるの？");
        }
        BeforeRandom = random;
        return randomtopic;
    }

    // 更新
    public void OnChangeText(string text)
    {
        //吹き出しを出現
        Panel.SetActive(true);
        // オブジェクトからTextコンポーネントを取得(書き入れるキャンパスを取得)
        Text score_text = talk_text.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = text;
        //SilentTimesを0に戻す
        SilentTimes = 0;

        //2秒後に吹き出しを消す関数を呼び出す
        //Invoke("DestroySpeechBubble", 2.0f);
    }

    void Update()
    {

        // テキストを顔の座標近くに移動
        //UnityEngine.Debug.Log(text_x);
        //UnityEngine.Debug.Log(text_y);
        //Panel.transform.position = new Vector3(text_x, text_y, 0);
        string randomtopic = "null";
        //Silent = voice.Silent;

        SilentTimes += Time.deltaTime;
        time += Time.deltaTime;
        //UnityEngine.Debug.Log(SilentTimes);

        //吹き出しを消す関数を呼び出す
        DestroyTopicBox();

        //下キーが押されたときtopicを表示
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //UnityEngine.Debug.Log("Topic");
            time = 0;
            //トピックエフェクトを出現
            Topic_box.SetActive(true);
            // オブジェクトからTextコンポーネントを取得(書き入れるキャンパスを取得)
            Text topic_text = Topic_text.GetComponent<Text>();
            //関数呼び出し
            randomtopic = RandomTopicInit();
            // テキストの表示を入れ替える
            topic_text.text = randomtopic;
        }

        //1が押されたとき
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //UnityEngine.Debug.Log("Topic");
            //トピックエフェクトを出現
            Topic_box.SetActive(true);
            // オブジェクトからTextコンポーネントを取得(書き入れるキャンパスを取得)
            Text topic_text = Topic_text.GetComponent<Text>();
            //関数呼び出し
            randomtopic = ("仕様です");
            // テキストの表示を入れ替える
            topic_text.text = randomtopic;
            Invoke("DestroyTopicBox", 4.0f);
        }

        //一定時間会話が続かなかったときトピックエフェクトを出現
        //if (SilentTimes >= 10)
        //{
        //    //UnityEngine.Debug.Log("Topic");
        //    //トピックエフェクトを出現
        //    Topic_box.SetActive(true);
        //    // オブジェクトからTextコンポーネントを取得(書き入れるキャンパスを取得)
        //    Text topic_text = Topic_text.GetComponent<Text>();
        //    //関数呼び出し
        //    randomtopic = RandomTopicInit();
        //    // テキストの表示を入れ替える
        //    topic_text.text = randomtopic;
        //    Invoke("DestroyTopicBox", 4.0f);
        //    //SilentTimesを戻す
        //    SilentTimes = 0.0f;
        //}

        //Escapeで戻る
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Activate", LoadSceneMode.Single);
        }
    }
}