﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UG_Settings
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ChkUpdate = New System.Windows.Forms.CheckBox()
        Me.LatestVer = New System.Windows.Forms.CheckBox()
        Me.AbletonSet = New System.Windows.Forms.ComboBox()
        Me.UniPackSet = New System.Windows.Forms.ComboBox()
        Me.SaveButton = New System.Windows.Forms.Button()
        Me.ResetButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ChkUpdate
        '
        Me.ChkUpdate.AutoSize = True
        Me.ChkUpdate.Checked = True
        Me.ChkUpdate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkUpdate.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkUpdate.Location = New System.Drawing.Point(29, 26)
        Me.ChkUpdate.Name = "ChkUpdate"
        Me.ChkUpdate.Size = New System.Drawing.Size(147, 18)
        Me.ChkUpdate.TabIndex = 0
        Me.ChkUpdate.Text = "Auto Check Update"
        Me.ChkUpdate.UseVisualStyleBackColor = True
        '
        'LatestVer
        '
        Me.LatestVer.AutoSize = True
        Me.LatestVer.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LatestVer.Location = New System.Drawing.Point(29, 48)
        Me.LatestVer.Name = "LatestVer"
        Me.LatestVer.Size = New System.Drawing.Size(254, 18)
        Me.LatestVer.TabIndex = 1
        Me.LatestVer.Text = "Execute Latest Version After Update"
        Me.LatestVer.UseVisualStyleBackColor = True
        '
        'AbletonSet
        '
        Me.AbletonSet.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AbletonSet.FormattingEnabled = True
        Me.AbletonSet.Location = New System.Drawing.Point(29, 87)
        Me.AbletonSet.Name = "AbletonSet"
        Me.AbletonSet.Size = New System.Drawing.Size(108, 22)
        Me.AbletonSet.TabIndex = 2
        Me.AbletonSet.Text = "Any Ableton"
        '
        'UniPackSet
        '
        Me.UniPackSet.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UniPackSet.FormattingEnabled = True
        Me.UniPackSet.Location = New System.Drawing.Point(148, 87)
        Me.UniPackSet.Name = "UniPackSet"
        Me.UniPackSet.Size = New System.Drawing.Size(108, 22)
        Me.UniPackSet.TabIndex = 3
        Me.UniPackSet.Text = "Zip / Uni File"
        '
        'SaveButton
        '
        Me.SaveButton.Font = New System.Drawing.Font("Ubuntu", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveButton.Location = New System.Drawing.Point(200, 131)
        Me.SaveButton.Name = "SaveButton"
        Me.SaveButton.Size = New System.Drawing.Size(75, 47)
        Me.SaveButton.TabIndex = 4
        Me.SaveButton.Text = "Save"
        Me.SaveButton.UseVisualStyleBackColor = True
        '
        'ResetButton
        '
        Me.ResetButton.Font = New System.Drawing.Font("Ubuntu", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ResetButton.Location = New System.Drawing.Point(119, 131)
        Me.ResetButton.Name = "ResetButton"
        Me.ResetButton.Size = New System.Drawing.Size(75, 47)
        Me.ResetButton.TabIndex = 5
        Me.ResetButton.Text = "Reset"
        Me.ResetButton.UseVisualStyleBackColor = True
        '
        'UG_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 187)
        Me.Controls.Add(Me.ResetButton)
        Me.Controls.Add(Me.SaveButton)
        Me.Controls.Add(Me.UniPackSet)
        Me.Controls.Add(Me.AbletonSet)
        Me.Controls.Add(Me.LatestVer)
        Me.Controls.Add(Me.ChkUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "UG_Settings"
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ChkUpdate As CheckBox
    Friend WithEvents LatestVer As CheckBox
    Friend WithEvents AbletonSet As ComboBox
    Friend WithEvents UniPackSet As ComboBox
    Friend WithEvents SaveButton As Button
    Friend WithEvents ResetButton As Button
End Class
