Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Editors
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Windows


Namespace CellTemplate
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            Me.DataContext = Me
        End Sub

        Protected _Items As ObservableCollection(Of CountryCities)

        Public ReadOnly Property Items() As ObservableCollection(Of CountryCities)
            Get
                If Me._Items Is Nothing Then
                    Me._Items = New ObservableCollection(Of CountryCities)()

                    Dim usa As New CountryCities() With { _
                        .Country = "USA", _
                        .Cities = New List(Of String) From {"Washington, D.C.", "New York", "Los Angeles", "Las Vegas"}, _
                        .City = "Los Angeles" _
                    }
                    Me._Items.Add(usa)

                    Dim germany As New CountryCities() With { _
                        .Country = "Germany", _
                        .Cities = New List(Of String) From {"Berlin", "Munich", "Frankfurt"}, _
                        .City = "Munich" _
                    }
                    Me._Items.Add(germany)

                    Dim uk As New CountryCities() With { _
                        .Country = "United Kingdom", _
                        .Cities = New List(Of String) From {"London", "Birmingham"}, _
                        .City = "London" _
                    }
                    Me._Items.Add(uk)

                    Dim canada As New CountryCities() With { _
                        .Country = "Canada", _
                        .Cities = New List(Of String) From {"Montreal", "Toronto"}, _
                        .City = "Montreal" _
                    }
                    Me._Items.Add(canada)

                    Dim china As New CountryCities() With { _
                        .Country = "China", _
                        .Cities = New List(Of String) From {"Beijing", "Tianjin", "Shanghai", "Chongqing"}, _
                        .City = "Beijing" _
                    }
                    Me._Items.Add(china)
                End If
                Return Me._Items
            End Get
        End Property

        Public Class CountryCities
            Inherits BindableBase

            Protected _Country As String
            Public Property Country() As String
                Get
                    Return Me._Country
                End Get
                Set(ByVal value As String)
                    Me.SetProperty(Me._Country, value, "Country")
                End Set
            End Property

            Protected _Cities As List(Of String)
            Public Property Cities() As List(Of String)
                Get
                    Return Me._Cities
                End Get
                Set(ByVal value As List(Of String))
                    Me.SetProperty(Me._Cities, value, "Cities")
                End Set
            End Property

            Protected _City As String
            Public Property City() As String
                Get
                    Return Me._City
                End Get
                Set(ByVal value As String)
                    Me.SetProperty(Me._City, value, "City")
                End Set
            End Property
        End Class

        Private Sub TableView_ProcessEditorActivationAction(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.ProcessEditorActivationActionEventArgs)
            If e.Column.FieldName = "City" AndAlso (e.ActivationAction = ActivationAction.MouseLeftButtonDown AndAlso e.MouseLeftButtonEventArgs.LeftButton = System.Windows.Input.MouseButtonState.Pressed) Then
                e.RaiseEventAgain = True
            End If
        End Sub

        Private Sub TableView_GetActiveEditorNeedsKey(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.GetActiveEditorNeedsKeyEventArgs)
            If e.Column.FieldName = "City" AndAlso (e.Key = System.Windows.Input.Key.Up OrElse e.Key = System.Windows.Input.Key.Down) Then
                e.NeedsKey = True
            End If
        End Sub
    End Class
End Namespace
