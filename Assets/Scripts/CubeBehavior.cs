using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    void Update()
    {
        transform.position -= Time.deltaTime * transform.forward * 7;
        
        if(transform.position.z <= 0){
            Destroy(this.gameObject, 3);
            ResetComboStreak();
        }
    }

    void ResetComboStreak()
    {
        GameData.comboStreak = 0;
        GameData.scoreMultiplier = 1;
        GameData.missedCubes++;
    }
}
