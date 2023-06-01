using System;
using UnityEngine;

//скрипт размещаем на объект для запуска
public class SkullLauncher : MonoBehaviour
{
    [SerializeField] private TrajectoryCalculation trajectoryCalculation;
    [SerializeField] private float scalarVelocity = 8f;
    [SerializeField] private Transform centerCircle;

    private Vector3 _currentSkullPosition;
    private Rigidbody2D _skullRigidbody;
    private Vector2 _startSpeed;
    private float _startAngle;
    private Vector2 _launchDirection;

    private void Awake()
    {
        _skullRigidbody = GetComponent<Rigidbody2D>();
        _skullRigidbody.isKinematic = true;
    }

    private void Update()
    {
        _currentSkullPosition = transform.position;
    }

    public void Launch()
    {
        _skullRigidbody.isKinematic = false;
        _skullRigidbody.AddForce(_startSpeed, ForceMode2D.Impulse);

        trajectoryCalculation.ActivateDots(false);
    }

    public void PrepareForLaunch()
    {
        transform.rotation = Quaternion.identity;

        CalculateLaunchDirection();
        CalculateStartSpeed();
        CalculateAngle();
        trajectoryCalculation.CalculateTrajectory(_currentSkullPosition, _startSpeed, _startAngle);
    }

    public void ResetSkull()
    {
        _skullRigidbody.isKinematic = true;
        _skullRigidbody.AddForce(Vector2.zero);
        _skullRigidbody.GetComponent<Transform>().transform.position = new Vector3(0, 0, 0);
    }


    private void CalculateLaunchDirection() //направление запуска
    {
        _launchDirection = centerCircle.position - _currentSkullPosition;
    }

    private void CalculateStartSpeed() //начальная скорость
    {
        _startSpeed = _launchDirection * scalarVelocity;
    }

    private void CalculateAngle() //угол направления
    {
        _startAngle = Mathf.Atan2(_launchDirection.y, _launchDirection.x);
    }
}