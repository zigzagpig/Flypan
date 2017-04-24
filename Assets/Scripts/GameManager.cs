using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //游戏状态枚举
    public enum GameState
	{
	    START,
        GAME,
        END
	}

    private int score = 0;
    private float time = 40;
    private bool startTime = false;

    //存储3个ui
    private GameObject m_StartUI;
    private GameObject m_GameUI;
    private GameObject m_EndUI;

    private GUIText m_GuiText_score;
    private GUIText m_GuiText_time;
    private GUIText m_GuiText_TotalScore;

    private AudioSource audioSource;

    private Weapon m_Weapon;
    private FeipanManager m_FeipanManager;

    //游戏状态
    private GameState gameState;

    void StartTime()
    {
        startTime = true;
    }

	void Start () {
        //查找3个UI
	    m_StartUI = GameObject.Find("StartUI");
        m_GameUI = GameObject.Find("GameUI");
        m_EndUI = GameObject.Find("EndUI");

        m_GuiText_score = GameObject.Find("GameScore").GetComponent<GUIText>();
	    m_GuiText_time = GameObject.Find("GameTime").GetComponent<GUIText>();
        //m_GuiText_TotalScore = GameObject.Find("GameTotal").GetComponent<GUIText>();

        m_Weapon = GameObject.Find("Weapon").GetComponent<Weapon>();
	    m_FeipanManager = GameObject.Find("FeipanParent").GetComponent<FeipanManager>();

	    audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Debug.Log("aaaa");
        ChangeGameState(GameState.START);
    }
	
	// Update is called once per frame
	void Update () {
	    if (startTime)
	    {
	        time = time - Time.deltaTime;
	        m_GuiText_time.text = "时间剩下:" + time + "秒";
	    }
	    if (time <= 0)
	    {
	        ChangeGameState(GameState.END);
            //m_GuiText_TotalScore.text = "总分:" + score + "分";

	        startTime = false;
	        time = 40;
	        score = 0;
	    }
	}

    public void AddScore()
    {
        score++;
        m_GuiText_score.text = "消灭：" + score.ToString();
    }

    public void ChangeGameState(GameState state)
    {
        gameState = state;

        if (gameState == GameState.START)
        {
            m_StartUI.SetActive(true);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(false);

            audioSource.Stop();

            m_Weapon.ChangeCanMove(false);
            m_Weapon.count = 0;
            m_Weapon.hash = new int[20];

            m_FeipanManager.StopCreateFeipan();
        }
        else if (gameState == GameState.GAME)
        {
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(true);
            m_EndUI.SetActive(false);

            audioSource.Play();

            m_Weapon.ChangeCanMove(true);

            m_FeipanManager.StartCreateFeipan();

            StartTime();

            m_GuiText_score.text = "消灭" + score.ToString();
        }
        else if (gameState == GameState.END)
        {
            m_StartUI.SetActive(false);
            m_GameUI.SetActive(false);
            m_EndUI.SetActive(true);

            audioSource.Stop();

            m_Weapon.ChangeCanMove(false);

            m_FeipanManager.StopCreateFeipan();

            m_FeipanManager.RemoveFeipan();

            m_EndUI.GetComponent<Hate>().Cal();
        }
    }
}
