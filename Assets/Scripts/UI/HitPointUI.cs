using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IHittable))]
[DisallowMultipleComponent]
public class HitPointUI : MonoBehaviour
{
    private IHittable _iam;
    private int _maxHP;

    public Vector3 ProgressBarOffset;
    public Texture2D ProgressBar;

    private Rect pbPosition;
    private Rect pbSize;
    private float progress;

    public void Awake()
    {
        _iam = GetComponent<HaveHitPoint>();
        _maxHP = _iam.HP;
    }

    public void Start()
    {
        StartCoroutine(pbPositionUpdater());
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

    private IEnumerator pbPositionUpdater()
    {
        while (!_iam.IsDead)
        {
            progress = (float)_iam.HP / _maxHP;
            var pos = Camera.main.WorldToScreenPoint(gameObject.transform.position + ProgressBarOffset);
            pbPosition = new Rect(pos.x, Screen.height - pos.y - ProgressBar.height, ProgressBar.width * progress,
                ProgressBar.height);
            pbSize = new Rect(0, 0, 1f * progress, 1f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void OnGUI()
    {
        GUI.DrawTextureWithTexCoords(pbPosition, ProgressBar, pbSize, true);
    }
}
