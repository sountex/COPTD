using UnityEngine;

[RequireComponent(typeof (IGame))]
public class GameUI : MonoBehaviour
{
    private IGame _game;

    public void Awake()
    {
        _game = GetComponent<IGame>();
    }
    public void OnGUI()
    {
        GUILayout.Label(string.Format("Волна {0} из {1}", _game.CurrentWave, _game.WaveCounts));
        if (_game.Status != Game.GameResult.InProcess)
            GUILayout.Label(string.Format("Игра окончена. Вы {0} ", _game.Status == Game.GameResult.Victory ? "выиграли":"проиграли"));
    }
}
