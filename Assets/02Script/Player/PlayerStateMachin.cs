using System.Collections.Generic;

public enum States : byte 
{
    Idle, Move
}

public class PlayerStateMachin
{
    Dictionary<States, IState> _stateTable = new Dictionary<States, IState>();

    IState _currentState;

    public PlayerStateMachin()
    {
        //_stateTable.Add(States.Idle, new IState(States.Idle));
    }

    public void ChangeState(States state)
    {
        _currentState?.Exit();
        _currentState = _stateTable[state];
        _currentState.Enter();
    }

    public void StateUpdate()
    {
        _currentState.Update();
    }
}
