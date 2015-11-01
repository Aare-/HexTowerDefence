using UnityEngine;
using System.Collections;

public class Msg {
    public class MDummyMsg : TinyMessenger.ITinyMessage {
        #region Implementation
        public MDummyMsg() { }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }
    public class SpawnBasicEnemy : TinyMessenger.ITinyMessage {
        #region Implementation
        public SpawnBasicEnemy() { }
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }	
}
