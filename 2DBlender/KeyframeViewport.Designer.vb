<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KeyframeViewport
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TrackBar = New System.Windows.Forms.TrackBar()
        Me.OutputBox = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OutputBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TrackBar
        '
        Me.TrackBar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrackBar.Location = New System.Drawing.Point(0, 0)
        Me.TrackBar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TrackBar.Minimum = 1
        Me.TrackBar.Name = "TrackBar"
        Me.TrackBar.Size = New System.Drawing.Size(767, 52)
        Me.TrackBar.TabIndex = 0
        Me.TrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.TrackBar.Value = 1
        '
        'OutputBox
        '
        Me.OutputBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OutputBox.Location = New System.Drawing.Point(0, 0)
        Me.OutputBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OutputBox.Name = "OutputBox"
        Me.OutputBox.Padding = New System.Windows.Forms.Padding(17, 0, 16, 0)
        Me.OutputBox.Size = New System.Drawing.Size(767, 142)
        Me.OutputBox.TabIndex = 1
        Me.OutputBox.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.OutputBox)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TrackBar)
        Me.SplitContainer1.Size = New System.Drawing.Size(767, 204)
        Me.SplitContainer1.SplitterDistance = 142
        Me.SplitContainer1.SplitterWidth = 10
        Me.SplitContainer1.TabIndex = 2
        '
        'KeyframeViewport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "KeyframeViewport"
        Me.Size = New System.Drawing.Size(767, 204)
        CType(Me.TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OutputBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TrackBar As TrackBar
    Friend WithEvents OutputBox As PictureBox
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
