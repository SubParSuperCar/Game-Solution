using Avalonia.Data.Converters;

namespace Game.UI.Converters;

public sealed class BooleanToOnOffConverter() : FuncValueConverter<bool, string>(value => value ? "On" : "Off");
