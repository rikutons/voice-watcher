using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class TextManager : MonoBehaviour
{


    public GameObject campas = null; // キャンパスを読み込む;
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

    // 更新
    public void OnChangeText(string text)
    {
        //TextHandlerクラスのSentenceを取得
        //string Sentence = script.Text;
        // オブジェクトからTextコンポーネントを取得(書き入れるキャンパスを取得)
        Text score_text = campas.GetComponent<Text>();
        //文字数を取得
        //int count = Sentence.Length;
        //文字列の最初の10文字を取得
        //string partA = Sentence.Substring(1, 10);
        //文字列の次の10文字を取得
        //string partB = Sentence.Substring(11, 20);
        //Debug.Log(count);
        // テキストの表示を入れ替える
        //string Sentence_new = partA;//+ "\n" + partB;
        score_text.text = text;
    }
}