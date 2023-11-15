using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheKiwiCoder {
    public class Log : ActionNode
    {
        public string message;
        public bool returnRunning = false;
        public bool returnSuccess = false;
        public bool returnFailure = false;

        protected override void OnStart() {
        }

        protected override void OnStop() {
        }

        protected override State OnUpdate() {
            Debug.Log($"{message}");
            if (returnRunning)
            {
                return State.Running;
            }
            if (returnSuccess)
            {
                return State.Success;
            }
            if (returnFailure)
            {
                return State.Failure;
            }
            return State.Success;
        }
    }
}
