using System;
using System.Windows;
using Models;
using Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Interaction logic for CreateShiffWindow.xaml
    /// </summary>
    public partial class CreateShiffWindow : Window, INotifyPropertyChanged
    {
        public Shifts NewShift { get; set; }
        public UserShifts NewUserShift { get; set; }

        private readonly ShiftService _shiftService;
        private readonly UserShiftService _userShiftService;
        private readonly UserService _userService;

        private ObservableCollection<Users> _usersList;
        public ObservableCollection<Users> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged(nameof(UsersList));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CreateShiffWindow()
        {
            InitializeComponent();
            NewShift = new Shifts { IsActive = 1 }; // Default to active
            NewUserShift = new UserShifts();

            _shiftService = new ShiftService();
            _userShiftService = new UserShiftService();
            _userService = new UserService();

            this.DataContext = this; // Set DataContext for binding
            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = _userService.GetAllUsers();
            UsersList = new ObservableCollection<Users>(users);
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Combine DatePicker and TextBox values for StartTime and EndTime
                if (dpStartTime.SelectedDate.HasValue && !string.IsNullOrEmpty(txtStartTimeHour.Text) && !string.IsNullOrEmpty(txtStartTimeMinute.Text))
                {
                    NewShift.StartTime = dpStartTime.SelectedDate.Value.Date +
                                         new TimeSpan(int.Parse(txtStartTimeHour.Text), int.Parse(txtStartTimeMinute.Text), 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid Start Time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (dpEndTime.SelectedDate.HasValue && !string.IsNullOrEmpty(txtEndTimeHour.Text) && !string.IsNullOrEmpty(txtEndTimeMinute.Text))
                {
                    NewShift.EndTime = dpEndTime.SelectedDate.Value.Date +
                                       new TimeSpan(int.Parse(txtEndTimeHour.Text), int.Parse(txtEndTimeMinute.Text), 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid End Time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Set ShiftNum (you might want to derive this based on StartTime or other logic)
                NewUserShift.ShiftNum = 1; // Example: Set a default ShiftNum

                // Combine DatePicker and TextBox values for CheckIn and CheckOut
                if (dpWorkDate.SelectedDate.HasValue && !string.IsNullOrEmpty(txtCheckInHour.Text) && !string.IsNullOrEmpty(txtCheckInMinute.Text))
                {
                    NewUserShift.CheckIn = dpWorkDate.SelectedDate.Value.Date +
                                           new TimeSpan(int.Parse(txtCheckInHour.Text), int.Parse(txtCheckInMinute.Text), 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid Check In time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (dpWorkDate.SelectedDate.HasValue && !string.IsNullOrEmpty(txtCheckOutHour.Text) && !string.IsNullOrEmpty(txtCheckOutMinute.Text))
                {
                    NewUserShift.CheckOut = dpWorkDate.SelectedDate.Value.Date +
                                            new TimeSpan(int.Parse(txtCheckOutHour.Text), int.Parse(txtCheckOutMinute.Text), 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid Check Out time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Validate UserId from ComboBox
                if (cmbUser.SelectedValue == null)
                {
                    MessageBox.Show("Please select a User.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                NewUserShift.UserId = (int)cmbUser.SelectedValue;

                _shiftService.AddShift(NewShift);
                NewUserShift.ShiftId = NewShift.ShiftId; // Link UserShift to the newly created Shift
                _userShiftService.AddUserShift(NewUserShift);

                this.DialogResult = true;
                this.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for hour and minute.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating shift: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
            }
        }
    }
}
