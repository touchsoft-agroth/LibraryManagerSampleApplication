using LibraryManager.Data.Models;
using LibraryManager.Service.Services;

namespace LibraryManager.GUI.Dialogs.Borrowing
{
    public partial class BorrowBookDialog : Form
    {
        private readonly Book _bookToBorrow;
        private readonly UserService _userService;
        private readonly BorrowingService _borrowingService;

        public BorrowBookDialog(Book bookToBorrow, UserService userService, BorrowingService borrowingService)
        {
            _bookToBorrow = bookToBorrow;
            _userService = userService;
            _borrowingService = borrowingService;

            InitializeComponent();
        }

        private void BorrowBookDialog_Load(object sender, EventArgs e)
        {
            bookTitleLabel.Text = _bookToBorrow.Title;

            borrowerDropdown.DataSource = _userService.GetAll().Select(user => user.Id).ToList();

            SetAllowedFromDate();
            OnAnyValueChanged();
        }

        private void SetAllowedFromDate()
        {
            var today = DateTime.Today;
            
            fromDatePicker.MinDate = today;
            UpdateToDateRange(today);
        }

        private void UpdateToDateRange(DateTime fromDate)
        {
            const int minBorrowDays = 1;
            const int maxBorrowDays = 7;
            
            var minDate = fromDate.AddDays(minBorrowDays);
            var maxDate = fromDate.AddDays(maxBorrowDays);
            
            if (toDatePicker.Value < minDate)
            {
                toDatePicker.Value = minDate;
            }

            if (toDatePicker.Value > maxDate)
            {
                toDatePicker.Value = maxDate;
            }

            toDatePicker.MinDate = minDate;
            toDatePicker.MaxDate = maxDate;
        }

        private void borrowerDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnAnyValueChanged();
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            OnAnyValueChanged();

            var selectedFromDate = fromDatePicker.Value;
            UpdateToDateRange(selectedFromDate);
        }

        private void toDatePicker_ValueChanged(object sender, EventArgs e)
        {
            OnAnyValueChanged();
        }

        private void borrowButton_Click(object sender, EventArgs e)
        {
            if (ValidateChoices())
            {
                var selectedFromTime = fromDatePicker.Value;
                var selectedToTime = toDatePicker.Value;

                var user = (int)borrowerDropdown.SelectedItem;
                
                _borrowingService.Borrow(_bookToBorrow.Id, user, selectedFromTime, selectedToTime);
            }
            
            Close();
        }

        private void OnAnyValueChanged()
        {
            borrowButton.Enabled = ValidateChoices();
        }

        private bool ValidateChoices()
        {
            var selectedFromTime = fromDatePicker.Value;
            var selectedToTime = toDatePicker.Value;

            return selectedFromTime < selectedToTime;
        }
    }
}
