using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    //得点を表示するテキスト
    private GameObject scoreText;

    //得点
    private int score;

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "SmallStarTag")
        {
            score = score + 10;
        }
        else if (col.gameObject.tag == "LargeStarTag")
        {
            score = score + 20;
        }
        else if (col.gameObject.tag == "SmallCloudTag")
        {
            score = score + 15;
        }
        else if (col.gameObject.tag == "LargeCloudTag")
        {
            score = score + 5;
        }

        this.scoreText.GetComponent<Text>().text = "score:" + score;

    }

    // Use this for initialization
    void Start()
    {
        //シーン中のTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");

        //得点初期化
        score = 0;

        //得点を表示
        this.scoreText.GetComponent<Text>().text = "score:" + score;
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }
}