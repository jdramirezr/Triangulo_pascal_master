Public Class Form1



    Public Function par(ByVal n)
        Dim numero As Integer
        Dim npar As Integer

        numero = n

        If numero Mod 2 = 0 Then
            npar = n + 2
            npar = npar / 2
        Else
            npar = n + 1
            npar = npar / 2
        End If

        Return (npar)

    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DataGridView1.Columns.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()


        'Try


        Dim n As Integer
        Dim fila As Integer
        Dim columna As Integer
        Dim i As Integer
        Dim j As Integer
        Dim inicio As Integer

        'Button3.Enabled = True
        n = TextBox1.Text
        fila = n + 1
        columna = n + fila
        fila = fila - 1
        columna = columna - 1
        For x = 0 To columna
            DataGridView1.Columns.Add(x, "")
            DataGridView1.Columns(x).Width = 30
        Next
        For x = 0 To fila
            DataGridView1.Rows.Add(x, "")
        Next
        Dim fibonacci(fila) As Double
        'fibonacci(0) = 1
        'fibonacci(1) = 1

        'Llenar matriz de espacios en blanco

        For i = 0 To columna
            For j = 0 To fila
                DataGridView1(i, j).Value = ""
            Next
        Next

        Dim q As Integer
        Dim anterior As Integer
        Dim despues As Integer

        inicio = columna / 2
        q = 0
        anterior = inicio - q
        despues = inicio + q

        Dim paranterior As Integer
        Dim pardespues As Integer
        paranterior = anterior + 1
        pardespues = despues + 1

        Dim fianterior As Integer
        Dim fidespues As Integer
        Dim iteracion As Integer


        ' TRIANGULO DE PASCAL

        Dim k As Integer
        k = 0
        Dim suma As Double
        suma = 0
        fianterior = anterior + 1
        fidespues = despues + 1

        For i = 0 To fila
            anterior = inicio - q
            despues = inicio + q


            DataGridView1(anterior, i).Value = 1
            DataGridView1(despues, i).Value = 1
            q = q + 1

            For j = anterior To despues Step 2

                If j > anterior And j < despues Then

                    ' Sumar e imprimir vlores para completar el triangulo de pascal

                    DataGridView1(j, i).Value = DataGridView1(j - 1, i - 1).Value + DataGridView1(j + 1, i - 1).Value

                End If
            Next

        Next

        ' SERIE DE FIBONACCI
        Dim listado As Integer
        Dim g As Integer
        g = 0
        Dim v As Integer
        v = 2
        Dim t As Integer
        Dim colsum As Integer
        Dim filsum As Integer

        q = 0
        columna = columna - 3

         Dim valofibonaci As Integer
        If txtfibonaci.Text <> "" Then
            valofibonaci = txtfibonaci.Text

        End If
        For i = 0 To fila
            fianterior = inicio - q
            fidespues = inicio + q
            q = q + 1

            ' Llamamos funcion par, para saber cuantas repeticiones realizar al momento de sumar, formula # iteraciones, SIGUIENTE PAR DIVIDIDO ENTRE DOS

            iteracion = par(i)


            For k = fianterior To fidespues Step 2
                g = k

                If k <= fidespues And i > 1 Then
                    If g < columna Then
                        colsum = g
                        filsum = i


                        For t = 0 To iteracion - 1
                            suma = suma + DataGridView1(colsum, filsum).Value
                            ListBox1.Items.Add(DataGridView1(colsum, filsum).Value)
                            colsum = colsum + 3
                            filsum = filsum - 1


                        Next

                        ' Asignamos al vector de fibonacci la suma

                        fibonacci(v) = suma

                        v = v + 1
                        suma = 0


                        Exit For

                    End If
                End If
            Next

        Next


        Dim y As Integer
        y = 0







        'If txtfibonaci.Text <> "" Then
        '    valofibonaci = txtfibonaci.Text

        'End If
        If valofibonaci > n Then
            MsgBox("el numero de fibonaci no puede ser mayor al numero de filas ", MsgBoxStyle.Critical, "error")
            txtfibonaci.Text = ""
            txtfibonaci.Focus()
        End If
        For y = 0 To fila
            If txtfibonaci.Text = "" Then
                ListBox1.Items.Add("")
            ElseIf valofibonaci = y Then

                ListBox1.Items.Add("numero de Fibonacci " & y & "  =   " & fibonacci(y))
                'DataGridView1.Rows(i).Cells(y).Style.BackColor = Drawing.Color.Brown
            End If

        Next

        y = 0
        i = 0
        y = 0
        q = 0

        ' FRACTALES DE SIERPINSKI



        For i = 0 To fila

            paranterior = inicio - q
            pardespues = inicio + q
            q = q + 1



            For y = paranterior To pardespues Step 2

                If (DataGridView1(y, i).Value Mod 2 = 0) Then

                    ListBox2.Items.Add("Fila= " & i & " Columna= " & y & " = " & DataGridView1(y, i).Value)

                End If
            Next
        Next


        Dim sum As Integer
        Dim filadiag As Integer
        filadiag = fila - 1
        sum = 0

        ' SUMA DE DIAGONALES

        ' Recorrer diagonal principal 1+2+3+4...

        If ComboBox1.SelectedItem.ToString() = "Izquierda" Then
            y = inicio + 1

            For i = 1 To filadiag

                ListBox3.Items.Add(DataGridView1(y, i).Value)
                DataGridView1.Rows(i).Cells(y).Style.BackColor = Drawing.Color.Brown
                sum = sum + DataGridView1(y, i).Value

                y = y - 1

            Next
        End If

        ' Recorrer diagonal principal de manera inversa 10+9+8...

        If ComboBox1.SelectedItem.ToString() = "Derecha" Then
            y = inicio - 1

            For i = 1 To filadiag

                ListBox3.Items.Add(DataGridView1(y, i).Value)
                DataGridView1.Rows(i).Cells(y).Style.BackColor = Drawing.Color.Red
                sum = sum + DataGridView1(y, i).Value
                y = y + 1

            Next

        End If
        Label5.Text = sum

        'Catch ex As Exception
        '    MsgBox("Error  " & ex.Message)

        'End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        DataGridView1.Columns.Clear()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        TextBox1.Clear()
        Label5.Text = " "
        txtfibonaci.Clear()


    End Sub

    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        Button1.Enabled = False
       

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Then

            If TextBox1.Text <> "" And Asc(e.KeyChar) = 13 Then
                Button1.Enabled = True

            End If
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If TextBox1.Text = "" Then
            Button1.Enabled = False
        End If
    End Sub

    Private Sub txtfibonaci_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtfibonaci.KeyPress
        'If Asc(e.KeyChar) >= 48 And Asc(e.KeyChar) <= 57 Or Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 13 Then

        '    If txtfibonaci.Text <> "" And Asc(e.KeyChar) = 13 Then
        '        Button1.Enabled = True

        '    End If


        'Else
        'e.Handled = True

        'End If
    End Sub

    Private Sub txtfibonaci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtfibonaci.TextChanged

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class
