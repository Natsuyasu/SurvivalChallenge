using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityTools
{
    public static Vector3 GenerateRandomPositionSquarePattern(Vector2 spawnArea)
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.7f ? -1.2f : 1.2f;
        if (UnityEngine.Random.value > 0.7f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.x = spawnArea.x * f;
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.y);
        }

        position.z = 0;
        return position;
    }
}
