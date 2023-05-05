using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    public TextMeshProUGUI finalScore;
    public TextMeshProUGUI longestComboStreak;
    public TextMeshProUGUI hitMissRatio;
    private int totalCubes;

    void Start()
    {
        totalCubes = GameData.hitCubes + GameData.missedCubes;
        finalScore.text = "" + GameData.score;
        longestComboStreak.text = "LONGEST STREAK: " + GameData.longestComboStreak;
        hitMissRatio.text = GameData.hitCubes + "/" + totalCubes;
        GameData.score = 0;
        GameData.comboStreak = 0;
        GameData.longestComboStreak = 0;
        GameData.scoreMultiplier = 1;
        GameData.hitCubes = 0;
        GameData.missedCubes = 0;
        totalCubes = 0;
    }
}
