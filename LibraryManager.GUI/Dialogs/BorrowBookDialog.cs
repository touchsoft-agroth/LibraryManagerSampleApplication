using LibraryManager.Data.Models;
using LibraryManager.Service.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManager.GUI.Dialogs
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

            DateTime today = DateTime.Today;
            fromDatePicker.MinDate = today;

            toDatePicker.MinDate = today.AddDays(1);
            toDatePicker.MaxDate = today.AddDays(7);

            OnAnyValueChanged();
        }

        private void borrowerDropdown_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnAnyValueChanged();
        }

        private void fromDatePicker_ValueChanged(object sender, EventArgs e)
        {
            OnAnyValueChanged();
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
