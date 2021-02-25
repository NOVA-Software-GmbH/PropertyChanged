using System.Xml.Linq;
using Xunit;

public class OnlyWeaveIWeaveINotifyPropertyChangedConfigTests
{
    [Fact]
    public void False()
    {
        var xElement = XElement.Parse("<PropertyChanged OnlyWeaveIWeaveINotifyPropertyChanged='false'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ResolveOnlyWeaveIWeaveINotifyPropertyChangedConfig();
        Assert.False(moduleWeaver.OnlyWeaveIWeaveINotifyPropertyChanged);
    }

    [Fact]
    public void False0()
    {
        var xElement = XElement.Parse("<PropertyChanged OnlyWeaveIWeaveINotifyPropertyChanged='0'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ResolveOnlyWeaveIWeaveINotifyPropertyChangedConfig();
        Assert.False(moduleWeaver.OnlyWeaveIWeaveINotifyPropertyChanged);
    }

    [Fact]
    public void True()
    {
        var xElement = XElement.Parse("<PropertyChanged OnlyWeaveIWeaveINotifyPropertyChanged='True'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ResolveOnlyWeaveIWeaveINotifyPropertyChangedConfig();
        Assert.True(moduleWeaver.OnlyWeaveIWeaveINotifyPropertyChanged);
    }

    [Fact]
    public void True1()
    {
        var xElement = XElement.Parse("<PropertyChanged OnlyWeaveIWeaveINotifyPropertyChanged='1'/>");
        var moduleWeaver = new ModuleWeaver { Config = xElement };
        moduleWeaver.ResolveOnlyWeaveIWeaveINotifyPropertyChangedConfig();
        Assert.True(moduleWeaver.OnlyWeaveIWeaveINotifyPropertyChanged);
    }

    [Fact]
    public void Default()
    {
        var moduleWeaver = new ModuleWeaver();
        moduleWeaver.ResolveOnlyWeaveIWeaveINotifyPropertyChangedConfig();
        Assert.False(moduleWeaver.OnlyWeaveIWeaveINotifyPropertyChanged);
    }
}
