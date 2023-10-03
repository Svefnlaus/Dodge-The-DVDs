using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score;

    private TMP_Text scoreBoard;

    private void Awake()
    {
        scoreBoard = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        scoreBoard.SetText("Score: " + Score);
    }
}
