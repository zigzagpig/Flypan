using UnityEngine;
using System.Collections;

public class GameReset : MonoBehaviour {

    private GameManager m_GameManager;

    void Start()
    {
        m_GameManager = GameObject.Find("UI").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("游戏重新开始");
        m_GameManager.ChangeGameState(GameManager.GameState.START);
    }
}
