﻿Imports System.Globalization

Public Class Translator
    Private lang As tL
    Private IsDM As Boolean = False

#Region "Enum: 언어"
    Public Enum tL
        English
        Korean
    End Enum
#End Region
#Region "Translator New 선언"
    Public Sub New(ByVal Language As tL)
        lang = Language
    End Sub

    Public Sub New(ByVal Language As tL, ByVal IsDeveloperMode As Boolean)
        lang = Language
        IsDM = IsDeveloperMode
    End Sub

    Public Shared Function GetTranslator(ByVal Language As tL) As Translator
        Return New Translator(Language)
    End Function

    Public Shared Function GetTranslator(ByVal Language As tL, IsDeveloperMode As Boolean) As Translator
        Return New Translator(Language, IsDeveloperMode)
    End Function
#End Region

    Public Shared Function GetLanguage(ByVal CultureInfo As CultureInfo) As String
        Dim lan As String = CultureInfo.EnglishName.Split(" ")(0)
        If lan = "English" OrElse lan = "Korean" Then
            Return lan
        Else
            Return "English"
        End If
    End Function

    Public Shared Function GetLnEnum(ByVal Name As String) As tL
        Select Case Name
            Case "English"
                Return tL.English
            Case "Korean"
                Return tL.Korean
            Case Else
                Throw New CultureNotFoundException("Not Found. Please try 'English' or 'Korean'.")
        End Select
    End Function

    ''' <summary>
    ''' Translate the MainProject Form.
    ''' </summary>
    Public Sub TranslateMain()
        Select Case lang
            Case tL.English
                Exit Sub '유니컨버터의 기본값 텍스트는 영어다.
            Case tL.Korean

                '유니컨버터 v1.2.0.4 한글 버전.
                With MainProject
                    'info 탭
                    .HomeEdit.TabPages(0).Text = Space(7) & "정보"
                    .infoT1.Text = Space(5) & "제목"
                    .infoT2.Text = Space(24) & "제작자"
                    .infoT3.Text = Space(7) & "체인"
                    .infoTB1.Text = "나의 멋진 유니팩!"
                    .infoTB2.Text = "유니컨버터, " & My.Computer.Name
                    .Info_SaveButton.Text = "저장"
                    .Tip1.Text = "팁: 에이블톤 프로젝트를 열면 info를 수정할 수 있습니다."

                    'keySound 탭
                    .Tip3.Text = "팁: 만약 음악 파일이 잘라져 있지 않다면, 음악 파일을 불러오지 마세요." & vbNewLine & "그대신, '음악 자르기' 기능을 이용하여 음악을 자를 수 있습니다. (비추천)"
                    .DevelopingLabel1.Text = "'keySound 변환' 기능을 만들고 있습니다!" & vbNewLine & Space(17) & "잠시만 기다려주세요..."

                    'keyLED 탭
                    .DevelopingLabel2.Text = "'keyLED 변환' 기능을 만들고 있습니다!" & vbNewLine & Space(18) & "잠시만 기다려주세요..."

                    'keyLED (MIDEX) 탭
                    .HomeEdit.TabPages(3).Text = "keyLED (미디 익스텐션)"
                    .DevelopingLabel3.Text = "keyLED (미디 익스텐션)" & vbNewLine & "[ 베타 ]"
                    .keyLEDMIDEX_BetaButton.Text = "keyLED 편집! (미디 익스텐션) (고급)"
                    .keyLEDMIDEX_Md.Text = "keyLED 모드"
                    .keyLEDMIDEX_prMode.Text = "테스트 모드"
                    .keyLEDMIDEX_LEDViewMode.Text = "LED 보기 모드"

                    'MIDI Devices 탭
                    .HomeEdit.TabPages(4).Text = "미디 디바이스"
                    .MIDIn_Test.Text = "미디 입력 테스트"
                    .LoadButton.Text = "불러오기"
                    .ConnectButton.Text = "연결"
                    .MIDIStat.Text = "미디 상태:"
                    .MIDIStatIn.Text = "미디 입력: 연결 안됨"
                    .MIDIStatOut.Text = "미디 출력: 연결 안됨"

                    'MainProject 폼
                    If IsDM = False Then
                        .Text = "유니컨버터 베타 6"
                    Else
                        .Text = "유니컨버터 베타 6 (제작자 모드)"
                    End If

                    'Tool Strip
                    .FileToolStripMenuItem.Text = "파일"
                    .OpenProjectToolStripMenuItem.Text = "프로젝트 열기"
                    .OpenAbletonProjectToolStripMenuItem.Text = "에이블톤 프로젝트 파일 열기"
                    .SoundsToolStripMenuItem.Text = "음악 파일 열기"
                    .OpenKeyLEDToolStripMenuItem.Text = "LED 파일 열기"
                    .SaveProjectToolStripMenuItem.Text = "프로젝트 저장 (불러온 프로젝트만)"
                    .ConvertALSToUnipackToolStripMenuItem.Text = "에이블톤 프로젝트에서 유니팩으로 변환!"

                    .EditToolStripMenuItem.Text = "편집"
                    .ResetTheProjectToolStripMenuItem.Text = "프로젝트 초기화"

                    .TutorialsToolStripMenuItem.Text = "튜토리얼"

                    .SettingsToolStripMenuItem.Text = "정보"
                    .CheckUpdateToolStripMenuItem.Text = "업데이트 확인"
                    .ReportBugsToolStripMenuItem.Text = "버그 제보"
                    .DeveloperModeToolStripMenuItem.Text = "제작자 모드"
                    .SettingsToolStripMenuItem1.Text = "설정"
                    .InfoToolStripMenuItem.Text = "유니컨버터 정보"
                End With

            Case Else
                Throw New CultureNotFoundException("Not Found. Please try 'English' or 'Korean'.")
        End Select
    End Sub
End Class
