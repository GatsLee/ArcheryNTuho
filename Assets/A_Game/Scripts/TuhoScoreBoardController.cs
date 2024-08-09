using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TuhoScoreBoardController : MonoBehaviour
{
    public GameObject scoreBoard;
    private TextMeshPro scoreText;

    void Start()
    {
        scoreText = scoreBoard.GetComponent<TextMeshPro>();

        UpdateScoreText(0);
    }

    // Update is called once per frame
    public void UpdateScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore.ToString();
    }

    private void Update()
    {
        UpdateScoreText(TuhoGameController.Instance.playerOneScore);
    }
}
