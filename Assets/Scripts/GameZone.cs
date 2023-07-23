using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameZone : MonoBehaviour
{
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform leftPoint;
    [SerializeField] private Transform rightPoint;
    [SerializeField] private Transform bottomPoint;

    [SerializeField] private Transform gameZoneTopPoint;

    [SerializeField] private float GameZonePercent = 0.25f;
    void Start()
    {
        var camera = Camera.main;
        topPoint.position = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 10));
        bottomPoint.position = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, 0, 10));
        leftPoint.position = camera.ScreenToWorldPoint(new Vector3(0, Screen.height / 2, 10));
        rightPoint.position = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2, 10));
        gameZoneTopPoint.position = camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height * GameZonePercent, 10));
    }
}
