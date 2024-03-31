<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lstInventory = New System.Windows.Forms.ListBox()
        Me.txtNewItem = New System.Windows.Forms.TextBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstInventory
        '
        Me.lstInventory.FormattingEnabled = True
        Me.lstInventory.Location = New System.Drawing.Point(299, 92)
        Me.lstInventory.Name = "lstInventory"
        Me.lstInventory.Size = New System.Drawing.Size(216, 160)
        Me.lstInventory.TabIndex = 0
        '
        'txtNewItem
        '
        Me.txtNewItem.Location = New System.Drawing.Point(299, 55)
        Me.txtNewItem.Name = "txtNewItem"
        Me.txtNewItem.Size = New System.Drawing.Size(216, 20)
        Me.txtNewItem.TabIndex = 1
        Me.txtNewItem.Tag = ""
        Me.txtNewItem.Text = "Enter Inventory Item"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(190, 92)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "Add Item"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(190, 166)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete Item"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(190, 123)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit Item"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtNewItem)
        Me.Controls.Add(Me.lstInventory)
        Me.Name = "Form1"
        Me.Text = "Inventory Management System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lstInventory As ListBox
    Friend WithEvents txtNewItem As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button


    Private inventory As New List(Of String)()
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim newItem As String = txtNewItem.Text.Trim()

        If Not String.IsNullOrWhiteSpace(newItem) Then
            inventory.Add(newItem)
            lstInventory.Items.Add(newItem)
            txtNewItem.Clear()
        Else
            MessageBox.Show("Please enter an item name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstInventory.SelectedIndex <> -1 Then
            Dim selectedItem As String = lstInventory.SelectedItem.ToString()
            inventory.Remove(selectedItem)
            lstInventory.Items.Remove(selectedItem)
        Else
            MessageBox.Show("Please select an item to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Friend WithEvents btnEdit As Button

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If lstInventory.SelectedIndex <> -1 Then
            Dim selectedIndex As Integer = lstInventory.SelectedIndex
            Dim editedItem As String = InputBox("Enter the new item name:", "Edit Item", lstInventory.SelectedItem.ToString())

            If Not String.IsNullOrWhiteSpace(editedItem) Then
                inventory(selectedIndex) = editedItem
                lstInventory.Items(selectedIndex) = editedItem
            Else
                MessageBox.Show("Please enter a valid item name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            MessageBox.Show("Please select an item to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub lstInventory_DoubleClick(sender As Object, e As EventArgs) Handles lstInventory.DoubleClick
        If lstInventory.SelectedIndex <> -1 Then
            txtNewItem.Text = lstInventory.SelectedItem.ToString()
        End If
    End Sub
End Class
