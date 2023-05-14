using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;


namespace WpfMvvmArchitecture101.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        private ObservableCollection<WpfMvvmArchitecture101.Model.EuropeanCallOption>? _ListOfEuropeanCallOptions;
        public ObservableCollection<WpfMvvmArchitecture101.Model.EuropeanCallOption>? pListOfEuropeanCallOptions
        {
            get => _ListOfEuropeanCallOptions;
            set => SetProperty(ref _ListOfEuropeanCallOptions, value);
        }
        private WpfMvvmArchitecture101.Model.EuropeanCallOption? _SelectedEuropeanCallOptions;
        public WpfMvvmArchitecture101.Model.EuropeanCallOption? pSelectedEuropeanCallOptions 
        { 
            get=> _SelectedEuropeanCallOptions; 
            set=>SetProperty(ref _SelectedEuropeanCallOptions, value); 
        }
        private int? _SelectedEuropeanCallOptionsIndex;
        public int? pSelectedEuropeanCallOptionsIndex
        {
            get => _SelectedEuropeanCallOptionsIndex;
            set => SetProperty(ref _SelectedEuropeanCallOptionsIndex, value);
        }
        public ICommand EuropeanCallPriceComputeCommand { get; }
        public ICommand MsgBoxCommand { get; }
        public MainWindowViewModel()
        {
            //SelectedEuropeanCallOptions = new Model.EuropeanCallOption();
            _ListOfEuropeanCallOptions = new ObservableCollection<WpfMvvmArchitecture101.Model.EuropeanCallOption>();
            for (int i = 1; i <= 10; i++)
            {
                WpfMvvmArchitecture101.Model.EuropeanCallOption opt = new WpfMvvmArchitecture101.Model.EuropeanCallOption();
                opt.K = opt.K + i;
                // le point d'exclatation devant la variable permet de forcer le compilateur a ne pas la considérer comme un possible null
                _ListOfEuropeanCallOptions.Add(opt);

            }
            EuropeanCallPriceComputeCommand = new RelayCommand(EuropeanCallPriceCompute);
            MsgBoxCommand = new RelayCommand(MsgBoxCommandCompute);
        }

        public void MsgBoxCommandCompute()
        {
            MessageBox.Show("Please select an Compute Option to compute its price");
        }

        public void EuropeanCallPriceCompute()
        {
            if(_SelectedEuropeanCallOptions is not null)
            {
                //MessageBox.Show("_SelectedEuropeanCallOptionsIndex ", _SelectedEuropeanCallOptionsIndex.Value.ToString(), " / _ListOfEuropeanCallOptions.IndexOf(pSelectedEuropeanCallOptions).ToString() ", _ListOfEuropeanCallOptions.IndexOf(pSelectedEuropeanCallOptions).ToString());
                _ListOfEuropeanCallOptions![_ListOfEuropeanCallOptions.IndexOf(_SelectedEuropeanCallOptions)].PriceComputation();
                //MessageBox.Show(_ListOfEuropeanCallOptions.IndexOf(pSelectedEuropeanCallOptions).ToString());
            }
            else
            {
                MessageBox.Show("Please select an Compute Option to compute its price");
            }
        }
    }
}
