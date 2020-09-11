Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports <xmlns="urn:vgs:wa">
Namespace Model.ProgramOutcomes


    Public Class WaOutcome
        Implements iProgramOutcome




        Private _Attendance1 As Integer
        Private _Attendance2 As Integer
        Private _Punctuality1 As Integer
        Private _Punctuality2 As Integer
        Private _WorkQuality1 As Integer
        Private _WorkQuality2 As Integer
        Private _Productivity1 As Integer
        Private _Productivity2 As Integer
        Private _OnTaskBehavior1 As Integer
        Private _OnTaskBehavior2 As Integer
        Private _AcceptingAuthority1 As Integer
        Private _AcceptingAuthority2 As Integer
        Private _Appearance1 As Integer
        Private _Appearance2 As Integer

        Private _CompletedBy As String
        Private _ed As String

        Public Property AcceptingAuthority1() As Integer
            Get
                Return _AcceptingAuthority1
            End Get
            Set(ByVal value As Integer)
                _AcceptingAuthority1 = value
            End Set
        End Property
        Public Property AcceptingAuthority2() As Integer
            Get
                Return _AcceptingAuthority2
            End Get
            Set(ByVal value As Integer)
                _AcceptingAuthority2 = value
            End Set
        End Property
        Public Property Appearance1() As Integer
            Get
                Return _Appearance1
            End Get
            Set(ByVal value As Integer)
                _Appearance1 = value
            End Set
        End Property
        Public Property Appearance2() As Integer
            Get
                Return _Appearance2
            End Get
            Set(ByVal value As Integer)
                _Appearance2 = value
            End Set
        End Property
        Public Property Attendance1() As Integer
            Get
                Return _Attendance1

            End Get
            Set(ByVal value As Integer)
                _Attendance1 = value
            End Set
        End Property
        Public Property Attendance2() As Integer
            Get
                Return _Attendance2
            End Get
            Set(ByVal value As Integer)
                _Attendance2 = value
            End Set
        End Property
        Public Property OnTaskBehavior1() As Integer
            Get
                Return _OnTaskBehavior1
            End Get
            Set(ByVal value As Integer)
                _OnTaskBehavior1 = value
            End Set
        End Property
        Public Property OnTaskBehavior2() As Integer
            Get
                Return _OnTaskBehavior2
            End Get
            Set(ByVal value As Integer)
                _OnTaskBehavior2 = value
            End Set
        End Property '
        Public Property Productivity1() As Integer
            Get
                Return _Productivity1
            End Get
            Set(ByVal value As Integer)
                _Productivity1 = value
            End Set
        End Property
        Public Property Productivity2() As Integer
            Get
                Return _Productivity2
            End Get
            Set(ByVal value As Integer)
                _Productivity2 = value
            End Set
        End Property
        Public Property Punctuality1() As Integer
            Get
                Return _Punctuality1
            End Get
            Set(ByVal value As Integer)
                _Punctuality1 = value
            End Set
        End Property
        Public Property Punctuality2() As Integer
            Get
                Return _Punctuality2
            End Get
            Set(ByVal value As Integer)
                _Punctuality2 = value
            End Set
        End Property
        Public Property WorkQuality1() As Integer
            Get
                Return _WorkQuality1
            End Get
            Set(ByVal value As Integer)
                _WorkQuality1 = value
            End Set
        End Property
        Public Property WorkQuality2() As Integer
            Get
                Return _WorkQuality2
            End Get
            Set(ByVal value As Integer)
                _WorkQuality2 = value
            End Set
        End Property
        Public Function toXml(ByVal CompletedBy As String) As System.Xml.Linq.XElement Implements iProgramOutcome.toXml


            If String.IsNullOrEmpty(_CompletedBy) Then
                _CompletedBy = CompletedBy
            End If

            If String.IsNullOrEmpty(_ed) Then
                _ed = Date.Now.ToShortDateString
            End If

            Dim x = <ProgramOutcome xmlns="urn:vgs:wa" CompletedBy=<%= _CompletedBy %> type='wa' ed=<%= _ed %> version='1.0'>
                        <AcceptingAuthority1><%= AcceptingAuthority1 %></AcceptingAuthority1>
                        <AcceptingAuthority2><%= AcceptingAuthority2 %></AcceptingAuthority2>
                        <Appearance1><%= Appearance1 %></Appearance1>
                        <Appearance2><%= Appearance2 %></Appearance2>
                        <Attendance1><%= Attendance1 %></Attendance1>
                        <Attendance2><%= Attendance2 %></Attendance2>
                        <OnTaskBehavior1><%= OnTaskBehavior1 %></OnTaskBehavior1>
                        <OnTaskBehavior2><%= OnTaskBehavior2 %></OnTaskBehavior2>
                        <Productivity1><%= Productivity1 %></Productivity1>
                        <Productivity2><%= Productivity2 %></Productivity2>
                        <Punctuality1><%= Punctuality1 %></Punctuality1>
                        <Punctuality2><%= Punctuality2 %></Punctuality2>
                        <WorkQuality1><%= WorkQuality1 %></WorkQuality1>
                        <WorkQuality2><%= WorkQuality2 %></WorkQuality2>
                        <waScore1><%= (AcceptingAuthority1 + Appearance1 + Attendance1 + OnTaskBehavior1 + Productivity1 + Punctuality1 + WorkQuality1) / 7 %></waScore1>
                        <waScore2><%= (AcceptingAuthority2 + Appearance2 + Attendance2 + OnTaskBehavior2 + Productivity2 + Punctuality2 + WorkQuality2) / 7 %></waScore2>
                    </ProgramOutcome>


            Return x
        End Function

        Public Sub ReadXml(ByVal el As System.Xml.Linq.XElement) Implements iProgramOutcome.ReadXml
            _CompletedBy = el.@CompletedBy
            _ed = el.@ed
            Me.AcceptingAuthority1 = el.<AcceptingAuthority1>.Value
            Me.AcceptingAuthority2 = el.<AcceptingAuthority2>.Value
            Me.Appearance1 = el.<Appearance1>.Value
            Me.Appearance2 = el.<Appearance2>.Value
            Me.Attendance1 = el.<Attendance1>.Value
            Me.Attendance2 = el.<Attendance2>.Value
            Me.OnTaskBehavior1 = el.<OnTaskBehavior1>.Value
            Me.OnTaskBehavior2 = el.<OnTaskBehavior2>.Value
            Me.Productivity1 = el.<Productivity1>.Value
            Me.Productivity2 = el.<Productivity2>.Value
            Me.Punctuality1 = el.<Punctuality1>.Value
            Me.Punctuality2 = el.<Punctuality2>.Value
            Me.WorkQuality1 = el.<WorkQuality1>.Value
            Me.WorkQuality2 = el.<WorkQuality2>.Value
        End Sub
        Public Shared Function GetSelectList() As Dictionary(Of String, SelectList)
            Dim di As New Dictionary(Of String, SelectList)


            Dim AttendanceL As New List(Of SelectListItem)
            Dim PunctualityL As New List(Of SelectListItem)
            Dim ProductivityL As New List(Of SelectListItem)
            Dim WorkQualityL As New List(Of SelectListItem)
            Dim OnTaskBehaviorL As New List(Of SelectListItem)
            Dim AuthorityL As New List(Of SelectListItem)
            Dim AppearanceL As New List(Of SelectListItem)



            Dim Attendanceli As New SelectListItem
            Attendanceli.Text = "90% or less - Misses more than 2 days in each 4-week period"
            Attendanceli.Value = 1
            AttendanceL.Add(Attendanceli)

            Dim Attendanceli2 As New SelectListItem
            Attendanceli2.Text = "90% to 94% - Misses between 1 and 2 days in each 4-week period"
            Attendanceli2.Value = 2
            AttendanceL.Add(Attendanceli2)

            Dim Attendanceli3 As New SelectListItem
            Attendanceli3.Text = "95% to 97% - Does not miss more than 1 day in a 4-week period"
            Attendanceli3.Value = 3
            AttendanceL.Add(Attendanceli3)

            Dim Attendanceli4 As New SelectListItem
            Attendanceli4.Text = "98% to 100% - Does not miss more than half a day in a 4-week period"
            Attendanceli4.Value = 4
            AttendanceL.Add(Attendanceli4)

            Dim Attendanceli5 As New SelectListItem
            Attendanceli5.Text = "100% - Has 0 incidents of absence over enirety of program"
            Attendanceli5.Value = 5
            AttendanceL.Add(Attendanceli5)



            Dim Punctualityli As New SelectListItem
            Punctualityli.Text = "90% or less - Has MORE than TWO incidents of tardiness in each 4-week period"
            Punctualityli.Value = 1
            PunctualityL.Add(Punctualityli)

            Dim Punctualityli2 As New SelectListItem
            Punctualityli2.Text = "90% to 94% - Has not more than TWO incidents of tardiness in each 4-week period"
            Punctualityli2.Value = 2
            PunctualityL.Add(Punctualityli2)

            Dim Punctualityli3 As New SelectListItem
            Punctualityli3.Text = "95% to 97% - Has not more than ONE incident of tardiness in a 4-week period"
            Punctualityli3.Value = 3
            PunctualityL.Add(Punctualityli3)

            Dim Punctualityli4 As New SelectListItem
            Punctualityli4.Text = "98% to 99% - Has 0 incidents of tardiness over a 4-week period"
            Punctualityli4.Value = 4
            PunctualityL.Add(Punctualityli4)

            Dim Punctualityli5 As New SelectListItem
            Punctualityli5.Text = "100% - Has 0 incidents of tardiness over entirety of program"
            Punctualityli5.Value = 5
            PunctualityL.Add(Punctualityli5)



            Dim Productivityli As New SelectListItem
            Productivityli.Text = "54% or less"
            Productivityli.Value = 1
            ProductivityL.Add(Productivityli)

            Dim Productivityli2 As New SelectListItem
            Productivityli2.Text = "55% to 69%"
            Productivityli2.Value = 2
            ProductivityL.Add(Productivityli2)

            Dim Productivityli3 As New SelectListItem
            Productivityli3.Text = "70% to 84%"
            Productivityli3.Value = 3
            ProductivityL.Add(Productivityli3)

            Dim Productivityli4 As New SelectListItem
            Productivityli4.Text = "85% to 100%"
            Productivityli4.Value = 4
            ProductivityL.Add(Productivityli4)

            Dim Productivityli5 As New SelectListItem
            Productivityli5.Text = "100% + and completes work without errors"
            Productivityli5.Value = 5
            ProductivityL.Add(Productivityli5)



            Dim WorkQualityli As New SelectListItem
            WorkQualityli.Text = "Usually produces incomplete or incomplete work"
            WorkQualityli.Value = 1
            WorkQualityL.Add(WorkQualityli)

            Dim WorkQualityli2 As New SelectListItem
            WorkQualityli2.Text = "Often produces incomplete or incorrect work"
            WorkQualityli2.Value = 2
            WorkQualityL.Add(WorkQualityli2)

            Dim WorkQualityli3 As New SelectListItem
            WorkQualityli3.Text = "Often produces correctly completed work"
            WorkQualityli3.Value = 3
            WorkQualityL.Add(WorkQualityli3)

            Dim WorkQualityli4 As New SelectListItem
            WorkQualityli4.Text = "Usually produces correctly completed work"
            WorkQualityli4.Value = 4
            WorkQualityL.Add(WorkQualityli4)

            Dim WorkQualityli5 As New SelectListItem
            WorkQualityli5.Text = "Work without errors while producing at a 85% or greater"
            WorkQualityli5.Value = 5
            WorkQualityL.Add(WorkQualityli5)



            Dim OnTaskBehaviorli As New SelectListItem
            OnTaskBehaviorli.Text = "Usually is NOT engaged"
            OnTaskBehaviorli.Value = 1
            OnTaskBehaviorL.Add(OnTaskBehaviorli)

            Dim OnTaskBehaviorli2 As New SelectListItem
            OnTaskBehaviorli2.Text = "Often is NOT engaged"
            OnTaskBehaviorli2.Value = 2
            OnTaskBehaviorL.Add(OnTaskBehaviorli2)

            Dim OnTaskBehaviorli3 As New SelectListItem
            OnTaskBehaviorli3.Text = "Often is engaged"
            OnTaskBehaviorli3.Value = 3
            OnTaskBehaviorL.Add(OnTaskBehaviorli3)

            Dim OnTaskBehaviorli4 As New SelectListItem
            OnTaskBehaviorli4.Text = "Usually is engaged"
            OnTaskBehaviorli4.Value = 4
            OnTaskBehaviorL.Add(OnTaskBehaviorli4)

            Dim OnTaskBehaviorli5 As New SelectListItem
            OnTaskBehaviorli5.Text = "Consistently is engaged"
            OnTaskBehaviorli5.Value = 5
            OnTaskBehaviorL.Add(OnTaskBehaviorli5)



            Dim Authorityli1 As New SelectListItem
            Authorityli1.Text = "Usually resistant to rules and supervision, very difficult to supervise"
            Authorityli1.Value = 1
            AuthorityL.Add(Authorityli1)

            Dim Authorityli2 As New SelectListItem
            Authorityli2.Text = "Often resistant to rules and supervision, difficult to supervise"
            Authorityli2.Value = 2
            AuthorityL.Add(Authorityli2)

            Dim Authorityli3 As New SelectListItem
            Authorityli3.Text = "Often listens and attempts to comply with rules and regulations"
            Authorityli3.Value = 3
            AuthorityL.Add(Authorityli3)

            Dim Authorityli4 As New SelectListItem
            Authorityli4.Text = "Usually listens and attempts to comply with rules and supervision"
            Authorityli4.Value = 4
            AuthorityL.Add(Authorityli4)

            Dim Authorityli5 As New SelectListItem
            Authorityli5.Text = "Consistently listens to and complies with rules and supervision"
            Authorityli5.Value = 5
            AuthorityL.Add(Authorityli5)




            Dim Appearanceli1 As New SelectListItem
            Appearanceli1.Text = "Usually NOT properly groomed and dressed for the applicable work setting"
            Appearanceli1.Value = 1
            AppearanceL.Add(Appearanceli1)

            Dim Appearanceli2 As New SelectListItem
            Appearanceli2.Text = "Often NOT properly groomed and dressed for the applicable work setting"
            Appearanceli2.Value = 2
            AppearanceL.Add(Appearanceli2)

            Dim Appearanceli3 As New SelectListItem
            Appearanceli3.Text = "Often properly groomed and dressed for the applicable work setting"
            Appearanceli3.Value = 3
            AppearanceL.Add(Appearanceli3)

            Dim Appearanceli4 As New SelectListItem
            Appearanceli4.Text = "Usually properly groomed and dressed for the applicable work setting"
            Appearanceli4.Value = 4
            AppearanceL.Add(Appearanceli4)

            Dim Appearanceli5 As New SelectListItem
            Appearanceli5.Text = "Consistently properly groomed and dressed for the applicable work setting"
            Appearanceli5.Value = 5
            AppearanceL.Add(Appearanceli5)


            Dim PunctualitySL As New SelectList(PunctualityL.AsEnumerable, "Value", "Text")
            di("Punctuality") = PunctualitySL
            Dim ProductivitySL As New SelectList(ProductivityL.AsEnumerable, "Value", "Text")
            di("Productivity") = ProductivitySL
            Dim WorkQualitySL As New SelectList(WorkQualityL.AsEnumerable, "Value", "Text")
            di("WorkQuality") = WorkQualitySL
            Dim OnTaskBehaviorSL As New SelectList(OnTaskBehaviorL.AsEnumerable, "Value", "Text")
            di("OnTaskBehavior") = OnTaskBehaviorSL
            Dim AuthoritySL As New SelectList(AuthorityL.AsEnumerable, "Value", "Text")
            di("Authority") = AuthoritySL
            Dim AppearanceSL As New SelectList(AppearanceL.AsEnumerable, "Value", "Text")
            di("Appearance") = AppearanceSL
            Dim AttendanceSL As New SelectList(AttendanceL.AsEnumerable, "Value", "Text")
            di("Attendance") = AttendanceSL

            Dim Punctuality2SL As New SelectList(PunctualityL.AsEnumerable, "Value", "Text")
            di("Punctuality22") = PunctualitySL
            Dim Productivity2SL As New SelectList(ProductivityL.AsEnumerable, "Value", "Text")
            di("Productivity22") = ProductivitySL
            Dim WorkQuality2SL As New SelectList(WorkQualityL.AsEnumerable, "Value", "Text")
            di("WorkQuality22") = WorkQualitySL
            Dim OnTaskBehavior2SL As New SelectList(OnTaskBehaviorL.AsEnumerable, "Value", "Text")
            di("OnTaskBehavior22") = OnTaskBehaviorSL
            Dim Authority2SL As New SelectList(AuthorityL.AsEnumerable, "Value", "Text")
            di("Authority22") = AuthoritySL
            Dim Appearance2SL As New SelectList(AppearanceL.AsEnumerable, "Value", "Text")
            di("Appearance22") = AppearanceSL
            Dim Attendance2SL As New SelectList(AttendanceL.AsEnumerable, "Value", "Text")
            di("Attendance22") = AttendanceSL



            Return di


            'Dim s As String

        End Function
        Public Shared Function GetSelectList(ByVal outcome As Model.ProgramOutcomes.WaOutcome) As Dictionary(Of String, SelectList)
            Dim di As New Dictionary(Of String, SelectList)


            Dim AttendanceL As New List(Of SelectListItem)
            Dim PunctualityL As New List(Of SelectListItem)
            Dim ProductivityL As New List(Of SelectListItem)
            Dim WorkQualityL As New List(Of SelectListItem)
            Dim OnTaskBehaviorL As New List(Of SelectListItem)
            Dim AuthorityL As New List(Of SelectListItem)
            Dim AppearanceL As New List(Of SelectListItem)



            Dim Attendanceli As New SelectListItem
            Attendanceli.Text = "90% or less - Misses more than 2 days in each 4-week period"
            Attendanceli.Value = 1
            AttendanceL.Add(Attendanceli)

            Dim Attendanceli2 As New SelectListItem
            Attendanceli2.Text = "90% to 94% - Misses between 1 and 2 days in each 4-week period"
            Attendanceli2.Value = 2
            AttendanceL.Add(Attendanceli2)

            Dim Attendanceli3 As New SelectListItem
            Attendanceli3.Text = "95% to 97% - Does not miss more than 1 day in a 4-week period"
            Attendanceli3.Value = 3
            AttendanceL.Add(Attendanceli3)

            Dim Attendanceli4 As New SelectListItem
            Attendanceli4.Text = "98% to 100% - Does not miss more than half a day in a 4-week period"
            Attendanceli4.Value = 4
            AttendanceL.Add(Attendanceli4)

            Dim Attendanceli5 As New SelectListItem
            Attendanceli5.Text = "100% - Has 0 incidents of absence over enirety of program"
            Attendanceli5.Value = 5
            AttendanceL.Add(Attendanceli5)



            Dim Punctualityli As New SelectListItem
            Punctualityli.Text = "90% or less - Has MORE than TWO incidents of tardiness in each 4-week period"
            Punctualityli.Value = 1
            PunctualityL.Add(Punctualityli)

            Dim Punctualityli2 As New SelectListItem
            Punctualityli2.Text = "90% to 94% - Has not more than TWO incidents of tardiness in each 4-week period"
            Punctualityli2.Value = 2
            PunctualityL.Add(Punctualityli2)

            Dim Punctualityli3 As New SelectListItem
            Punctualityli3.Text = "95% to 97% - Has not more than ONE incident of tardiness in a 4-week period"
            Punctualityli3.Value = 3
            PunctualityL.Add(Punctualityli3)

            Dim Punctualityli4 As New SelectListItem
            Punctualityli4.Text = "98% to 99% - Has 0 incidents of tardiness over a 4-week period"
            Punctualityli4.Value = 4
            PunctualityL.Add(Punctualityli4)

            Dim Punctualityli5 As New SelectListItem
            Punctualityli5.Text = "100% - Has 0 incidents of tardiness over entirety of program"
            Punctualityli5.Value = 5
            PunctualityL.Add(Punctualityli5)



            Dim Productivityli As New SelectListItem
            Productivityli.Text = "54% or less"
            Productivityli.Value = 1
            ProductivityL.Add(Productivityli)

            Dim Productivityli2 As New SelectListItem
            Productivityli2.Text = "55% to 69%"
            Productivityli2.Value = 2
            ProductivityL.Add(Productivityli2)

            Dim Productivityli3 As New SelectListItem
            Productivityli3.Text = "70% to 84%"
            Productivityli3.Value = 3
            ProductivityL.Add(Productivityli3)

            Dim Productivityli4 As New SelectListItem
            Productivityli4.Text = "85% to 100%"
            Productivityli4.Value = 4
            ProductivityL.Add(Productivityli4)

            Dim Productivityli5 As New SelectListItem
            Productivityli5.Text = "100% + and completes work without errors"
            Productivityli5.Value = 5
            ProductivityL.Add(Productivityli5)



            Dim WorkQualityli As New SelectListItem
            WorkQualityli.Text = "Usually produces incomplete or incomplete work"
            WorkQualityli.Value = 1
            WorkQualityL.Add(WorkQualityli)

            Dim WorkQualityli2 As New SelectListItem
            WorkQualityli2.Text = "Often produces incomplete or incorrect work"
            WorkQualityli2.Value = 2
            WorkQualityL.Add(WorkQualityli2)

            Dim WorkQualityli3 As New SelectListItem
            WorkQualityli3.Text = "Often produces correctly completed work"
            WorkQualityli3.Value = 3
            WorkQualityL.Add(WorkQualityli3)

            Dim WorkQualityli4 As New SelectListItem
            WorkQualityli4.Text = "Usually produces correctly completed work"
            WorkQualityli4.Value = 4
            WorkQualityL.Add(WorkQualityli4)

            Dim WorkQualityli5 As New SelectListItem
            WorkQualityli5.Text = "Work without errors while producing at a 85% or greater"
            WorkQualityli5.Value = 5
            WorkQualityL.Add(WorkQualityli5)



            Dim OnTaskBehaviorli As New SelectListItem
            OnTaskBehaviorli.Text = "Usually is NOT engaged"
            OnTaskBehaviorli.Value = 1
            OnTaskBehaviorL.Add(OnTaskBehaviorli)

            Dim OnTaskBehaviorli2 As New SelectListItem
            OnTaskBehaviorli2.Text = "Often is NOT engaged"
            OnTaskBehaviorli2.Value = 2
            OnTaskBehaviorL.Add(OnTaskBehaviorli2)

            Dim OnTaskBehaviorli3 As New SelectListItem
            OnTaskBehaviorli3.Text = "Often is engaged"
            OnTaskBehaviorli3.Value = 3
            OnTaskBehaviorL.Add(OnTaskBehaviorli3)

            Dim OnTaskBehaviorli4 As New SelectListItem
            OnTaskBehaviorli4.Text = "Usually is engaged"
            OnTaskBehaviorli4.Value = 4
            OnTaskBehaviorL.Add(OnTaskBehaviorli4)

            Dim OnTaskBehaviorli5 As New SelectListItem
            OnTaskBehaviorli5.Text = "Consistently is engaged"
            OnTaskBehaviorli5.Value = 5
            OnTaskBehaviorL.Add(OnTaskBehaviorli5)



            Dim Authorityli1 As New SelectListItem
            Authorityli1.Text = "Usually resistant to rules and supervision, very difficult to supervise"
            Authorityli1.Value = 1
            AuthorityL.Add(Authorityli1)

            Dim Authorityli2 As New SelectListItem
            Authorityli2.Text = "Often resistant to rules and supervision, difficult to supervise"
            Authorityli2.Value = 2
            AuthorityL.Add(Authorityli2)

            Dim Authorityli3 As New SelectListItem
            Authorityli3.Text = "Often listens and attempts to comply with rules and regulations"
            Authorityli3.Value = 3
            AuthorityL.Add(Authorityli3)

            Dim Authorityli4 As New SelectListItem
            Authorityli4.Text = "Usually listens and attempts to comply with rules and supervision"
            Authorityli4.Value = 4
            AuthorityL.Add(Authorityli4)

            Dim Authorityli5 As New SelectListItem
            Authorityli5.Text = "Consistently listens to and complies with rules and supervision"
            Authorityli5.Value = 5
            AuthorityL.Add(Authorityli5)




            Dim Appearanceli1 As New SelectListItem
            Appearanceli1.Text = "Usually NOT properly groomed and dressed for the applicable work setting"
            Appearanceli1.Value = 1
            AppearanceL.Add(Appearanceli1)

            Dim Appearanceli2 As New SelectListItem
            Appearanceli2.Text = "Often NOT properly groomed and dressed for the applicable work setting"
            Appearanceli2.Value = 2
            AppearanceL.Add(Appearanceli2)

            Dim Appearanceli3 As New SelectListItem
            Appearanceli3.Text = "Often properly groomed and dressed for the applicable work setting"
            Appearanceli3.Value = 3
            AppearanceL.Add(Appearanceli3)

            Dim Appearanceli4 As New SelectListItem
            Appearanceli4.Text = "Usually properly groomed and dressed for the applicable work setting"
            Appearanceli4.Value = 4
            AppearanceL.Add(Appearanceli4)

            Dim Appearanceli5 As New SelectListItem
            Appearanceli5.Text = "Consistently properly groomed and dressed for the applicable work setting"
            Appearanceli5.Value = 5
            AppearanceL.Add(Appearanceli5)


            Dim PunctualitySL As New SelectList(PunctualityL.AsEnumerable, "Value", "Text", outcome.Punctuality1)
            di("Punctuality") = PunctualitySL
            Dim ProductivitySL As New SelectList(ProductivityL.AsEnumerable, "Value", "Text", outcome.Productivity1)
            di("Productivity") = ProductivitySL
            Dim WorkQualitySL As New SelectList(WorkQualityL.AsEnumerable, "Value", "Text", outcome.WorkQuality1)
            di("WorkQuality") = WorkQualitySL
            Dim OnTaskBehaviorSL As New SelectList(OnTaskBehaviorL.AsEnumerable, "Value", "Text", outcome.OnTaskBehavior1)
            di("OnTaskBehavior") = OnTaskBehaviorSL
            Dim AuthoritySL As New SelectList(AuthorityL.AsEnumerable, "Value", "Text", outcome.AcceptingAuthority1)
            di("Authority") = AuthoritySL
            Dim AppearanceSL As New SelectList(AuthorityL.AsEnumerable, "Value", "Text", outcome.Appearance1)
            di("Appearance") = AppearanceSL
            Dim AttendanceSL As New SelectList(AttendanceL.AsEnumerable, "Value", "Text", outcome.Attendance1)
            di("Attendance") = AttendanceSL

            Dim Punctuality2SL As New SelectList(PunctualityL.AsEnumerable, "Value", "Text", outcome.Punctuality2)
            di("Punctuality22") = Punctuality2SL
            Dim Productivity2SL As New SelectList(ProductivityL.AsEnumerable, "Value", "Text", outcome.Productivity2)
            di("Productivity22") = Productivity2SL
            Dim WorkQuality2SL As New SelectList(WorkQualityL.AsEnumerable, "Value", "Text", outcome.WorkQuality2)
            di("WorkQuality22") = WorkQuality2SL
            Dim OnTaskBehavior2SL As New SelectList(OnTaskBehaviorL.AsEnumerable, "Value", "Text", outcome.OnTaskBehavior2)
            di("OnTaskBehavior22") = OnTaskBehavior2SL
            Dim Authority2SL As New SelectList(AuthorityL.AsEnumerable, "Value", "Text", outcome.AcceptingAuthority2)
            di("Authority22") = Authority2SL
            Dim Appearance2SL As New SelectList(AuthorityL.AsEnumerable, "Value", "Text", outcome.Appearance2)
            di("Appearance22") = Appearance2SL
            Dim Attendance2SL As New SelectList(AttendanceL.AsEnumerable, "Value", "Text", outcome.Attendance2)
            di("Attendance22") = Attendance2SL



            Return di


            'Dim s As String

        End Function



        Public Function Body() As String Implements iProgramOutcome.Body


            Dim score1 = AcceptingAuthority1 + Appearance1 + Attendance1 + OnTaskBehavior1 + Productivity1 + Punctuality1 + WorkQuality1
            Dim score2 = AcceptingAuthority2 + Appearance2 + Attendance1 + OnTaskBehavior2 + Productivity2 + Punctuality2 + WorkQuality2


            Dim output = <div>
                             <p><strong>Accepting Authority</strong></p>
                             <p class="Description">Willingness to listen and make an effort to comply with work place and rules</p>
                             <p>Start: <%= AcceptingAuthority1 %> End: <%= AcceptingAuthority2 %></p>
                             <p><strong>Appearance </strong></p>
                             <p class="Description">The practice of good personal hygiene, personal grooming, and wearing of appropriate attire for the assigned work setting</p>
                             <p>Start: <%= Appearance1 %> End: <%= Appearance2 %></p>
                             <p><strong>Attendance </strong></p>
                             <p class="Description">Percent of total scheduled workdays present</p>
                             <p>Start: <%= Attendance1 %> End: <%= Attendance2 %></p>
                             <p><strong>OnTaskBehavior </strong></p>
                             <p class="Description">The ability to consistently engage in activities that lead to completion of assigned work</p>
                             <p>Start: <%= OnTaskBehavior1 %> End: <%= OnTaskBehavior2 %></p>
                             <p><strong>Productivity </strong></p>
                             <p class="Description">The rate of speed that work is completed in for a specific period of time</p>
                             <p>Start: <%= Productivity1 %> End: <%= Productivity2 %></p>
                             <p><strong>Punctuality </strong></p>
                             <p class="Description">Percent of total scheduled workdays when the individual  was not more than 5 minutes late arriving for work or returning from lunch or breaks</p>
                             <p>Start: <%= Punctuality1 %> End: <%= Punctuality2 %></p>
                             <p><strong>WorkQuality</strong></p>
                             <p class="Description">The ability to produce work that is correctly completed</p>
                             <p>Start: <%= WorkQuality1 %> End: <%= WorkQuality2 %></p>
                             <p><strong>Score</strong> Start: <%= score1 / 7 %> End: <%= score2 / 7 %></p>
                             <p><strong>Completed by </strong><%= _CompletedBy %> on <%= _ed %></p>
                         </div>

            Return output.ToString

        End Function


        Function bodyxslt() As String
            Dim x As XElement = toXml("")
            Dim markup As XDocument = XDocument.Load(Myapp.LocalPath("waOutcome.xslt"))


            Dim newTree As XDocument = New XDocument

            Dim settings As New System.Xml.XmlWriterSettings

            settings.ConformanceLevel = System.Xml.ConformanceLevel.Fragment

            Dim si As New System.Text.StringBuilder

            'Using writer As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(si, settings) 'newTree.CreateWriter
            Using writer As System.Xml.XmlWriter = newTree.CreateWriter

                ' Load the style sheet.
                Dim xslt As System.Xml.Xsl.XslCompiledTransform = New System.Xml.Xsl.XslCompiledTransform()
                xslt.Load(markup.CreateReader())
                'writer.
                'writer.Settings.ConformanceLevel = System.Xml.ConformanceLevel.Fragment
                ' Execute the transform and output the results to a writer.
                xslt.Transform(x.CreateReader(), writer)
            End Using


            Return newTree.ToString




        End Function

        Public Function EditLink(ByVal Permilink As String, ByVal id As Integer) As String Implements iProgramOutcome.EditLink
            Return String.Format("<a href=""{0}"">Edit</a>", R2kdoiMVC.Myapp.BuildUri.Action("WorkAdjustment", New With {.permilink = Permilink, .id = id}))
        End Function

        Public Function Title() As String Implements iProgramOutcome.Title
            Return "Work Adjustment"
        End Function
    End Class
End Namespace