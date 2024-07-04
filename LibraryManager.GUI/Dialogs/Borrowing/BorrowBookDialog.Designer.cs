namespace LibraryManager.GUI.Dialogs.Borrowing
{
    partial class BorrowBookDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bookTitleLabel = new Label();
            borrowerDropdown = new ComboBox();
            borrowerTitleLabel = new Label();
            fromDatePicker = new DateTimePicker();
            fromDateTitleLabel = new Label();
            toDatePicker = new DateTimePicker();
            toDateTitleLabel = new Label();
            borrowButton = new Button();
            SuspendLayout();
            // 
            // bookTitleLabel
            // 
            bookTitleLabel.AutoSize = true;
            bookTitleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bookTitleLabel.Location = new Point(12, 9);
            bookTitleLabel.Name = "bookTitleLabel";
            bookTitleLabel.Size = new Size(121, 32);
            bookTitleLabel.TabIndex = 0;
            bookTitleLabel.Text = "Book Title";
            // 
            // borrowerDropdown
            // 
            borrowerDropdown.FormattingEnabled = true;
            borrowerDropdown.Location = new Point(12, 80);
            borrowerDropdown.Name = "borrowerDropdown";
            borrowerDropdown.Size = new Size(121, 23);
            borrowerDropdown.TabIndex = 1;
            borrowerDropdown.SelectionChangeCommitted += borrowerDropdown_SelectionChangeCommitted;
            // 
            // borrowerTitleLabel
            // 
            borrowerTitleLabel.AutoSize = true;
            borrowerTitleLabel.Location = new Point(12, 62);
            borrowerTitleLabel.Name = "borrowerTitleLabel";
            borrowerTitleLabel.Size = new Size(55, 15);
            borrowerTitleLabel.TabIndex = 2;
            borrowerTitleLabel.Text = "Borrower";
            // 
            // fromDatePicker
            // 
            fromDatePicker.Location = new Point(12, 132);
            fromDatePicker.Name = "fromDatePicker";
            fromDatePicker.Size = new Size(200, 23);
            fromDatePicker.TabIndex = 3;
            fromDatePicker.ValueChanged += fromDatePicker_ValueChanged;
            // 
            // fromDateTitleLabel
            // 
            fromDateTitleLabel.AutoSize = true;
            fromDateTitleLabel.Location = new Point(12, 114);
            fromDateTitleLabel.Name = "fromDateTitleLabel";
            fromDateTitleLabel.Size = new Size(35, 15);
            fromDateTitleLabel.TabIndex = 4;
            fromDateTitleLabel.Text = "From";
            // 
            // toDatePicker
            // 
            toDatePicker.Location = new Point(12, 188);
            toDatePicker.Name = "toDatePicker";
            toDatePicker.Size = new Size(200, 23);
            toDatePicker.TabIndex = 5;
            toDatePicker.ValueChanged += toDatePicker_ValueChanged;
            // 
            // toDateTitleLabel
            // 
            toDateTitleLabel.AutoSize = true;
            toDateTitleLabel.Location = new Point(12, 170);
            toDateTitleLabel.Name = "toDateTitleLabel";
            toDateTitleLabel.Size = new Size(19, 15);
            toDateTitleLabel.TabIndex = 6;
            toDateTitleLabel.Text = "To";
            // 
            // borrowButton
            // 
            borrowButton.Location = new Point(12, 227);
            borrowButton.Name = "borrowButton";
            borrowButton.Size = new Size(200, 45);
            borrowButton.TabIndex = 7;
            borrowButton.Text = "Borrow";
            borrowButton.UseVisualStyleBackColor = true;
            borrowButton.Click += borrowButton_Click;
            // 
            // BorrowBookDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(228, 285);
            Controls.Add(borrowButton);
            Controls.Add(toDateTitleLabel);
            Controls.Add(toDatePicker);
            Controls.Add(fromDateTitleLabel);
            Controls.Add(fromDatePicker);
            Controls.Add(borrowerTitleLabel);
            Controls.Add(borrowerDropdown);
            Controls.Add(bookTitleLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "BorrowBookDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            Text = "BorrowBookDialog";
            Load += BorrowBookDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label bookTitleLabel;
        private ComboBox borrowerDropdown;
        private Label borrowerTitleLabel;
        private DateTimePicker fromDatePicker;
        private Label fromDateTitleLabel;
        private DateTimePicker toDatePicker;
        private Label toDateTitleLabel;
        private Button borrowButton;
    }
}