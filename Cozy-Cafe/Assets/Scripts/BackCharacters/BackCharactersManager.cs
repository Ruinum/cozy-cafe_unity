using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ruinum.Core;

public class BackCharactersManager : BaseSingleton<BackCharactersManager>
{
    [SerializeField] private float startTime = 5;

    [SerializeField] private float repeatTime = 30;

    [SerializeField] private List<Vector2> positions;

    private void Start()
    { 
        InvokeRepeating(nameof(Spawn), startTime, repeatTime);
    }

    private void Spawn()
    {
        var backCharacter = Instantiate(Resources.Load<GameObject>("Prefabs/BackCharacter"), null);

        backCharacter.transform.position = positions[Random.Range(0, positions.Count)];
    }

}
