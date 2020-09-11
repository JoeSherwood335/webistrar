Imports R2kdoiMVC.Model
Imports R2kdoiMVC.Controllers.ProductFormViewModel

Namespace Controllers
    <Authorize(Roles:="feeAdmin")> _
    Public Class feesController
        Inherits System.Web.Mvc.Controller

        '
        ' GET: /fee/



        'Function Index() As ActionResult
        '    Dim db As New R2kdoiMVCDataContext


        '    ViewData("FeeScheduals") = New SelectList(db.Mains, "MainId", "FeeSchedualName")
        '    ViewData("Locations") = New SelectList(db.Locations, "LocationId", "LocationName")
        '    Return View(db.Fees.Where(Function(e) e.Main.MainId = 1 And e.LocationId = 1))
        'End Function


        '
        ' Post: /fee/

        '<AcceptVerbs(HttpVerbs.Post)> _
        Function Index(ByVal FeeSchedual? As Int16, ByVal Location? As Int16) As ActionResult
            Dim db As New R2kdoiMVCDataContext

            Dim x = From e In db.Fees Order By e.Product.Product.ProductName, e.Product.ProductName Select e


            If FeeSchedual.HasValue Then
                x = x.Where(Function(e) e.Main.MainId = FeeSchedual)
            Else
                x = x.Where(Function(e) e.Main.MainId = 1)
            End If

            If Location.HasValue Then
                x = x.Where(Function(e) e.LocationId = Location)
            Else
                x = x.Where(Function(e) e.LocationId = 1)
            End If

            ViewData("FeeScheduals") = New SelectList(db.Mains, "MainId", "FeeSchedualName")
            ViewData("Locations") = New SelectList(db.Locations, "LocationId", "LocationName")
            Return View(x)


        End Function
        '
        ' GET: /fee/Details/5

        Function Details(ByVal id As Integer) As ActionResult
            Dim db As New R2kdoiMVCDataContext

            Dim x = db.Fees.SingleOrDefault(Function(e) e.FeeId = id)

            Return View(x)
        End Function

        '
        ' GET: /fee/Create

        Function Create(ByVal f? As Int16, ByVal l? As Int16) As ActionResult
            ViewData("ProductId") = 0

            Dim db As New R2kdoiMVCDataContext

            'ViewData.Add(
            'ViewData.Add("FundingSources", New SelectList(db.FundingSources.Where(Function(e) e.discontinued = False).Select(Function(e) e), "FundingSourceId", "FullName"))
            Dim sf As SelectList


            If f.HasValue Then
                sf = New SelectList(db.Mains, "MainId", "FeeSchedualName", f.Value)
            Else
                sf = New SelectList(db.Mains, "MainId", "FeeSchedualName")
            End If
            Dim sl As SelectList
            If l.HasValue Then
                sl = New SelectList(db.Locations, "LocationId", "LocationName", l.Value)
            Else
                sl = New SelectList(db.Locations, "LocationId", "LocationName")
            End If


            ViewData("FeeScheduals") = sf


            ViewData.Add("UnitTypes", New SelectList((From x In db.UnitTypes Order By x.Orderby Select x), "UnitTypeId", "UnitType"))
            ViewData.Add("Locations", sl)
            Dim b = From x In db.GetProductsforList Where x.Discontinued = 0 Select New With {.Name = x.ProductName, .Id = x.ProductId}
            ViewData.Add("Products", New SelectList(b, "Id", "Name"))
            ViewData.Add("MinUnitTypes", New SelectList((From x In db.UnitTypes Order By x.Orderby Select x), "UnitTypeId", "UnitType"))


            ' Return renderview(

            Return View()
        End Function

        '
        ' POST: /fee/Create

        <AcceptVerbs(HttpVerbs.Post)> _
        Function Create(ByVal New_Fee As Model.Fee) As ActionResult
            Try
                ' TODO: Add insert logic here
                Dim db As New R2kdoiMVCDataContext

                New_Fee.InputedBy = Myapp.UserId
                New_Fee.ed = DateTime.Now
                New_Fee.ud = DateTime.Now
                db.Fees.InsertOnSubmit(New_Fee)

                db.SubmitChanges()


                Return RedirectToAction("Index", New With {.FeeSchedual = New_Fee.MainId, .Location = New_Fee.LocationId})
            Catch ex As Exception


                Dim db As New R2kdoiMVCDataContext

                'ViewData.Add(
                'ViewData.Add("FundingSources", New SelectList(db.FundingSources.Where(Function(e) e.discontinued = False).Select(Function(e) e), "FundingSourceId", "FullName"))

                ViewData("FeeScheduals") = New SelectList(db.Mains, "MainId", "FeeSchedualName")
                ViewData.Add("UnitTypes", New SelectList((From x In db.UnitTypes Order By x.Orderby Select x), "UnitTypeId", "UnitType"))
                ViewData.Add("Locations", New SelectList(db.Locations, "LocationId", "LocationName"))
                Dim f = From x In db.GetProductsforList Where x.Discontinued = 0 Select New With {.Name = x.ProductName, .Id = x.ProductId}
                ViewData.Add("Products", New SelectList(f, "Id", "Name"))

                ViewData.Add("MinUnitTypes", New SelectList((From x In db.UnitTypes Order By x.Orderby Select x), "UnitTypeId", "UnitType"))
                Return View()
            End Try
        End Function

        '
        ' GET: /fee/Edit/5

        Function Edit(ByVal id As Integer) As ActionResult
            Dim db As New R2kdoiMVCDataContext

            Dim fee = db.Fees.SingleOrDefault(Function(e) e.FeeId = id)


            ' ViewData.Add("FundingSources", New SelectList(db.FundingSources.Where(Function(e) e.discontinued = False).Select(Function(e) e), "FundingSourceId", "FullName", fee.FundingSourceId))
            ViewData("FeeScheduals") = New SelectList(db.Mains, "MainId", "FeeSchedualName", fee.MainId)
            ViewData.Add("UnitTypes", New SelectList((From x In db.UnitTypes Order By x.Orderby Select x), "UnitTypeId", "UnitType", fee.UnitTypeId))
            ViewData.Add("Locations", New SelectList(db.Locations, "LocationId", "LocationName", fee.LocationId))
            Dim f = From x In db.GetProductsforList Where x.Discontinued = 0 Select New With {.Name = x.ProductName, .Id = x.ProductId}
            ViewData.Add("Products", New SelectList(f, "Id", "Name", fee.ProductId))
            ViewData.Add("MinUnitTypes", New SelectList((From x In db.UnitTypes Order By x.Orderby Select x), "UnitTypeId", "UnitType", fee.MinUnitTypeId))


            Return View(fee)
        End Function

        '
        ' POST: /fee/Edit/5

        <AcceptVerbs(HttpVerbs.Post)> _
        Function Edit(ByVal id As Integer, ByVal collection As FormCollection) As ActionResult
            Try
                ' TODO: Add update logic here
                Dim db As New R2kdoiMVCDataContext
                Dim fee = db.Fees.SingleOrDefault(Function(e) e.FeeId = id)

                fee.ud = Date.Now


                UpdateModel(fee)

                db.SubmitChanges()

                Return RedirectToAction("Index", New With {.FeeSchedual = fee.MainId, .Location = fee.LocationId})
            Catch
                ViewData("edit") = True
                Return View()
            End Try
        End Function


        Function Delete(ByVal id As Integer) As ActionResult
            Dim db As New R2kdoiMVCDataContext
            Dim fee = db.Fees.SingleOrDefault(Function(e) e.FeeId = id)

            Return View(fee)
        End Function


        <AcceptVerbs(HttpVerbs.Post)> _
        Function Delete(ByVal DeleteFee As Model.Fee) As ActionResult

            Dim db As New R2kdoiMVCDataContext

            Dim fee = db.Fees.SingleOrDefault(Function(e) e.FeeId = DeleteFee.FeeId)

            db.Fees.DeleteOnSubmit(fee)
            db.SubmitChanges()

            Return RedirectToAction("Index", New With {.FeeSchedual = fee.MainId, .Location = fee.LocationId})

        End Function

    End Class


    Public Class NewFee

        Sub New()

        End Sub



        Private newPropertyValue As String
        Public ReadOnly Property NewPropertyView() As IQueryable(Of Model.FundingSource)

            Get
                Dim db As New R2kdoiMVCDataContext

                Return db.FundingSources

            End Get

        End Property

    End Class
End Namespace
