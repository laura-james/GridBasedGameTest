<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GFX
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GFX))
        Me.pbGFX = New System.Windows.Forms.PictureBox()
        CType(Me.pbGFX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbGFX
        '
        Me.pbGFX.Image = CType(resources.GetObject("pbGFX.Image"), System.Drawing.Image)
        Me.pbGFX.Location = New System.Drawing.Point(40, 44)
        Me.pbGFX.Name = "pbGFX"
        Me.pbGFX.Size = New System.Drawing.Size(616, 342)
        Me.pbGFX.TabIndex = 0
        Me.pbGFX.TabStop = False
        '
        'GFX
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pbGFX)
        Me.Name = "GFX"
        Me.Text = "GFX"
        CType(Me.pbGFX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbGFX As PictureBox
End Class
