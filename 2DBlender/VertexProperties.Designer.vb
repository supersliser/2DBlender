<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VertexProperties
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Y = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NameValue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.InterpolationType = New System.Windows.Forms.ComboBox()
        Me.AddInterpolation = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Keyframe = New System.Windows.Forms.Button()
        Me.Delete = New System.Windows.Forms.Button()
        Me.X = New System.Windows.Forms.NumericUpDown()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Y, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.X, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Y, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.NameValue, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.X, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(250, 250)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 90)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 45)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vertex Location"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "X"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Location = New System.Drawing.Point(3, 135)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 45)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Y"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Y
        '
        Me.Y.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Y.Location = New System.Drawing.Point(128, 147)
        Me.Y.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.Y.Name = "Y"
        Me.Y.Size = New System.Drawing.Size(119, 20)
        Me.Y.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Location = New System.Drawing.Point(3, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 45)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NameValue
        '
        Me.NameValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameValue.Location = New System.Drawing.Point(128, 12)
        Me.NameValue.Name = "NameValue"
        Me.NameValue.Size = New System.Drawing.Size(119, 20)
        Me.NameValue.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 70)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Interpolation"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.InterpolationType, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.AddInterpolation, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(128, 183)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(119, 64)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'InterpolationType
        '
        Me.InterpolationType.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InterpolationType.FormattingEnabled = True
        Me.InterpolationType.Items.AddRange(New Object() {"Static", "Constant"})
        Me.InterpolationType.Location = New System.Drawing.Point(3, 3)
        Me.InterpolationType.Name = "InterpolationType"
        Me.InterpolationType.Size = New System.Drawing.Size(113, 21)
        Me.InterpolationType.TabIndex = 0
        Me.InterpolationType.Text = "Static"
        '
        'AddInterpolation
        '
        Me.AddInterpolation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AddInterpolation.Location = New System.Drawing.Point(3, 35)
        Me.AddInterpolation.Name = "AddInterpolation"
        Me.AddInterpolation.Size = New System.Drawing.Size(113, 26)
        Me.AddInterpolation.TabIndex = 1
        Me.AddInterpolation.Text = "Add Interpolation"
        Me.AddInterpolation.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.66667!))
        Me.TableLayoutPanel3.Controls.Add(Me.Keyframe, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Delete, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(127, 92)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(121, 41)
        Me.TableLayoutPanel3.TabIndex = 10
        '
        'Keyframe
        '
        Me.Keyframe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Keyframe.Location = New System.Drawing.Point(3, 3)
        Me.Keyframe.Name = "Keyframe"
        Me.Keyframe.Size = New System.Drawing.Size(58, 35)
        Me.Keyframe.TabIndex = 3
        Me.Keyframe.Text = "Keyframe"
        Me.Keyframe.UseVisualStyleBackColor = True
        '
        'Delete
        '
        Me.Delete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Delete.Location = New System.Drawing.Point(66, 2)
        Me.Delete.Margin = New System.Windows.Forms.Padding(2)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New System.Drawing.Size(53, 37)
        Me.Delete.TabIndex = 4
        Me.Delete.Text = "Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'X
        '
        Me.X.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.X.Location = New System.Drawing.Point(128, 57)
        Me.X.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.X.Name = "X"
        Me.X.Size = New System.Drawing.Size(119, 20)
        Me.X.TabIndex = 4
        '
        'VertexProperties
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "VertexProperties"
        Me.Size = New System.Drawing.Size(250, 250)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Y, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.X, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents TableLayoutPanel1 As TableLayoutPanel
    Private WithEvents Label1 As Label
    Private WithEvents Label2 As Label
    Private WithEvents Label3 As Label
    Private WithEvents Keyframe As Button
    Friend WithEvents X As NumericUpDown
    Friend WithEvents Y As NumericUpDown
    Private WithEvents Label4 As Label
    Friend WithEvents NameValue As TextBox
    Friend WithEvents Label5 As Label
    Private WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents InterpolationType As ComboBox
    Friend WithEvents AddInterpolation As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Delete As Button
End Class
