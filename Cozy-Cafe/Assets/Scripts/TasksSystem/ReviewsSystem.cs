using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewsSystem : MonoBehaviour
{
    public static ReviewsSystem Singletone;

    [Range(-20, 20)]
    public int Rating = 0;

    private void Awake()
    {
        Singletone = this;
    }

    public void ChangeRating(int value)
    {
        Rating += value;
    }
}
