using UnityEngine;

[RequireComponent(typeof (ITowerBuilder))]
[DisallowMultipleComponent]
public class TowerBuilderUI : MonoBehaviour
{
    private ITowerBuilder _builder;
    private const float towerInfoWindowWidth = 250;
    private const float towerInfoWindowHeight = 450;
    private readonly Rect uiRect = new Rect(Screen.width / 2 - towerInfoWindowWidth/2, Screen.height / 2 - towerInfoWindowHeight/2, towerInfoWindowWidth, towerInfoWindowHeight);

    private bool selectTowerSpawnMode = false;
    private int selectTowerIndx;

    public void Awake()
    {
        _builder = GetComponent<TowerBuilder>();
    }

    public void OnGUI()
    {
        if (!_builder.ShowUI) return;
        //В режиме выбора места для постройки башни скрываем ui выбора башни
        if (selectTowerSpawnMode)
            selectTowerPlace();
        else
            drawTowersBtns();
    }

    private void drawTowersBtns()
    {
        GUILayout.BeginArea(uiRect);
        GUILayout.Label("Выберите башню для постройки, и укажите где её построить");
        for (int i = 0; i < _builder.TowersForBuild.Length; i++)
        {
            var tower = _builder.TowersForBuild[i];
            GUILayout.BeginVertical();
            GUILayout.Label(string.Format("Башня {0}", tower.name));
            GUILayout.Label(string.Format("Радиус действия: {0}", tower.GetComponent<CircleCollider2D>().radius));
            GUILayout.Label(string.Format("Урон: {0} ед каждые {1} сек", tower.GetComponent<InflictDamage>().DamageValue, tower.GetComponent<InflictDamage>().Cooldown));
            if (tower.GetComponent<WeekCriptSelector>() != null)
                GUILayout.Label("Особенность: В первую очередь атакует самую слабую цель из доступных");
            if (GUILayout.Button("Построить"))
            {
                selectTowerSpawnMode = true;
                selectTowerIndx = i;
            }
            GUILayout.EndVertical();
        }
        GUILayout.EndArea();
    }

    private void selectTowerPlace()
    {
        if (Event.current.type != EventType.Repaint) return;
        if (Input.GetMouseButton(0))
        {
            var rc = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), -Vector2.up);
            if (rc.collider != null && rc.collider.tag == "TowerPlace")
            {
                selectTowerSpawnMode = false;
                _builder.Build(selectTowerIndx, rc.collider.gameObject.transform.position);
            }
        }
    }
}
