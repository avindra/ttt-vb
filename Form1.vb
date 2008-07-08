Public Class Form1
    Dim btnArray() As Button
    Dim turns As Integer
    Dim blnComp As Boolean = True
    'glitch in impossible mode: 1,5,8, next game, press 1
    Private Sub MakeMove(ByVal button_pressed As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click
        turns += 1
        lblturns.Text = turns & " Turns"
        If lblTurn.Text = "X" Then
            button_pressed.Text = "X"
            lblTurn.Text = "O"
        Else
            button_pressed.Text = "O"
            lblTurn.Text = "X"
        End If
        button_pressed.Enabled = False
        If Winner() Then Exit Sub
        If radComp.Checked And blnComp Then
            blnComp = False
            MakeMove(ComputerMove, e)
        Else
            blnComp = True
        End If
    End Sub
#Region "    Computer's Brain      "
    Function ComputerMove() As Button
        Randomize()
        Dim north() As Button = {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
        Dim northr() As Button = {Button3, Button2, Button1, Button6, Button5, Button4, Button9, Button8, Button7}
        Dim east() As Button = {Button3, Button6, Button9, Button2, Button5, Button8, Button1, Button4, Button7}
        Dim eastr() As Button = {Button9, Button6, Button3, Button8, Button5, Button2, Button7, Button4, Button1}
        Dim west() As Button = {Button7, Button4, Button1, Button8, Button5, Button2, Button9, Button6, Button3}
        Dim westr() As Button = {Button1, Button4, Button7, Button2, Button5, Button8, Button3, Button6, Button9}
        Dim south() As Button = {Button9, Button8, Button7, Button6, Button5, Button4, Button3, Button2, Button1}
        Dim southr() As Button = {Button7, Button8, Button9, Button4, Button5, Button6, Button1, Button2, Button3}
        Dim orientations As New Collection
        orientations.Add(north) : orientations.Add(northr)
        orientations.Add(east) : orientations.Add(eastr)
        orientations.Add(west) : orientations.Add(westr)
        orientations.Add(south) : orientations.Add(southr)
        'win
        If radHard.Checked Or radImp.Checked Then
            For Each rot As Button() In orientations
                If rot(0).Text = "O" And rot(1).Text = "O" And rot(2).Enabled Then Return rot(2)
                'midmiss
                If rot(0).Text = "O" And rot(2).Text = "O" And rot(1).Enabled Then Return rot(1)
                If rot(0).Text = "O" And Button5.Text = "O" And rot(8).Enabled Then Return rot(8)
                '3
                If rot(3).Text = "O" And Button5.Text = "O" And rot(5).Enabled Then Return rot(5)
            Next
        End If
        'defend
        If radNormal.Checked Or radHard.Checked Or radImp.Checked Then
            For Each rot As Button() In orientations
                If rot(0).Text = "X" And rot(1).Text = "X" And rot(2).Enabled Then Return rot(2)
                If rot(0).Text = "X" And rot(2).Text = "X" And rot(1).Enabled Then Return rot(1)
                If rot(0).Text = "X" And Button5.Text = "X" And rot(8).Enabled Then Return rot(8)
                If rot(3).Text = "X" And Button5.Text = "X" And rot(5).Enabled Then Return rot(5)
            Next
        End If
        If radImp.Checked Then
            '<-------------------------------------------------------------------------->
            '                                   FORKING
            '<-------------------------------------------------------------------------->
            '<--a-->
            For Each rot As Button() In orientations
                If rot(0).Text = "O" And rot(2).Text = "O" And Button5.Enabled Then Return Button5
                If rot(0).Text = "O" And Button5.Text = "O" And rot(2).Enabled Then Return rot(2)
                If rot(2).Text = "O" And Button5.Text = "O" And rot(0).Enabled Then Return rot(0)
            Next
            '<--b-->
            For Each rot As Button() In orientations
                If Button5.Text = "O" And rot(6).Text = "O" And rot(7).Enabled Then Return rot(7)
                If Button5.Text = "O" And rot(7).Text = "O" And rot(6).Enabled Then Return rot(6)
                If rot(7).Text = "O" And rot(6).Text = "O" And Button5.Enabled Then Return Button5
            Next
            '<--c-->
            For Each rot As Button() In orientations
                If rot(0).Text = "O" And rot(1).Text = "O" And rot(3).Enabled Then Return rot(3)
                If rot(0).Text = "O" And rot(3).Text = "O" And rot(1).Enabled Then Return rot(1)
                If rot(3).Text = "O" And rot(1).Text = "O" And rot(0).Enabled Then Return rot(0)
            Next
            '<--d-->
            For Each rot As Button() In orientations
                If rot(0).Text = "O" And rot(8).Text = "O" And rot(6).Enabled Then Return rot(6)
                If rot(0).Text = "O" And rot(6).Text = "O" And rot(2).Enabled Then Return rot(2)
                If rot(0).Text = "O" And rot(2).Text = "O" And rot(6).Enabled Then Return rot(6)
                If rot(6).Text = "O" And rot(2).Text = "O" And rot(0).Enabled Then Return rot(0)
            Next
            '<--e-->
            For Each rot As Button() In orientations
                If rot(1).Text = "O" And rot(6).Text = "O" And rot(7).Enabled Then Return rot(7)
                If rot(1).Text = "O" And rot(7).Text = "O" And rot(6).Enabled Then Return rot(6)
                If rot(6).Text = "O" And rot(7).Text = "O" And rot(1).Enabled Then Return rot(1)
            Next
            '<-------------------------------------------------------------------------->
            '                            BLOCK FORKING
            '<-------------------------------------------------------------------------->
            '<--f-->
            For Each rot As Button() In orientations
                If rot(0).Text = "X" And rot(2).Text = "X" And rot(5).Enabled Then Return rot(5)
                If rot(0).Text = "X" And rot(5).Text = "X" And rot(2).Enabled Then Return rot(2)
                If rot(5).Text = "X" And rot(2).Text = "X" And rot(0).Enabled Then Return rot(0)
            Next
            '<--a-->
            For Each rot As Button() In orientations
                If rot(0).Text = "X" And rot(2).Text = "X" And Button5.Enabled Then Return Button5
                If rot(0).Text = "X" And Button5.Text = "X" And rot(2).Enabled Then Return rot(2)
                If rot(2).Text = "X" And Button5.Text = "X" And rot(0).Enabled Then Return rot(0)
            Next
            '<--b-->
            For Each rot As Button() In orientations
                If Button5.Text = "X" And rot(6).Text = "X" And rot(7).Enabled Then Return rot(7)
                If Button5.Text = "X" And rot(7).Text = "X" And rot(6).Enabled Then Return rot(6)
                If rot(7).Text = "X" And rot(6).Text = "X" And Button5.Enabled Then Return Button5
            Next
            '<--c-->
            For Each rot As Button() In orientations
                If rot(0).Text = "X" And rot(1).Text = "X" And rot(3).Enabled Then Return rot(3)
                If rot(0).Text = "X" And rot(3).Text = "X" And rot(1).Enabled Then Return rot(1)
                If rot(3).Text = "X" And rot(1).Text = "X" And rot(0).Enabled Then Return rot(0)
            Next
            '<--d-->
            Dim defend As Boolean
            Dim badbut As Button
            For Each rot As Button() In orientations
                If rot(0).Text = "X" And rot(6).Text = "X" And (rot(2).Enabled Or rot(8).Enabled) Then
                    defend = True
                    badbut = rot(2)
                End If
                If rot(0).Text = "X" And rot(2).Text = "X" And (rot(6).Enabled Or rot(8).Enabled) Then
                    defend = True
                    badbut = rot(6)
                End If
                If rot(6).Text = "X" And rot(2).Text = "X" And (rot(0).Enabled Or rot(8).Enabled) Then
                    defend = True
                    badbut = rot(0)
                End If
                If defend Then
                    Dim theMove As Button = Button1
                    Do While theMove.Enabled = False Or theMove Is badbut Or theMove Is rot(8)
                        theMove = btnArray(Int(Rnd() * 8))
                    Loop
                    Return theMove
                End If
            Next
            '<--e-->
            For Each rot As Button() In orientations
                If rot(1).Text = "X" And rot(6).Text = "X" And rot(7).Enabled Then Return rot(7)
                If rot(1).Text = "X" And rot(7).Text = "X" And rot(6).Enabled Then Return rot(6)
                If rot(6).Text = "X" And rot(7).Text = "X" And rot(1).Enabled Then Return rot(1)
            Next
            'center
            If Button5.Enabled Then Return Button5
            'opposite corner
            If Button1.Text = "X" And Button9.Enabled Then Return Button9
            If Button9.Text = "X" And Button1.Enabled Then Return Button1
            If Button3.Text = "X" And Button7.Enabled Then Return Button7
            If Button7.Text = "X" And Button3.Enabled Then Return Button3
            'empty corner
            Dim corners() As Button = {Button1, Button3, Button7, Button9}
            Dim cornPlay As Button = corners(Int(Rnd() * 3))
            Do While cornPlay.Enabled = False
                cornPlay = corners(Int(Rnd() * 3))
            Loop
            Return cornPlay
            'empty side
            Dim sides() As Button = {Button2, Button4, Button6, Button8}
            Dim sidePlay As Button = sides(Int(Rnd() * 3))
            Do While sidePlay.Enabled = False
                sidePlay = sides(Int(Rnd() * 3))
            Loop
            Return sidePlay
        End If

        Dim compMove As Button = btnArray(Int(Rnd() * 8))
        Do While compMove.Enabled = False
            compMove = btnArray(Int(Rnd() * 8))
        Loop
        Return compMove
    End Function
#End Region
    Function Winner() As Boolean
        Dim nulle As System.EventArgs = Nothing
        If (Button1.Text = "X" And Button2.Text = "X" And Button3.Text = "X") Or (Button4.Text = "X" And Button5.Text = "X" And Button6.Text = "X") Or (Button7.Text = "X" And Button8.Text = "X" And Button9.Text = "X") Or (Button4.Text = "X" And Button1.Text = "X" And Button7.Text = "X") Or (Button2.Text = "X" And Button5.Text = "X" And Button8.Text = "X") Or (Button3.Text = "X" And Button9.Text = "X" And Button6.Text = "X") Or (Button1.Text = "X" And Button5.Text = "X" And Button9.Text = "X") Or (Button3.Text = "X" And Button5.Text = "X" And Button7.Text = "X") Then
            Dim playgain As DialogResult = MessageBox.Show("Do you want to play again?", "X Wins!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If playgain = Windows.Forms.DialogResult.Yes Then New_Game(vbNull, nulle) Else Application.Exit()
            Return True
        End If
        If (Button1.Text = "O" And Button2.Text = "O" And Button3.Text = "O") Or (Button4.Text = "O" And Button5.Text = "O" And Button6.Text = "O") Or (Button7.Text = "O" And Button8.Text = "O" And Button9.Text = "O") Or (Button4.Text = "O" And Button1.Text = "O" And Button7.Text = "O") Or (Button2.Text = "O" And Button5.Text = "O" And Button8.Text = "O") Or (Button3.Text = "O" And Button9.Text = "O" And Button6.Text = "O") Or (Button1.Text = "O" And Button5.Text = "O" And Button9.Text = "O") Or (Button3.Text = "O" And Button5.Text = "O" And Button7.Text = "O") Then
            Dim playgain As DialogResult = MessageBox.Show("Do you want to play again?", "O Wins!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If playgain = Windows.Forms.DialogResult.Yes Then New_Game(vbNull, nulle) Else Application.Exit()
            Return True
        End If
        Dim blnDraw As Boolean = True
        For Each gamebutton As Button In btnArray
            If gamebutton.Enabled Then blnDraw = False
        Next
        If blnDraw And radImp.Checked Then
            Dim playgain As DialogResult = MessageBox.Show("I told you it was impossible! Want to try again, even though you'll lose?", "It's a Draw ~ Give Up Already!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If playgain = Windows.Forms.DialogResult.Yes Then New_Game(vbNull, nulle) Else Application.Exit()
            Return True
        End If
        If blnDraw Then
            Dim playgain As DialogResult = MessageBox.Show("Do you want to play again?", "It's a Draw!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If playgain = Windows.Forms.DialogResult.Yes Then New_Game(vbNull, nulle) Else Application.Exit()
            Return True
        End If
        Return False
    End Function
    Private Sub InitializeButtonArray(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btnArray = New Button() {Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9}
    End Sub
    Private Sub New_Game(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGame.Click
        turns = 0
        For Each gamebutton As Button In btnArray
            gamebutton.Text = ""
            gamebutton.Enabled = True
        Next
        lblTurn.Text = "X"
        blnComp = True
    End Sub
    Private Sub Exit_Game(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class