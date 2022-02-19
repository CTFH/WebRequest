using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HttpController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HttpConnect());  
    }
    IEnumerator HttpConnect()//method
    {
        string url = "https://joytas.net/php/hello.php";
        //Unity2018~
        UnityWebRequest uwr = UnityWebRequest.Get(url);
        //Unity WebRequest クラスのインスタンスuwr
        //　.Getでインスタンスを作成出来る
        yield return uwr.SendWebRequest();//実際に通信しているメソッド
        //yield return 一回処理して終わったら下に行く
        if(uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            Debug.Log(uwr.downloadHandler.text);
            //本文にアクセスできる
        }

    }

}
