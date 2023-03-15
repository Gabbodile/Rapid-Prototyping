using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proto2 : GameBehaviour
{
    public GameState gameState;

    public void ChangeGameState(GameState _gameState)
    {
        gameState = _gameState;
    }
}
