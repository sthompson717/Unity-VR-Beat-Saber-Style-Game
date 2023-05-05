using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaberBehavior : MonoBehaviour
{
    public TextMeshProUGUI scoreBoard;
    public TextMeshProUGUI comboTracker;

    private void IncreaseScore(int pointsEarned)
    {
        GameData.score += pointsEarned * GameData.scoreMultiplier;
        scoreBoard.text = "SCORE" + "<br>" + GameData.score;
    }

    public void IncreaseComboStreak()
    {
        if(GameData.scoreMultiplier < 8)
        {
            GameData.scoreMultiplier *= 2;
        }

        GameData.comboStreak++;

        if (GameData.comboStreak > GameData.longestComboStreak)
        {
            GameData.longestComboStreak = GameData.comboStreak;
        }

        comboTracker.text = "COMBO STREAK" + "<br>" + GameData.comboStreak + "<br><br>" + GameData.scoreMultiplier + "x";
    }

    void OnCollisionEnter(Collision cube)
    {
        Vector3 normal = cube.contacts[0].normal;
        float angle = Vector3.Angle(normal, cube.gameObject.transform.up);

        if (angle <= 90)
        {
            SliceCubes.Slice(cube.gameObject.transform, transform.position, normal);
            IncreaseScore((100 - Mathf.RoundToInt(Mathf.Abs(angle))));
            IncreaseComboStreak();
            GameData.hitCubes++;
        }
    }
}
