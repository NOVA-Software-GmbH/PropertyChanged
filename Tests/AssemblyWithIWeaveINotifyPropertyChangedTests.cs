using System.ComponentModel;
using Fody;
using Xunit;

public class AssemblyWithIWeaveINotifyPropertyChangedTests
{
    [Fact]
    public void WeaveWithoutOnlyWeaveIWeaveINotifyPropertyChangedOption()
    {
        var weavingTask = new ModuleWeaver();
        var testResult = weavingTask.ExecuteTestRun(
            "AssemblyWithIWeaveINotifyPropertyChanged.dll", 
            runPeVerify: false);

        var assembly = testResult.Assembly;
        
        var classWithIWeaveINotifyPropertyChangedInstance = assembly.GetInstance("ClassWithIWeaveINotifyPropertyChanged");
        TestProperty(classWithIWeaveINotifyPropertyChangedInstance, true);

        var classWithINotifyPropertyChangedInstance = assembly.GetInstance("ClassWithINotifyPropertyChanged");
        TestProperty(classWithINotifyPropertyChangedInstance, true);
    }

    [Fact]
    public void WeaveWithOnlyWeaveIWeaveINotifyPropertyChangedOption()
    {
        var weavingTask = new ModuleWeaver();
        
        weavingTask.OnlyWeaveIWeaveINotifyPropertyChanged = true;

        var testResult = weavingTask.ExecuteTestRun(
            "AssemblyWithIWeaveINotifyPropertyChanged.dll",
            runPeVerify: false);

        var assembly = testResult.Assembly;

        var classWithIWeaveINotifyPropertyChangedInstance = assembly.GetInstance("ClassWithIWeaveINotifyPropertyChanged");
        TestProperty(classWithIWeaveINotifyPropertyChangedInstance, true);

        var classWithINotifyPropertyChangedInstance = assembly.GetInstance("ClassWithINotifyPropertyChanged");
        TestProperty(classWithINotifyPropertyChangedInstance, false);
    }

    private void TestProperty(dynamic instance, bool assertPropertyChangedEventCalled)
    {
        var property1EventCalled = false;
        var property2EventCalled = false;

        ((INotifyPropertyChanged)instance).PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == "Property1")
            {
                property1EventCalled = true;
            }

            if (args.PropertyName == "Property2")
            {
                property2EventCalled = true;
            }
        };

        instance.Property1 = "a";
        instance.Property2 = "b";

        if (assertPropertyChangedEventCalled)
        {
            Assert.True(property1EventCalled);
            Assert.True(property2EventCalled);
        }
        else
        {
            Assert.False(property1EventCalled);
            Assert.False(property2EventCalled);
        }
    }
}