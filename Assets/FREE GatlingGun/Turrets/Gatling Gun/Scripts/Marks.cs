using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Marks : MonoBehaviour
{
    private static Marks instance;
    public static Marks Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("Marks");
                go.AddComponent<Marks>();
            }
            return instance;
        }
    }
    public Text MarksText;

    public int Score { get; set; }
    public bool gameStart { get; set; }
    public bool challenge { get; set; }

    public bool canFire { get; set; }
    void Awake()
    {
        instance = this;
        Application.targetFrameRate = 60;
        canFire = true;
    }

    void Start()
    {
        Score = 0;
        gameStart = false;
        challenge = false;
    }

    public void switchGame()
    {
        gameStart = !gameStart;
        Score = 0;
    }


    public void openChallengeGame()
    {
        gameStart = !gameStart;
        challenge = true;
        Score = 0;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        MarksText.text = Score.ToString();
        if (Marks.Instance.challenge)
        {
            MarksText.color = new Color(1f, 0.88f, 0f);
        }
    }
}
