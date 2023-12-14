<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class speedmeter
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SeelzionaFontTestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelezionaCororeTestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelezionaColoreDownloadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SelezionaColoreUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelezioneNetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.ContextMenuStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Label1.Location = New System.Drawing.Point(43, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelezioneNetworkToolStripMenuItem, Me.ToolStripSeparator1, Me.SeelzionaFontTestoToolStripMenuItem, Me.SelezionaCororeTestoToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(224, 82)
        '
        'SeelzionaFontTestoToolStripMenuItem
        '
        Me.SeelzionaFontTestoToolStripMenuItem.Name = "SeelzionaFontTestoToolStripMenuItem"
        Me.SeelzionaFontTestoToolStripMenuItem.Size = New System.Drawing.Size(223, 24)
        Me.SeelzionaFontTestoToolStripMenuItem.Text = "seleziona font testo"
        '
        'SelezionaCororeTestoToolStripMenuItem
        '
        Me.SelezionaCororeTestoToolStripMenuItem.Name = "SelezionaCororeTestoToolStripMenuItem"
        Me.SelezionaCororeTestoToolStripMenuItem.Size = New System.Drawing.Size(223, 24)
        Me.SelezionaCororeTestoToolStripMenuItem.Text = "seleziona colore testo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.Label2.Location = New System.Drawing.Point(42, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Label2"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelezionaColoreDownloadToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(260, 28)
        '
        'SelezionaColoreDownloadToolStripMenuItem
        '
        Me.SelezionaColoreDownloadToolStripMenuItem.Name = "SelezionaColoreDownloadToolStripMenuItem"
        Me.SelezionaColoreDownloadToolStripMenuItem.Size = New System.Drawing.Size(259, 24)
        Me.SelezionaColoreDownloadToolStripMenuItem.Text = "seleziona colore Download"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ContextMenuStrip = Me.ContextMenuStrip2
        Me.Label3.ForeColor = System.Drawing.Color.Green
        Me.Label3.Location = New System.Drawing.Point(10, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 22)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "↓"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ContextMenuStrip = Me.ContextMenuStrip3
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(10, 26)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 22)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "↑"
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelezionaColoreUploadToolStripMenuItem})
        Me.ContextMenuStrip3.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(242, 28)
        '
        'SelezionaColoreUploadToolStripMenuItem
        '
        Me.SelezionaColoreUploadToolStripMenuItem.Name = "SelezionaColoreUploadToolStripMenuItem"
        Me.SelezionaColoreUploadToolStripMenuItem.Size = New System.Drawing.Size(241, 24)
        Me.SelezionaColoreUploadToolStripMenuItem.Text = "Seleziona colore Upload"
        '
        'SelezioneNetworkToolStripMenuItem
        '
        Me.SelezioneNetworkToolStripMenuItem.Name = "SelezioneNetworkToolStripMenuItem"
        Me.SelezioneNetworkToolStripMenuItem.Size = New System.Drawing.Size(223, 24)
        Me.SelezioneNetworkToolStripMenuItem.Text = "Seleziona Network"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(220, 6)
        '
        'speedmeter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(148, 55)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Arial", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "speedmeter"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Speed-meter"
        Me.TopMost = True
        Me.TransparencyKey = System.Drawing.Color.Silver
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.ContextMenuStrip3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents SeelzionaFontTestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelezionaCororeTestoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Timer2 As Timer
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents SelezionaColoreDownloadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents SelezionaColoreUploadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelezioneNetworkToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
