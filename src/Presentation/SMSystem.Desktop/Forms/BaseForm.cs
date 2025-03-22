using Microsoft.Extensions.DependencyInjection;

namespace SMSystem.Desktop.Forms
{
    public class BaseForm : Form
    {
        protected void OpenChildForm<T>(Panel containerPanel) where T : Form
        {
            var form = Program.ServiceProvider.GetRequiredService<T>();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(form);
            form.Show();
        }

        protected void OpenMainForm(Form thisForm)
        {
            var mainForm = Program.ServiceProvider.GetRequiredService<MainForm>();
            thisForm.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }
    }
}
