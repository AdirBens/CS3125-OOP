using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GameGUI
{
    internal class GuiUtils
    {
        internal static DialogResult ShowQuestionDialog(string i_Message, string i_Caption)
        {
            DialogResult results = MessageBox.Show(i_Message, i_Caption, 
                                                   MessageBoxButtons.YesNo, 
                                                   MessageBoxIcon.Question);

            return results;
        }

        internal static DialogResult ShowErrorDialog(string i_Message, string i_Caption)
        {
            DialogResult results = MessageBox.Show(i_Message, i_Caption,
                                                   MessageBoxButtons.RetryCancel,
                                                   MessageBoxIcon.Error);

            return results;
        }

        internal static void HorizontalCentralizeObject(Form i_Form, Control i_ControlObject)
        {
            i_ControlObject.Location = new Point((i_Form.Width - i_ControlObject.Width) / 2, i_ControlObject.Location.Y);
        }

        internal static void AlignToRightOf(Control i_ObjectToAlign,  Control i_RelativeObject, int i_Margin = 5)
        {
            i_ObjectToAlign.Location = new Point(i_RelativeObject.Right + i_Margin, i_ObjectToAlign.Location.Y);
        }

        internal static int CalcTotalWidth(List<Control> i_ControlList)
        {
            return i_ControlList.Sum(ControlElement => ControlElement.Width);
        }
    }
}
