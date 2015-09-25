public static class ComponentIds {
    public const int Disc = 0;
    public const int Position = 1;
    public const int Prefab = 2;
    public const int View = 3;

    public const int TotalComponents = 4;

    static readonly string[] components = {
        "Disc",
        "Position",
        "Prefab",
        "View"
    };

    public static string IdToString(int componentId) {
        return components[componentId];
    }
}

namespace Entitas {
    public partial class Matcher : AllOfMatcher {
        public Matcher(int index) : base(new [] { index }) {
        }

        public override string ToString() {
            return ComponentIds.IdToString(indices[0]);
        }
    }
}