//namespace Trace.MyContrlClass

//{

//    class DocementBase : PrintDocument

//    {

//        //fields

//        public Font Font = new Font("Verdana", 10, GraphicsUnit.Point);
//        private object dialog;
//        private object returndialog;

//        public static object GraphicsUnit { get; private set; }
//        public PrintPreviewDialog PrintPreviewDialogdialog { get; private set; }
//        public PageSetupDialog PageSetupDialogdialog { get; private set; }



//        //预览打印

//        public DialogResult showPrintPreviewDialog()

//        {

//            PrintPreviewDialogdialog = new PrintPreviewDialog();

//            dialog.Document = this;



//            returndialog.ShowDialog();

//        }



//        //先设置后打印

//        public DialogResult ShowPageSettingsDialog()

//        {

//            PageSetupDialogdialog = new PageSetupDialog();

//            dialog.Document = this;



//            returndialog.ShowDialog();

//        }

//    }

//    public class PageSetupDialog
//    {
//    }

//    public class Font
//    {
//        private object point;
//        private string v1;
//        private int v2;

//        public Font(string v1, int v2, object point)
//        {
//            this.v1 = v1;
//            this.v2 = v2;
//            this.point = point;
//        }
//    }

//    internal class PrintDocument
//    {
//    }
//}