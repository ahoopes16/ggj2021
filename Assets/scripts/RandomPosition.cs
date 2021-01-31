using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomPosition
{
    public static Vector2 GetRandomTablePosition()
    {
        float xRange = 2f;
        float yRange = 2f;

        float randomX = Random.Range(1.5f - xRange, 1.5f + xRange);
        float randomY = Random.Range(-0.82f - yRange, -0.82f + yRange);

        return new Vector3(randomX, randomY);
    }
}
