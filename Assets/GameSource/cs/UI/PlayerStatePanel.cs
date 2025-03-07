using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatePanel : MonoBehaviour
{
    [SerializeField] bool isP1;

    [SerializeField] Text score;
    [SerializeField] Image[] lifes;
    [SerializeField] Text bombCnt;

    int cnt;

    void Start()
    {

    }

    void Update()
    {
        if(GameManager.Instance.isForDos)
        {
            if (isP1)
            {
                score.text = GameManager.Instance.ScoreSystem.Player1Score.ToString();
                bombCnt.text = GameManager.Instance.GetCurrentSceneT<InGameScene>().Player.bomb.ToString();

                cnt = (int)GameManager.Instance.GetCurrentSceneT<InGameScene>().Player.hp;
                SetLifeColorAlphaZero();
            }
            else
            {
                score.text = GameManager.Instance.ScoreSystem.Player2Score.ToString();
                bombCnt.text = GameManager.Instance.GetCurrentSceneT<InGameScene>().Player2.bomb.ToString();

                cnt = (int)GameManager.Instance.GetCurrentSceneT<InGameScene>().Player2.hp;
                SetLifeColorAlphaZero();
            }
        }
        else
        {
            if (isP1)
            {
                score.text = GameManager.Instance.ScoreSystem.Player1Score.ToString();
                bombCnt.text = GameManager.Instance.GetCurrentSceneT<InGameScene>().Player.bomb.ToString();

                cnt = (int)GameManager.Instance.GetCurrentSceneT<InGameScene>().Player.hp;
                SetLifeColorAlphaZero();
            }
            else
            {
                score.text = "INSERT COIN!!";
                return;
            }
            
        }
        
    }

    void SetLifeColorAlphaZero()
    {
        int tmp = 3 - cnt;

        for (int i = 0; i < tmp; i++)
        {
            if(lifes[i].IsActive())
                lifes[i].gameObject.SetActive(false);
        }
    }
}
