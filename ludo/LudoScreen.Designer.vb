<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LudoScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LudoScreen))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Play = New System.Windows.Forms.Button
        Me.Path = New System.Windows.Forms.ListBox
        Me.Rounds = New System.Windows.Forms.ListView
        Me.Reset = New System.Windows.Forms.Button
        Me.Die1 = New System.Windows.Forms.PictureBox
        Me.Dice = New System.Windows.Forms.ImageList(Me.components)
        Me.Die2 = New System.Windows.Forms.PictureBox
        CType(Me.Die1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Die2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 250
        '
        'Play
        '
        Me.Play.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Play.Font = New System.Drawing.Font("Webdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Play.Location = New System.Drawing.Point(404, 5)
        Me.Play.Name = "Play"
        Me.Play.Size = New System.Drawing.Size(30, 30)
        Me.Play.TabIndex = 0
        Me.Play.Text = "4"
        Me.Play.UseVisualStyleBackColor = True
        '
        'Path
        '
        Me.Path.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Path.FormattingEnabled = True
        Me.Path.Location = New System.Drawing.Point(453, 4)
        Me.Path.Name = "Path"
        Me.Path.Size = New System.Drawing.Size(69, 67)
        Me.Path.TabIndex = 2
        '
        'Rounds
        '
        Me.Rounds.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Rounds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Rounds.FullRowSelect = True
        Me.Rounds.HideSelection = False
        Me.Rounds.Location = New System.Drawing.Point(281, 79)
        Me.Rounds.Name = "Rounds"
        Me.Rounds.Size = New System.Drawing.Size(241, 181)
        Me.Rounds.TabIndex = 3
        Me.Rounds.UseCompatibleStateImageBehavior = False
        Me.Rounds.View = System.Windows.Forms.View.Details
        '
        'Reset
        '
        Me.Reset.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Reset.Font = New System.Drawing.Font("Webdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Reset.Location = New System.Drawing.Point(404, 43)
        Me.Reset.Name = "Reset"
        Me.Reset.Size = New System.Drawing.Size(30, 30)
        Me.Reset.TabIndex = 1
        Me.Reset.Text = "q"
        Me.Reset.UseVisualStyleBackColor = True
        '
        'Die1
        '
        Me.Die1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Die1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Die1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Die1.Location = New System.Drawing.Point(337, 4)
        Me.Die1.Name = "Die1"
        Me.Die1.Size = New System.Drawing.Size(50, 50)
        Me.Die1.TabIndex = 4
        Me.Die1.TabStop = False
        '
        'Dice
        '
        Me.Dice.ImageStream = CType(resources.GetObject("Dice.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.Dice.TransparentColor = System.Drawing.Color.Transparent
        Me.Dice.Images.SetKeyName(0, "01.gif")
        Me.Dice.Images.SetKeyName(1, "02.gif")
        Me.Dice.Images.SetKeyName(2, "03.gif")
        Me.Dice.Images.SetKeyName(3, "04.gif")
        Me.Dice.Images.SetKeyName(4, "05.gif")
        Me.Dice.Images.SetKeyName(5, "06.gif")
        '
        'Die2
        '
        Me.Die2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Die2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Die2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Die2.Location = New System.Drawing.Point(281, 4)
        Me.Die2.Name = "Die2"
        Me.Die2.Size = New System.Drawing.Size(50, 50)
        Me.Die2.TabIndex = 4
        Me.Die2.TabStop = False
        '
        'LudoScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 273)
        Me.Controls.Add(Me.Die2)
        Me.Controls.Add(Me.Die1)
        Me.Controls.Add(Me.Rounds)
        Me.Controls.Add(Me.Path)
        Me.Controls.Add(Me.Reset)
        Me.Controls.Add(Me.Play)
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "LudoScreen"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Ludo - cselian.com"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Die1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Die2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Play As System.Windows.Forms.Button
    Friend WithEvents Path As System.Windows.Forms.ListBox
    Friend WithEvents Rounds As System.Windows.Forms.ListView
    Friend WithEvents Reset As System.Windows.Forms.Button
    Friend WithEvents Die1 As System.Windows.Forms.PictureBox
    Friend WithEvents Dice As System.Windows.Forms.ImageList
    Friend WithEvents Die2 As System.Windows.Forms.PictureBox

End Class
