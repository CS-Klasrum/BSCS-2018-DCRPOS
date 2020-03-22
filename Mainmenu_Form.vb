Public Class Mainmenu_Form

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MessageBox.Show("Please enter valid barcode/product id")
        Else
            ask_quantity()
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

 
    Private Sub AP_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AP_Button.Click
       
        Me.Hide()
        Admin_Form.Show()
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        i = DataGridView1.Rows.Count - 1
        If i > 0 Then
            Me.Hide()
            Cashout_Form.Show()
            Cashout_Form.TextBox3.Text = Label2.Text
        Else
            MessageBox.Show("There's no product to transact")
        End If

        
    End Sub

    
    Private Sub Void_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Void_Button.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to void this transaction?", "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Dim i As Integer
        i = DataGridView1.Rows.Count - 1
        If i > 0 Then
            If result = DialogResult.Yes Then
                DataGridView1.Rows.Clear()
                Label2.Text = "0.00"
            End If
        Else
            MessageBox.Show("There's no on going transaction")
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label6.Text = Date.Now.ToString("yyyy-MM-dd")
    End Sub

 
    Private Sub Mainmenu_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        get_trans()
    End Sub
End Class