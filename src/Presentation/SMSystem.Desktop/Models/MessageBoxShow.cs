namespace SMSystem.Desktop.Models
{
    public class MessageBoxShow
    {
        public static DialogResult Success(string message)
        {
            return MessageBox.Show(message, "Başarılı", MessageBoxButtons.OK);
        }

        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Warning(string message)
        {
            return MessageBox.Show(message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult Info(string message)
        {
            return MessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirm(string message, string caption = "Onay")
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
