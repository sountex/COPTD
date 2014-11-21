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
        _iam = GetComponent<HaveHitPoint>();
        _maxHP = _iam.HP;
    }

     /// <summary>
     /// Обрабортка события получения урона
     /// </summary>
    public void HaveHitPointIsDamaged()
    {
        if (_iam.HP < _maxHP / 4)//Присмерти
            GetComponent<SpriteRenderer>().color = Color.red;
    }
    /// <summary>
    /// Обработка события смерти
    /// </summary>
    public void HaveHitPointIsDead()
    {
        GetComponent<SpriteRenderer>().enabled = false;
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
