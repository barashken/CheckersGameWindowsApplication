using System.Windows.Forms;

namespace CheckersUI
{
    public class ApplicationGame 
    {
        public ApplicationGame()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            new ManageGameUI().ShowDialog();
        }
    }
}
