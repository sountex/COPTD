using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Компонент основной бизнес-логики игры
/// </summary>
public class Game : MonoBehaviour, IGame
{
    [SerializeField]
    private int _waveCounts;
    /// <summary>
    /// Количество волн
    /// </summary>
    public int WaveCounts { get { return _waveCounts; } }
    
    private int _currentWave;
    /// <summary>
    /// Текущая волна
    /// </summary>
    public int CurrentWave { get { return _currentWave; } }

    /// <summary>
    /// Увеличение количества криптов с каждой волной
    /// </summary>
    [SerializeField]
    private int _criptsPerWave;
    /// <summary>
    /// Задержка между спауном врага
    /// </summary>
    [SerializeField]
    private float _spawnInterval = 0.3f;

    private bool gameIsEnd;

    private GameResult _status;
    /// <summary>
    /// Текущий статус игры - в процессе, проигрыш, выигрыш
    /// </summary>
    public GameResult Status { get { return _status; } }

    /// <summary>
    /// Прототип для инстанционирования первого типа - простой крипт
    /// </summary>
    public GameObject EnemyPrototypeOne;
    /// <summary>
    /// Прототип для инстанционирования второго типа - сильный крипт
    /// </summary>
    public GameObject EnemyPrototypeTwo;
    /// <summary>
    /// Точка спауна
    /// </summary>
    public Transform SpawnPoint;

    private List<IHittable> _allEnemies;
    private IHittable _keep;

    public enum GameResult
    {
        InProcess,
        Victory,
        Lose
    }

    public void Start()
    {
        _allEnemies = new List<IHittable>();
        _keep = GameObject.FindGameObjectWithTag("Keep").GetComponent<IHittable>();
        StartCoroutine(spawnEnemys());
        gameIsEnd = false;
        _status = GameResult.InProcess;
    }

    private void GameOver(GameResult result)
    {
        gameIsEnd = true;
        _status = result;
    }

    private IEnumerator spawnEnemys()
    {
        _currentWave += 1;
        _allEnemies.Clear();
        int count = _criptsPerWave * _currentWave;
        for (int i = 0; i < count; i++)
        {
            var enemy = Instantiate(i%2 == 0 ? EnemyPrototypeTwo : EnemyPrototypeOne);
            enemy.transform.position = SpawnPoint.position;
            _allEnemies.Add(enemy.GetComponent<IHittable>());
            yield return new WaitForSeconds(_spawnInterval);
        }
    }
    /// <summary>
    /// Основная логика игры - если дом уничтожен то проигрыш, если уничтожены все крипты но не последняя волна то спауним ещё,
    /// если волна последняя и дом не разрушен то победили.
    /// </summary>
    public void Update()
    {
        if(gameIsEnd) return;

        if(_keep.IsDead) 
            GameOver(GameResult.Lose);

        var allDead = _allEnemies.FindAll(enemy => enemy.IsDead);
        if (allDead.Count == _allEnemies.Count)
        {
            if(CurrentWave < WaveCounts)
                StartCoroutine(spawnEnemys());
            else
                GameOver(GameResult.Victory);
        }
    }
}
