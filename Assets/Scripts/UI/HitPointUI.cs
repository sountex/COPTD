using UnityEngine;

[RequireComponent(typeof(IHittable))]
public class HitPointUI : MonoBehaviour
{
    private IHittable _iam;
    private int _maxHP;

    public Vector3 ProgressBarOffset;
    public Texture2D ProgressBar;

    public void Awake()
    {
        _iam = GetComponent<IHittable>();
        _maxHP = _iam.HP;
    }

    public void OnGUI()
    {
        var pos = Camera.main.WorldToScreenPoint(gameObject.transform.position + ProgressBarOffset);
        float progress = (float) _iam.HP/_maxHP;
        GUI.DrawTextureWithTexCoords(
            new Rect(pos.x, Screen.height - pos.y - ProgressBar.height, ProgressBar.width * progress, ProgressBar.height),
            ProgressBar,
            new Rect(0, 0, 1f * progress, 1f), true);
    }
}
