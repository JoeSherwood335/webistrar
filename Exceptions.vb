'Imports System.Web.Mvc.UrlHelper

Public Class ServiceNotCompletedException
    Inherits Exception

    Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub

    Sub New(ByVal referral As Model.Referral)
        MyBase.New(String.Format("{0} You can't Close this Referral while you have Non Completed Services", referral.ReferralId))
    End Sub

End Class

Public Class ServiceStartDateLessThanSchedualStartDateException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} ServiceStartDate can not be set before Authorization ServiceStartDate", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class ServiceEndDateGreaterThanSchedualEndDateException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} ServiceEndDate can not be set after Authorization ServiceEndDate", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub
End Class

Public Class ServiceEndDateCantBeNullException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} ServiceEndDate can not be Empty", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub
End Class


Public Class NumberOfUnitsCantBeZeroException
    Inherits Exception


    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} Number of Units Can't be Zero.", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class AllUnitsOfServiceHasAllreadyBeenBilledException
    Inherits Exception


    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} All units of service has allready been billed.", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class AuthorizationNotApprovedException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} Authorization has not been Approved by supervisor.", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class BillsInAcrueException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} You can't do that while you have bills in Acrue", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub
End Class

Public Class ServiceNotBilledBeforeCompletedException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} You must have created one 110 before you can complete this service", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub
End Class


Public Class NullServiceEndDateException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} Service End Date Can't be Null", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class NullServiceStartDateException
    Inherits Exception

    Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub

    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} Service Start Date Can't be Null", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class BillNotAccruedException
    Inherits Exception

    Sub New(ByVal Message As String)
        MyBase.New(Message)
    End Sub
End Class

Public Class RecordNotFoundException
    Inherits Exception

    Sub New(ByVal id As Integer, ByVal type As String)
        MyBase.New(String.Format("{0} record {1} not found", id, type))
    End Sub

    Sub New(ByVal name As String, ByVal type As String)
        MyBase.New(String.Format("{0} record {1} not found", name, type))
    End Sub

    Private _Id As Integer
    Public Property Id() As Integer
        Get
            Return _Id
        End Get
        Set(ByVal value As Integer)
            _Id = value
        End Set
    End Property

    Private Type As String
    Public Property NewProperty() As String
        Get
            Return Type
        End Get
        Set(ByVal value As String)
            Type = value
        End Set
    End Property


End Class

Public Class ServiceAllReadyCompletedOrCanceledException
    Inherits Exception

    Sub New(ByVal service As Model.Service)
        MyBase.New("Service allready Completed or Canceled")
    End Sub

End Class

Public Class ServiceAllReadyBilledInFull
    Inherits Exception

    Sub New(ByVal Service As Model.Service)
        MyBase.New("This Service has allready been billed in full")
    End Sub

End Class

Public Class AuthorizationServiceStartdateisNullException
    Inherits Exception
    Sub New(ByVal Service As Model.Service)
        MyBase.New(String.Format("{0},{1} Has a no Schedual Start Date", Service.Authorization.AuthorizationNumber, Service.ServiceId))
    End Sub
End Class

Public Class AuthorizationServiceEndDateisNullException
    Inherits Exception
    Sub New(ByVal Service As Model.Service)
        MyBase.New(String.Format("{0},{1} Has a no Schedual Start Date", Service.Authorization.AuthorizationNumber, Service.ServiceId))
    End Sub
End Class

Public Class ServiceStatusIsInvalid
    Inherits Exception


    Sub New(Service As Model.Service)
        MyBase.new(String.Format("{0},{1} Service Status is Invalid", Service.Authorization.AuthorizationNumber, Service.ServiceId))
    End Sub
End Class

Public Class ReferralIsClosedException
    Inherits System.Exception

    Sub New(ByVal authorization As Model.Authorization)
        MyBase.New(String.Format("{0},{1} You cant add any services to this autorization where the referral is closed", authorization.ReferralId, authorization.AuthorizationNumber))
    End Sub

    Sub New(ByVal referral As Model.Referral)
        MyBase.New(String.Format("{0} You can't add any services to this autorization where the referral is closed", referral.ReferralId))
    End Sub

    Sub New(ByVal referral As Model.Service)
        MyBase.New(String.Format("{0} You can't add/changeany services to this autorization where the referral is closed", referral.ServiceId))
    End Sub


End Class

Public Class ProgramOutcomeNotCompletedException
    Inherits System.Exception


    Sub New(ByVal referral As Model.Referral)
        MyBase.New(String.Format("{0} You must complete at least one Service Outcome to close this Referral", referral.ReferralId))
    End Sub
End Class

Public Class AttendanceLessThenPreviousException
    Inherits System.Exception


    Sub New(ByVal referral As Model.Attendance.Attendance)
        MyBase.New(String.Format("{0} Clock Less then Previous", referral.AttendanceId))
    End Sub
End Class

Public Class ServcieAttendanceLessThenPreviousException
    Inherits System.Exception


    Sub New(ByVal referral As Model.ServiceAttendance)
        MyBase.New(String.Format("{0} Clock Less then Previous", referral.AttendanceId))
    End Sub
End Class

Public Class AttachNotInfopathException
    Inherits System.Exception

    Sub New()
        MyBase.New("You have To many files in outcome")
    End Sub
End Class

Public Class InputCantBeBlankException
    Inherits Exception
    Sub New(ByVal Input As String)
        MyBase.New(String.Format("{0} Cant be Empty", Input))
    End Sub

End Class


Public Class ProductAllReadyAddedException
    Inherits Exception
    Sub New(ByVal Input As String)
        MyBase.New(String.Format("{0} Product Allready Added", Input))
    End Sub



End Class

Public Class YouMustHaveAtLeastOneBillingToCompleteServiceException
    Inherits Exception


    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} You must have at least one Billing To complete this service.", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

Public Class YouAllreadyHaveAProgramOpenException
    Inherits Exception


    Sub New(ByVal Info As Model.Info)
        MyBase.New(String.Format("{1} You Allready have a program open for {0}. Please add the new Authorization to the current Open Program", Info.GetFullName, Info.RegistrarNo))
    End Sub

End Class



Public Class SocialSecurityNumberAllreadyAddedToWebistrarException
    Inherits Exception


    Sub New(ByVal Info As Model.Info)
        MyBase.New(String.Format("{0} allready exists for another consumers", Info.SSN))
    End Sub

End Class


Public Class ReferaralIdNumberAllreadyAddedToWebistrarException
    Inherits Exception


    Sub New(ByVal Info As Model.Info)
        MyBase.New(String.Format("{0} allready exists for another consumers", Info.SSN))
    End Sub

End Class

Public Class InsufficantIdNumbersException
    Inherits Exception


    Sub New()
        MyBase.New(String.Format("You must eather have a ssn or a referral id number "))
    End Sub

End Class

Public Class ServiceNotUpdateableException
    Inherits Exception


    Sub New(ByVal service As Model.Service)
        MyBase.New(String.Format("{0},{1} Service Not Updatable while Completed or Canceled", service.Authorization.AuthorizationNumber, service.ServiceId))
    End Sub

End Class

