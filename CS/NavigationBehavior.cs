using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;

namespace CellTemplate {
    public class NavigationBehavior : Behavior<TableView> {
        protected override void OnAttached() {
            base.OnAttached();
            AssociatedObject.ProcessEditorActivationAction += TableView_ProcessEditorActivationAction;
            AssociatedObject.GetActiveEditorNeedsKey += TableView_GetActiveEditorNeedsKey;
        }
        protected override void OnDetaching() {
            AssociatedObject.ProcessEditorActivationAction -= TableView_ProcessEditorActivationAction;
            AssociatedObject.GetActiveEditorNeedsKey -= TableView_GetActiveEditorNeedsKey;
            base.OnDetaching();
        }
        void TableView_ProcessEditorActivationAction(object sender, ProcessEditorActivationActionEventArgs e) {
            if (e.Column.FieldName == nameof(Place.City))
                if (e.ActivationAction == ActivationAction.MouseLeftButtonDown && e.MouseLeftButtonEventArgs.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                    e.RaiseEventAgain = true;
        }
        void TableView_GetActiveEditorNeedsKey(object sender, GetActiveEditorNeedsKeyEventArgs e) {
            if (e.Column.FieldName == nameof(Place.City))
                if (e.Key == System.Windows.Input.Key.Up || e.Key == System.Windows.Input.Key.Down)
                    e.NeedsKey = true;
        }
    }
}
