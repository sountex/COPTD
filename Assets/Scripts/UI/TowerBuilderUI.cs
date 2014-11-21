using UnityEngine;

[RequireComponent(typeof (ITowerBuilder))]
public class TowerBuilderUI : MonoBehaviour
{
    private ITowerBuilder _builder;
    private readonly Rect uiRect = new Rect(Screen.width/2, Screen.height/2, 150, 200);

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
            if (GUILayout.Button("Башня " + _builder.TowersForBuild[i].name))
            {
                selectTowerSpawnMode = true;
                selectTowerIndx = i;
            }
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
