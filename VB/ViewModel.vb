Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Namespace CellTemplate

    Public Class ViewModel
        Inherits ViewModelBase

        Public Sub New()
            Source = GetPlace()
        End Sub

        Public Property Source As ObservableCollection(Of Place)
    End Class

    Public Class Place

        Public Property Country As String

        Public Property City As String

        Public Property Cities As List(Of String)
    End Class

    Public Module Places

        Public Function GetPlace() As ObservableCollection(Of Place)
            Dim places As ObservableCollection(Of Place) = New ObservableCollection(Of Place)()
            places.Add(New Place() With {.Country = "USA", .City = "Washington, D.C.", .Cities = New List(Of String) From {"Washington, D.C.", "New York", "Los Angeles", "Las Vegas"}})
            places.Add(New Place() With {.Country = "Germany", .City = "Berlin", .Cities = New List(Of String) From {"Berlin", "Munich", "Frankfurt"}})
            places.Add(New Place() With {.Country = "United Kingdom", .City = "London", .Cities = New List(Of String) From {"London", "Birmingham"}})
            places.Add(New Place() With {.Country = "Canada", .City = "Montreal", .Cities = New List(Of String) From {"Montreal", "Toronto"}})
            places.Add(New Place() With {.Country = "China", .City = "Beijing", .Cities = New List(Of String) From {"Beijing", "Tianjin", "Shanghai", "Chongqing"}})
            Return places
        End Function
    End Module
End Namespace
