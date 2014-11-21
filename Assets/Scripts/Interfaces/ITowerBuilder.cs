using UnityEngine;

public interface ITowerBuilder
{
    void Build(int towerIndx, Vector3 position);

    bool ShowUI { get; set; }

    GameObject[] TowersForBuild { get; }
}
