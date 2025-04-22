using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pg197
{
   public class ControllerHelper
    {
        public static bool AddItem(ComboBox comboBox,List<string> infoList,bool showFirstInfo=true) 
        {
            bool result = false;
            if (infoList!=null && infoList.Count>0)
            {
                comboBox.Items.Clear();
                comboBox.DataSource = infoList;
                if (showFirstInfo)
                {
                    comboBox.SelectedIndex = 0;
                }
                result= true;
            }

            return result;
        }
    }
}
