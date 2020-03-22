Imports MySql.Data.MySqlClient

Public Class Cashout_Form
    Dim balance As Integer
    Dim command As MySqlCommand
    Dim salesDate As String

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Cashout_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        salesDate = Format(Date.Now(), "yyyy-MM-dd")
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox4.Text = Val(TextBox1.Text) - Val(TextBox3.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Val(TextBox1.Text) >= Val(TextBox3.Text) Then
                save_info("insert into dcr.sales (SALES_TOTAL , SALES_CASH , SALES_CHANGE,SALES_DATE) Values('" & TextBox3.Text & "' , '" & TextBox1.Text & "' , '" & TextBox4.Text & "' , '" & salesDate & "')")
                MessageBox.Show("Thank you for buying", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Hide()
                TextBox1.Text = 0
                TextBox2.Text = 0
                Mainmenu_Form.Label2.Text = "0.00"
                TextBox4.Text = 0
                balance = 0
                sales_detail()
                reduce_stock()
                get_trans()
                Mainmenu_Form.DataGridView1.Rows.Clear()
                Mainmenu_Form.Label2.Text = "0.00"
                Me.Hide()
                Mainmenu_Form.Show()

            Else
                MessageBox.Show("Error", "Error404", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If
        Catch ex As MySqlException
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = 0
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        Me.Hide()
        Mainmenu_Form.Show()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class