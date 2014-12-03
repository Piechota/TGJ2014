using UnityEngine;
using System.Collections;

public class CommandDie : Command {
    float _timeToReach = 0;

    public override void execute()
    {
        if (_currentTime > 0)
        {
            duringTime();
            return;
        }
        //_parent.GetComponent<MeshRenderer>().enabled = false;
        _isComplete = true;
    }



    public override void start()
    {
        _agent.SetDestination(_endPosition);
        _agent.speed = 0;
        _timeToReach = _time;
    }

    public override void duringTime()
    {
        base.duringTime();

        //WALK PART
        if (_agent.remainingDistance > 0)
            _timeToReach -= Time.deltaTime;

        float pathLenght = 0;
        if (_agent.path.corners.Length > 0)
        {
            for (int i = 0; i < _agent.path.corners.Length - 1; i++)
            {
                pathLenght += Vector3.Distance(_agent.path.corners[i], _agent.path.corners[i + 1]);
            }
        }

        if (_timeToReach != 0)
        {
            _agent.speed = pathLenght / _timeToReach;
            _agent.acceleration = 2 * _agent.speed;
        }
        //////////
    }
}
