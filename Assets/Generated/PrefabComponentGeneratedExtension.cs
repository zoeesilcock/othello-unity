using System.Collections.Generic;

namespace Entitas {
    public partial class Entity {
        public PrefabComponent prefab { get { return (PrefabComponent)GetComponent(ComponentIds.Prefab); } }

        public bool hasPrefab { get { return HasComponent(ComponentIds.Prefab); } }

        static readonly Stack<PrefabComponent> _prefabComponentPool = new Stack<PrefabComponent>();

        public static void ClearPrefabComponentPool() {
            _prefabComponentPool.Clear();
        }

        public Entity AddPrefab(UnityEngine.GameObject newGameObject) {
            var component = _prefabComponentPool.Count > 0 ? _prefabComponentPool.Pop() : new PrefabComponent();
            component.gameObject = newGameObject;
            return AddComponent(ComponentIds.Prefab, component);
        }

        public Entity ReplacePrefab(UnityEngine.GameObject newGameObject) {
            var previousComponent = hasPrefab ? prefab : null;
            var component = _prefabComponentPool.Count > 0 ? _prefabComponentPool.Pop() : new PrefabComponent();
            component.gameObject = newGameObject;
            ReplaceComponent(ComponentIds.Prefab, component);
            if (previousComponent != null) {
                _prefabComponentPool.Push(previousComponent);
            }
            return this;
        }

        public Entity RemovePrefab() {
            var component = prefab;
            RemoveComponent(ComponentIds.Prefab);
            _prefabComponentPool.Push(component);
            return this;
        }
    }

    public partial class Matcher {
        static AllOfMatcher _matcherPrefab;

        public static AllOfMatcher Prefab {
            get {
                if (_matcherPrefab == null) {
                    _matcherPrefab = new Matcher(ComponentIds.Prefab);
                }

                return _matcherPrefab;
            }
        }
    }
}
