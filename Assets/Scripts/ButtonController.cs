using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ButtonController : MonoBehaviour
{
    public InputField et1;//インプットフィールド用の変数
    public InputField et2;
    public Text result;　//結果表示用のテキスト

    public void btClick()//クリックしたときの処理 （ボタンのインスペクターから追加）
    {
        string x = et1.text;//入っている情報を.textで取得
        string y = et2.text;
        StartCoroutine(HttpConnect(x, y));//通信で渡す　文字列で渡す
    }
    
    IEnumerator HttpConnect(string x, string y)
    {
        WWWForm form = new WWWForm();//リクエスト通信
        form.AddField("x", x);//情報追加
        form.AddField("y", y);
        string url = "https://joytas.net/php/calc.php";
        UnityWebRequest uwr = UnityWebRequest.Post(url, form);
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
            result.text = uwr.downloadHandler.text;
        }
    }
}
