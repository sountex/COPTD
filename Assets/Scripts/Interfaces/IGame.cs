
    public interface IGame
    {
        int WaveCounts { get; }
        int CurrentWave { get; }

        Game.GameResult Status { get; }
    }
