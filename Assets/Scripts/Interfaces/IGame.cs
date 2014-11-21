
    public interface IGame
    {
        int WaveCounts { get; }
        int CurrentWave { get; }

        void StartGame();
        Game.GameResult Status { get; }
    }
