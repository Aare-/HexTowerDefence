using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyMessenger;

class TinyTokenManager {
    private static TinyTokenManager _Instance;
    public static TinyTokenManager Instance {
        get {
            if (_Instance == null) _Instance = new TinyTokenManager();
            return _Instance;
        }
        private set {}
    }

    private Dictionary<String, TinyMessageSubscriptionToken> _CachedTokens;

    public TinyTokenManager() {
        _CachedTokens = new Dictionary<string, TinyMessageSubscriptionToken>();
    }
    public void Register<T>(String tag, Action<T> action) where T : class, ITinyMessage {
        _CachedTokens.Add(tag, 
            TinyMessengerHub.Instance
                .Subscribe<T>(action));
    }
    public void RegisterAndCallWithNull<T>(String tag, Action<T> action) where T : class, ITinyMessage {
        Register<T>(tag, action);
        action(null);
    }
    public void Unregister<T>(String tag) where T : class, ITinyMessage {
        if (_CachedTokens.ContainsKey(tag)) {
            TinyMessageSubscriptionToken token = _CachedTokens[tag];
            if (token != null) {
                _CachedTokens.Remove(tag);
                TinyMessengerHub.Instance.Unsubscribe<T>(token);
            }
        }
    }    
}
