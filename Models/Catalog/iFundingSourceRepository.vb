Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel

Public Interface iFundingSourceRepository



    ''' <summary>
    ''' Returns All Funding Sources from model
    ''' </summary>
    Function GetAllFundingSources() As IQueryable(Of Model.FundingSource)

    ''' <summary>
    ''' Returns One Funding Source from Model
    ''' </summary>
    Function GetFundingSource(ByVal id As Long) As Model.FundingSource

    ''' <summary>
    ''' Returns One Funding Source from Model
    ''' </summary>
    Function GetFundingSource(ByVal Acronym As String) As Model.FundingSource


    ''' <summary>
    ''' Do i really need to explain this
    ''' </summary>
    Sub Save()

    ''' <summary>
    ''' Add New Funding Source
    ''' </summary>
    ''' <param name="NewFundingSource"></param>
    Sub Add(ByVal NewFundingSource As Model.FundingSource)




End Interface






