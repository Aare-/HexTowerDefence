using UnityEngine;
using System.Collections;

public class Msg {
    public class MLoadGame : TinyMessenger.ITinyMessage {
        #region Implementation
        public MLoadGame() {}
        public object Sender {
            get {
                return null;
            }
        }
        #endregion
    }	
}
