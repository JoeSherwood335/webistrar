Namespace Model
    Partial Class Info


        Public Shared Function GetConsumerType() As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.ConsumerTypes, "ConsumerTypeId", "ConsumerType")
        End Function


        Public Shared Function GetConsumerType(ByVal SelectedValue As Integer) As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.ConsumerTypes, "ConsumerTypeId", "ConsumerType", SelectedValue)

        End Function

        Public Function GetFullName() As String
            Return GetFullName(NameTypes.FirstLast)
        End Function
        Public Function GetNameFull() As String
            Return String.Format("{1}, {0}", FirstName, LastName)
        End Function


        Public Enum NameTypes
            PreFirstMiddleLastSuf = 1
            FirstMiddleLast = 2
            FirstLast = 3
            PreFirstLastSuf = 4
            FirstLastSuf = 5
            LastFirst = 6
        End Enum

        Function GetFullName(ByVal type As NameTypes)

            Dim s As New StringBuilder


            Select Case type
                Case Is = NameTypes.FirstLast
                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0} ", FirstName)
                    End If

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0}", LastName)
                    End If

                Case Is = NameTypes.FirstMiddleLast
                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0} ", FirstName)
                    End If

                    If Not String.IsNullOrEmpty(MiddleName) Then
                        s.AppendFormat("{0} ", MiddleName)
                    End If

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0}", LastName)
                    End If

                Case Is = NameTypes.PreFirstMiddleLastSuf

                    If PrefixId.HasValue Then
                        s.AppendFormat("{0} ", PrefixName.PrefixName)
                    End If

                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0} ", FirstName)
                    End If

                    If Not String.IsNullOrEmpty(MiddleName) Then
                        s.AppendFormat("{0} ", MiddleName)
                    End If

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0} ", LastName)
                    End If

                    If SufixId.HasValue Then
                        s.AppendFormat("{0}", SufixName.SufixName)
                    End If


                Case Is = NameTypes.PreFirstLastSuf
                    If PrefixId.HasValue Then
                        s.AppendFormat("{0} ", PrefixName.PrefixName)
                    End If

                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0} ", FirstName)
                    End If

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0} ", LastName)
                    End If

                    If SufixId.HasValue Then
                        s.AppendFormat("{0}", SufixName.SufixName)
                    End If

                Case Is = NameTypes.FirstLastSuf
                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0} ", FirstName)
                    End If

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0} ", LastName)
                    End If

                    If SufixId.HasValue Then
                        s.AppendFormat("{0}", SufixName.SufixName)
                    End If
                Case Is = NameTypes.LastFirst

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0} ", LastName)
                    End If

                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0}", FirstName)
                    End If

                Case Else
                    If Not String.IsNullOrEmpty(FirstName) Then
                        s.AppendFormat("{0} ", FirstName)
                    End If

                    If Not String.IsNullOrEmpty(LastName) Then
                        s.AppendFormat("{0}", LastName)
                    End If
            End Select


            Return s.ToString

        End Function



        Public Shared Function GetPrefixes() As SelectList


            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.PrefixNames.OrderBy(Function(e) e.OrderBy), "PrefixId", "PrefixName")
        End Function


        Public Shared Function GetPrefixes(ByVal SelectedValue? As Integer) As SelectList

            Dim _DC As New R2kdoiMVCDataContext

            If SelectedValue.HasValue Then

                Return New SelectList(_DC.PrefixNames.OrderBy(Function(e) e.OrderBy), "PrefixId", "PrefixName", SelectedValue)

            Else

                Return New SelectList(_DC.PrefixNames.OrderBy(Function(e) e.OrderBy), "PrefixId", "PrefixName")

            End If

        End Function



        Public Shared Function GetSufixes() As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.SufixNames.OrderBy(Function(e) e.OrderBy), "SuffixId", "SufixName")
        End Function


        Public Shared Function GetSufixes(ByVal SelectedValue? As Integer) As SelectList

            Dim _DC As New R2kdoiMVCDataContext

            If SelectedValue.HasValue Then
                Return New SelectList(_DC.SufixNames.OrderBy(Function(e) e.OrderBy), "SuffixId", "SufixName", SelectedValue)
            Else
                Return New SelectList(_DC.SufixNames.OrderBy(Function(e) e.OrderBy), "SuffixId", "SufixName")

            End If


        End Function

        Public Function Link() As String

            Return Myapp.ConsumerLink(Me.Permilink, GetFullName(NameTypes.FirstLastSuf))
        End Function


    End Class




End Namespace

Namespace Model.Billing
    Partial Class Info
        Public Function Link() As String
            Return Myapp.ConsumerLink(Me.Permilink, Me.FirstName, Me.LastName)
        End Function


        Public Shared Function GetConsumerType() As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.ConsumerTypes, "ConsumerTypeId", "ConsumerType")
        End Function


        Public Shared Function GetConsumerType(ByVal SelectedValue As Integer) As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.ConsumerTypes, "ConsumerTypeId", "ConsumerType", SelectedValue)

        End Function

        Public Function GetFullName() As String
            Return String.Format("{0} {1}", FirstName, LastName)
        End Function
        Public Function GetNameFull() As String
            Return String.Format("{1}, {0}", FirstName, LastName)
        End Function
    End Class
End Namespace
Namespace Model.Attendance
    Partial Class Info
        Public Function Link() As String
            Return Myapp.ConsumerLink(Me.Permilink, Me.FirstName, Me.LastName)
        End Function


        Public Shared Function GetConsumerType() As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.ConsumerTypes, "ConsumerTypeId", "ConsumerType")
        End Function


        Public Shared Function GetConsumerType(ByVal SelectedValue As Integer) As SelectList

            Dim _DC As New R2kdoiMVCDataContext
            Return New SelectList(_DC.ConsumerTypes, "ConsumerTypeId", "ConsumerType", SelectedValue)

        End Function

        Public Function GetFullName() As String
            Return String.Format("{0} {1}", FirstName, LastName)
        End Function
        Public Function GetNameFull() As String
            Return String.Format("{1}, {0}", FirstName, LastName)
        End Function
    End Class

End Namespace