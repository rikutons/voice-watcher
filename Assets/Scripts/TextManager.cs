using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class TextManager : MonoBehaviour
{


    public GameObject campas = null; // キャンパスを読み込む;
    public GameObject SpeechBubble; //吹き出しを読み込む;
    GameObject TextHandler;
    TextHandler script;
    int count;


    // 初期化
    void Start()
    {
        //TextHandlerオブジェクトを読み込む
        TextHandler = GameObject.Find("TextHandler");
        //TextHandlerオブジェクト内のTextHandlerクラスを読み込む
        script = TextHandler.GetComponent<TextHandler> ();
    }

    //吹き出しを消す関数
    void DestroySpeechBubble()
    {
        SpeechBubble.SetActive(false);
    }

    // 更新
    public void OnChangeText(string text)
    {
        //吹き出しを出現
        SpeechBubble.SetActive(true);
        // オブジェクトからTextコンポーネントを取得(書き入れるキャンパスを取得)
        Text score_text = campas.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = text;
        //2秒後に吹き出しを消す関数を呼び出す
        Invoke("DestroySpeechBubble", 2.0f);
    }
}