Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Grid

Namespace CellTemplate

    Public Class NavigationBehavior
        Inherits Behavior(Of TableView)

        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AddHandler AssociatedObject.ProcessEditorActivationAction, AddressOf TableView_ProcessEditorActivationAction
            AddHandler AssociatedObject.GetActiveEditorNeedsKey, AddressOf TableView_GetActiveEditorNeedsKey
        End Sub

        Protected Overrides Sub OnDetaching()
            RemoveHandler AssociatedObject.ProcessEditorActivationAction, AddressOf TableView_ProcessEditorActivationAction
            RemoveHandler AssociatedObject.GetActiveEditorNeedsKey, AddressOf TableView_GetActiveEditorNeedsKey
            MyBase.OnDetaching()
        End Sub

        Private Sub TableView_ProcessEditorActivationAction(ByVal sender As Object, ByVal e As ProcessEditorActivationActionEventArgs)
            If Equals(e.Column.FieldName, NameOf(Place.City)) Then
                If e.ActivationAction = ActivationAction.MouseLeftButtonDown AndAlso e.MouseLeftButtonEventArgs.LeftButton = System.Windows.Input.MouseButtonState.Pressed Then e.RaiseEventAgain = True
            End If
        End Sub

        Private Sub TableView_GetActiveEditorNeedsKey(ByVal sender As Object, ByVal e As GetActiveEditorNeedsKeyEventArgs)
            If Equals(e.Column.FieldName, NameOf(Place.City)) Then
                If e.Key = System.Windows.Input.Key.Up OrElse e.Key = System.Windows.Input.Key.Down Then e.NeedsKey = True
            End If
        End Sub
    End Class
End Namespace
