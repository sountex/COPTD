using UnityEngine;
[DisallowMultipleComponent]
[AddComponentMenu("TDCore/TowerBuilder")]
public class TowerBuilder : MonoBehaviour, ITowerBuilder
{
    /// <summary>
    /// Максимальное количество башен для постройки
    /// </summary>
    [SerializeField] private int _maxTowersCount;

    private int builedTowerCount;

    [SerializeField]
    private GameObject[] _towersForBuild;

    public GameObject[] TowersForBuild
    {
        get { return _towersForBuild; }
    }

    public bool ShowUI { get; set; }

    public void Build(int towerIndx, Vector3 position)
    {
        var towerInst = Instantiate(_towersForBuild[towerIndx], position, Quaternion.identity) as GameObject;
        towerInst.transform.parent = this.transform;
        builedTowerCount++;
        //Все башни построены
        if (builedTowerCount == _maxTowersCount)
        {
            ShowUI = false;
            SendMessageUpwards("OnTowersIsBuild");
        }
    }
}
