Imports MySql.Data.MySqlClient
Public Class Configuration_Form
    Private TstServerMySQL As String
    Private TstPortMySQL As String
    Private TstUserNameMySQL As String
    Private TstPwdMySQL As String
    Private TstDBNameMySQL As String
    Dim conn As New MySqlConnection
    Private Sub cmdTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTest.Click
        TstServerMySQL = txtServerHost.Text
        TstPortMySQL = txtPort.Text
        TstUserNameMySQL = txtUserName.Text
        TstPwdMySQL = txtPassword.Text
        TstDBNameMySQL = txtDatabase.Text
        Try
            conn.ConnectionString = "Server = '" & TstServerMySQL & "';  " _
                                         & "Port = '" & TstPortMySQL & "'; " _
                                         & "Database = '" & TstDBNameMySQL & "'; " _
                                         & "user id = '" & TstUserNameMySQL & "'; " _
                                         & "password = '" & TstPwdMySQL & "'"


            conn.Open()
            MsgBox("Test connection successful", MsgBoxStyle.Information, "Database Settings")

        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")

        End Try
        Call conn.Close()

    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        TstServerMySQL = txtServerHost.Text
        TstPortMySQL = txtPort.Text
        TstUserNameMySQL = txtUserName.Text
        TstPwdMySQL = txtPassword.Text
        TstDBNameMySQL = txtDatabase.Text

        Try
            conn.ConnectionString = "Server = '" & TstServerMySQL & "';  " _
                                         & "Port = '" & TstPortMySQL & "'; " _
                                         & "Database = '" & TstDBNameMySQL & "'; " _
                                         & "user id = '" & TstUserNameMySQL & "'; " _
                                         & "password = '" & TstPwdMySQL & "'"
            conn.Open()

            DBNameMySQL = txtDatabase.Text
            ServerMySQL = txtServerHost.Text
            UserNameMySQL = txtUserName.Text
            PortMySQL = txtPort.Text
            PwdMySQL = txtPassword.Text

            Call SaveData_Conf()
            Me.Close()
        Catch ex As Exception
            MsgBox("The system failed to establish a connection", MsgBoxStyle.Information, "Database Settings")
        End Try
        Call conn.Close()
        'save database
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        txtDatabase.Text = ""
        txtPassword.Text = ""
        txtPort.Text = ""
        txtServerHost.Text = ""
        txtUserName.Text = ""
        Me.Hide()
        Mainmenu_Form.Show()
    End Sub

    Private Sub Configuration_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtServerHost.Text = ServerMySQL
        txtPort.Text = PortMySQL
        txtUserName.Text = UserNameMySQL
        txtPassword.Text = PwdMySQL
        txtDatabase.Text = DBNameMySQL
    End Sub
End Class
