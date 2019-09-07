﻿Imports System.IO
Imports NAudio.Midi
Imports A2UP.A2U.keyLED_MIDEX

Public Class keyLED_Edit
    Public CanEnable As Boolean = False

    Private Sub KeyLED_Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'FileName 표시.
        For Each foundFile As String In My.Computer.FileSystem.GetFiles("Workspace\ableproj\CoLED", FileIO.SearchOption.SearchTopLevelOnly, "*.mid") 'FileName의 파일 찾기
            Invoke(Sub()
                       Dim itm As New ListViewItem(New String() {Path.GetFileName(foundFile), foundFile})
                       LED_ListView.Items.Add(itm)  '파일 이름 추가
                   End Sub)
        Next
    End Sub

    Private Sub CopyButton_Click(sender As Object, e As EventArgs) Handles CopyButton.Click
        '복사 코드.
        If UniLED_Edit.Enabled = False Then
            MessageBox.Show("First, You should convert LED!", "UniConverter", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Clipboard.SetText(UniLED_Edit.Text)
            MessageBox.Show("UniPack LED Copied!", "UniConverter", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub GazuaButton_Click(sender As Object, e As EventArgs) Handles GazuaButton.Click
        Try
            If GAZUA_.IsBusy = False Then
                GAZUA_.RunWorkerAsync()
            ElseIf GAZUA_.IsBusy = True Then
                MessageBox.Show("Please Wait...", Me.Text & ": Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            If MainProject.IsGreatExMode Then
                MessageBox.Show("Error - " & ex.Message & vbNewLine & "Error Message: " & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error: " & ex.Message, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub KeyLED_Edit_Closing() Handles MyBase.FormClosing, MyBase.Disposed
        keyLED_Test.Enabled = True
        keyLED_Test.Dispose()
    End Sub

    Private Sub GAZUA__DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles GAZUA_.DoWork
        Try
            Dim ConLEDFile As String = String.Empty
            Invoke(Sub() ConLEDFile = LED_ListView.FocusedItem.SubItems.Item(0).Text) '선택한 아이템.

            Invoke(Sub()
                       CanEnable = False
                       TestButton.Enabled = False
                       keyLED_Test.Enabled = False
                       CopyButton.Enabled = False
                   End Sub)

            'Beta Code!
            '이 Beta Convert Code는 오류가 발생할 수 있습니다.
            '주의사항을 다 보셨다면, 당신은 Editor 권한을 가질 수 있습니다.

            '변환 코드...            
            'V1.0.0.1 ~ V1.0.0.2 - String.Replace로 이용한 ConLED 파일 표시: ConLEDFile '[ConLEDFile String 계산: ":FileName.Ext"]
            'V1.1.0.3 - Item.ToString을 Item.Text로 코드 최적화.

            Dim stopw As New Stopwatch
            stopw.Start()

            Dim LEDFileName As String = "Workspace\ableproj\CoLED\" & ConLEDFile
            Dim keyLED As New MidiFile(LEDFileName, False)

            Invoke(Sub()
                       UniLED_Edit.Enabled = True
                       UniLED_Edit.Clear()
                       UniLED_Edit.Text = "Please Wait..."
                       UniLED1.Text = "File Name: " & ConLEDFile
                   End Sub)

            '이 코드는 Follow_JB님의 midi2keyLED를 참고하여 만든 코드. (Thanks to Follow_JB. :D)

            Dim str As String = String.Empty
            Dim delaycount As Integer = 0
            Dim UniNoteNumberX As Integer 'X
            Dim UniNoteNumberY As Integer 'Y

            For Each mdEvent_list In keyLED.Events
                For Each mdEvent In mdEvent_list

                    Dim Item_a As String = String.Empty
                    Invoke(Sub() Item_a = ALGModeBox.SelectedItem.ToString())
                    If Item_a = "Ableton 9 ALG1" Then

                        If mdEvent.CommandCode = MidiCommandCode.NoteOn Then
                            Dim a As NoteOnEvent = DirectCast(mdEvent, NoteOnEvent)
                            Dim bpm As New TempoEvent(500000, a.AbsoluteTime)

                            If Not delaycount = a.AbsoluteTime OrElse Not a.DeltaTime = 0 Then
                                str = str & vbNewLine & "d " & GetNoteDelay(keyLED_NoteEvents.NoteLength_2, bpm.Tempo, keyLED.DeltaTicksPerQuarterNote, a.AbsoluteTime - delaycount)
                            End If

                            UniNoteNumberX = GX_keyLED(keyLED_NoteEvents.NoteNumber_1, a.NoteNumber)
                            UniNoteNumberY = GY_keyLED(keyLED_NoteEvents.NoteNumber_1, a.NoteNumber)
                            delaycount = a.AbsoluteTime

                            If Not UniNoteNumberX = -8192 Then
                                str = str & vbNewLine & "o " & UniNoteNumberX & " " & UniNoteNumberY & " a " & a.Velocity
                            Else
                                str = str & vbNewLine & "o mc " & UniNoteNumberY & " a " & a.Velocity
                            End If

                        ElseIf mdEvent.CommandCode = MidiCommandCode.NoteOff Then

                            Dim a As NoteEvent = DirectCast(mdEvent, NoteEvent)
                            Dim bpm As New TempoEvent(500000, a.AbsoluteTime)

                            If Not delaycount = a.AbsoluteTime OrElse Not a.DeltaTime = 0 Then
                                str = str & vbNewLine & "d " & GetNoteDelay(keyLED_NoteEvents.NoteLength_2, bpm.Tempo, keyLED.DeltaTicksPerQuarterNote, a.AbsoluteTime - delaycount)
                            End If

                            UniNoteNumberX = GX_keyLED(keyLED_NoteEvents.NoteNumber_1, a.NoteNumber)
                            UniNoteNumberY = GY_keyLED(keyLED_NoteEvents.NoteNumber_1, a.NoteNumber)
                            delaycount = a.AbsoluteTime

                            If UniNoteNumberX = 0 AndAlso UniNoteNumberY = 0 Then
                                Debug.WriteLine("Unknown Note Number. [ Note: " & a.NoteNumber & " ]")
                                Continue For
                            End If

                            If Not UniNoteNumberX = -8192 Then
                                str = str & vbNewLine & "f " & UniNoteNumberX & " " & UniNoteNumberY
                            Else
                                str = str & vbNewLine & "f mc " & UniNoteNumberY
                            End If

                        End If

                    ElseIf Item_a = "Non-Convert (Developer Mode)" Then
#Region "Non-Convert (Developer Mode)"
                        If mdEvent.CommandCode = MidiCommandCode.NoteOn Then
                            Dim a As NoteOnEvent = DirectCast(mdEvent, NoteOnEvent)

                            If Not delaycount = a.AbsoluteTime Then
                                str = str & vbNewLine & "d " & a.AbsoluteTime - delaycount
                            End If

                            delaycount = a.AbsoluteTime
                            str = str & vbNewLine & "o " & a.NoteNumber & " a " & a.Velocity

                        ElseIf mdEvent.CommandCode = MidiCommandCode.NoteOff Then

                            Dim a As NoteEvent = DirectCast(mdEvent, NoteEvent)

                            If Not delaycount = a.AbsoluteTime Then
                                str = str & vbNewLine & "d " & a.AbsoluteTime - delaycount
                            End If

                            str = str & vbNewLine & "f " & a.NoteNumber

                        End If
#End Region

                    Else
                        MessageBox.Show("You have to select the 'Ableton ALG1' or 'Non-Convert (Developer Mode)'.'", Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        e.Cancel = True
                        Exit Sub
                    End If
                Next
            Next

            Invoke(Sub()
                       UniLED_Edit.Text = str.Remove(0, 0)
                       TestButton.Enabled = True
                       keyLED_Test.Enabled = True
                       CopyButton.Enabled = True
                   End Sub)
            CanEnable = True 'Enabled to Test the LED.
            keyLED_Test.LoadkeyLEDText(UniLED_Edit.Text)

            stopw.Stop()
            Debug.WriteLine(String.Format("'{0}' Elapsed Time: {1}ms", ConLEDFile, stopw.ElapsedMilliseconds))

        Catch ex As Exception
            If MainProject.IsGreatExMode Then
                MessageBox.Show("Error - " & ex.Message & vbNewLine & "Error Message: " & ex.StackTrace, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show("Error: " & ex.Message, Me.Text & ": Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub TestButton_Click(sender As Object, e As EventArgs) Handles TestButton.Click
        If CanEnable Then
            keyLED_Test.Show()
            keyLED_Test.LoadkeyLEDText(UniLED_Edit.Text)
        Else
            MessageBox.Show("You have to convert the LED first!" & vbNewLine & "Please wait...", Me.Text & ": Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class