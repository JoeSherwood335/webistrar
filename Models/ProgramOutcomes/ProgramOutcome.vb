
Namespace Model
    Partial Class ProgramOutcome




        Sub SetDetail(ByVal Name As String, ByVal value As Object)

            If Me.PoData Is Nothing Then
                Me.PoData = <ProgramOutcome></ProgramOutcome>

            End If

            Dim details = From a In Me.PoData.Elements _
                          Where a.Name = "detail" _
                          Select a



            Dim detail = From a In details _
                         Where a.Attribute("name").Value.Equals(Name) _
                         Select a

            If detail.Count = 1 Then
                detail.Single.Value = value

            Else
                Dim newdetail = <detail name=<%= Name %> type=<%= value.GetType.ToString() %>>
                                    <%= value %>
                                </detail>
                PoData.AddFirst(newdetail)

            End If

            ' forces the datacontext to accept the changes
            Me.PoData = New XElement(Me.PoData)

        End Sub
        Function HasDetail() As Boolean
            If Me.PoData Is Nothing Then
                Return False
            Else
                Return True

            End If
        End Function
        Function HasDetail(ByVal Name As String) As Boolean
            If Me.PoData Is Nothing Then
                Return False

            End If

            Dim details = From a In Me.PoData.Elements _
                          Where a.Name = "detail" _
                          Select a



            Dim detail = From a In details _
                         Where a.Attribute("name").Value.Equals(Name) _
                         Select a



            If detail.Count = 0 Then
                Return False
            Else
                Return True
                End If



        End Function
        Function GetDetail(ByVal Name As String) As Object

            If Me.PoData Is Nothing Then
                Me.PoData = <ProgramOutcome></ProgramOutcome>

            End If

            Dim n As XName




            Dim detail = From a In Me.PoData.Elements _
                         Where a.Attribute("name").Value.Equals(Name) _
                         Select a Take 1


            If detail.Count = 0 Then

                Throw New Exception("Detail Record Not Found")
            End If

            Return detail.First.Value
        End Function
        Sub DeleteDetail(ByVal name As String)
            If Me.PoData Is Nothing Then
                Me.PoData = <ProgramOutcome></ProgramOutcome>

            End If
            If HasDetail(name) Then
                Dim details = From a In Me.PoData.Elements _
                              Where a.Name = "detail" _
                              Select a



                Dim detail = From a In details _
                             Where a.Attribute("name").Value.Equals(name) _
                             Select a

                detail.Remove()

            End If
            

        End Sub
    End Class
End Namespace

