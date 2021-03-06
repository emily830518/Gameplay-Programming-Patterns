﻿//most are taken from our course example Events
public class ScoreChanged : GameEvent
{
    public int NewScore { get; }

    public ScoreChanged(int newScore)
    {
        NewScore = newScore;
    }
}

public class LifeChanged : GameEvent
{
    public int NewLife { get; }

    public LifeChanged(int newLife)
    {
        NewLife = newLife;
    }
}

public class PlayerDied : GameEvent { }

public class PlayerWin : GameEvent { }

public class EnemyDied : GameEvent
{
    public int PointValue { get; }

    public EnemyDied(int value)
    {
        PointValue = value;
    }
}

public class GameStateChanged : GameEvent
{
    public GameState State { get; }
    public int FinalScore { get; }

    public GameStateChanged(GameState state, int finalScore)
    {
        State = state;
        FinalScore = finalScore;
    }
}