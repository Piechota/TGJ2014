using UnityEngine;
using System.Collections;

    public interface ICommand
    {
        Vector3 endPosition { set; get; }
        float time { set; get; }
        bool isComplete { get; set; }

        GameObject parent { set; }

        void execute();
        void start();
        void duringTime();
    }
