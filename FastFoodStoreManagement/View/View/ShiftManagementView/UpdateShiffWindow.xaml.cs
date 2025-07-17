using System;
using System.Windows;
using Models;
using Services.Services;
using System.Linq;
using System.ComponentModel;

namespace View
{
    /// <summary>
    /// Interaction logic for UpdateShiffWindow.xaml
    /// </summary>
    public partial class UpdateShiffWindow : Window, INotifyPropertyChanged
    {
        public Shifts CurrentShift { get; set; }
        public UserShifts CurrentUserShift { get; set; }

        public int? StartTimeHour { get; set; }
        public int? StartTimeMinute { get; set; }
        public int? EndTimeHour { get; set; }
        public int? EndTimeMinute { get; set; }
        public int? CheckInHour { get; set; }
        public int? CheckInMinute { get; set; }
        public int? CheckOutHour { get; set; }
        public int? CheckOutMinute { get; set; }

        private readonly ShiftService _shiftService;
        private readonly UserShiftService _userShiftService;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public UpdateShiffWindow(UserShifts userShiftToUpdate)
        {
            InitializeComponent();
            _shiftService = new ShiftService();
            _userShiftService = new UserShiftService();

            CurrentUserShift = userShiftToUpdate;
            CurrentShift = userShiftToUpdate.Shift;

            // Populate temporary properties for binding
            StartTimeHour = CurrentShift.StartTime?.Hour;
            StartTimeMinute = CurrentShift.StartTime?.Minute;
            EndTimeHour = CurrentShift.EndTime?.Hour;
            EndTimeMinute = CurrentShift.EndTime?.Minute;
            CheckInHour = CurrentUserShift.CheckIn?.Hour;
            CheckInMinute = CurrentUserShift.CheckIn?.Minute;
            CheckOutHour = CurrentUserShift.CheckOut?.Hour;
            CheckOutMinute = CurrentUserShift.CheckOut?.Minute;

            this.DataContext = this;

            // --- DEBUGGING START ---
            // MessageBox.Show($"CurrentShift.StartTime: {CurrentShift.StartTime?.ToString("HH:mm") ?? "null"}", "Debug StartTime");
            // MessageBox.Show($"CurrentShift.EndTime: {CurrentShift.EndTime?.ToString("HH:mm") ?? "null"}", "Debug EndTime");
            // MessageBox.Show($"CurrentUserShift.CheckIn: {CurrentUserShift.CheckIn?.ToString("HH:mm") ?? "null"}", "Debug CheckIn");
            // MessageBox.Show($"CurrentUserShift.CheckOut: {CurrentUserShift.CheckOut?.ToString("HH:mm") ?? "null"}", "Debug CheckOut");
            // --- DEBUGGING END ---
        }

        private async void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Combine DatePicker and TextBox values for StartTime and EndTime
                if (dpStartTime.SelectedDate.HasValue && StartTimeHour.HasValue && StartTimeMinute.HasValue)
                {
                    CurrentShift.StartTime = dpStartTime.SelectedDate.Value.Date +
                                             new TimeSpan(StartTimeHour.Value, StartTimeMinute.Value, 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid Start Time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (dpEndTime.SelectedDate.HasValue && EndTimeHour.HasValue && EndTimeMinute.HasValue)
                {
                    CurrentShift.EndTime = dpEndTime.SelectedDate.Value.Date +
                                           new TimeSpan(EndTimeHour.Value, EndTimeMinute.Value, 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid End Time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Update CurrentUserShift properties from UI
                if (dpWorkDate.SelectedDate.HasValue)
                {
                    CurrentUserShift.WorkDate = dpWorkDate.SelectedDate.Value;
                }
                else
                {
                    MessageBox.Show("Please select a valid Work Date.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (CheckInHour.HasValue && CheckInMinute.HasValue)
                {
                    CurrentUserShift.CheckIn = CurrentUserShift.WorkDate.Value.Date +
                                               new TimeSpan(CheckInHour.Value, CheckInMinute.Value, 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid Check In time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (CheckOutHour.HasValue && CheckOutMinute.HasValue)
                {
                    CurrentUserShift.CheckOut = CurrentUserShift.WorkDate.Value.Date +
                                                new TimeSpan(CheckOutHour.Value, CheckOutMinute.Value, 0);
                }
                else
                {
                    MessageBox.Show("Please enter valid Check Out time.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                await _shiftService.UpdateShift(CurrentShift);
                await _userShiftService.UpdateUserShift(CurrentUserShift);
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
                MessageBox.Show($"Error updating shift: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                this.DialogResult = false;
            }
        }
    }
} 