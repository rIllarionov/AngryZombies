using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private SkullMover skullMover;
    [SerializeField] private SlingDrawer slingDrawer;
    [SerializeField] private Collider2D circleCollider;
    [SerializeField] private SkullLauncher skullLauncher;

    private bool _clickInCircle;

    private void Update()
    {
        if (IsMouseInCircle() && Input.GetMouseButton(0))
        {
            _clickInCircle = true;
        }

        if (_clickInCircle)
        {
            skullLauncher.ResetSkull();
            skullMover.MoveSkull();
            slingDrawer.Draw();
            skullLauncher.PrepareForLaunch();
        }

        if (Input.GetMouseButtonUp(0))
        {
            slingDrawer.ResetLines();
            _clickInCircle = false;
            skullLauncher.Launch();
        }
    }

    private bool IsMouseInCircle()
    {
        return circleCollider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}