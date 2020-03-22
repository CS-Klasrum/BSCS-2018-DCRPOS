Imports MySql.Data.MySqlClient

Module Code
    Public ServerMySQL As String
    Public PortMySQL As String
    Public UserNameMySQL As String
    Public PwdMySQL As String
    Public DBNameMySQL As String
    Dim MySqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand
    Dim quantity As Integer = 0
    Dim subtotal As String
    Dim trans_no As Integer
    Dim salesDate As String
    Sub Connection()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=;database=dcr"
        MySqlConn.Open()

    End Sub

    Sub LoginAccount()
        Connection()
        Dim READER As MySqlDataReader
        Dim Query As String
        Query = "select * from dcr.employees where E_USERNAME='" & Login_Form.TextBox1.Text & "' and E_PASSWORD='" & Login_Form.TextBox2.Text & "'"
        COMMAND = New MySqlCommand(Query, MySqlConn)
        READER = COMMAND.ExecuteReader
        Dim count As Integer
        count = 0
        While READER.Read
            count += 1
            Mainmenu_Form.Label4.Text = READER("E_ROLE")
            Mainmenu_Form.Label5.Text = READER("E_FN")
        End While
      
        If Login_Form.TextBox1.Text = "" Or Login_Form.TextBox2.Text = "" Then
            MessageBox.Show("Please enter username/password correctly")
            MySqlConn.Close()
        Else
            Try
                If count = 1 Then
                    MessageBox.Show("Username and password are correct")
                    MessageBox.Show("Successfully Login")
                    Login_Form.Hide()
                    Mainmenu_Form.Show()
                    If READER("E_role") = "Cashier" Then
                        Mainmenu_Form.AP_Button.Enabled = False
                        Mainmenu_Form.Void_Button.Enabled = False
                        MySqlConn.Close()
                    ElseIf READER("E_role") = "Admin" Then
                        Mainmenu_Form.AP_Button.Enabled = True
                        Mainmenu_Form.Void_Button.Enabled = True
                        MySqlConn.Close()
                    End If

                ElseIf count > 1 Then
                    MessageBox.Show("Username and password are duplicate")
                    MySqlConn.Close()
                Else
                    MessageBox.Show("Username and password are incorrect")
                    MySqlConn.Close()
                End If
            Catch ex As MySqlException
                MsgBox(ex.Message)
            Finally
                MySqlConn.Dispose()
            End Try
        End If
    End Sub



    Sub register_clear()
        Register_Form.TextBox1.Text = ""
        Register_Form.TextBox2.Text = ""
        Register_Form.TextBox3.Text = ""
        Register_Form.TextBox4.Text = ""
        Register_Form.RadioButton1.Checked = False
        Register_Form.RadioButton2.Checked = False

    End Sub

    Sub login_clear()
        Login_Form.TextBox1.Text = ""
        Login_Form.TextBox2.Text = ""
    End Sub

    Sub prod_clear()
        Add_ProductForm.TextBox1.Text = ""
        Add_ProductForm.TextBox2.Text = ""
        Add_ProductForm.TextBox3.Text = ""
        Add_ProductForm.TextBox4.Text = ""
        Add_ProductForm.TextBox5.Text = ""

    End Sub

    Sub update_clear()
        Admin_Form.TextBox1.Text = ""
        Admin_Form.TextBox2.Text = ""
        Admin_Form.TextBox3.Text = ""
        Admin_Form.TextBox4.Text = ""
        Admin_Form.TextBox5.Text = ""
        Admin_Form.TextBox6.Text = ""
        Admin_Form.TextBox7.Text = ""
        Admin_Form.TextBox8.Text = ""
        Admin_Form.TextBox9.Text = ""
        Admin_Form.TextBox10.Text = ""
        Admin_Form.TextBox11.Text = ""
        Admin_Form.TextBox12.Text = ""
    End Sub

    Function save_info(ByVal Query As String) As Boolean
        Connection()
        Dim READER As MySqlDataReader
        Try
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
        Return True
    End Function

    Sub display_items()
        Connection()
        Dim READER As MySqlDataReader
        Try

            Dim Query As String
            Query = "select * from dcr.products where PROD_ID='" & Mainmenu_Form.TextBox1.Text & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            Dim count As Integer
            count = 0
            While READER.Read
                count = count + 1
                Mainmenu_Form.DataGridView1.Rows.Add(READER("PROD_ID"), READER("PROD_NAME"), READER("PROD_PRICE"), quantity, READER("PROD_SKU"), Format(READER("PROD_EXPDATE"), "yyyy-MM-dd"), READER("PROD_MANUF"))
                subtotal += quantity * READER("PROD_PRICE")
                Mainmenu_Form.Label2.Text = subtotal
            End While
            MySqlConn.Close()
        Catch ex As MySqlException
            MsgBox(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
        Mainmenu_Form.TextBox1.Text = ""



    End Sub

    Sub ask_quantity()
        Connection()
        Dim READER As MySqlDataReader
        Try
            Dim QUERY As String
            QUERY = "SELECT PROD_STCK from dcr.products where PROD_ID='" & Mainmenu_Form.TextBox1.Text & "'"
            COMMAND = New MySqlCommand(QUERY, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                If READER("PROD_STCK") > 0 Then
                    Dim valid As Boolean
                    While valid = False
                        quantity = InputBox("Enter quantity")
                        If Not IsNumeric(quantity) Then
                            valid = False
                            MessageBox.Show("Please enter valid number")
                        Else
                            valid = True
                            display_items()

                        End If
                    End While
                Else
                    MessageBox.Show("Out of stock", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End While

        Catch ex As Exception

        End Try


    End Sub

    Function display_infos(ByVal Query As String) As DataTable
        Connection()
        Dim dbDataSet As New DataSet
        Try
            Dim sqlCommand As New MySqlCommand(Query, MySqlConn)
            Dim sqlAdapater As New MySqlDataAdapter(sqlCommand)
            sqlAdapater.Fill(dbDataSet)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MySqlConn.Close()
        End Try
        Return dbDataSet.Tables(0)
    End Function

    Function delete(ByVal Query As String) As Boolean
        Connection()
        Dim READER As MySqlDataReader
        Try
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()

        End Try
        Return True
    End Function

    Sub sales_detail()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=;database=dcr"

        salesDate = Date.Now.ToString("yyyy-MM-dd")
        Dim cmd As MySqlCommand

        Try
            MySqlConn.Open()
            For i As Integer = 0 To Mainmenu_Form.DataGridView1.Rows.Count - 1
                cmd = New MySqlCommand("insert into dcr.product_sales (SALES_ID,PROD_ID,SALES_PRICE,SALES_QTY,SALES_BUY_PRICE,SALES_DATE) VALUES('" & Mainmenu_Form.TextBox2.Text & "', @PROD_ID , @SALES_PRICE , @SALES_QTY , @SALES_BUY_PRICE ,'" & salesDate & "')", MySqlConn)

                cmd.Parameters.Add("@PROD_ID", MySqlDbType.Int32).Value = Mainmenu_Form.DataGridView1.Rows(i).Cells(0).Value.ToString()
                cmd.Parameters.Add("@SALES_PRICE", MySqlDbType.Int32).Value = Mainmenu_Form.DataGridView1.Rows(i).Cells(2).Value.ToString()
                cmd.Parameters.Add("@SALES_QTY", MySqlDbType.Int32).Value = Mainmenu_Form.DataGridView1.Rows(i).Cells(3).Value.ToString()
                cmd.Parameters.Add("@SALES_BUY_PRICE", MySqlDbType.Int32).Value = Mainmenu_Form.DataGridView1.Rows(i).Cells(2).Value.ToString() * Mainmenu_Form.DataGridView1.Rows(i).Cells(3).Value.ToString()

                cmd.ExecuteNonQuery()


            Next

        Catch ex As Exception

        End Try
        MySqlConn.Close()

    End Sub

    Sub get_password()
        Connection()
        Dim READER As MySqlDataReader
        Try
            Dim Query As String
            Dim i As Integer
            Dim a As Integer
            i = Admin_Form.DataGridView1.CurrentRow.Index
            a = Admin_Form.DataGridView1.Item(0, i).Value
            Query = "select * from dcr.employees where EID='" & a & "'"
            COMMAND = New MySqlCommand(Query, MySqlConn)
            READER = COMMAND.ExecuteReader
            While READER.Read
                Admin_Form.TextBox3.Text = READER("E_PASSWORD")
            End While

            MySqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            MySqlConn.Dispose()
        End Try
    End Sub

    Sub reduce_stock()
        MySqlConn = New MySqlConnection
        MySqlConn.ConnectionString = "server=localhost;userid=root;password=;database=dcr"
        Dim cmd As MySqlCommand
        Dim QUERY As String
        MySqlConn.Open()
        For i As Integer = 0 To Mainmenu_Form.DataGridView1.Rows.Count - 1
            QUERY = "UPDATE dcr.products SET PROD_STCK= PROD_STCK - '" & Mainmenu_Form.DataGridView1.Rows(i).Cells(3).Value & "' WHERE PROD_ID='" & Mainmenu_Form.DataGridView1.Rows(i).Cells(0).Value & "'"
            cmd = New MySqlCommand(QUERY, MySqlConn)
            cmd.ExecuteNonQuery()

        Next

        MySqlConn.Close()
    End Sub


    Function update_acc(ByVal Query As String) As Boolean
        Connection()

        Try

            COMMAND = New MySqlCommand(Query, MySqlConn)
            COMMAND.Parameters.AddWithValue("@EID", Admin_Form.TextBox1.Text)
            COMMAND.Parameters.AddWithValue("@E_USERNAME", Admin_Form.TextBox2.Text)
            COMMAND.Parameters.AddWithValue("@E_PASSWORD", Admin_Form.TextBox3.Text)
            COMMAND.Parameters.AddWithValue("@E_FN", Admin_Form.TextBox4.Text)
            COMMAND.Parameters.AddWithValue("@E_LN", Admin_Form.TextBox5.Text)
            COMMAND.Parameters.AddWithValue("@E_ROLE", Admin_Form.TextBox6.Text)

            COMMAND.ExecuteNonQuery()


            MessageBox.Show("Account updated")
            MySqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()

        End Try

        Admin_Form.Hide()
        Mainmenu_Form.Show()
        Return True
    End Function

    Function update_prod(ByVal Query As String) As Boolean
        Connection()
        Try
            COMMAND = New MySqlCommand(Query, MySqlConn)
            COMMAND.Parameters.AddWithValue("@PROD_ID", Admin_Form.TextBox7.Text)
            COMMAND.Parameters.AddWithValue("@PROD_NAME", Admin_Form.TextBox8.Text)
            COMMAND.Parameters.AddWithValue("@PROD_SKU", Admin_Form.TextBox11.Text)
            COMMAND.Parameters.AddWithValue("@PROD_STCK", Admin_Form.TextBox10.Text)
            COMMAND.Parameters.AddWithValue("@PROD_PRICE", Admin_Form.TextBox9.Text)
            COMMAND.Parameters.AddWithValue("@PROD_MANUF", Admin_Form.TextBox12.Text)

            COMMAND.ExecuteNonQuery()

            MySqlConn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MySqlConn.Dispose()

        End Try

        Admin_Form.Hide()
        Mainmenu_Form.Show()
        Return True
    End Function

    Sub getData_Conf()
        Dim AppName As String = Application.ProductName

        Try
            DBNameMySQL = GetSetting(AppName, "DBSection", "DB_Name", "temp")
            ServerMySQL = GetSetting(AppName, "DBSection", "DB_IP", "temp")
            PortMySQL = GetSetting(AppName, "DBSection", "DB_Port", "temp")
            UserNameMySQL = GetSetting(AppName, "DBSection", "DB_User", "temp")
            PwdMySQL = GetSetting(AppName, "DBSection", "DB_Password", "temp")
        Catch ex As Exception
            MsgBox("System registry was not established, you can set/save " & _
            "these settings by pressing F1", MsgBoxStyle.Information)
        End Try

    End Sub

    Sub SaveData_Conf()
        Dim AppName As String = Application.ProductName

        SaveSetting(AppName, "DBSection", "DB_Name", DBNameMySQL)
        SaveSetting(AppName, "DBSection", "DB_IP", ServerMySQL)
        SaveSetting(AppName, "DBSection", "DB_Port", PortMySQL)
        SaveSetting(AppName, "DBSection", "DB_User", UserNameMySQL)
        SaveSetting(AppName, "DBSection", "DB_Password", PwdMySQL)

        MsgBox("Database connection settings are saved.", MsgBoxStyle.Information)
    End Sub

    Sub get_trans()
        Connection()
        Dim QUERY As String
        Dim READER As MySqlDataReader
        QUERY = "SELECT MAX(SALES_ID) FROM dcr.sales"
        COMMAND = New MySqlCommand(QUERY, MySqlConn)
        READER = COMMAND.ExecuteReader
        While READER.Read
            Mainmenu_Form.TextBox2.Text = READER.GetString(0) + 1
        End While
        MySqlConn.Close()
        MySqlConn.Dispose()


    End Sub
End Module
