using System.ComponentModel;

public class ClassWithIWeaveINotifyPropertyChanged : IWeaveINotifyPropertyChanged
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}

public class ClassWithINotifyPropertyChanged : INotifyPropertyChanged
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;
}