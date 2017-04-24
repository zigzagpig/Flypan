using UnityEngine;
using System.Collections;

public class Hate : MonoBehaviour {

    private GUIText m_GUItext0;
    private GUIText m_GUItext1;
    private GUIText m_GUItext2;
    private GUIText m_GUItext3;
    private GUIText m_GUItext4;
    private GUIText m_GUItext5;
    private GUIText m_GUItext6;
    private GUIText m_GUItext7;
    private GUIText m_GUItext8;


    // Use this for initialization
    void Start () {
        m_GUItext0 = GameObject.Find("Game0").GetComponent<GUIText>();
        m_GUItext1 = GameObject.Find("Game1").GetComponent<GUIText>();
        m_GUItext2 = GameObject.Find("Game2").GetComponent<GUIText>();
        m_GUItext3 = GameObject.Find("Game3").GetComponent<GUIText>();
        m_GUItext4 = GameObject.Find("Game4").GetComponent<GUIText>();
        m_GUItext5 = GameObject.Find("Game5").GetComponent<GUIText>();
        m_GUItext6 = GameObject.Find("Game6").GetComponent<GUIText>();
        m_GUItext7 = GameObject.Find("Game7").GetComponent<GUIText>();
        m_GUItext8 = GameObject.Find("Game8").GetComponent<GUIText>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int[] hash = new int[20];
    public float count = 0f;

    public void Cal()
    {
        hash = GameObject.Find("Weapon").GetComponent<Weapon>().ReturnHash();
        count = GameObject.Find("Weapon").GetComponent<Weapon>().ReturnCount();

        string pre = "", left = "", right = "只";
        for (int i = 0; i < 9; i++)
        {
            if (Rank(hash[i]) == 8)
                pre = "真是血海深仇啊";
            else if (Rank(hash[i]) == 7)
                pre = "不共戴天";
            else if (Rank(hash[i]) == 6)
                pre = "恩将仇报";
            else if (Rank(hash[i]) == 5)
                pre = "愤世嫉俗";
            else if (Rank(hash[i]) == 4)
                pre = "苦大仇深";
            else if (Rank(hash[i]) == 3)
                pre = "深仇大恨";
            else if (Rank(hash[i]) == 2)
                pre = "以德报怨";
            else if (Rank(hash[i]) == 15)
                pre = "随便杀";
            else if (Rank(hash[i])== 9)
                pre = "默默蹲你两分钟";
            else if (Rank(hash[i]) == 10)
                pre = "从此打野只抓你";
            else if (Rank(hash[i]) == 11)
                pre = "哼才不是喜欢被杀";
            else if (Rank(hash[i]) == 12)
                pre = "好气呀";
            else if (Rank(hash[i]) == 13)
                pre = "越塔也要干掉你";
            else if (Rank(hash[i]) == 14)
                pre = "打本不带你了";
            else if (Rank(hash[i]) == 1)
                pre = "小拳拳锤你";
            else
                pre = "哟哟甜蜜蜜";

            if (hash[8] > 10 && i == 8)
            {
                pre = "！！！敢打我徒弟10多次，不想活了!!!";
            }
            else if (hash[1] > 10 && i == 1)
            {
                pre = "！！！土豪资本主义被打倒咯";
            }
            else if (hash[3] > 10 && i == 3)
            {
                pre = "！！！小拳拳锤你";
            }
            else if (hash[5] > 10 && i == 5)
            {
                pre = "！！！好气呀";
            }
            else if (hash[4] > 10 && i == 4)
            {
                pre = "！！！哼才不是喜欢被杀";
            }
            else if (hash[2] > 10 && i == 2)
            {
                pre = "！！！讨厌";
            }
            else if (hash[6] > 10 && i == 6)
            {
                pre = "！！！信不信大劈秒你";
            }
            else if (hash[7] > 10 && i == 7)
            {
                pre = "！！！帮费该交了";
            }
            else if (hash[0] > 10 && i == 0)
            {
                pre = "！！！不带你们打本了";
            }
            else
            {
                pre = "";
            }


            if (i == 8)
                m_GUItext8.text = "娘娘:" + hash[i] + right + pre;
            else if (i == 1)                             
                m_GUItext1.text = "大叔:" + hash[i] + right + pre;
            else if (i == 7)                               
                m_GUItext7.text = "帮主:" + hash[i] + right + pre;
            else if (i == 3)                             
                m_GUItext3.text = "樱月:" + hash[i] + right + pre;
            else if (i == 4)                            
                m_GUItext4.text = "小哥:" + hash[i] + right + pre;
            else if (i == 5)                               
                m_GUItext5.text = "代代:" + hash[i] + right + pre;
            else if (i == 0)           
                m_GUItext0.text = "士力架:" + hash[i] + right + pre;
            else if (i == 6)           
                m_GUItext6.text = "天香:" + hash[i] + right + pre;
            else if (i == 2)           
                m_GUItext2.text = "嫣红:" + hash[i] + right + pre;
        }
    }

    private int Rank(int x)
    {
        int c = 0;
        for (int i = 0; i < 9; i++)
        {
            if (x > hash[i])
            {
                c++;
            }
        }

        return Random.Range(1,16);

    }
}
