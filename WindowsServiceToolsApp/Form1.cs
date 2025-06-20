using System.Diagnostics;
using System.Security.Principal;
using System.Configuration;

namespace WindowsServiceToolsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static bool IsAdministrator()
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private bool EnsureAdministrator()
        {
            if (IsAdministrator()) return true;

            Log("Run the app as administrator.");
            MessageBox.Show(
                "Run the app as administrator.",
                "Permission denied",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return false;
        }

        private static bool IsValidServiceName(string name) =>
            !string.IsNullOrWhiteSpace(name) && name.Length <= 256;

        private void BtnInstall_Click(object sender, EventArgs e)
        {
            if (!EnsureAdministrator()) return;

            var serviceName = txtServiceName.Text.Trim();
            var exePath = txtExePath.Text.Trim();

            if (!ValidateInstallInputs(serviceName, exePath)) return;

            RunScCommand(
                $"create \"{serviceName}\" binPath= \"{exePath}\" start= auto",
                $"Service '{serviceName}' installed.");
        }

        private void BtnUninstall_Click(object sender, EventArgs e)
        {
            if (!EnsureAdministrator()) return;

            var serviceName = txtServiceName.Text.Trim();

            if (string.IsNullOrWhiteSpace(serviceName))
            {
                Log("Service name cannot be empty.");
                return;
            }

            if (!IsValidServiceName(serviceName))
            {
                Log("Invalid service name. Cannot be empty or longer than 256 characters.");
                return;
            }

            RunScCommand($"stop \"{serviceName}\"", $"Service '{serviceName}' stopped (if it was running).");
            RunScCommand($"delete \"{serviceName}\"", $"Service '{serviceName}' removed.");
        }

        private bool ValidateInstallInputs(string serviceName, string exePath)
        {
            if (string.IsNullOrWhiteSpace(serviceName))
            {
                Log("Service name cannot be empty.");
                return false;
            }

            if (!IsValidServiceName(serviceName))
            {
                Log("Invalid service name. Cannot be empty or longer than 256 characters.");
                return false;
            }

            if (!File.Exists(exePath))
            {
                Log("Executable not found.");
                return false;
            }

            return true;
        }

        private void RunScCommand(string args, string successMsg)
        {
            try
            {
                var startInfo = new ProcessStartInfo("sc.exe", args)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = Process.Start(startInfo);
                if (process == null)
                {
                    Log("Failed to start process.");
                    return;
                }

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrWhiteSpace(output))
                    Log(output.Trim());

                if (!string.IsNullOrWhiteSpace(error))
                    Log($"Error output: {error.Trim()}");

                Log($"Exit code: {process.ExitCode}");
                Log(successMsg);
            }
            catch (Exception ex)
            {
                Log($"Exception: {ex}");
            }
        }

        private void Log(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => Log(message)));
                return;
            }

            txtLog.AppendText($"{DateTime.Now:HH:mm:ss} - {message}{Environment.NewLine}");
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog
            {
                Filter = "Executables (*.exe)|*.exe",
                Title = "Select Service Executable"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtExePath.Text = dlg.FileName;
                TryLoadServiceNameFromConfig(dlg.FileName);
            }
        }

        private void TryLoadServiceNameFromConfig(string exePath)
        {
            try
            {
                string configFilePath = exePath + ".config";
                if (!File.Exists(configFilePath))
                {
                    Log($"Config file not found: {configFilePath}");
                    return;
                }

                var map = new ExeConfigurationFileMap { ExeConfigFilename = configFilePath };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                string? serviceName = config.AppSettings.Settings["NOME_SERVICO"]?.Value;
                if (!string.IsNullOrWhiteSpace(serviceName))
                {
                    txtServiceName.Text = serviceName;
                    Log($"Service name loaded from config: {serviceName}");
                }
                else
                {
                    Log("NOME_SERVICO not found in config.");
                }
            }
            catch (Exception ex)
            {
                Log($"Failed to read config: {ex.Message}");
            }
        }

        private void BtnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }
    }
}
