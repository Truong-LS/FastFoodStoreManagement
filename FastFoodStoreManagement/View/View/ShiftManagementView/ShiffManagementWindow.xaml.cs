using System.Windows;
using System.Windows.Controls;
using Models;
using Services.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System;

namespace View
{
    /// <summary>
    /// Interaction logic for ShiffManagementWindow.xaml
    /// </summary>
    public partial class ShiffManagementWindow : UserControl, INotifyPropertyChanged
    {
        private readonly ShiftService _shiftService;
        private readonly UserShiftService _userShiftService;

        private ObservableCollection<UserShifts> _userShiftsList;
        public ObservableCollection<UserShifts> UserShiftsList
        {
            get { return _userShiftsList; }
            set
            {
                _userShiftsList = value;
                OnPropertyChanged(nameof(UserShiftsList));
            }
        }

        private ObservableCollection<int> _daysList;
        public ObservableCollection<int> DaysList
        {
            get { return _daysList; }
            set
            {
                _daysList = value;
                OnPropertyChanged(nameof(DaysList));
            }
        }

        private ObservableCollection<int> _monthsList;
        public ObservableCollection<int> MonthsList
        {
            get { return _monthsList; }
            set
            {
                _monthsList = value;
                OnPropertyChanged(nameof(MonthsList));
            }
        }

        private ObservableCollection<int> _yearsList;
        public ObservableCollection<int> YearsList
        {
            get { return _yearsList; }
            set
            {
                _yearsList = value;
                OnPropertyChanged(nameof(YearsList));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ShiffManagementWindow()
        {
            InitializeComponent();
            _shiftService = new ShiftService();
            _userShiftService = new UserShiftService();
            this.DataContext = this; // Set DataContext to itself for binding

            PopulateDateComboBoxes();
            LoadUserShifts();
        }

        private void PopulateDateComboBoxes()
        {
            DaysList = new ObservableCollection<int>();
            DaysList.Add(0); // Placeholder for "Ngày"
            for (int i = 1; i <= 31; i++)
            {
                DaysList.Add(i);
            }

            MonthsList = new ObservableCollection<int>();
            MonthsList.Add(0); // Placeholder for "Tháng"
            for (int i = 1; i <= 12; i++)
            {
                MonthsList.Add(i);
            }

            YearsList = new ObservableCollection<int>();
            YearsList.Add(0); // Placeholder for "Năm"
            int currentYear = DateTime.Now.Year;
            for (int i = currentYear - 5; i <= currentYear + 5; i++)
            {
                YearsList.Add(i);
            }
        }

        private void LoadUserShifts()
        {
            var userShifts = _userShiftService.GetAllUserShifts();
            UserShiftsList = new ObservableCollection<UserShifts>(userShifts);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int? day = cmbDay.SelectedIndex > 0 ? (int?)cmbDay.SelectedItem : null;
            int? month = cmbMonth.SelectedIndex > 0 ? (int?)cmbMonth.SelectedItem : null;
            int? year = cmbYear.SelectedIndex > 0 ? (int?)cmbYear.SelectedItem : null;

            if (!day.HasValue && !month.HasValue && !year.HasValue)
            {
                // If no filters selected, load all shifts
                LoadUserShifts();
                return;
            }

            var filteredUserShifts = _userShiftService.SearchUserShiftsByDate(day, month, year);
            UserShiftsList = new ObservableCollection<UserShifts>(filteredUserShifts);
        }

        private void ResetSearch_Click(object sender, RoutedEventArgs e)
        {
            cmbDay.SelectedIndex = 0;
            cmbMonth.SelectedIndex = 0;
            cmbYear.SelectedIndex = 0;
            LoadUserShifts();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new CreateShiffWindow { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                // TODO: Implement logic to get data from CreateShiffWindow and add a new shift.
                // For now, just reload data.
                LoadUserShifts();
            }
        }

        private void EditUserShift_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var userShift = (UserShifts)button.DataContext;

            var dlg = new UpdateShiffWindow(userShift) { Owner = Window.GetWindow(this) };
            if (dlg.ShowDialog() == true)
            {
                LoadUserShifts();
            }
        }

        private void DeleteUserShift_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var userShift = (UserShifts)button.DataContext;

            if (MessageBox.Show("Are you sure you want to delete this user shift?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _userShiftService.DeleteUserShift(userShift.UserShiftId);
                LoadUserShifts(); // Reload data after deletion
            }
        }
    }
}

