using UnityEngine;
using System.Collections;

    public abstract class Command : ICommand
    {
        // Protected var
        protected Vector3 _endPosition;
        protected float _time;
        protected float _currentTime;
        protected bool _isComplete;
        protected GameObject _parent;
        protected NavMeshAgent _agent;

        //Properitis
        public Vector3 endPosition
        {
            set { _endPosition = value; }
            get { return _endPosition; }
        }

        public float time
        {
            set { _time = value; _currentTime = _time;}
            get { return _time; }
        }

        public bool isComplete
        {
            get { return _isComplete; }
            set { _isComplete = value; _currentTime = _time; }
        }

        public GameObject parent
        {
            set 
            { 
                _parent = value;
                _agent = _parent.GetComponent<NavMeshAgent>();
            }
        }

        //Method
        public abstract void execute();
        public abstract void start();
        public virtual void duringTime()
        {
            _currentTime -= Time.deltaTime;
        }
    }

