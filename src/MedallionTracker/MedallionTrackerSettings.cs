
// =======================================================
// MedallionTracker v1.0.0
// Author: Strafeous
// Description: Color-coded Incursion Medallion tracker
// =======================================================

using ExileCore2.Shared.Interfaces;
using ExileCore2.Shared.Nodes;
using System.Drawing;

namespace MedallionTracker
{
    public class MedallionTrackerSettings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);

        public ToggleNode DrawLine { get; set; } = new ToggleNode(true);
        public ToggleNode DrawPath { get; set; } = new ToggleNode(true);

        public ToggleNode Juatalotli { get; set; } = new ToggleNode(true);
        public ToggleNode Quipolatl { get; set; } = new ToggleNode(true);
        public ToggleNode Xopec { get; set; } = new ToggleNode(true);
        public ToggleNode Estazunti { get; set; } = new ToggleNode(true);
        public ToggleNode Zantipi { get; set; } = new ToggleNode(true);
        public ToggleNode Hayoxi { get; set; } = new ToggleNode(true);
        public ToggleNode Uromoti { get; set; } = new ToggleNode(true);
        public ToggleNode Azcapa { get; set; } = new ToggleNode(true);
        public ToggleNode Puhuarte { get; set; } = new ToggleNode(true);

        public ColorNode LineColor { get; set; } = new ColorNode(Color.Lime);
        public RangeNode<int> Thickness { get; set; } = new RangeNode<int>(3, 1, 10);
    }
}
