using System.Linq;
using System.Xml;

public partial class ModuleWeaver
{
    public bool OnlyWeaveIWeaveINotifyPropertyChanged;

    public void ResolveOnlyWeaveIWeaveINotifyPropertyChangedConfig()
    {
        var value = Config?.Attributes("OnlyWeaveIWeaveINotifyPropertyChanged")
            .Select(a => a.Value)
            .SingleOrDefault();
        if (value != null)
        {
            OnlyWeaveIWeaveINotifyPropertyChanged = XmlConvert.ToBoolean(value.ToLowerInvariant());
        }
    }
}
