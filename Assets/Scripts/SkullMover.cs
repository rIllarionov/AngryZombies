using UnityEngine;

//скрипт двигает объект за мышкой
public class SkullMover : MonoBehaviour
{
    [SerializeField] private Transform movementCenter;
    [SerializeField] private float movementRadius;
    private Vector3 _mousePosition;

    private void GetMousePosition()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.z = 0;
    }

    public void MoveSkull()
    {
        GetMousePosition();

        Vector3 direction = _mousePosition - movementCenter.position;
        direction = Vector3.ClampMagnitude(direction, movementRadius);
        transform.position = movementCenter.position + direction;
    }
}