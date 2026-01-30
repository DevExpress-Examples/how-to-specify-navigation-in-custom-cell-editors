Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Editors
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows

Namespace CellTemplate

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            DataContext = Me
        End Sub

        Protected _Items As ObservableCollection(Of CountryCities)

        Public ReadOnly Property Items As ObservableCollection(Of CountryCities)
            Get
                If _Items Is Nothing Then
                    _Items = New ObservableCollection(Of CountryCities)()
                    Dim usa As CountryCities = New CountryCities() With {.Country = "USA", .Cities = New List(Of String) From {"Washington, D.C.", "New York", "Los Angeles", "Las Vegas"}, .City = "Los Angeles"}
                    _Items.Add(usa)
                    Dim germany As CountryCities = New CountryCities() With {.Country = "Germany", .Cities = New List(Of String) From {"Berlin", "Munich", "Frankfurt"}, .City = "Munich"}
                    _Items.Add(germany)
                    Dim uk As CountryCities = New CountryCities() With {.Country = "United Kingdom", .Cities = New List(Of String) From {"London", "Birmingham"}, .City = "London"}
                    _Items.Add(uk)
                    Dim canada As CountryCities = New CountryCities() With {.Country = "Canada", .Cities = New List(Of String) From {"Montreal", "Toronto"}, .City = "Montreal"}
                    _Items.Add(canada)
                    Dim china As CountryCities = New CountryCities() With {.Country = "China", .Cities = New List(Of String) From {"Beijing", "Tianjin", "Shanghai", "Chongqing"}, .City = "Beijing"}
                    _Items.Add(china)
                End If

                Return _Items
            End Get
        End Property

        Public Class CountryCities
            Inherits BindableBase

            Protected _Country As String

            Public Property Country As String
                Get
                    Return _Country
                End Get

                Set(ByVal value As String)
                    SetProperty(_Country, value, "Country")
                End Set
            End Property

            Protected _Cities As List(Of String)

            Public Property Cities As List(Of String)
                Get
                    Return _Cities
                End Get

                Set(ByVal value As List(Of String))
                    SetProperty(_Cities, value, "Cities")
                End Set
            End Property

            Protected _City As String

            Public Property City As String
                Get
                    Return _City
                End Get

                Set(ByVal value As String)
                    SetProperty(_City, value, "City")
                End Set
            End Property
        End Class

        Private Sub TableView_ProcessEditorActivationAction(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.ProcessEditorActivationActionEventArgs)
            If Equals(e.Column.FieldName, "City") AndAlso e.ActivationAction = ActivationAction.MouseLeftButtonDown AndAlso e.MouseLeftButtonEventArgs.LeftButton = Input.MouseButtonState.Pressed Then e.RaiseEventAgain = True
        End Sub

        Private Sub TableView_GetActiveEditorNeedsKey(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GetActiveEditorNeedsKeyEventArgs)
            If Equals(e.Column.FieldName, "City") AndAlso (e.Key = Input.Key.Up OrElse e.Key = Input.Key.Down) Then e.NeedsKey = True
        End Sub
    End Class
End Namespace
