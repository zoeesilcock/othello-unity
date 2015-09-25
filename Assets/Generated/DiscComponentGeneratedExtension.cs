using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public DiscComponent disc { get { return (DiscComponent)GetComponent(ComponentIds.Disc); } }

        public bool hasDisc { get { return HasComponent(ComponentIds.Disc); } }

        static readonly Stack<DiscComponent> _discComponentPool = new Stack<DiscComponent>();

        public static void ClearDiscComponentPool() {
            _discComponentPool.Clear();
        }

        public Entity AddDisc(bool newIsBlack) {
            var component = _discComponentPool.Count > 0 ? _discComponentPool.Pop() : new DiscComponent();
            component.isBlack = newIsBlack;
            return AddComponent(ComponentIds.Disc, component);
        }

        public Entity ReplaceDisc(bool newIsBlack) {
            var previousComponent = hasDisc ? disc : null;
            var component = _discComponentPool.Count > 0 ? _discComponentPool.Pop() : new DiscComponent();
            component.isBlack = newIsBlack;
            ReplaceComponent(ComponentIds.Disc, component);
            if (previousComponent != null) {
                _discComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemoveDisc() {
            var component = disc;
            RemoveComponent(ComponentIds.Disc);
            _discComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherDisc;

        public static AllOfMatcher Disc {
            get {
                if (_matcherDisc == null) {
                    _matcherDisc = new Matcher(ComponentIds.Disc);
                }

                return _matcherDisc;
            }
        }
    }
}
