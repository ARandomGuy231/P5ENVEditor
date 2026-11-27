using P5ENVEditor.Env;

namespace P5ENVEditor
{
    public partial class MainWindow : Form
    {
        private readonly string defaultWindowTitleText = "P5 ENV Editor";
        private bool isFileOpen = false;
        private bool hasUnsavedChanges = false;

        public MainWindow()
        {
            InitializeComponent();

            UpdateWindowTitle();
            appVerLabel.Text = $"v{Application.ProductVersion.Split("+")[0]}";
            CheckForUnsavedChanges(this);
        }

        private void OpenENV(string envFilePath)
        {
            try //load the file first before updating UI info
            {
                Logger.WriteToLog($"Attempting to load {envFilePath}", LogLevel.Info);
                EnvFunctions.LoadENVFile(envFilePath);
            }
            catch (Exception ex)
            {
                Logger.WriteToLog(ex.ToString(), LogLevel.Error);
                MessageBox.Show($"{ex.Message}\n\nIt's likely this is a bug, " +
                    $"please report this error on GitHub with the ENV you were trying to load and your log file.", "Failed to open ENV file.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; //stop here if there's an error
            }

            try //update UI info
            {
                if (EnvFunctions.partiallySupportedEnvVersions.Contains(EnvFunctions.loadedENVHeader.gfsVersion))
                {
                    string message = "You have loaded a partially supported ENV version, some parameters may appear disabled, empty or incorrect. " +
                        "See the table on the GitHub page for more information.";

                    Logger.WriteToLog(message, LogLevel.Warn);
                    MessageBox.Show($"{message}\n\nIf you notice anything incorrect, please report it on GitHub with the ENV file you're trying to edit.",
                        "Partially supported ENV version detected.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                DisplayAllENVParams();
                MarkFileSaved(); //clear the unsaved status
                isFileOpen = true;
                UpdateENVInformation();

                Logger.WriteToLog($"Successfully loaded: {envFilePath}", LogLevel.Info);

            }
            catch (Exception ex)
            {
                Logger.WriteToLog(ex.ToString(), LogLevel.Error);
                MessageBox.Show($"{ex.Message}\n\nPlease report this error on GitHub with the ENV you were trying to load and your log file.", "Failed to display ENV data.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); //close the program to prevent the user from modifying broken parameters
            }
        }

        private void SaveENV(string saveFilePath)
        {
            Logger.WriteToLog($"Attempting to save ENV file to {saveFilePath}", LogLevel.Info);

            try
            {
                EnvParams newParams = CreateNewENVParams();
                EnvFunctions.SaveENVFile(EnvFunctions.loadedENVHeader, newParams, saveFilePath);
                EnvFunctions.LoadENVFile(saveFilePath); //load the file we just saved to update the current file the editor is working with.
                MarkFileSaved();
                UpdateENVInformation();

                Logger.WriteToLog($"Successfully saved ENV file to {saveFilePath}", LogLevel.Info);
            }
            catch (Exception ex)
            {
                Logger.WriteToLog(ex.ToString(), LogLevel.Error);
                MessageBox.Show($"{ex.Message}\n\nPlease report this error on GitHub with the ENV you were editing, the tmp file in your output folder and your log file.", "Failed to save ENV file.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private EnvParams CreateNewENVParams()
        {
            var newParams = EnvFunctions.loadedENVParams; //make a copy of the currently loaded ENV params

            newParams.fieldModelSection = CreateFieldModelSection();
            newParams.characterModelSection = CreateCharacterModelSection();
            newParams.fogSection = CreateFogSection();
            newParams.lightingSection = CreateLightingSection();
            newParams.unknownSection = CreateUnknownSection();
            newParams.fieldShadowSection = CreateFieldShadowSection();
            newParams.colorCorrectionSection = CreateColorCorrectionSection();
            newParams.secondUnknownSection = CreateSecondUnknownSection();
            newParams.physicsSection = CreatePhysicsSection();
            newParams.skyColorSection = CreateSkyColorSection();

            return newParams;
        }

        private void DisplayAllENVParams()
        {
            DisplayFieldModelParams();
            DisplayCharacterModelParams();
            DisplayFogParams();
            DisplayLightingParams();
            DisplayUnknownParams();
            DisplayFieldShadowParams();
            DisplayColorCorrectionParams();
            DisplaySecondUnknownParams();
            DisplayPhysicsParams();
            DisplaySkyColorParams();
        }

        private void UpdateENVInformation() //updates window title and ENV version label
        {
            UpdateWindowTitle();
            string gameVersion = EnvFunctions.loadedENVHeader.gfsVersion > 0x1105070 ? "Royal" : "Vanilla";
            envVerLabel.Text = $"ENV Version: 0x{EnvFunctions.loadedENVHeader.gfsVersion:X} ({gameVersion})";
        }

        private void UpdateWindowTitle()
        {
            if (isFileOpen)
            {
                if (hasUnsavedChanges)
                {
                    Text = $"{defaultWindowTitleText} - {Path.GetFileName(EnvFunctions.loadedENVFilePath)}*";
                }
                else
                {
                    Text = $"{defaultWindowTitleText} - {Path.GetFileName(EnvFunctions.loadedENVFilePath)}";
                }
            }
            else
            {
                Text = defaultWindowTitleText;
            }
        }

        private int FloatToRGB(float f)
        {
            f = Math.Clamp(MathF.Round(f * 255f), 0f, 255f);
            return (int)f;
        }

        private void SetNumberBox(NumericUpDown box, decimal value)
        {
            bool allowedValue = value >= box.Minimum && value <= box.Maximum;
            box.Enabled = allowedValue; //only enable the box if it has an allowed value

            if (allowedValue)
            {
                box.Value = value;
            }
            else
            {
                Logger.WriteToLog($"'{box.Name}' is outside of the expected range. " +
                    $"Allowed range is {box.Minimum} to {box.Maximum}, actual value was {value}. This value will be disabled and ignored when saving.", LogLevel.Warn);
#if DEBUG
                MessageBox.Show($"'{box.Name}' is outside of the expected range. " +
                    $"Allowed range is {box.Minimum} to {box.Maximum}, actual value was {value}.",
                        "Debug message.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
            }
        }

        //make sure a box hasn't been disabled before saving back to file
        private static float CheckNumberBox(NumericUpDown box, float originalValue) => box.Enabled ? (float)box.Value : originalValue;
        private static uint CheckNumberBox(NumericUpDown box, uint originalValue) => box.Enabled ? (uint)box.Value : originalValue;
        private static byte CheckNumberBox(NumericUpDown box, byte originalValue) => box.Enabled ? (byte)box.Value : originalValue;

        private static byte CheckToggleBox(CheckBox box, byte originalValue) => box.Enabled ? (byte)box.CheckState : originalValue;

        private static void DisableNumberBox(NumericUpDown box)
        {
            Logger.WriteToLog($"Disabling {box.Name}", LogLevel.Debug);

            box.Value = 0; //sometimes the minimum is below 0 so this looks cleaner
            box.Enabled = false;
        }

        private static void DisableCheckBox(CheckBox box)
        {
            Logger.WriteToLog($"Disabling {box.Name}", LogLevel.Debug);

            box.Checked = false;
            box.Enabled = false;
        }

        private static void DisableComboBox(ComboBox box)
        {
            Logger.WriteToLog($"Disabling {box.Name}", LogLevel.Debug);

            box.SelectedIndex = -1;
            box.Enabled = false;
        }

        private void CheckForUnsavedChanges(Control parents)
        {
            foreach (Control child in parents.Controls)
            {
                switch (child)
                {
                    case NumericUpDown numericUpDown:
                        numericUpDown.ValueChanged += MarkFileUnsaved;
                        break;
                    case CheckBox checkbox:
                        checkbox.CheckStateChanged += MarkFileUnsaved;
                        break;
                    case ComboBox comboBox:
                        comboBox.SelectedIndexChanged += MarkFileUnsaved;
                        break;
                }

                CheckForUnsavedChanges(child);
            }
        }

        private void UpdateColorFromHex(TextBox hexText, NumericUpDown red, NumericUpDown green, NumericUpDown blue)
        {
            if (hexText.Text.Length == 7 && hexText.Text.StartsWith('#'))
            {
                Color hexColor;

                try
                {
                    hexColor = ColorTranslator.FromHtml(hexText.Text);
                }
                catch (Exception ex)
                {
                    Logger.WriteToLog($"An error occured while grabbing color from {hexText.Name}: {ex.Message}", LogLevel.Debug);
                    return;
                }

                red.Value = hexColor.R;
                green.Value = hexColor.G;
                blue.Value = hexColor.B;
            }
        }

        private void MarkFileUnsaved(object? sender, EventArgs e)
        {
            hasUnsavedChanges = true;
            UpdateWindowTitle();
        }

        private void MarkFileSaved()
        {
            hasUnsavedChanges = false;
            UpdateWindowTitle();
        }

        private bool ShowUnsavedConfirmation(string userAction)
        {
            if (!isFileOpen || !hasUnsavedChanges)
            {
                return true;
            }

            DialogResult confirmation = MessageBox.Show($"You have unsaved changes, you will lose any unsaved progress if you {userAction}.\n\n" +
                $"Are you sure you want to continue?",
                "Unsaved changes detected.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            return confirmation == DialogResult.Yes;
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!ShowUnsavedConfirmation("choose to load a new file"))
            {
                return;
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                OpenENV(openFileDialog.FileName);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileOpen)
            {
                DialogResult overwriteConfirm = MessageBox.Show($"Are you sure you wish to overwrite {EnvFunctions.loadedENVFilePath}?",
                "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (overwriteConfirm == DialogResult.Yes)
                {
                    SaveENV(EnvFunctions.loadedENVFilePath);
                }
            }
            else
            {
                string message = "You must load an ENV file first before attempting to save.";
                Logger.WriteToLog(message, LogLevel.Info);
                MessageBox.Show(message, "Failed to save ENV file.",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isFileOpen)
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveENV(saveFileDialog.FileName);
                }
            }
            else
            {
                string message = "You must load an ENV file first before attempting to save.";
                Logger.WriteToLog(message, LogLevel.Info);
                MessageBox.Show(message, "Failed to save ENV file.",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog(this);
        }

        private void MainWindow_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void MainWindow_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedFile = (string[])e.Data.GetData(DataFormats.FileDrop);

            BeginInvoke(new Action(() =>
            {
                if (ShowUnsavedConfirmation("choose to load a new file"))
                    OpenENV(droppedFile[0]);
            }));
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !ShowUnsavedConfirmation("close the editor"))
            {
                e.Cancel = true;
            }
        }
    }
}
