using DevExpress.Mvvm;
using DevExpress.Xpf.Editors;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;


namespace CellTemplate {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        protected ObservableCollection<CountryCities> _Items;

        public ObservableCollection<CountryCities> Items {
            get {
                if(this._Items == null) {
                    this._Items = new ObservableCollection<CountryCities>();
                    
                    CountryCities usa = new CountryCities() {
                        Country = "USA",
                        Cities = new List<string> { "Washington, D.C.", "New York", "Los Angeles", "Las Vegas" },
                        City = "Los Angeles"
                    };
                    this._Items.Add(usa);

                    CountryCities germany = new CountryCities() {
                        Country = "Germany",
                        Cities = new List<string> { "Berlin", "Munich", "Frankfurt" },
                        City = "Munich"
                    };
                    this._Items.Add(germany);

                    CountryCities uk = new CountryCities() {
                        Country = "United Kingdom",
                        Cities = new List<string> { "London", "Birmingham" },
                        City = "London"
                    };
                    this._Items.Add(uk);

                    CountryCities canada = new CountryCities() {
                        Country = "Canada",
                        Cities = new List<string> { "Montreal", "Toronto" },
                        City = "Montreal"
                    };
                    this._Items.Add(canada);

                    CountryCities china = new CountryCities() {
                        Country = "China",
                        Cities = new List<string> { "Beijing", "Tianjin", "Shanghai", "Chongqing" },
                        City = "Beijing"
                    };
                    this._Items.Add(china);
                }
                return this._Items;
            }
        }

        public class CountryCities : BindableBase {
            protected string _Country;
            public string Country {
                get { return this._Country; }
                set { this.SetProperty(ref this._Country, value, "Country"); }
            }

            protected List<string> _Cities;
            public List<string> Cities {
                get { return this._Cities; }
                set { this.SetProperty(ref this._Cities, value, "Cities"); }
            }

            protected string _City;
            public string City {
                get { return this._City; }
                set { this.SetProperty(ref this._City, value, "City"); }
            }
        }

        void TableView_ProcessEditorActivationAction(object sender, DevExpress.Xpf.Grid.ProcessEditorActivationActionEventArgs e) {
            if (e.Column.FieldName == "City" && (e.ActivationAction == ActivationAction.MouseLeftButtonDown && e.MouseLeftButtonEventArgs.LeftButton == System.Windows.Input.MouseButtonState.Pressed))
                e.RaiseEventAgain = true;
        }

        void TableView_GetActiveEditorNeedsKey(object sender, DevExpress.Xpf.Grid.GetActiveEditorNeedsKeyEventArgs e) {
            if (e.Column.FieldName == "City" && (e.Key == System.Windows.Input.Key.Up || e.Key == System.Windows.Input.Key.Down))
                e.NeedsKey = true;
        }
    }
}
