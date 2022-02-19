using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PostController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HttpConnect());       
    }

    IEnumerator HttpConnect()
    {
        //post通信なのでリクエストパラメータとして送るにはWWWForm
        //リクエストパラメータ…情報を保持して送信
        //URL露出はゲット　　URL露出しないのはポスト
        //URL露出せずに、xとyの値も露出せずに保持したまま情報を送るのがポストでWWWForm
        WWWForm form = new WWWForm();
        form.AddField("x", 5);//第一引数 変数名、第二引数 値（intか文字列か）　で値を追加
        form.AddField("y", 8);　//少数を送りたいときは文字列に変換

        string url = "https://joytas.net/php/calc.php";
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
        //インスタンス作成
        yield return uwr.SendWebRequest();
        if(uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            //通信した結果をかきこむ
            //通信した結果をdownloadHandker.textが持っている
            //それをresult.textに代入
            Debug.Log(uwr.downloadHandler.text);
        }
    }
    
}
