using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CellTemplate {
    public class ViewModel : ViewModelBase {
        public ViewModel() {
            Source = Places.GetPlaces();
        }
        public ObservableCollection<Place> Source { get; set; }
    }

    public class Place {
        public string Country { get; set; }
        public string City { get; set; }
        public List<string> Cities { get; set; }
    }
    public static class Places {
        public static ObservableCollection<Place> GetPlaces() {
            ObservableCollection<Place> places = new ObservableCollection<Place>();
            places.Add(new Place() { Country = "USA", City = "Washington, D.C.", Cities = new List<string> { "Washington, D.C.", "New York", "Los Angeles", "Las Vegas" } });
            places.Add(new Place() { Country = "Germany", City = "Berlin", Cities = new List<string> { "Berlin", "Munich", "Frankfurt" } });
            places.Add(new Place() { Country = "United Kingdom", City = "London", Cities = new List<string> { "London", "Birmingham" } });
            places.Add(new Place() { Country = "Canada", City = "Montreal", Cities = new List<string> { "Montreal", "Toronto" } });
            places.Add(new Place() { Country = "China", City = "Beijing", Cities = new List<string> { "Beijing", "Tianjin", "Shanghai", "Chongqing" } });
            return places;
        }
    }
}
