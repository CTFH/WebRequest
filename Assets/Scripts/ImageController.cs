using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class ImageController : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(HttpConnect());
    }

    IEnumerator HttpConnect()
    {
        string url = "https://joytas.net/php/man.jpg";
            UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url);
            //UnityWebRequestクラスのインスタンス　メソッドからインスタンスの生成
            yield return uwr.SendWebRequest();//Get通信している
        if(uwr.isHttpError || uwr.isNetworkError)
        {
            Debug.Log(uwr.error);
        }
        else
        {
            //ダウンロードされた画像をTexture型で取得
            Texture texture = DownloadHandlerTexture.GetContent(uwr);

            //キャンバス上で使うにはテクスチャーからスプライトに変換必要
            //textureからスプライトに変換
            //Sprite.Create(もとのダウンロードしたtexture2D,ダウンロードしたtexture2Dのどこを使うか、スプライトのpivot（中心）を指定）
            Sprite sp = Sprite.Create((Texture2D)texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));//0,0が左上、1,1が右下
            //（Texture2D）はダウンキャストしてテクスチャー　をもとにスプライトを作成
            //ダウンキャストはスプライト作成時に必要

            //Imageコンポーネント取得
            Image image = GetComponent<Image>();
            
            //いつもはインスペクターから登録してるコンポーネントのところをC#から登録

            //取得した画像サイズをもとにImageコンポーネントの大きさ設定
            image.rectTransform.sizeDelta = new Vector2(
                texture.width, texture.height);
            //青色のサイズの四角をダウンロードした画像のサイズに変換する
           　//sizeDeltaは青のイメージの真ん中の白の四角のwidthとheight

            //作成したスプライトを設定
            image.sprite = sp;
        }
    }
 }
