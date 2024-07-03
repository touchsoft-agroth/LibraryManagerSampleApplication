using System.ComponentModel;

namespace LibraryManager.GUI;

partial class LibraryManagementGui
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        bookListBox = new ListBox();
        bookEditTitleLabel = new Label();
        bookEditTitleTextBox = new TextBox();
        bookEditAuthorLabel = new Label();
        bookEditAuthorTextBox = new TextBox();
        bookEditSaveButton = new Button();
        bookTitleSearchTextBox = new TextBox();
        label1 = new Label();
        label2 = new Label();
        statusHeaderLabel = new Label();
        statusCurrentStatusLabel = new Label();
        statusBorrowButton = new Button();
        statusReturnButton = new Button();
        SuspendLayout();
        // 
        // bookListBox
        // 
        bookListBox.FormattingEnabled = true;
        bookListBox.ItemHeight = 15;
        bookListBox.Location = new Point(12, 12);
        bookListBox.Name = "bookListBox";
        bookListBox.Size = new Size(303, 259);
        bookListBox.TabIndex = 0;
        bookListBox.SelectedIndexChanged += bookListBox_SelectedIndexChanged;
        // 
        // bookEditTitleLabel
        // 
        bookEditTitleLabel.AutoSize = true;
        bookEditTitleLabel.Location = new Point(321, 51);
        bookEditTitleLabel.Name = "bookEditTitleLabel";
        bookEditTitleLabel.Size = new Size(29, 15);
        bookEditTitleLabel.TabIndex = 1;
        bookEditTitleLabel.Text = "Title";
        // 
        // bookEditTitleTextBox
        // 
        bookEditTitleTextBox.Location = new Point(371, 48);
        bookEditTitleTextBox.Name = "bookEditTitleTextBox";
        bookEditTitleTextBox.Size = new Size(201, 23);
        bookEditTitleTextBox.TabIndex = 2;
        // 
        // bookEditAuthorLabel
        // 
        bookEditAuthorLabel.AutoSize = true;
        bookEditAuthorLabel.Location = new Point(321, 84);
        bookEditAuthorLabel.Name = "bookEditAuthorLabel";
        bookEditAuthorLabel.Size = new Size(44, 15);
        bookEditAuthorLabel.TabIndex = 3;
        bookEditAuthorLabel.Text = "Author";
        // 
        // bookEditAuthorTextBox
        // 
        bookEditAuthorTextBox.Location = new Point(371, 81);
        bookEditAuthorTextBox.Name = "bookEditAuthorTextBox";
        bookEditAuthorTextBox.Size = new Size(201, 23);
        bookEditAuthorTextBox.TabIndex = 4;
        // 
        // bookEditSaveButton
        // 
        bookEditSaveButton.Location = new Point(321, 110);
        bookEditSaveButton.Name = "bookEditSaveButton";
        bookEditSaveButton.Size = new Size(75, 23);
        bookEditSaveButton.TabIndex = 5;
        bookEditSaveButton.Text = "Save";
        bookEditSaveButton.UseVisualStyleBackColor = true;
        bookEditSaveButton.Click += bookEditSaveButton_Click;
        // 
        // bookTitleSearchTextBox
        // 
        bookTitleSearchTextBox.Location = new Point(12, 304);
        bookTitleSearchTextBox.Name = "bookTitleSearchTextBox";
        bookTitleSearchTextBox.Size = new Size(303, 23);
        bookTitleSearchTextBox.TabIndex = 10;
        bookTitleSearchTextBox.TextChanged += bookTitleSearchTextBox_TextChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 286);
        label1.Name = "label1";
        label1.Size = new Size(72, 15);
        label1.TabIndex = 11;
        label1.Text = "Search book";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.Location = new Point(321, 12);
        label2.Name = "label2";
        label2.Size = new Size(78, 28);
        label2.TabIndex = 12;
        label2.Text = "Details";
        label2.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // statusHeaderLabel
        // 
        statusHeaderLabel.AutoSize = true;
        statusHeaderLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
        statusHeaderLabel.Location = new Point(321, 161);
        statusHeaderLabel.Name = "statusHeaderLabel";
        statusHeaderLabel.Size = new Size(76, 28);
        statusHeaderLabel.TabIndex = 13;
        statusHeaderLabel.Text = "Status:";
        // 
        // statusCurrentStatusLabel
        // 
        statusCurrentStatusLabel.AutoSize = true;
        statusCurrentStatusLabel.ForeColor = Color.LimeGreen;
        statusCurrentStatusLabel.Location = new Point(398, 172);
        statusCurrentStatusLabel.Name = "statusCurrentStatusLabel";
        statusCurrentStatusLabel.Size = new Size(55, 15);
        statusCurrentStatusLabel.TabIndex = 15;
        statusCurrentStatusLabel.Text = "Available";
        // 
        // statusBorrowButton
        // 
        statusBorrowButton.Location = new Point(321, 202);
        statusBorrowButton.Name = "statusBorrowButton";
        statusBorrowButton.Size = new Size(75, 23);
        statusBorrowButton.TabIndex = 16;
        statusBorrowButton.Text = "Borrow";
        statusBorrowButton.UseVisualStyleBackColor = true;
        statusBorrowButton.Click += statusBorrowButton_Click;
        // 
        // statusReturnButton
        // 
        statusReturnButton.Location = new Point(402, 202);
        statusReturnButton.Name = "statusReturnButton";
        statusReturnButton.Size = new Size(75, 23);
        statusReturnButton.TabIndex = 17;
        statusReturnButton.Text = "Return";
        statusReturnButton.UseVisualStyleBackColor = true;
        statusReturnButton.Click += statusReturnButton_Click;
        // 
        // LibraryManagementGui
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(601, 360);
        Controls.Add(statusReturnButton);
        Controls.Add(statusBorrowButton);
        Controls.Add(statusCurrentStatusLabel);
        Controls.Add(statusHeaderLabel);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(bookTitleSearchTextBox);
        Controls.Add(bookEditSaveButton);
        Controls.Add(bookEditAuthorTextBox);
        Controls.Add(bookEditAuthorLabel);
        Controls.Add(bookEditTitleTextBox);
        Controls.Add(bookEditTitleLabel);
        Controls.Add(bookListBox);
        Name = "LibraryManagementGui";
        Text = "RootForm";
        Load += RootForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox bookListBox;
    private Label bookEditTitleLabel;
    private TextBox bookEditTitleTextBox;
    private Label bookEditAuthorLabel;
    private TextBox bookEditAuthorTextBox;
    private Button bookEditSaveButton;
    private TextBox bookTitleSearchTextBox;
    private Label label1;
    private Label label2;
    private Label statusHeaderLabel;
    private Label statusCurrentStatusLabel;
    private Button statusBorrowButton;
    private Button statusReturnButton;
}