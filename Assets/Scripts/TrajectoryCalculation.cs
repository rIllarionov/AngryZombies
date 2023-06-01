using System;
using UnityEngine;

public class TrajectoryCalculation : MonoBehaviour
{
    [SerializeField] private GameObject trajectorySprite;
    [SerializeField] private int countTrajectoryPoints;

    private GameObject[] _trajectoryPoints;
    private float _stepTime = 0.1f;
    readonly float _acceleration = 9.8f;

    private void Awake()
    {
        _trajectoryPoints = new GameObject[countTrajectoryPoints];

        for (int i = 0; i < countTrajectoryPoints; i++)
        {
            _trajectoryPoints[i] = Instantiate(trajectorySprite);
        }
    }


    public void CalculateTrajectory(Vector2 currentSkullPosition, Vector2 startSpeed, float startAngle)
    {
        ActivateDots(true);

        for (int i = 0; i < countTrajectoryPoints; i++)
        {
            var x = startSpeed.magnitude * _stepTime * Math.Cos(startAngle);
            var y = startSpeed.magnitude * _stepTime * Math.Sin(startAngle) - _acceleration * _stepTime * _stepTime / 2;

            var currentPosition = new Vector2(currentSkullPosition.x + (float)x, currentSkullPosition.y + (float)y);

            _trajectoryPoints[i].transform.position = currentPosition;

            _stepTime += 0.1f;
        }

        _stepTime = 0.1f;
    }

    public void ActivateDots(bool isActive)
    {
        foreach (var dot in _trajectoryPoints)
        {
            dot.SetActive(isActive);
        }
    }
}