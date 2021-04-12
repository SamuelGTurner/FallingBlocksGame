using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty {

    static float secondsToMaxDifficulty = 60;

    public static float GetDifficultyPercent() {
        // return 1; // Remove to set difficulty to max difficulty
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDifficulty);
    }


}
