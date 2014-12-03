using UnityEngine;
using System.Collections;

public class CommandRespawn : Command {


    public override void execute()
    {
        //_agent.Stop();
        //_agent.ResetPath();
        _agent.enabled = false;
        _parent.transform.position = _endPosition;
        _agent.enabled = true;
        _isComplete = true;
    }

    public override void start()
    {
    
    }
}
