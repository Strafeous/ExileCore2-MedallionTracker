
// =======================================================
// MedallionTracker v1.0.0
// Author: Strafeous
// Description: Color-coded Incursion Medallion tracker
// =======================================================

using ExileCore2;
using ExileCore2.PoEMemory.MemoryObjects;
using System.Linq;
using Color = System.Drawing.Color;

namespace MedallionTracker
{
    public class MedallionTracker : BaseSettingsPlugin<MedallionTrackerSettings>
    {
        private Entity _currentMedallion;
        private Color _currentColor = Color.Lime;

        public override bool Initialise() => true;

        private bool IsEnabledByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;

            if (name.Contains("Juatalotli") && Settings.Juatalotli) return true;
            if (name.Contains("Quipolatl") && Settings.Quipolatl) return true;
            if (name.Contains("Xopec") && Settings.Xopec) return true;
            if (name.Contains("Estazunti") && Settings.Estazunti) return true;
            if (name.Contains("Zantipi") && Settings.Zantipi) return true;
            if (name.Contains("Hayoxi") && Settings.Hayoxi) return true;
            if (name.Contains("Uromoti") && Settings.Uromoti) return true;
            if (name.Contains("Azcapa") && Settings.Azcapa) return true;
            if (name.Contains("Puhuarte") && Settings.Puhuarte) return true;

            return false;
        }

        private Color GetColor(string name)
        {
            if (string.IsNullOrEmpty(name)) return Color.Lime;

            if (name.Contains("Juatalotli")) return Color.Red;
            if (name.Contains("Quipolatl")) return Color.Lime;
            if (name.Contains("Xopec")) return Color.Cyan;
            if (name.Contains("Estazunti")) return Color.Purple;
            if (name.Contains("Zantipi")) return Color.Yellow;
            if (name.Contains("Hayoxi")) return Color.Orange;
            if (name.Contains("Uromoti")) return Color.White;
            if (name.Contains("Azcapa")) return Color.Aqua;
            if (name.Contains("Puhuarte")) return Color.DeepPink;

            return Color.Lime;
        }

        public override void Tick()
        {
            if (!Settings.Enable) return;

            var player = GameController.Player;
            if (player == null) return;

            _currentMedallion = GameController.Entities
                .FirstOrDefault(e =>
                    e.Path != null &&
                    e.Path.Contains("Incursion/Objects/Medallions") &&
                    e.IsValid &&
                    !e.IsHidden &&
                    e.IsTargetable &&
                    e.DistancePlayer > 5f &&
                    IsEnabledByName(e.RenderName));

            _currentColor = _currentMedallion != null ? GetColor(_currentMedallion.RenderName) : Color.Lime;
        }

        public override void Render()
        {
            if (!Settings.Enable) return;
            if (_currentMedallion == null || !_currentMedallion.IsValid) return;

            var player = GameController.Player;
            if (player == null) return;

            var camera = GameController.Game.IngameState.Camera;

            var medallionScreen = camera.WorldToScreen(_currentMedallion.Pos);
            var playerScreen = camera.WorldToScreen(player.Pos);

            if (Settings.DrawLine)
                Graphics.DrawLine(playerScreen, medallionScreen, Settings.Thickness.Value, _currentColor);

            if (Settings.DrawPath)
            {
                var direction = _currentMedallion.Pos - player.Pos;
                const int segments = 20;

                for (int i = 1; i <= segments; i++)
                {
                    var step = player.Pos + (direction * (i / (float)segments));
                    var stepScreen = camera.WorldToScreen(step);
                    Graphics.DrawCircle(stepScreen, 3, _currentColor);
                }
            }
        }
    }
}
