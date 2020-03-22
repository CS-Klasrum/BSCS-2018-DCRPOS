Public Class Admin_Form

    Private Sub Admin_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.ForeColor = Color.Red
        DataGridView2.ForeColor = Color.Red
       
        Dim bSource1 As New BindingSource
        Dim accounts As DataTable = display_infos("SELECT EID as 'Employee ID',E_USERNAME as 'Username',E_FN as 'Firstname',E_LN as 'Lastname',E_ROLE as 'Role' from dcr.employees")
        bSource1.DataSource = accounts
        DataGridView1.DataSource = bSource1

        Dim bSource As New BindingSource
        Dim product As DataTable = display_infos("SELECT PROD_ID as 'Product ID',PROD_NAME as 'Product Name',PROD_PRICE as 'Product Price',PROD_STCK as 'Product Stock', PROD_SKU as 'Product SKU', PROD_MANUF as 'Manufacturer' from dcr.products")
        bSource.DataSource = product
        DataGridView2.DataSource = bSource

        TextBox1.Enabled = False
        TextBox7.Enabled = False
    End Sub

    

   
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        get_password()
        TextBox1.Text = DataGridView1.Item(0, i).Value
        TextBox2.Text = DataGridView1.Item(1, i).Value
        TextBox4.Text = DataGridView1.Item(2, i).Value
        TextBox5.Text = DataGridView1.Item(3, i).Value
        TextBox6.Text = DataGridView1.Item(4, i).Value



    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Dim i As Integer
        i = DataGridView2.CurrentRow.Index

        TextBox7.Text = DataGridView2.Item(0, i).Value
        TextBox8.Text = DataGridView2.Item(1, i).Value
        TextBox9.Text = DataGridView2.Item(2, i).Value
        TextBox10.Text = DataGridView2.Item(3, i).Value
        TextBox11.Text = DataGridView2.Item(4, i).Value
        TextBox12.Text = DataGridView2.Item(5, i).Value
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        update_clear()
        Me.Hide()
        Mainmenu_Form.Show()

    End Sub

    Private Sub DelAcc_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelAcc_Button.Click
        Dim results As DialogResult = MessageBox.Show("Are you sure you want to delete this account?", "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If results = DialogResult.OK Then
            If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
                MessageBox.Show("Please enter valid data")
            Else
                Code.delete("DELETE from dcr.employees where E_ID='" & TextBox6.Text & "'")
                MessageBox.Show("Successfully deleted an account")
            End If
        End If

    End Sub

    Private Sub DelProd_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelProd_Button.Click
        Dim results As DialogResult = MessageBox.Show("Are you sure you want to delete this product?", "Important Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If results = DialogResult.OK Then
            If TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Then
                MessageBox.Show("Please enter valid data")
            Else
                Code.delete("DELETE from cdpos.product where PROD_ID='" & TextBox7.Text & "'")
                MessageBox.Show("Successfully deleted an product")
            End If
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers and Letters only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Not Char.IsLetterOrDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers and Letters only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Letters only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Letters only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Letters only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

   
    Private Sub TextBox9_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
        If Not Char.IsDigit(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) Then
            e.Handled = True
            MessageBox.Show("Numbers only", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CreateAcc_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAcc_Button.Click
        Me.Hide()
        Register_Form.Show()
    End Sub

    Private Sub CreateProd_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateProd_Button.Click
        Me.Hide()
        Add_ProductForm.Show()
    End Sub

 
    Private Sub UpAcc_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpAcc_Button.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MessageBox.Show("Please enter valid data")
        Else
            update_acc("UPDATE dcr.employees SET E_USERNAME=@E_USERNAME, E_PASSWORD=@E_PASSWORD,E_FN=@E_FN,E_LN=@E_LN,E_ROLE=@E_ROLE where EID=@EID")
            MessageBox.Show("Successfully updated account")
        End If
    End Sub

    Private Sub UpProd_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpProd_Button.Click
        If TextBox7.Text = "" Or TextBox8.Text = "" Or TextBox9.Text = "" Or TextBox10.Text = "" Or TextBox11.Text = "" Or TextBox12.Text = "" Then
            MessageBox.Show("Please enter valid data")
        Else
            update_prod("UPDATE dcr.products SET PROD_NAME=@PROD_NAME,PROD_SKU=@PROD_SKU,PROD_STCK=@PROD_STCK,PROD_PRICE=@PROD_PRICE where PROD_ID=@PROD_ID")

            MessageBox.Show("Successfully updated product")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Configuration_Form.Show()
    End Sub



End Class