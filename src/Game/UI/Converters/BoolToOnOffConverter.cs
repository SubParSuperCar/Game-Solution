using Avalonia.Data.Converters;

namespace Game.UI.Converters;

public sealed class BoolToOnOffConverter() : FuncValueConverter<bool, string>(value => value ? "On" : "Off");
