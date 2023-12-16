﻿Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports System.Runtime
Imports System.Security.Principal
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class speedmeter


    Public Function FindDockedTaskBars(Optional DockedRectCounter As Integer = 0) As Rectangle()
        '  Dim TmpScrn As Screen = Nothing
        Dim LeftDockedWidth As Integer = 0
        Dim TopDockedHeight As Integer = 0
        Dim RightDockedWidth As Integer = 0
        Dim BottomDockedHeight As Integer = 0
        Dim DockedRects(Screen.AllScreens.Count * 4) As Rectangle

        DockedRectCounter = 0

        Dim TmpScrn As Screen = Screen.FromControl(Me)
        If Not TmpScrn.Bounds.Equals(TmpScrn.WorkingArea) Then
            LeftDockedWidth = Math.Abs(Math.Abs(TmpScrn.Bounds.Left) - Math.Abs(TmpScrn.WorkingArea.Left))
            TopDockedHeight = Math.Abs(Math.Abs(TmpScrn.Bounds.Top) - Math.Abs(TmpScrn.WorkingArea.Top))
            RightDockedWidth = (TmpScrn.Bounds.Width - LeftDockedWidth) - TmpScrn.WorkingArea.Width
            BottomDockedHeight = (TmpScrn.Bounds.Height - TopDockedHeight) - TmpScrn.WorkingArea.Height

            If LeftDockedWidth > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.Bounds.Left
                DockedRects(DockedRectCounter).Y = TmpScrn.Bounds.Top
                DockedRects(DockedRectCounter).Width = LeftDockedWidth
                DockedRects(DockedRectCounter).Height = TmpScrn.Bounds.Height
                DockedRectCounter += 1
            End If
            If RightDockedWidth > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.WorkingArea.Right
                DockedRects(DockedRectCounter).Y = TmpScrn.Bounds.Top
                DockedRects(DockedRectCounter).Width = RightDockedWidth
                DockedRects(DockedRectCounter).Height = TmpScrn.Bounds.Height
                DockedRectCounter += 1
            End If
            If TopDockedHeight > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.WorkingArea.Left
                DockedRects(DockedRectCounter).Y = TmpScrn.Bounds.Top
                DockedRects(DockedRectCounter).Width = TmpScrn.WorkingArea.Width
                DockedRects(DockedRectCounter).Height = TopDockedHeight
                DockedRectCounter += 1
            End If
            If BottomDockedHeight > 0 Then
                DockedRects(DockedRectCounter).X = TmpScrn.WorkingArea.Left
                DockedRects(DockedRectCounter).Y = TmpScrn.WorkingArea.Bottom
                DockedRects(DockedRectCounter).Width = TmpScrn.WorkingArea.Width
                DockedRects(DockedRectCounter).Height = BottomDockedHeight
                DockedRectCounter += 1
            End If
        End If

        Return DockedRects
    End Function
    Dim TaskBarRect As Rectangle()

    Dim coloredown As Color = Nothing
    Sub cambiagiu()
        Dim x As Integer
        Dim y As Integer
        Dim a As Byte

        Dim img As Bitmap = My.Resources.giu

        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1

                a = img.GetPixel(x, y).A

                If a > 250 Then
                    If coloredown <> Nothing Then
                        img.SetPixel(x, y, coloredown)
                    Else
                        img.SetPixel(x, y, My.Settings.coloredown)
                    End If

                End If

            Next
        Next

        PictureBox2.Image = img
    End Sub

    Dim coloreup As Color = Nothing
    Sub cambiasu()
        Dim x As Integer
        Dim y As Integer
        Dim a As Byte


        Dim img As Bitmap = My.Resources.su

        For x = 0 To img.Width - 1
            For y = 0 To img.Height - 1

                a = img.GetPixel(x, y).A

                If a > 250 Then
                    If coloreup <> Nothing Then
                        img.SetPixel(x, y, coloreup)
                    Else
                        img.SetPixel(x, y, My.Settings.coloreup)
                    End If

                End If

            Next
        Next

        PictureBox3.Image = img
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load




        IsAdministrator = New WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator)
        If IsAdministrator Then
            CreateShortCut()
        End If
        TaskBarRect = FindDockedTaskBars()

        Me.Top = TaskBarRect(0).Top + 1
        Me.Left = TaskBarRect(0).Width / 2 - Me.Width / 2

        If My.Settings.posizione <> 0 Then
            Me.Left = My.Settings.posizione
        End If

        If My.Settings.font Is Nothing Then
        Else
            Label1.Font = My.Settings.font
            Label2.Font = My.Settings.font

        End If

        If My.Settings.colore = Nothing Then
        Else
            Label1.ForeColor = My.Settings.colore
            Label2.ForeColor = My.Settings.colore
        End If

        If My.Settings.coloredown = Nothing Then
        Else
            cambiagiu()
        End If

        If My.Settings.coloreup = Nothing Then
        Else
            cambiasu()
        End If
        If My.Settings.banda <> "" Then
            bandwidth = My.Settings.banda
        Else
            bandwidth = "Mb"
        End If


        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
                If i.Text = bandwidth Then
                    i.Checked = True
                End If
            Next
        Catch ex As Exception

        End Try



        AddHandler NetworkChange.NetworkAvailabilityChanged, AddressOf OnNetWorkChanged_Event
        AddHandler NetworkChange.NetworkAddressChanged, AddressOf OnNetworkAddrChanged_Event
        Invoke(New MethodInvoker(Sub()

                                     loadnic()
                                 End Sub))

        If IO.File.Exists(Application.StartupPath & "\speed-meter.cfg") Then
            caricaconfig
        End If
        posiziona()
        Timer2_Tick(Nothing, Nothing)
    End Sub

    Dim fontx As Font
    Dim labelcolor As Color
    Dim posizione As Integer = -1
    Dim duepunti As Boolean = True
    Sub caricaconfig()


        fontx = New Font("Microsoft Sans Serif", 12, FontStyle.Regular)

        Dim streamReader As System.IO.StreamReader = New System.IO.StreamReader(String.Concat(Application.StartupPath, "\speed-meter.cfg"))
        While streamReader.Peek() <> -1
            Dim str As String = streamReader.ReadLine().Trim()
            If (str.StartsWith("'")) Then
                Continue While
            End If

            '[duepunti]=no

            If str.StartsWith("[duepunti]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim

                    If str.ToLower.Trim.StartsWith("s") Then
                        duepunti = True
                    Else
                        duepunti = False
                    End If


                    labelcolor = Label1.ForeColor
                Catch ex As Exception

                End Try
            End If

            If str.StartsWith("[labelcolor]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim

                    If IsNumeric(Val("&H" & str)) Then
                        Label1.ForeColor = Color.FromArgb(str)
                        Label2.ForeColor = Color.FromArgb(str)
                    Else
                        Label1.ForeColor = Color.FromName(str)
                        Label2.ForeColor = Color.FromName(str)
                    End If


                    labelcolor = Label1.ForeColor
                Catch ex As Exception

                End Try
            End If



            If str.StartsWith("[downcolor]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If IsNumeric(Val("&H" & str)) Then
                        coloredown = Color.FromArgb(str)
                    Else
                        coloredown = Color.FromName(str)
                    End If

                    cambiagiu()
                Catch ex As Exception

                End Try
            End If


            If str.StartsWith("[upcolor]") Then
                Try
                    str = Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim
                    If IsNumeric(Val("&H" & str)) Then
                        coloreup = Color.FromArgb(str)
                    Else
                        coloreup = Color.FromName(str)
                    End If

                    cambiasu()
                Catch ex As Exception

                End Try
            End If


            If str.StartsWith("[posizione]") Then
                Try
                    posizione = Convert.ToInt32(Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim)
                Catch ex As Exception
                    Dim TmpScrn As Screen = Screen.FromControl(Me)
                    posizione = TmpScrn.Bounds.Width - Me.Width - 300
                End Try
            End If





            If str.StartsWith("[font]") Then
                Dim fontf As String = ""
                Dim font2() As String
                Try

                    fontf = (Strings.Mid(str, str.LastIndexOf("=") + 2, str.Length).Trim.ToLower)
                    If fontf.Contains(",") Then
                        font2 = Split(fontf, ",")
                        If font2.Length = 4 Then
                            fontx = CreateFont(font2(0), CInt(font2(1)), font2(2), font2(3))
                        ElseIf font2.Length = 3 Then
                            fontx = CreateFont(font2(0), CInt(font2(1)), font2(2))
                        ElseIf font2.Length = 2 Then
                            fontx = CreateFont(font2(0), CInt(font2(1)))
                        End If

                    Else
                        fontx = CreateFont(fontf)
                    End If
                Catch ex As Exception

                End Try

                Me.Font = fontx
                Label1.Font = fontx
                Label2.Font = fontx
            End If

        End While

        streamReader.Close()
        streamReader.Dispose()


        lastedit = IO.File.GetLastWriteTime(Application.StartupPath & "\speed-meter.cfg")

    End Sub
    Public Function CreateFont(Optional fontName As String = "Microsoft Sans Serif", Optional fontSize As Integer = 12, Optional tipo As String = "", Optional tipo2 As String = "") As Drawing.Font
        fontName = fontName.Trim
        tipo = tipo.Trim
        tipo2 = tipo2.Trim


        Dim styles As FontStyle = FontStyle.Regular
        tipo = tipo.ToLower.Trim
        Select Case tipo
            Case "bold"
                styles = styles Or FontStyle.Bold
            Case "italic"
                styles = styles Or FontStyle.Italic
        End Select

        Select Case tipo2
            Case "bold"
                styles = styles Or FontStyle.Bold
            Case "italic"
                styles = styles Or FontStyle.Italic
        End Select

        Dim newFont As New Font(fontName, fontSize, styles)
        Return newFont

    End Function

    Private Sub OnNetworkAddrChanged_Event(ByVal sender As Object, ByVal e As EventArgs)

        Invoke(New MethodInvoker(Sub()

                                     loadnic()

                                 End Sub))
    End Sub

    Private Sub OnNetWorkChanged_Event(ByVal sender As Object, ByVal e As NetworkInformation.NetworkAvailabilityEventArgs) ' Handles Me.NetChangedHandler
        Invoke(New MethodInvoker(Sub()

                                     loadnic()

                                 End Sub))
    End Sub

    Sub posiziona()
        If posizione <> -1 Then
            Me.Left = posizione
        Else
            Me.Left = My.Settings.posizione
        End If

        Me.Height = TaskBarRect(0).Height - 1
        Dim mezzo As Integer = Me.Height / 2
        Label1.Left = PictureBox2.Width
        Label2.Left = PictureBox3.Width
        Me.Label1.Top = mezzo - Label1.Height - 1 '+1
        Me.Label2.Top = mezzo + 1 '- 1


    End Sub

    Dim IsAdministrator As Boolean = False
    Function CreateShortCut() As Boolean

        Dim TargetName As String = Application.ProductName
        Dim ShortCutPath As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup)
        Dim myshortcutpath As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
        Dim oShell As Object
        Dim oLink As Object

        If IsAdministrator Then
            Try
                oShell = CreateObject("WScript.Shell")
                oLink = oShell.CreateShortcut(ShortCutPath & "\" & TargetName & ".lnk")

                oLink.TargetPath = Application.ExecutablePath
                ''' oLink.WindowStyle = 1
                oLink.Save()

                MsgBox("Eseguito con diritti AMMINISTRATORE, Link ad esecuzione autmatica allusers creata!" & vbCr & " ora mi chiudo, rieseguimi con diritti utente!")

                End
            Catch ex As Exception
                MsgBox("ERRORE nell' esecuzione con diritti AMMINISTRATORE, ora mi chiudo, Riprovare!!!")
                End
                Return False
            End Try
        End If
        Return True


    End Function

    Dim lastedit As DateTime = Nothing
    Dim sizeold As Rectangle = Nothing
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ritorna Then
            Return
        End If



        TaskBarRect = FindDockedTaskBars()

        Me.Top = TaskBarRect(0).Top + 1
        If Me.Left < TaskBarRect(0).Left Then
            Me.Left = TaskBarRect(0).Left
        End If

        If Me.Left > TaskBarRect(0).Width Then
            Me.Left = TaskBarRect(0).Width - Me.Width
        End If
        Me.TopMost = True
        Me.Visible = True
        Application.DoEvents()
    End Sub
    Dim ritorna As Boolean = False
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If IO.File.Exists(Application.StartupPath & "\speed-meter.cfg") Then
            Dim TmpScrn As Screen = Screen.FromControl(Me)
            Dim size As Rectangle = TmpScrn.Bounds
            If IO.File.GetLastWriteTime(Application.StartupPath & "\speed-meter.cfg") <> lastedit Or sizeold <> size Then
                caricaconfig()
                sizeold = size
                posiziona()
            End If
        End If



        '''autonic()

        BandSec()
    End Sub

    Private isMouseDown As Boolean = False
    Private mouseOffset As Point

    ' Left mouse button pressed
    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown

    End Sub

    ' MouseMove used to check if mouse cursor is moving
    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove

    End Sub

    ' Left mouse button released, form should stop moving
    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp

    End Sub


    Public net As NetworkInterface

    Public Function BytesConverter(ByVal bytes As Long) As String
        Dim divisore As Integer = 1
        Dim banda As Double = bytes / 1024 / 1024
        Select Case bandwidth.Trim
            Case "Gb", "Mb", "Kb"
                divisore = 8
        End Select

        Select Case bandwidth.ToLower.Trim
            Case "gb"
                banda = bytes / 1024 / 1024 / 1024
            Case "mb"
                banda = bytes / 1024 / 1024
            Case "kb"
                banda = bytes / 1024
        End Select


        Dim ret As String = "0 Mb"
        ret = (banda * divisore).ToString("000.00") & " " & bandwidth.Trim


        Return ret.ToString
    End Function

    Dim LastUpload As Long = -1
    Dim LastDownload As Long = -1

    Public Function CheckNet() As Boolean
        Dim num As Integer
        Return InternetGetConnectedState(num, 0)
    End Function
    Private Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Int32,
ByVal dwReserved As Int32) As Boolean



    Public Function GetLocalIPAddress() As String
        Dim addressList As IPAddress() = Dns.GetHostEntry(Dns.GetHostName()).AddressList
        Dim num As Integer = 0
        Do
            Dim pAddress As IPAddress = addressList(num)
            If (pAddress.AddressFamily = AddressFamily.InterNetwork) Then

                Return pAddress.ToString()

            End If
            num = num + 1
        Loop While num < CInt(addressList.Length)
        Return ""
        Throw New Exception("no ip4 found")

    End Function

    Dim LocalIPAddress As String

    Private Sub mnuItem_Clicked(sender As Object, e As EventArgs)

        ContextMenuStrip1.Hide() 'Sometimes the menu items can remain open.  May not be necessary for you.
        Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
        If item IsNot Nothing Then
            net = item.Tag


            Try
                For Each i As ToolStripMenuItem In SelezioneNetworkToolStripMenuItem.DropDownItems
                    If My.Settings.nic <> "" And My.Settings.nic.ToString.ToLower.Trim = i.Text.ToString.ToLower.Trim Then
                        i.Checked = False
                    End If
                Next
            Catch ex As Exception

            End Try

            item.Checked = True
            My.Settings.nic = net.Description
            My.Settings.Save()
        End If
    End Sub

    Dim menu2 As New ToolStripMenuItem


    Private Sub loadnic()
        Try
            SelezioneNetworkToolStripMenuItem.DropDownItems.Clear()
            RemoveHandler menu2.Click, AddressOf mnuItem_Clicked

        Catch ex As Exception

        End Try
        Try
            Dim Adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            Dim ce As Boolean = False
            Dim conta As Integer = 0
            For Each network As NetworkInterface In Adapters
                If network.OperationalStatus = 1 Then

                    If GetLocalIPAddress() <> "" And (network.NetworkInterfaceType = 6 Or network.NetworkInterfaceType = 71) Then
                        Dim ip = network.GetIPProperties().UnicastAddresses(1).Address.ToString

                        conta = conta + 1
                        menu2 = New ToolStripMenuItem With {.Text = network.Description, .Name = CStr(conta), .Tag = network}
                        'We have a reference to menu1 already, but here's how you can find the menu item by name...
                        Try
                            For Each item As Object In ContextMenuStrip1.Items
                                If item.Name = "SelezioneNetworkToolStripMenuItem" Then
                                    If item.DropDownItems.Contains(menu2) = False Then
                                        item.DropDownItems.Add(menu2)
                                        AddHandler menu2.Click, AddressOf mnuItem_Clicked
                                    End If

                                    If ce = False Then
                                        net = network
                                        ce = True
                                        menu2.Checked = True
                                    End If
                                End If
                            Next
                        Catch ex As Exception

                        End Try

                    End If

                End If
            Next

            Dim esiste As Boolean = False

            Try
                For Each item As ToolStripMenuItem In SelezioneNetworkToolStripMenuItem.DropDownItems
                    If My.Settings.nic <> "" And My.Settings.nic.ToString.ToLower.Trim = item.Text.ToString.ToLower.Trim Then
                        esiste = True
                        Exit For
                    Else
                        My.Settings.nic = ""
                    End If
                Next
            Catch ex As Exception

            End Try
            If esiste Then
                Try
                    For Each item As ToolStripMenuItem In SelezioneNetworkToolStripMenuItem.DropDownItems
                        item.Checked = False
                        If My.Settings.nic <> "" And My.Settings.nic.ToString.ToLower.Trim = item.Text.ToString.ToLower.Trim Then
                            item.Checked = True
                        End If
                    Next
                Catch ex As Exception

                End Try
            End If




        Catch exception As System.Exception
            Throw
        End Try
    End Sub
    Private Sub BandSec()
        If net Is Nothing Then
            Exit Sub
        End If
        Try

            Dim NicStats As IPv4InterfaceStatistics = net.GetIPv4Statistics
            If LastUpload = -1 Then
                LastUpload = NicStats.BytesSent
            End If

            If LastDownload = -1 Then
                LastDownload = NicStats.BytesReceived
            End If


            Dim Up = NicStats.BytesSent - LastUpload
            Dim Down = NicStats.BytesReceived - LastDownload

            LastUpload = NicStats.BytesSent
            LastDownload = NicStats.BytesReceived
            Try
                If duepunti Then
                    Label1.Text = ": " & BytesConverter(If(Down < 0, 0, Down)) & "/s"
                    Label2.Text = ": " & BytesConverter(If(Up < 0, 0, Up)) & "/s"
                Else
                    Label1.Text = " " & BytesConverter(If(Down < 0, 0, Down)) & "/s"
                    Label2.Text = " " & BytesConverter(If(Up < 0, 0, Up)) & "/s"
                End If

                Label1.Text = Label1.Text.Replace(",", ".")
                Label2.Text = Label2.Text.Replace(",", ".")



                PictureBox1.Top = 10
                PictureBox1.Left = Label1.Left
                PictureBox1.Width = Label1.Width / 2
                PictureBox1.Height = Me.Height - 20

                PictureBox3.Top = Label2.Top
                PictureBox3.Left = 0
                PictureBox3.Height = Label2.Height
                PictureBox3.Width = PictureBox3.Height / 8 * 7

                PictureBox2.Top = Label1.Top
                PictureBox2.Left = 0
                PictureBox2.Height = PictureBox3.Height
                PictureBox2.Width = PictureBox3.Width

                Label1.Left = PictureBox2.Width
                Label2.Left = PictureBox3.Width

                If Label1.Width > Label2.Width Then
                    Me.Width = Label1.Width + PictureBox2.Width + 5
                Else
                    Me.Width = Label2.Width + PictureBox3.Width + 5
                End If

            Catch ex As Exception

            End Try



        Catch ex As Exception

        End Try

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        cambiagiu()
    End Sub

    Private Sub SelezionaCororeTestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezionaCororeTestoToolStripMenuItem.Click
        Me.ColorDialog1.Color = Label1.ForeColor
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            Label1.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            My.Settings.colore = ColorDialog1.Color
            My.Settings.Save()
            salvaconfig("labelcolor", Label1.ForeColor.Name.ToString.ToLower)
        End If
        ritorna = False
    End Sub

    Private Sub SeelzionaFontTestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeelzionaFontTestoToolStripMenuItem.Click
        Me.FontDialog1.Font = Label1.Font
        ritorna = True
        If FontDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            Label1.Font = FontDialog1.Font
            Label2.Font = FontDialog1.Font

            My.Settings.font = FontDialog1.Font
            My.Settings.Save()
            posiziona()
            Dim a, b, c, d As String
            a = Label1.Font.Name
            b = CStr(CInt(Label1.Font.Size))
            If Label1.Font.Bold Then
                c = "bold"
            Else
                c = ""
            End If
            If Label1.Font.Italic Then
                d = "italic"
            Else
                d = ""
            End If
            If c = "" Then
                c = "regular"
            End If
            Dim f As String = ""
            If d <> "" Then
                f = a & "," & b & "," & c & "," & d
            Else
                f = a & "," & b & "," & c
            End If
            salvaconfig("font", f)

        End If
        ritorna = False
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SelezionaColoreUploadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ColorDialog1.Color = My.Settings.coloreup
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            My.Settings.coloreup = ColorDialog1.Color
            My.Settings.Save()
            cambiasu()
        End If
        ritorna = False
    End Sub

    Private Sub SelezionaColoreDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ColorDialog1.Color = My.Settings.coloredown
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            My.Settings.coloredown = ColorDialog1.Color
            My.Settings.Save()
            cambiagiu()
        End If
        ritorna = False
    End Sub

    Private Sub SpostamiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SpostamiToolStripMenuItem.Click
        Me.PictureBox1.Visible = Not Me.PictureBox1.Visible
        SpostamiToolStripMenuItem.Checked = Me.PictureBox1.Visible
        If SpostamiToolStripMenuItem.Checked Then
            SpostamiToolStripMenuItem.Text = "FINE Spostami"
        Else
            SpostamiToolStripMenuItem.Text = "Spostami"
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = MouseButtons.Left Then
            ' Get the new position
            mouseOffset = New Point(-e.X, -e.Y)
            ' Set that left button is pressed
            isMouseDown = True
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If isMouseDown Then
            Dim mousePos As Point = Control.MousePosition
            ' Get the new form position
            mousePos.Offset(mouseOffset.X, mouseOffset.Y)
            Me.Left = mousePos.X
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If e.Button = MouseButtons.Left Then
            isMouseDown = False
            My.Settings.posizione = Me.Left
            My.Settings.Save()
            salvaconfig("posizione", posizione.ToString)
        End If
    End Sub
    Sub salvaconfig(cosa As String, valore As String)
        If IO.File.Exists(Application.StartupPath & "\speed-meter.cfg") Then
            Dim linee As String() = IO.File.ReadAllLines(Application.StartupPath & "\speed-meter.cfg")
            For x As Integer = 0 To linee.Count - 1
                Dim s As String = linee(x).ToLower.Trim

                If s.StartsWith("[" & cosa & "]") Then
                    linee(x) = "[" & cosa & "]=" & valore.Trim
                End If
            Next

            IO.File.WriteAllLines(Application.StartupPath & "\speed-meter.cfg", linee)
        End If
    End Sub
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub ContextMenuStrip3_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub SeleionaColoreUploadToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ColorDialog1.Color = My.Settings.coloredown
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            My.Settings.coloredown = ColorDialog1.Color
            My.Settings.Save()
            cambiagiu()
        End If
        ritorna = False
    End Sub

    Private Sub SelezionaColoreTestoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Me.ColorDialog1.Color = Label1.ForeColor
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            Label1.ForeColor = ColorDialog1.Color
            Label2.ForeColor = ColorDialog1.Color
            My.Settings.colore = ColorDialog1.Color
            My.Settings.Save()

        End If
        ritorna = False
    End Sub

    Private Sub SelezioneColoreDownloadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelezioneColoreDownloadToolStripMenuItem.Click
        Me.ColorDialog1.Color = My.Settings.coloredown
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            My.Settings.coloredown = ColorDialog1.Color
            My.Settings.Save()
            cambiagiu()
            salvaconfig("downcolor", ColorDialog1.Color.Name.ToString.ToLower)
        End If
        ritorna = False
    End Sub

    Private Sub SelezionaColoreUploadToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SelezionaColoreUploadToolStripMenuItem1.Click
        Me.ColorDialog1.Color = My.Settings.coloreup
        ritorna = True
        If ColorDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then

            My.Settings.coloreup = ColorDialog1.Color
            My.Settings.Save()
            cambiasu()
            salvaconfig("upcolor", ColorDialog1.Color.Name.ToString.ToLower)
        End If
        ritorna = False
    End Sub
    Dim bandwidth As String = "Mb"
    Private Sub GBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GBToolStripMenuItem.Click
        bandwidth = "GB"
        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
        Catch ex As Exception

        End Try
        GBToolStripMenuItem.Checked = True
        My.Settings.banda = bandwidth
        My.Settings.Save()
    End Sub

    Private Sub GbToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GbToolStripMenuItem1.Click
        bandwidth = "Gb"
        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
        Catch ex As Exception

        End Try
        GbToolStripMenuItem1.Checked = True
        My.Settings.banda = bandwidth
        My.Settings.Save()
    End Sub


    Private Sub MBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MBToolStripMenuItem.Click
        bandwidth = "MB"
        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
        Catch ex As Exception

        End Try
        MBToolStripMenuItem.Checked = True
        My.Settings.banda = bandwidth
        My.Settings.Save()
    End Sub

    Private Sub MbToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MbToolStripMenuItem1.Click
        bandwidth = "Mb"
        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
        Catch ex As Exception

        End Try
        MbToolStripMenuItem1.Checked = True
        My.Settings.banda = bandwidth
        My.Settings.Save()

    End Sub

    Private Sub KBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KBToolStripMenuItem.Click
        bandwidth = "KB"
        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
        Catch ex As Exception

        End Try
        KBToolStripMenuItem.Checked = True
        My.Settings.banda = bandwidth
        My.Settings.Save()
    End Sub

    Private Sub KbToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles KbToolStripMenuItem1.Click
        bandwidth = "Kb"
        Try
            For Each i As ToolStripMenuItem In SelezionaBandWidthToolStripMenuItem.DropDownItems
                i.Checked = False
            Next
        Catch ex As Exception

        End Try
        KbToolStripMenuItem1.Checked = True
        My.Settings.banda = bandwidth
        My.Settings.Save()
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub
End Class

