using UnityEngine;
using System.Collections.Generic;

public class TriggerSimplex : MonoBehaviour
{
    [System.Serializable]
    public struct FunctionCallsStruct {
        public GameObject targetObject;
        public List<string> triggerEnterCalls;
        public List<string> triggerExitCalls;
    }

    public List<FunctionCallsStruct> calls;
    

    private void OnTriggerEnter(Collider other) {
        if (other.tag!="Player") {
            return;
        }
        // Debug.Log(other.tag+" "+other.gameObject.name+" trigger object name: "+gameObject.name);

        for (int i=0; i<calls.Count; i++) {
            List<string> triggerEnterCalls = calls[i].triggerEnterCalls;
            GameObject targetObject = calls[i].targetObject;
            if (triggerEnterCalls!=null && triggerEnterCalls.Count>0) {
                for (int j=0; j<triggerEnterCalls.Count; j++) {
                    targetObject.SendMessage(triggerEnterCalls[j]);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag!="Player") {
            return;
        }
        for (int i=0; i<calls.Count; i++) {
            List<string> triggerExitCalls = calls[i].triggerExitCalls;
            GameObject targetObject = calls[i].targetObject;
            if (triggerExitCalls!=null && triggerExitCalls.Count>0) {
                for (int j=0; j<triggerExitCalls.Count; j++) {
                    targetObject.SendMessage(triggerExitCalls[j]);
                }
            }
        }
    }

}
