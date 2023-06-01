using UnityEngine;


public class SlingDrawer : MonoBehaviour //рисует линию от начала резинки до черепа
{
    [SerializeField] private LineRenderer backLineRenderer;
    [SerializeField] private LineRenderer frontLineRenderer;
    [SerializeField] private Transform backSlingAnchor;
    [SerializeField] private Transform frontSlingAnchor;

    private Transform _skull;

    private void Awake()
    {
        _skull = GetComponent<Transform>();
    }

    public void Draw()
    {
        DrawLines(frontLineRenderer, frontSlingAnchor);
        DrawLines(backLineRenderer, backSlingAnchor);
    }

    private void DrawLines(LineRenderer lineRenderer, Transform slingAnchor)
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, slingAnchor.position);
        lineRenderer.SetPosition(1, _skull.position);
    }

    public void ResetLines()
    {
        backLineRenderer.positionCount = 0;
        frontLineRenderer.positionCount = 0;
    }
}